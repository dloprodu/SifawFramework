///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Controladora base de casos de uso
/// 
/// Diseñador:     David López Rguez
/// Programadores: David López Rguez
///	
/// </summary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 14/12/2011 -- Creación de la clase.
/// ===============================================================================================
/// Observaciones:
/// 
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Diagnostics.Contracts;

using Sifaw.Core;
using Sifaw.Core.Utilities;
using Sifaw.Views;


namespace Sifaw.Controllers
{
	/// <summary>
	/// Controladora base que provee de un patrón y funcionalidad para los casos de uso.
	/// </summary>
	/// <typeparam name="TInput">Tipo para establecer los parámetros de inicio de la controladora. Ha de ser serializable.</typeparam>
	/// <typeparam name="TOutput">Tipo para establcer los parametros de retorno cuando finaliza la controladora. Ha de ser serializable.</typeparam>
	public abstract class Controller<TInput, TOutput>
		: IController
		, IController<TInput, TOutput>
		where TInput  : Controller<TInput, TOutput>.Input
		where TOutput : Controller<TInput, TOutput>.Output
	{
		#region Constantes

		protected const string BR_START = "StartRules";
		protected const string BR_INSTANCE = "InstanceRules";

		#endregion

		#region Entrada / Salida

		/// <summary>
		/// Parámetros de entrada de la controladora.
		/// </summary>
		[Serializable]
		public abstract class Input : ICloneable
		{
			#region ICloneable Members

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

			public object Clone()
			{
				return UtilIO.Clone<TOutput>(this as TOutput);
			}

			#endregion
		}

		#endregion

		#region Variables

		/*
		 * No Reseteables
		 */

		// Indica el estado de la controladora.
		private CtrlStates _state;

		// Información básica de la controladora.
		protected CtrlInformation _information;

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
		/// Con el flag <see cref="isFinish"/> ignoramos esta posible segunda llamada.
		/// </para>
		/// </remarks>
		private bool isFinishing = false;

		/*
		 * Reseteables
		 */

		[CtrlReseteable(null)]
		private TInput _parameters;

		[CtrlReseteable(null)]
		private TInput _input;

		#endregion

		#region Eventos

		/*
		 * Desencadenadores privados.
		 *  • Solo son lanzados por la controladora padre.
		 */

		/// <summary>
		/// Evento para cominicar un cambio de estado.
		/// </summary>
		public event CtrlStatesEventHandler StateChanged;
		private void OnStateChanged(CtrlSatesEventArgs e)
		{
			if (StateChanged != null)
				StateChanged(this, e);
		}

		/// <summary>
		/// Evento para indicar que se está iniciando una controladora. 
		/// Se puede indicar que se cancele el proceso de inicio.
		/// </summary>
		public event CancelEventHandler Starting;
		private void OnStarting(CancelEventArgs e)
		{
			if (Starting != null)
				Starting(this, e);
		}

		/// <summary>
		/// Evento para indicar que se está finalizando una controladora. 
		/// Se puede indicar que se cancele el proceso de finalización.
		/// </summary>
		public event CancelEventHandler Finishing;
		private void OnFinishing(CancelEventArgs e)
		{
			if (Finishing != null)
				Finishing(this, e);
		}

		/// <summary>
		/// Evento para comunicar que la controladora ha finalizado.
		/// </summary>
		public event CtrlFinishedEventHandler<TOutput> Finished;
		private void OnFinished(CtrlFinishedEventArgs<TOutput> e)
		{
			if (Finished != null)
				Finished(this, e);
		}

		/*
		 * Desencadenadores protegidos.
		 *  • Pueden ser lanzados por controladoras hijas.
		 */

		/// <summary>
		/// Evento para comunicar el progreso del proceso.
		/// </summary>
		public event IntEventHandler ProgressChanged;
		protected void OnProgressChanged(IntEventArgs e)
		{
			if (ProgressChanged != null)
				ProgressChanged(this, e);
		}

		/// <summary>
		/// Evento para comunicar el mensaje de progreso del proceso.
		/// </summary>
		public event StringEventHandler ProgressMessageChanged;
		protected void OnProgressMessageChanged(StringEventArgs e)
		{
			if (ProgressMessageChanged != null)
				ProgressMessageChanged(this, e);
		}

		/// <summary>
		/// Evento para comunicar que se debe iniciar una controladora.
		/// </summary>
		public event CtrlEventHandler ThrowCtrl;
		protected void OnThrowCtrl(CtrlEventArgs e)
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
		/// Se llama al método <see cref="OnBeforeFinishController"/> antes de finalizar las
		/// controladoras embebidas. El método permite que las clases derivadas controlen
		/// el evento sin asociar un delegado.
		/// </summary>
		/// <param name="children">Lista de controladoras hijas.</param>
		/// <remarks>
		/// Al reemplazar <see cref="OnBeforeFinishController"/> en una clase derivada, asegúrese de llamar al
		/// método <see cref="OnBeforeFinishController"/> de la clase base para que los delegados registrados 
		/// reciban el evento.
		/// </remarks>
		protected virtual void OnBeforeFinishControllers(List<IController> children)
		{
			/* Emtpy */
		}

		/// <summary>
		/// Se llama al método <see cref="OnAfterFinishController"/> después de finalizar las
		/// controladoras embebidas. El método permite que las clases derivadas controlen 
		/// el evento sin asociar un delegado.
		/// </summary>
		/// <param name="children">Lista de controladoras hijas.</param>
		/// <remarks>
		/// Al reemplazar <see cref="OnAfterFinishController"/> en una clase derivada, asegúrese de llamar al
		/// método <see cref="OnAfterFinishController"/> de la clase base para que los delegados registrados
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
		/// Se llama al método <see cref="OnBeforeStartController"/></summary> antes de iniciar la
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
		/// Se llama al método <see cref="OnAfterStartController"/></summary> después de iniciar la
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

		#region Propiedades

		/*
		 * Públicas
		 */

		/// <summary>
		/// Obtiene o establece el el estado de la controladora.
		/// </summary>
		public CtrlStates State
		{
			get { return _state; }
			private set
			{
				if (_state != value)
				{
					_state = value;
					OnStateChanged(new CtrlSatesEventArgs(_state));
				}
			}
		}

		/// <summary>
		/// Obtiene la información básica de la controladora.
		/// </summary>
		public CtrlInformation Information
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
		/// Obtiene las reglas rotas de la controladora.
		/// </summary>
		protected BrokenRules BrokenPreconditions
		{
			get { return _brokenPreconditions; }
		}

		#endregion

		#region Constructor

		protected Controller()
			: base()
		{
			// Instanciamos el objeto que controla las precondiciones.
			_brokenPreconditions = new BrokenRules();

			// Iniciamos la información de la controladora.
			_information = CtrlInformation.Empty;

			// Estado de la controladora.
			_state = CtrlStates.NotStarted;

			CheckPreconditions(BR_INSTANCE);
		}

		#endregion

		#region Métodos protegidos

		#region Control de estados

		/// <summary>
		/// Comprueba el estado de la controladora. 
		/// </summary>
		/// <param name="estado">Estado de la controladora deseado</param>
		protected void CheckState(CtrlStates state)
		{
			if (State != state)
				throw new NotValidCtrlStateException();
		}

		#endregion

		#region Chequeo de precondiciones

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

		#region Metodos auxiliares

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
		/// <param name="modalidad">Modalidad de controladoras a obtener</param>
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

		#endregion

		#region Gestión de input / output

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

		#region Gestión de inicio

		/// <summary>
		/// Ejecuta los comandos de inicio de la controladora.
		/// </summary>
		protected abstract void StartController();

		/// <summary>
		/// Devuleve un valor que indica si la controladora se puede reiniciar.
		/// </summary>
		protected abstract bool AllowReset();

		/// <summary>
		/// Ejecuta las operaciones de reinicio de la controladora.
		/// </summary>
		protected abstract void ResetController();

		#endregion

		#region Gestión de finalización

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
				CheckState(CtrlStates.Started);

				CancelEventArgs cEventArgs = new CancelEventArgs();
				OnFinishing(cEventArgs);

				if (cEventArgs.Cancel)
					return;

				List<FieldInfo> fields = GetAllFilds();
				List<IController> children = GetControllers(fields);

				// Finalizamos inclusiones ...			
				OnProgressChanged(new IntEventArgs(5));
				OnBeforeFinishControllers(children);

				OnProgressChanged(new IntEventArgs(20));
				FinishControllers(children);

				OnProgressChanged(new IntEventArgs(35));
				OnAfterFinishControllers(children);

				// Reseteamos campos ...			
				OnProgressChanged(new IntEventArgs(50));
				OnBeforeResetFields(fields);

				OnProgressChanged(new IntEventArgs(65));
				ResetFields(fields);

				OnProgressChanged(new IntEventArgs(80));
				OnAfterResetFields(fields);

				// Retornamos la salida de la controladroa ...
				OnProgressChanged(new IntEventArgs(95));
				State = CtrlStates.NotStarted;

				OnProgressChanged(new IntEventArgs(100));
				OnFinished(new CtrlFinishedEventArgs<TOutput>(output));
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
				if (child.State.Equals(CtrlStates.Started))
					child.Finish();
		}

