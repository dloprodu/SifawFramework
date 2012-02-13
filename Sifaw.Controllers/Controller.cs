/*
 * Sifaw.Controllers
 * 
 * Dise�ador:   David L�pez Rguez
 * Programador: David L�pez Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 14/12/2011: Creaci�n de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Diagnostics.Contracts;

using Sifaw.Core;
using Sifaw.Core.Utilities;


namespace Sifaw.Controllers
{
	/// <summary>
    /// Controladora base que provee de un patr�n e infraestructura com�n para el resto de controladoras que derivan de ella.
	/// </summary>
    /// <remarks>
    /// <para>
	/// Las controladoras <see cref="Controller{TInput, TOutput}"/> implementan un ciclo de vida que permiten su inicio,
    /// reseteo o finalizaci�n asi como de un sistema de chequeo de reglas que permite definir en que estados se permite iniciar
    /// o reiniciar una controladora.
    /// </para>
    /// <para>
    /// Eventos como <see cref="StateChanged"/>, <see cref="Starting"/> o <see cref="Finishing"/>, entre otros, informan sobre la transici�n 
    /// de un estado a otro.
    /// </para>
    /// <para>
	/// Las controladoras <see cref="Controller{TInput, TOutput}"/> implementa un patr�n 'Before / After Action' que ayuda a las controladoras
    /// derivadas completar funcionalidad en cualquier punto del ciclo de vida de la controladora.
    /// </para>
    /// <para>
	/// Adem�s las controladoras han de definir los parametros que recibir�n como entrada cuando son iniciadas (<see cref="Controller{TInput, TOutput}.Input"/>)
	/// y aquellos que retornar�n cuando finalicen (<see cref="Controller{TInput, TOutput}.Output"/>).
    /// </para>
    /// </remarks>
	/// <typeparam name="TInput">
    /// Tipo para establecer los par�metros de inicio de la controladora. Ha de ser serializable y 
	/// derivar de <see cref="Controller{TInput, TOutput}.Input"/>.
    /// </typeparam>
	/// <typeparam name="TOutput">
    /// Tipo para establcer los parametros de retorno cuando finaliza la controladora. Ha de ser serializable y 
	/// derivar de <see cref="Controller{TInput, TOutput}.Output"/>.
    /// </typeparam>
	public abstract class Controller<TInput, TOutput>
		: IController
		, IController<TInput, TOutput>
		where TInput  : Controller<TInput, TOutput>.Input
		where TOutput : Controller<TInput, TOutput>.Output
    {
        #region Constants

		/// <summary>
		/// Identificador para las reglas que se han de chequedar cuando se inicia la controladora.
		/// </summary>
        protected const string BR_START = "StartRules";

		/// <summary>
		/// Identificador para las reglas que se han de chequear cuando se instancia la controladora.
		/// </summary>
		protected const string BR_INSTANCE = "InstanceRules";

		#endregion

		#region Input / Output

		/// <summary>
		/// Par�metros de entrada de la controladora.
		/// </summary>
		[Serializable]
		public abstract class Input : ICloneable
		{
			#region ICloneable Members

			/// <summary>
			/// Devuelve una copia de los par�metros de entrada de la controladora.
			/// </summary>
			public object Clone()
			{
				return UtilIO.Clone<TInput>(this as TInput);
			}

			#endregion
		}

		/// <summary>
		/// Par�metros de retorno de la controladora.
		/// </summary>
		[Serializable]
		public abstract class Output : ICloneable
		{
			#region ICloneable Members

			/// <summary>
			/// Devuelve una copia de los par�metros de retorno de la controladora.
			/// </summary>
			public object Clone()
			{
				return UtilIO.Clone<TOutput>(this as TOutput);
			}

			#endregion
		}

		#endregion

		#region Fields

		/*
		 * No Reseteables
		 */

		// Indica el estado de la controladora.
		private CLStates _state;

		/// <summary>
		/// Informaci�n b�sica de la controladora.
		/// </summary>
		protected CLInformation _information;

		// Conjunto de reglas rotas para las precondiciones de la controladora.
		private BrokenRules _brokenPreconditions;

		/// <summary>
		/// Flag que indica si la finalizaci�n ya ha sido iniciada.
		/// </summary>
		/// <remarks>
		/// <para>
		/// En un �rbol de controladoras, controladoras padres que instancian otras controladoras (controladoras hijas), se puede producir
		/// el caso en el que una controladora se finaliza derivando por tanto en la finalizaci�n de sus controladoras hijas.
		/// </para>
		/// <para>
		/// A su vez, la misma controladora puede haberse subscrito al evento de finalizaci�n de alguna de sus controladoras hijas 
		/// para finalizarse cuando finaliza su hija. En este caso, se producir�a una doble llamada al m�todo de finalizaci�n de la controladora padre.
		/// No llegaa entrar en un bucle de finalizaci�n porque en la segunda llamda ya sus controladoras hijas est�n finalizadas.
		/// </para>
		/// <para>
		/// Con el flag <see cref="isFinishing"/> ignoramos esta posible segunda llamada.
		/// </para>
		/// </remarks>
		private bool isFinishing = false;

		/*
		 * Reseteables
		 */

		[CLReseteable(null)]
		private TInput _parameters;

		[CLReseteable(null)]
		private TInput _input;

		#endregion

		#region Events

		/*
		 * Desencadenadores privados.
		 *  � Solo son lanzados por la controladora padre.
		 */

		/// <summary>
		/// Se produce cuando cambia el valor de la propiedad <see cref="State"/>.
		/// </summary>
		public event CLStateChangedEventHandler StateChanged;
		private void OnStateChanged(CLSateChangedEventArgs e)
		{
			if (StateChanged != null)
				StateChanged(this, e);
		}

		/// <summary>
		/// Se produce cuando se va a iniciar la controladora.
		/// </summary>
		public event SFCancelEventHandler Starting;
		private void OnStarting(SFCancelEventArgs e)
		{
			if (Starting != null)
				Starting(this, e);
		}

		/// <summary>
		/// Se produce cuando se va a finalizar la controladora.
		/// </summary>
		public event SFCancelEventHandler Finishing;
		private void OnFinishing(SFCancelEventArgs e)
		{
			if (Finishing != null)
				Finishing(this, e);
		}

		/// <summary>
		/// Se produce cuando ha finalizado la controladora.
		/// </summary>
		public event CLFinishedEventHandler<TOutput> Finished;
		private void OnFinished(CLFinishedEventArgs<TOutput> e)
		{
			if (Finished != null)
				Finished(this, e);
		}

		/*
		 * Desencadenadores protegidos.
		 *  � Pueden ser lanzados por controladoras hijas.
		 */

		/// <summary>
		/// Se produce cuando cambia el progreso del proceso.
		/// </summary>
        public event CLProgressChangedEventHandler ProgressChanged;        
		
		/// <summary>
		/// Provoca el evento <see cref="ProgressChanged"/>.
		/// </summary>
		/// <param name="e"><see cref="T:Sifaw.Controllers.CLProgressChangedEventArgs"/> que contiene los datos del evento.</param>
		protected void OnProgressChanged(CLProgressChangedEventArgs e)
		{
			if (ProgressChanged != null)
				ProgressChanged(this, e);
		}

		/// <summary>
		/// Se produce cuando se solicita el inicio de una controladora.
		/// </summary>
		public event CLThrowEventHandler ThrowCtrl;

		/// <summary>
		/// Provoca el evento <see cref="ThrowCtrl"/>.
		/// </summary>
		/// <param name="e"><see cref="T:Sifaw.Controllers.CLThrowEventArgs"/> que contiene los datos del evento.</param>
		protected void OnThrowCtrl(CLThrowEventArgs e)
		{
			if (ThrowCtrl != null)
				ThrowCtrl(this, e);
		}

		/*
		 * Desencadenadores protegidos virtuales sin manejadores asociados.
		 *  � Pueden ser sobreescritos por controladoras hijas para
		 *    completar funcionalidad.
		 */

		/// <summary>
		/// Se llama al m�todo <see cref="OnBeforeFinishControllers"/> antes de finalizar las
		/// controladoras embebidas. El m�todo permite que las clases derivadas controlen
		/// el evento sin asociar un delegado.
		/// </summary>
		/// <param name="children">Lista de controladoras hijas.</param>
		/// <remarks>
		/// Al reemplazar <see cref="OnBeforeFinishControllers"/> en una clase derivada, aseg�rese de llamar al
		/// m�todo <see cref="OnBeforeFinishControllers"/> de la clase base para que los delegados registrados 
		/// reciban el evento.
		/// </remarks>
		protected virtual void OnBeforeFinishControllers(List<IController> children)
		{
			/* Emtpy */
		}

		/// <summary>
		/// Se llama al m�todo <see cref="OnAfterFinishControllers"/> despu�s de finalizar las
		/// controladoras embebidas. El m�todo permite que las clases derivadas controlen 
		/// el evento sin asociar un delegado.
		/// </summary>
		/// <param name="children">Lista de controladoras hijas.</param>
		/// <remarks>
		/// Al reemplazar <see cref="OnAfterFinishControllers"/> en una clase derivada, aseg�rese de llamar al
		/// m�todo <see cref="OnAfterFinishControllers"/> de la clase base para que los delegados registrados
		/// reciban el evento.
		/// </remarks>
		protected virtual void OnAfterFinishControllers(List<IController> children)
		{
			/* Emtpy */
		}

		/// <summary>
		/// Se llama al m�todo <see cref="OnBeforeResetFields"/> antes de resetear los campos.
		/// El m�todo permite que las clases derivadas controlen el evento sin asociar un delegado.
		/// </summary>
		/// <param name="fields">Lista de campos de la controladora.</param>
		/// <remarks>
		/// Al reemplazar <see cref="OnBeforeResetFields"/> en una clase derivada, aseg�rese de llamar al
		/// m�todo <see cref="OnBeforeResetFields"/> de la clase base para que los delegados registrados 
		/// reciban el evento.
		/// </remarks>
		protected virtual void OnBeforeResetFields(List<FieldInfo> fields)
		{
			/* Emtpy */
		}

		/// <summary>
		/// Se llama al m�todo <see cref="OnAfterResetFields"/> despu�s de resetear los campos.
		/// El m�todo permite que las clases derivadas controlen el evento sin asociar un delegado.
		/// </summary>
		/// <param name="fields">Lista de campos de la controladora.</param>
		/// <remarks>
		/// Al reemplazar <see cref="OnAfterResetFields"/> en una clase derivada, aseg�rese de llamar al
		/// m�todo <see cref="OnAfterResetFields"/> de la clase base para que los delegados registrados 
		/// reciban el evento.
		/// </remarks>
		protected virtual void OnAfterResetFields(List<FieldInfo> fields)
		{
			/* Emtpy */
		}

		/// <summary>
		/// Se llama al m�todo <see cref="OnBeforeStartController"/> antes de iniciar la
		/// controladora. El m�todo permite que las clases derivadas controlen 
		/// el evento sin asociar un delegado.
		/// </summary>
		/// <remarks>
		/// Al reemplazar <see cref="OnBeforeStartController"/> en una clase derivada, aseg�rese de llamar al
		/// m�todo <see cref="OnBeforeStartController"/> de la clase base para que los delegados registrados
		/// reciban el evento.
		/// </remarks>
		protected virtual void OnBeforeStartController()
		{
			/* Emtpy */
		}

		/// <summary>
		/// Se llama al m�todo <see cref="OnAfterStartController"/> despu�s de iniciar la
		/// controladora. El m�todo permite que las clases derivadas controlen 
		/// el evento sin asociar un delegado.
		/// </summary>
		/// <remarks>
		/// Al reemplazar <see cref="OnAfterStartController"/> en una clase derivada, aseg�rese de llamar al
		/// m�todo <see cref="OnAfterStartController"/> de la clase base para que los delegados registrados
		/// reciban el evento.
		/// </remarks>
		protected virtual void OnAfterStartController()
		{
			/* Emtpy */
		}

		/// <summary>
		/// Se llama al m�todo <see cref="OnBeforeResetController"/> antes de reiniciar la
		/// controladora. El m�todo permite que las clases derivadas controlen 
		/// el evento sin asociar un delegado.
		/// </summary>
		/// <remarks>
		/// Al reemplazar <see cref="OnBeforeResetController"/> en una clase derivada, aseg�rese de llamar al
		/// m�todo <see cref="OnBeforeResetController"/> de la clase base para que los delegados registrados
		/// reciban el evento.
		/// </remarks>
		protected virtual void OnBeforeResetController()
		{
			/* Emtpy */
		}

		/// <summary>
		/// Se llama al m�todo <see cref="OnAfterResetController"/> despu�s de reiniciar la
		/// controladora. El m�todo permite que las clases derivadas controlen 
		/// el evento sin asociar un delegado.
		/// </summary>
		/// <remarks>
		/// Al reemplazar <see cref="OnAfterResetController"/> en una clase derivada, aseg�rese de llamar al
		/// m�todo <see cref="OnAfterResetController"/> de la clase base para que los delegados registrados
		/// reciban el evento.
		/// </remarks>
		protected virtual void OnAfterResetController()
		{
			/* Emtpy */
		}

		#endregion

        #region Properties

        /*
		 * P�blicas
		 */

		/// <summary>
		/// Devuelve el el estado de la controladora.
		/// </summary>
		public CLStates State
		{
			get { return _state; }
			private set
			{
				if (_state != value)
				{
					_state = value;
					OnStateChanged(new CLSateChangedEventArgs(_state));
				}
			}
		}

		/// <summary>
		/// Devuelve informaci�n descriptiva de la controladora.
		/// </summary>
		public CLInformation Information
		{
			get { return _information; }
		}

		/*
		 * Progegidas
		 */

		/// <summary>
		/// Devuelve los par�metros de la controladora.
		/// </summary>
		protected TInput Parameters
		{
			get { return _parameters; }
		}

		/// <summary>
		/// Devuelve las reglas rotas de la controladora.
		/// </summary>
		protected BrokenRules BrokenPreconditions
		{
			get { return _brokenPreconditions; }
		}

		#endregion

        #region Constructors

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="Controller{TInput, TOutput}"/>.
		/// </summary>
        protected Controller()
			: base()
		{
			// Instanciamos el objeto que controla las precondiciones.
			_brokenPreconditions = new BrokenRules();

			// Iniciamos la informaci�n de la controladora.
			_information = CLInformation.Empty;

			// Estado de la controladora.
			_state = CLStates.NotStarted;

			CheckPreconditions(BR_INSTANCE);
		}

		#endregion

		#region Check Preconditions

		/// <summary>
		/// Fuerza el chequeo de la preciondici�n indicada
		/// </summary>
		/// <param name="preconditionName">Nombre de la precondici�n indicada</param>
		protected void CheckPreconditions(string preconditionName)
		{
			OnCheckPreconditions(preconditionName);
		}

		/// <summary>
		/// Permite que un objeto realice su propio proceso de chequeo de precondiciones
		/// Las clases derivadas pueden sobreescribir este m�todo para chequear precondiciones
		/// </summary>
		protected virtual void OnCheckPreconditions(string preconditionName)
		{
			/* Empty */
		}

		#endregion

		#region Helpers
                
        /// <summary>
        /// Comprueba el estado de la controladora. 
        /// </summary>
		/// <param name="state">Estado de la controladora deseado</param>
        protected void CheckState(CLStates state)
        {
            if (State != state)
                throw new NotValidStateException();
        }

		/// <summary>
		/// Devuelve una copia del estado inicial de los par�metros.
		/// </summary>
		protected TInput GetInitialParameters()
		{
			return (TInput)_input.Clone();
		}

		/// <summary>
		/// Devuelve todos losa cmapos de la clase teneindo en cuenta las clases heredadas
		/// </summary>
		protected List<FieldInfo> GetAllFilds()
		{
			return UtilReflection.GetAllFields(
				  this.GetType()
				, BindingFlags.Public
				| BindingFlags.NonPublic
				| BindingFlags.Static
				| BindingFlags.Instance
				| BindingFlags.DeclaredOnly);
		}

		/// <summary>
		/// Devuelve las controladoras instanciadas.
		/// </summary>
		protected List<IController> GetControllers()
		{
			return GetControllers(GetAllFilds());
		}

		private List<IController> GetControllers(List<FieldInfo> fields)
		{
			// Lista que contendr� las controladora
			List<IController> list = new List<IController>();

			// Realizamos la b�squeda
			foreach (FieldInfo field in fields)
			{
				// Obtenemos el valor
				object v = field.GetValue(this);

				// comprobamos si se corresponde con una controladora
				if (v != null && v is IController)
				{
					list.Add((IController)field.GetValue(this));
				}
			}

			// Retornamos la lista
			return list;
		}

		#endregion

		#region Default Input / Output

		/// <summary>
		/// Devuelve los par�metros por defecto de inicio.
		/// </summary>
		public abstract TInput GetDefaultInput();

		/// <summary>
		/// Devuelve los par�metros de reinicio.
		/// </summary>
		public abstract TInput GetResetInput();

		/// <summary>
		/// Devuelve los par�metros por defecto de finalizaci�n.
		/// </summary>
		protected abstract TOutput GetDefaultOutput();

		#endregion
        
		#region Start Methods

        /// <summary>
        /// Ejecuta los comandos de inicio de la controladora.
        /// </summary>
        protected abstract void StartController();

		/// <summary>
		/// Devuelve un valor que indica si la controladora se puede inicar.
		/// </summary>
		protected virtual bool CanStart()
		{
			// -------------------------------------------------------------
			// Comprobamos las reglas de inicio de la controladora
			// -------------------------------------------------------------
			CheckPreconditions(BR_START);

			return BrokenPreconditions.IsValid;
		}

		/// <summary>
		/// Inicia la controladora con los par�metros por defecto
		/// </summary>
		/// <exception cref="NotValidStateException">La controladora ya est� iniciada.</exception>
		/// <exception cref="ArgumentNullException">input es null.</exception>
		/// <exception cref="ArgumentException">input no es serializable.</exception>
		/// <exception cref="NotCanStartException">input no contiene los par�metros esperados para el inicio.</exception>
		/// <exception cref="Exception">Excepci�n internal de la controladora.</exception>
		/// <returns>Valor que indica si la controladora se inici� correctamente.</returns>
		public bool Start()
		{
			return Start(GetDefaultInput());
		}

		/// <summary>
		/// Inicia la controladora.
		/// </summary>
		/// <exception cref="NotValidStateException">La controladora ya est� iniciada.</exception>
		/// <exception cref="ArgumentNullException">input es null.</exception>
		/// <exception cref="ArgumentException">input no es serializable.</exception>
		/// <exception cref="NotCanStartException">input no contiene los par�metros esperados para el inicio.</exception>
		/// <exception cref="Exception">Excepci�n interna de la controladora.</exception>
		/// <param name="input">Par�metros de inicio de la controladora</param>
		/// <returns>Valor que indica si la controladora se inici� correctamente.</returns>
		public bool Start(TInput input)
		{
			if (!typeof(TInput).IsSerializable)
				throw new ArgumentException();

			bool success = false;

			// Comprobamos que la controladora se encuentra en un estado correcto
			CheckState(CLStates.NotStarted);

			// Lanzamos el evento para comunicar el inicio y esperamos confirmaci�n de cancelaci�n
			SFCancelEventArgs cEventArgs = new SFCancelEventArgs();
			OnStarting(cEventArgs);

			if (!cEventArgs.Cancel)
			{
				// Establecemos los par�metros de inicio de la controladora.
				_parameters = UtilIO.Clone<TInput>(input);
				_parameters = _parameters ?? GetDefaultInput();
				// Guardamos una copia de los parametros de entrada que no podr� ser modificada.
				_input = UtilIO.Clone<TInput>(_parameters);

				if (_parameters == null)
					throw new ArgumentNullException();

				if (!CanStart())
					throw new NotCanStartException();

				// Establecemos el estado de inicio
				State = CLStates.Started;
				OnBeforeStartController();
				StartController();
				OnAfterStartController();
				success = true;
			}

			return success;
		}
        		
		#endregion

        #region Reset Methods

        /// <summary>
        /// Devuleve un valor que indica si la controladora se puede reiniciar.
        /// </summary>
        protected abstract bool AllowReset();

        /// <summary>
        /// Ejecuta las operaciones de reinicio de la controladora.
        /// </summary>
        protected abstract void ResetController();

        /// <summary>
        /// Reinicia la controladora con los par�metros por defecto
        /// </summary>
        /// <exception cref="NotValidStateException">La controladora no est� iniciada.</exception>
        /// <exception cref="NotAllowResetException">La controladora no soporta el reinicio.</exception>
        /// <exception cref="ArgumentNullException">input es null.</exception>
        /// <exception cref="ArgumentException">input no es serializable.</exception>
        /// <exception cref="NotCanStartException">input no contiene los par�metros esperados para el inicio.</exception>
        /// <exception cref="Exception">Excepci�n interna de la controladora.</exception>
        /// <returns>Valor que indica si la controladora se reinici� correctamente.</returns>
        public bool Reset()
        {
            return Reset(GetResetInput());
        }

        /// <summary>
        /// Reinicia la controladora.
        /// </summary>
        /// <exception cref="NotValidStateException">La controladora no est� iniciada.</exception>
        /// <exception cref="NotAllowResetException">La controladora no soporta el reinicio.</exception>
        /// <exception cref="ArgumentNullException">input es null.</exception>
        /// <exception cref="ArgumentException">input no es serializable.</exception>
        /// <exception cref="NotCanStartException">input no contiene los par�metros esperados para el inicio.</exception>
        /// <exception cref="Exception">Excepci�n interna de la controladora.</exception>
        /// <param name="input">Par�metros de la controladora para realizar el reinicio</param>
        /// <returns>Valor que indica si la controladora se reinici� correctamente.</returns>
        public bool Reset(TInput input)
        {
            if (!typeof(TInput).IsSerializable)
                throw new ArgumentException();

            bool success = false;

            // Comprobamos que la controladora se encuentra en un estado correcto
            CheckState(CLStates.Started);

            // Establecemos los par�metros de reinicio de la controladora
            _parameters = UtilIO.Clone<TInput>(input);
            _parameters = _parameters ?? GetResetInput();
            _parameters = _parameters ?? GetDefaultInput();
            // Guardamos una copia de los parametros de entrada que no podr� ser modificada.
            _input = UtilIO.Clone<TInput>(_parameters);

            if (!AllowReset())
                throw new NotAllowResetException();

            if (_parameters == null)
                throw new ArgumentNullException();

            if (!CanStart())
                throw new NotCanStartException();

            // Ejecutamos los comando de reinicio de la controladora
            OnBeforeResetController();
            ResetController();
            OnAfterResetController();
            success = true;

            return success;
        }

        #endregion

		#region Finish Methods

        /// <summary>
        /// Termina la ejecuci�n de la controladora.
        /// </summary>
        /// <exception cref="NotValidStateException">La controladora no est� iniciada.</exception>
        /// <returns>Valor que indica si la controladora se finaliz� correctamente.</returns>
        public bool Finish()
        {
            // --------------------------------------------------------------
            // Finalizamos las controladora
            // --------------------------------------------------------------
            FinishController(GetDefaultOutput());

            // --------------------------------------------------------------
            // Comunicaci�n del �xito o fracaso de la operaci�n
            // --------------------------------------------------------------
            return State == CLStates.NotStarted;
        }

		/// <summary>
		/// Realizar la finalizaci�n de la controladora.
		/// </summary>
		protected void FinishController(TOutput output)
		{
			if (isFinishing)
				return;

			isFinishing = true;

			try
			{
				CheckState(CLStates.Started);

				SFCancelEventArgs cEventArgs = new SFCancelEventArgs();
				OnFinishing(cEventArgs);

				if (cEventArgs.Cancel)
					return;

				List<FieldInfo> fields = GetAllFilds();
				List<IController> children = GetControllers(fields);

				// Finalizamos inclusiones ...			
                OnProgressChanged(new CLProgressChangedEventArgs(5, "Finalizando inclusiones..."));
				OnBeforeFinishControllers(children);

                OnProgressChanged(new CLProgressChangedEventArgs(20, "Finalizando inclusiones..."));
				FinishControllers(children);

                OnProgressChanged(new CLProgressChangedEventArgs(35, "Finalizando inclusiones..."));
				OnAfterFinishControllers(children);

				// Reseteamos campos ...			
                OnProgressChanged(new CLProgressChangedEventArgs(50, "Reseteando campos..."));
				OnBeforeResetFields(fields);

                OnProgressChanged(new CLProgressChangedEventArgs(65, "Reseteando campos..."));
				ResetFields(fields);

                OnProgressChanged(new CLProgressChangedEventArgs(80, "Reseteando campos..."));
				OnAfterResetFields(fields);

				// Retornamos la salida de la controladroa ...
                OnProgressChanged(new CLProgressChangedEventArgs(95, "Actualizando estado..."));
				State = CLStates.NotStarted;

                OnProgressChanged(new CLProgressChangedEventArgs(100));
				OnFinished(new CLFinishedEventArgs<TOutput>(output));
			}
			catch (Exception e)
			{
				throw e;
			}
			finally
			{
				isFinishing = false;
			}
		}

		/// <summary>
		/// Finaliza las controladoras hijas.
		/// </summary>
		private void FinishControllers(List<IController> children)
		{
			foreach (IController child in children)
				if (child.State.Equals(CLStates.Started))
					child.Finish();
		}

		/// <summary>
		/// Resetea los campos de la controladora.
		/// </summary>
		/// <param name="fields">Lista de campos de la controladora.</param>
		/// <remarks>
		/// Resetea los campos marcados con el atributo <see cref="CLReseteable"/>
		/// y las controladoras embebidas e incluidas.
		/// </remarks>
		private void ResetFields(List<FieldInfo> fields)
		{
			// Realizamos la b�squeda
			foreach (FieldInfo field in fields)
			{
				// Obtenemos el valor
				object v = field.GetValue(this);

				if (v != null && v is IController)
					// Corresponde con una controladora
					field.SetValue(this, null);
				else
				{
					// S�lo reseteamos aquellos campos que se han marcado para ello
					Attribute[] atributes = Attribute.GetCustomAttributes(field);

					if (atributes == null || atributes.Length.Equals(0))
						continue;

					foreach (Attribute atribute in atributes)
					{
						if (atribute is CLReseteable)
						{
							field.SetValue(this, ((CLReseteable)atribute).Value);
							break;
						}
					}
				}
			}
		}

		#endregion
    }
}