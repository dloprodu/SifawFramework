/*
 * Sifaw.Controllers
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 14/12/2011: Creación de la clase.
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
    /// Controladora base que provee de un patrón e infraestructura común para el resto de controladoras que derivan de ella.
	/// </summary>
    /// <remarks>
    /// <para>
	/// Las controladoras <see cref="Controller{TInput, TOutput}"/> implementan un ciclo de vida que permiten su inicio,
    /// reseteo o finalización asi como de un sistema de chequeo de reglas que permite definir en que estados se permite iniciar
    /// o reiniciar una controladora.
    /// </para>
    /// <para>
    /// Eventos como <see cref="StateChanged"/>, <see cref="Starting"/> o <see cref="Finishing"/>, entre otros, informan sobre la transición 
    /// de un estado a otro.
    /// </para>
    /// <para>
	/// Las controladoras <see cref="Controller{TInput, TOutput}"/> implementa un patrón 'Before / After Action' que ayuda a las controladoras
    /// derivadas completar funcionalidad en cualquier punto del ciclo de vida de la controladora.
    /// </para>
    /// <para>
	/// Además las controladoras han de definir los parametros que recibirán como entrada cuando son iniciadas (<see cref="Controller{TInput, TOutput}.Input"/>)
	/// y aquellos que retornarán cuando finalicen (<see cref="Controller{TInput, TOutput}.Output"/>).
    /// </para>
    /// </remarks>
	/// <typeparam name="TInput">
    /// Tipo para establecer los parámetros de inicio de la controladora. Ha de ser serializable y 
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
		/// Parámetros de entrada de la controladora.
		/// </summary>
		[Serializable]
		public abstract class Input : ICloneable
		{
			#region ICloneable Members

			/// <summary>
			/// Devuelve una copia de los parámetros de entrada de la controladora.
			/// </summary>
			public object Clone()
			{
				return UtilIO.Clone<TInput>(this as TInput);
			}

			#endregion
		}

		/// <summary>
		/// Parámetros de retorno de la controladora.
		/// </summary>
		[Serializable]
		public abstract class Output : ICloneable
		{
			#region ICloneable Members

			/// <summary>
			/// Devuelve una copia de los parámetros de retorno de la controladora.
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
		/// Información básica de la controladora.
		/// </summary>
		protected CLInformation _information;

		// Conjunto de reglas rotas para las precondiciones de la controladora.
		private BrokenRules _brokenPreconditions;

		/// <summary>
		/// Flag que indica si la finalización ya ha sido iniciada.
		/// </summary>
		/// <remarks>
		/// <para>
		/// En un árbol de controladoras, controladoras padres que instancian otras controladoras (controladoras hijas), se puede producir
		/// el caso en el que una controladora se finaliza derivando por tanto en la finalización de sus controladoras hijas.
		/// </para>
		/// <para>
		/// A su vez, la misma controladora puede haberse subscrito al evento de finalización de alguna de sus controladoras hijas 
		/// para finalizarse cuando finaliza su hija. En este caso, se produciría una doble llamada al método de finalización de la controladora padre.
		/// No llegaa entrar en un bucle de finalización porque en la segunda llamda ya sus controladoras hijas están finalizadas.
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
		 *  • Solo son lanzados por la controladora padre.
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
		 *  • Pueden ser lanzados por controladoras hijas.
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
		 *  • Pueden ser sobreescritos por controladoras hijas para
		 *    completar funcionalidad.
		 */

		/// <summary>
		/// Se llama al método <see cref="OnBeforeFinishControllers"/> antes de finalizar las
		/// controladoras embebidas. El método permite que las clases derivadas controlen
		/// el evento sin asociar un delegado.
		/// </summary>
		/// <param name="children">Lista de controladoras hijas.</param>
		/// <remarks>
		/// Al reemplazar <see cref="OnBeforeFinishControllers"/> en una clase derivada, asegúrese de llamar al
		/// método <see cref="OnBeforeFinishControllers"/> de la clase base para que los delegados registrados 
		/// reciban el evento.
		/// </remarks>
		protected virtual void OnBeforeFinishControllers(List<IController> children)
		{
			/* Emtpy */
		}

		/// <summary>
		/// Se llama al método <see cref="OnAfterFinishControllers"/> después de finalizar las
		/// controladoras embebidas. El método permite que las clases derivadas controlen 
		/// el evento sin asociar un delegado.
		/// </summary>
		/// <param name="children">Lista de controladoras hijas.</param>
		/// <remarks>
		/// Al reemplazar <see cref="OnAfterFinishControllers"/> en una clase derivada, asegúrese de llamar al
		/// método <see cref="OnAfterFinishControllers"/> de la clase base para que los delegados registrados
		/// reciban el evento.
		/// </remarks>
		protected virtual void OnAfterFinishControllers(List<IController> children)
		{
			/* Emtpy */
		}

		/// <summary>
		/// Se llama al método <see cref="OnBeforeResetFields"/> antes de resetear los campos.
		/// El método permite que las clases derivadas controlen el evento sin asociar un delegado.
		/// </summary>
		/// <param name="fields">Lista de campos de la controladora.</param>
		/// <remarks>
		/// Al reemplazar <see cref="OnBeforeResetFields"/> en una clase derivada, asegúrese de llamar al
		/// método <see cref="OnBeforeResetFields"/> de la clase base para que los delegados registrados 
		/// reciban el evento.
		/// </remarks>
		protected virtual void OnBeforeResetFields(List<FieldInfo> fields)
		{
			/* Emtpy */
		}

		/// <summary>
		/// Se llama al método <see cref="OnAfterResetFields"/> después de resetear los campos.
		/// El método permite que las clases derivadas controlen el evento sin asociar un delegado.
		/// </summary>
		/// <param name="fields">Lista de campos de la controladora.</param>
		/// <remarks>
		/// Al reemplazar <see cref="OnAfterResetFields"/> en una clase derivada, asegúrese de llamar al
		/// método <see cref="OnAfterResetFields"/> de la clase base para que los delegados registrados 
		/// reciban el evento.
		/// </remarks>
		protected virtual void OnAfterResetFields(List<FieldInfo> fields)
		{
			/* Emtpy */
		}

		/// <summary>
		/// Se llama al método <see cref="OnBeforeStartController"/> antes de iniciar la
		/// controladora. El método permite que las clases derivadas controlen 
		/// el evento sin asociar un delegado.
		/// </summary>
		/// <remarks>
		/// Al reemplazar <see cref="OnBeforeStartController"/> en una clase derivada, asegúrese de llamar al
		/// método <see cref="OnBeforeStartController"/> de la clase base para que los delegados registrados
		/// reciban el evento.
		/// </remarks>
		protected virtual void OnBeforeStartController()
		{
			/* Emtpy */
		}

		/// <summary>
		/// Se llama al método <see cref="OnAfterStartController"/> después de iniciar la
		/// controladora. El método permite que las clases derivadas controlen 
		/// el evento sin asociar un delegado.
		/// </summary>
		/// <remarks>
		/// Al reemplazar <see cref="OnAfterStartController"/> en una clase derivada, asegúrese de llamar al
		/// método <see cref="OnAfterStartController"/> de la clase base para que los delegados registrados
		/// reciban el evento.
		/// </remarks>
		protected virtual void OnAfterStartController()
		{
			/* Emtpy */
		}

		/// <summary>
		/// Se llama al método <see cref="OnBeforeResetController"/> antes de reiniciar la
		/// controladora. El método permite que las clases derivadas controlen 
		/// el evento sin asociar un delegado.
		/// </summary>
		/// <remarks>
		/// Al reemplazar <see cref="OnBeforeResetController"/> en una clase derivada, asegúrese de llamar al
		/// método <see cref="OnBeforeResetController"/> de la clase base para que los delegados registrados
		/// reciban el evento.
		/// </remarks>
		protected virtual void OnBeforeResetController()
		{
			/* Emtpy */
		}

		/// <summary>
		/// Se llama al método <see cref="OnAfterResetController"/> después de reiniciar la
		/// controladora. El método permite que las clases derivadas controlen 
		/// el evento sin asociar un delegado.
		/// </summary>
		/// <remarks>
		/// Al reemplazar <see cref="OnAfterResetController"/> en una clase derivada, asegúrese de llamar al
		/// método <see cref="OnAfterResetController"/> de la clase base para que los delegados registrados
		/// reciban el evento.
		/// </remarks>
		protected virtual void OnAfterResetController()
		{
			/* Emtpy */
		}

		#endregion

        #region Properties

        /*
		 * Públicas
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
		/// Devuelve información descriptiva de la controladora.
		/// </summary>
		public CLInformation Information
		{
			get { return _information; }
		}

		/*
		 * Progegidas
		 */

		/// <summary>
		/// Devuelve los parámetros de la controladora.
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

			// Iniciamos la información de la controladora.
			_information = CLInformation.Empty;

			// Estado de la controladora.
			_state = CLStates.NotStarted;

			CheckPreconditions(BR_INSTANCE);
		}

		#endregion

		#region Check Preconditions

		/// <summary>
		/// Fuerza el chequeo de la preciondición indicada
		/// </summary>
		/// <param name="preconditionName">Nombre de la precondición indicada</param>
		protected void CheckPreconditions(string preconditionName)
		{
			OnCheckPreconditions(preconditionName);
		}

		/// <summary>
		/// Permite que un objeto realice su propio proceso de chequeo de precondiciones
		/// Las clases derivadas pueden sobreescribir este método para chequear precondiciones
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
		/// Devuelve una copia del estado inicial de los parámetros.
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
			// Lista que contendrá las controladora
			List<IController> list = new List<IController>();

			// Realizamos la búsqueda
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
		/// Devuelve los parámetros por defecto de inicio.
		/// </summary>
		public abstract TInput GetDefaultInput();

		/// <summary>
		/// Devuelve los parámetros de reinicio.
		/// </summary>
		public abstract TInput GetResetInput();

		/// <summary>
		/// Devuelve los parámetros por defecto de finalización.
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
		/// Inicia la controladora con los parámetros por defecto
		/// </summary>
		/// <exception cref="NotValidStateException">La controladora ya está iniciada.</exception>
		/// <exception cref="ArgumentNullException">input es null.</exception>
		/// <exception cref="ArgumentException">input no es serializable.</exception>
		/// <exception cref="NotCanStartException">input no contiene los parámetros esperados para el inicio.</exception>
		/// <exception cref="Exception">Excepción internal de la controladora.</exception>
		/// <returns>Valor que indica si la controladora se inició correctamente.</returns>
		public bool Start()
		{
			return Start(GetDefaultInput());
		}

		/// <summary>
		/// Inicia la controladora.
		/// </summary>
		/// <exception cref="NotValidStateException">La controladora ya está iniciada.</exception>
		/// <exception cref="ArgumentNullException">input es null.</exception>
		/// <exception cref="ArgumentException">input no es serializable.</exception>
		/// <exception cref="NotCanStartException">input no contiene los parámetros esperados para el inicio.</exception>
		/// <exception cref="Exception">Excepción interna de la controladora.</exception>
		/// <param name="input">Parámetros de inicio de la controladora</param>
		/// <returns>Valor que indica si la controladora se inició correctamente.</returns>
		public bool Start(TInput input)
		{
			if (!typeof(TInput).IsSerializable)
				throw new ArgumentException();

			bool success = false;

			// Comprobamos que la controladora se encuentra en un estado correcto
			CheckState(CLStates.NotStarted);

			// Lanzamos el evento para comunicar el inicio y esperamos confirmación de cancelación
			SFCancelEventArgs cEventArgs = new SFCancelEventArgs();
			OnStarting(cEventArgs);

			if (!cEventArgs.Cancel)
			{
				// Establecemos los parámetros de inicio de la controladora.
				_parameters = UtilIO.Clone<TInput>(input);
				_parameters = _parameters ?? GetDefaultInput();
				// Guardamos una copia de los parametros de entrada que no podrá ser modificada.
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
        /// Reinicia la controladora con los parámetros por defecto
        /// </summary>
        /// <exception cref="NotValidStateException">La controladora no está iniciada.</exception>
        /// <exception cref="NotAllowResetException">La controladora no soporta el reinicio.</exception>
        /// <exception cref="ArgumentNullException">input es null.</exception>
        /// <exception cref="ArgumentException">input no es serializable.</exception>
        /// <exception cref="NotCanStartException">input no contiene los parámetros esperados para el inicio.</exception>
        /// <exception cref="Exception">Excepción interna de la controladora.</exception>
        /// <returns>Valor que indica si la controladora se reinició correctamente.</returns>
        public bool Reset()
        {
            return Reset(GetResetInput());
        }

        /// <summary>
        /// Reinicia la controladora.
        /// </summary>
        /// <exception cref="NotValidStateException">La controladora no está iniciada.</exception>
        /// <exception cref="NotAllowResetException">La controladora no soporta el reinicio.</exception>
        /// <exception cref="ArgumentNullException">input es null.</exception>
        /// <exception cref="ArgumentException">input no es serializable.</exception>
        /// <exception cref="NotCanStartException">input no contiene los parámetros esperados para el inicio.</exception>
        /// <exception cref="Exception">Excepción interna de la controladora.</exception>
        /// <param name="input">Parámetros de la controladora para realizar el reinicio</param>
        /// <returns>Valor que indica si la controladora se reinició correctamente.</returns>
        public bool Reset(TInput input)
        {
            if (!typeof(TInput).IsSerializable)
                throw new ArgumentException();

            bool success = false;

            // Comprobamos que la controladora se encuentra en un estado correcto
            CheckState(CLStates.Started);

            // Establecemos los parámetros de reinicio de la controladora
            _parameters = UtilIO.Clone<TInput>(input);
            _parameters = _parameters ?? GetResetInput();
            _parameters = _parameters ?? GetDefaultInput();
            // Guardamos una copia de los parametros de entrada que no podrá ser modificada.
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
        /// Termina la ejecución de la controladora.
        /// </summary>
        /// <exception cref="NotValidStateException">La controladora no está iniciada.</exception>
        /// <returns>Valor que indica si la controladora se finalizó correctamente.</returns>
        public bool Finish()
        {
            // --------------------------------------------------------------
            // Finalizamos las controladora
            // --------------------------------------------------------------
            FinishController(GetDefaultOutput());

            // --------------------------------------------------------------
            // Comunicación del éxito o fracaso de la operación
            // --------------------------------------------------------------
            return State == CLStates.NotStarted;
        }

		/// <summary>
		/// Realizar la finalización de la controladora.
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
			// Realizamos la búsqueda
			foreach (FieldInfo field in fields)
			{
				// Obtenemos el valor
				object v = field.GetValue(this);

				if (v != null && v is IController)
					// Corresponde con una controladora
					field.SetValue(this, null);
				else
				{
					// Sólo reseteamos aquellos campos que se han marcado para ello
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