		/// <summary>
		/// Resetea los campos de la controladora.
		/// </summary>
		/// <param name="fields">Lista de campos de la controladora.</param>
		/// <remarks>
		/// Resetea los campos marcados con el atributo <see cref="CtrlReseteable"/>
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
						if (atribute is CtrlReseteable)
						{
							field.SetValue(this, ((CtrlReseteable)atribute).Value);
							break;
						}
					}
				}
			}
		}

		#endregion

		#region IController

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
		/// <exception cref="NotValidCtrlStateException">La controladora ya está iniciada.</exception>
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
		/// <exception cref="NotValidCtrlStateException">La controladora ya está iniciada.</exception>
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
			CheckState(CtrlStates.NotStarted);

			// Lanzamos el evento para comunicar el inicio y esperamos confirmación de cancelación
			CancelEventArgs cEventArgs = new CancelEventArgs();
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
				State = CtrlStates.Started;
				OnBeforeStartController();
				StartController();
				OnAfterStartController();
				success = true;
			}

			return success;
		}

		/// <summary>
		/// Reinicia la controladora con los parámetros por defecto
		/// </summary>
		/// <exception cref="NotValidCtrlStateException">La controladora no está iniciada.</exception>
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
		/// <exception cref="NotValidCtrlStateException">La controladora no está iniciada.</exception>
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
			CheckState(CtrlStates.Started);

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

		/// <summary>
		/// Termina la ejecución de la controladora.
		/// </summary>
		/// <exception cref="NotValidCtrlStateException">La controladora no está iniciada.</exception>
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
			return State == CtrlStates.NotStarted;
		}

		#endregion
	}
}