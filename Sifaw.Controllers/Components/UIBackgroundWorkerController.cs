///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// Controladora encargada de la carga de los procesos pesados.
/// 
/// Diseñador:     David López Rguez
/// Programadores: David López Rguez
/// </sumary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 16/12/2011: Creación de controladora.
/// 
/// ===============================================================================================
/// Observaciones:
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;
using System.Text;

using Sifaw.Core;
using Sifaw.Views.Components;


namespace Sifaw.Controllers.Components
{
	/// <summary>
	/// Controladora encargada de ejecutar procesos pesados notificando el progreso en 
	/// un componente de UI.
	/// </summary>
	/// <typeparam name="TShell">Tipo del contenedor UI del componente <see cref="TComponent"/>.</typeparam>
	public class UIBackgroundWorkerController : UIComponentController
		< UIBackgroundWorkerController.Input
		, UIBackgroundWorkerController.Output
		, UIBackgroundWorkerController.UISettingsContainer
		, BackgroundWorkerComponent>
	{
		#region Parametros de inicio / finalización

		/// <summary>
		/// Clase que engloba los parámetros de inicio de la controladora de procesos pesados
		/// </summary>
		[Serializable]
		public new class Input : UIComponentController
			< Input
			, Output
			, UISettingsContainer
			, BackgroundWorkerComponent>.Input
		{
			#region Variables

			private BackgroundWorkerPack _workerPack;

			#endregion

			#region Propiedades

			/// <summary>
			/// Paquete de ejecución
			/// </summary>
			public BackgroundWorkerPack WorkerPack
			{
				get { return _workerPack; }
				set { _workerPack = value; }
			}

			#endregion

			#region Constructor

			/// <summary>
			/// Clase que engloba los parámetros de inicio de la controladora de procesos pesados
			/// </summary>
			/// <param name="worker">Paquete de ejecución</param>
			/// <param name="finishOnWorkEnd">Flag que indica si se finaliza la controladora al terminar el proceso pesado.</param>
			public Input(BackgroundWorkerPack worker)
				: base()
			{
				this._workerPack = worker;
			}

			#endregion
		}

		/// <summary>
		/// Clase que engloba los parámetros de finalización de la controladora de procesos pesados
		/// </summary>
		[Serializable]
		public new class Output : UIComponentController
			< Input
			, Output
			, UISettingsContainer
			, BackgroundWorkerComponent>.Output
		{
			#region Variables

			private object _result;
			private bool _cancelled;

			#endregion

			#region Propiedades

			/// <summary>
			/// Resultado del proceso
			/// </summary>
			public object Result
			{
				get { return _result; }
			}

			/// <summary>
			/// Indica si el proceso fue cancelado
			/// </summary>
			public bool Cancelled
			{
				get { return _cancelled; }
			}

			#endregion

			#region Constructor

			/// <summary>
			/// Clase que engloba los parámetros de finalización de la controladora de procesos pesados
			/// </summary>
			/// <param name="resultado">Resultado del proceso</param>
			/// <param name="cancelado">Indica si el proceso fue cancelado</param>
			internal protected Output(object result, bool cancelled)
				: base()
			{
				this._result = result;
				this._cancelled = cancelled;
			}

			#endregion
		}

		#endregion

		#region Variables

		// TODO: Mover el BackgroundWorker a la vista puesto que es un componente de System.Components o implementar un componente similar.

		/// <summary>
		/// Comunicador de procesos
		/// </summary>
		[CLReseteable(null)]
		private System.ComponentModel.BackgroundWorker worker = null;
		
		#endregion

		#region Eventos

		public event SFCancelEventHandler BeforeBackgroundWorker = null;

		/// <summary>
		/// Permite ejecutar operaciones antes de iniciar el proceso pesado.
		/// </summary>
		protected virtual void OnBeforeBackgroundWorker(SFCancelEventArgs e)
		{
			if (BeforeBackgroundWorker != null)
				BeforeBackgroundWorker(this, e);
		}

		public event EventHandler AfterBackgroundWorker = null;

		/// <summary>
		/// Permite ejecutar operaciones al finalizar el proceso pesado.
		/// </summary>
		protected virtual void OnAfterBackgroundWorker(EventArgs e)
		{
			if (AfterBackgroundWorker != null)
				AfterBackgroundWorker(this, e);
		}

		#endregion

		#region Settings

		[Serializable]
		public class UISettingsContainer : UIComponentController
			< Input
			, Output
			, UISettingsContainer
			, BackgroundWorkerComponent>.UISettingsContainer<BackgroundWorkerComponent>
		{
			#region Variables

			private bool _withControl = true;
			private bool _allowCancel = false;
			private string _summary = string.Empty;
			private string _processDescription = string.Empty;
			private string _progress = string.Empty;

			#endregion

			#region Propiedades

			/// <summary>
			/// Establece o devuelve un valor que indica si el proceso
			/// se ejecuta con o sin control de seguimiento.
			/// </summary>
			public bool WithControl
			{
				get { return _withControl; }
				set { _withControl = value; }
			}

			/// <summary>
			/// Establece o devuelve un valor que indica si se permite
			/// cancelar el proceso.
			/// </summary>
			public bool AllowCancel
			{
				get { return _allowCancel; }
				set { _allowCancel = value; }
			}

			/// <summary>
			/// Establece o devuelve una descripción breve del proceso.
			/// </summary>
			public string Summary
			{
				get { return _summary; }
				set { _summary = value; }
			}

			/// <summary>
			/// Establece o devuelve una descripción del proceso.
			/// </summary>
			public string ProcessDescription
			{
				get { return _processDescription; }
				set { _processDescription = value; }
			}

			/// <summary>
			/// Establece o devuelve el texto a mostrar durante el progreso del
			/// proceso.
			/// </summary>
			public string Progress
			{
				get { return _progress; }
				set { _progress = value; }
			}

			#endregion

			#region Constructor

			public UISettingsContainer()
				: base()
			{
				this.Summary = "Operación pesada";
				this.ProcessDescription = "Se está ejecutando un proceso pesado. Esta operación puede tardar varios minutos. Espere por favor...";
				this.Progress = "Ejecutando proceso...";
				this.WithControl = true;
				this.AllowCancel = false;
			}

			#endregion

			#region Métodos públicos

			public override void Apply()
			{
				base.Apply();

				UIElement.Summary = Summary;
				UIElement.ProcessDescription = ProcessDescription;
				UIElement.AllowCancel = AllowCancel;
				UIElement.WithControl = WithControl;
				UIElement.Progress = Progress;
			}

			#endregion
		}		

		#endregion

		#region Constructor

		public UIBackgroundWorkerController()
			: base()
		{
		}

		public UIBackgroundWorkerController(AbstractUILinker<BackgroundWorkerComponent> linker)
			: base(linker)
		{
		}

		#endregion

		#region Component

		protected override void OnAfterUIElementLoad()
		{
			base.OnAfterUIElementLoad();

			UIElement.Cancel += new EventHandler(UIElement_Cancel);
		}

		#endregion

		#region Chequeo de precondiciones

		protected override void OnCheckPreconditions(string preconditionName)
		{
			base.OnCheckPreconditions(preconditionName);

			if (preconditionName.Equals(BR_START))
			{
				BrokenPreconditions.Assert("Method",
					"No se ha proporcionado un método para ejecutar.",
					Parameters.WorkerPack == null
					|| Parameters.WorkerPack.Method == null);
			}
		}

		#endregion

		#region Gestión de parámetros

		protected override Output GetDefaultOutput()
		{
			return new Output(null, true);
		}

		public override Input GetDefaultInput()
		{
			return new Input(null);
		}

		public override Input GetResetInput()
		{
			return null;
		}

		#endregion

		#region Métodos públicos

		/// <summary>
		/// Ejecuta el proceso pesado. Antes de ejecutar el proceso se lanza el evento <see cref="BeforeBackgroundWorker"/>
		/// que permite cancelar la ejecución.
		/// </summary>
		public void RunWorker()
		{
			CheckState(CLStates.Started);
						
			if (!worker.IsBusy)
			{
				SFCancelEventArgs eArgs = new SFCancelEventArgs();

				OnBeforeBackgroundWorker(eArgs);

				if (!eArgs.Cancel)
					worker.RunWorkerAsync(Parameters.WorkerPack);
				else
					Finish();
			}
		}

		public void CancelWorker()
		{
			CheckState(CLStates.Started);

			UIElement_Cancel(UIElement, EventArgs.Empty);
		}

		#endregion

		#region IController

		protected override void StartController()
		{
			// Establecemos la configuración del componente.
			UISettings.Apply();		
			
			// Inicializamos el worker
			worker = new System.ComponentModel.BackgroundWorker();
			worker.DoWork += new System.ComponentModel.DoWorkEventHandler(worker_DoWork);
			worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(worker_ProgressChanged);
			worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
			worker.WorkerReportsProgress = true;			
		}

		protected override bool AllowReset()
		{
			return false;
		}

		protected override void ResetController()
		{
			/* Emtpy */
		}

		#endregion

		#region Gestión de la finalización

		protected override void OnBeforeFinishControllers(List<IController> children)
		{
			base.OnBeforeFinishControllers(children);

			// Liberamos el worker
			if (worker != null)
			{
				worker.Dispose();
				worker = null;
			}
		}

		#endregion

		#region Gestión de eventos

		protected override void OnUISettingsApplied()
		{
			base.OnUISettingsApplied();

			if (worker != null)
				worker.WorkerSupportsCancellation = UISettings.AllowCancel;
		}

		#endregion

		#region Gestión de eventos del componente

		private void UIElement_Cancel(object sender, EventArgs e)
		{
			if (worker.IsBusy && UISettings.AllowCancel && !worker.CancellationPending)
			{
				worker.CancelAsync();
				
				UIElement.UpdateProgress("Cancelando la operación. Este proceso puede tardar varios segundos...", true);
			}
		}

		#endregion

		#region Gestión de eventos del Worker

		private void worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
		{
			BackgroundWorkerPack pack = (BackgroundWorkerPack)e.Argument;
			System.ComponentModel.BackgroundWorker work = (System.ComponentModel.BackgroundWorker)sender;

			pack.Start(new BackgroundWorkerCommunicator(work));
			e.Result = pack.Result;

			if (work.CancellationPending)
				e.Cancel = true;
		}

		private void worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
			OnAfterBackgroundWorker(EventArgs.Empty);

			FinishController(new UIBackgroundWorkerController.Output(e.Cancelled ? null : e.Result, e.Cancelled));
		}

		private void worker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
		{
			Tuple<ReportProgressCommand, string> argumentos = (Tuple<ReportProgressCommand, string>)e.UserState;
			
			switch (argumentos.Item1)
			{
				case ReportProgressCommand.TextChanged:
					UIElement.UpdateProgress(argumentos.Item2);
					break;

				case ReportProgressCommand.ProgressAndTextChanged:
					if (UISettings.WithControl)
						UIElement.UpdateProgress(e.ProgressPercentage);
					
					UIElement.UpdateProgress(argumentos.Item2);
					break;

				case ReportProgressCommand.ProgressChanged:
					if (UISettings.WithControl)
						UIElement.UpdateProgress(e.ProgressPercentage);
					break;

				case ReportProgressCommand.MaximumProgressChanged:
					if (UISettings.WithControl)
						UIElement.MaxProgressPercentage = e.ProgressPercentage;
					break;

				case ReportProgressCommand.WithControlChanged:
					UIElement.WithControl = !UIElement.WithControl;
					break;
			}
		}

		#endregion
	}

	#region Miscelanea

	/// <summary>
	/// Define los comandos que puede enviar un proceso pesado a la controladora
	/// para actualizar la información mostrada al usuario.
	/// </summary>
	public enum ReportProgressCommand
	{
		ProgressAndTextChanged,
		TextChanged,
		ProgressChanged,
		MaximumProgressChanged,
		WithControlChanged
	}

	[Serializable]
	public delegate object BackgroundWorkerDelegate(BackgroundWorkerCommunicator comunicador, object[] arg);

	/// <summary>
	/// Representa un paquete de ejecucion de una tarea de fondo.
	/// </summary>
	[Serializable]
	public class BackgroundWorkerPack
	{
		#region Variables

		private BackgroundWorkerDelegate _method = null;
		private object[] _arguments = null;
		private object _result = null;

		#endregion

		#region Propiedades

		public BackgroundWorkerDelegate Method
		{
			get { return _method; }
		}

		public object Result
		{
			get { return _result; }
		}

		#endregion

		#region Constructor

		/// <summary>
		/// Construye el paquete de información para ejecutar un proceso pesado
		/// </summary>
		/// <param name="method">Delegado que contiene el código a ejecutar.</param>
		/// <param name="arguments">Lista de argumentos que se necesitan para ejecutar el delegado.</param>
		public BackgroundWorkerPack(BackgroundWorkerDelegate method, object[] arguments)
		{
			_method = method;
			_arguments = arguments;
		}

		#endregion

		#region Metodos

		public void Start(BackgroundWorkerCommunicator communicator)
		{
			try
			{
				_result = _method.DynamicInvoke(new object[] { communicator, _arguments });
			}
			catch (Exception)
			{
				_result = null;
			}
		}

		#endregion
	}

	/// <summary>
	/// Provee de soporte a la comunicación con procesos pesados que se ejecutan 
	/// en hilos.
	/// </summary>
	[Serializable]
	public class BackgroundWorkerCommunicator
	{
		#region Variables

		private System.ComponentModel.BackgroundWorker Worker = null;

		#endregion

		#region Propiedades

		/// <summary>
		/// Indica si el usuario ha solicitado la cancelación del proceso
		/// </summary>
		public bool CancellationPending
		{
			get { return Worker.CancellationPending; }
		}

		#endregion

		#region Constructor

		public BackgroundWorkerCommunicator(System.ComponentModel.BackgroundWorker worker)
		{
			Worker = worker;
		}

		#endregion

		#region Metodos para el progreso primario

		/// <summary>
		/// Indica al gestor de procesos pesados, el progreso y el texto a mostrar en el progreso.
		/// Si se ha iniciado el proceso en modo sin control, este método no hace nada.
		/// </summary>
		public void Progress(int progess, string text)
		{
			Worker.ReportProgress(progess, new Tuple<ReportProgressCommand, string>( ReportProgressCommand.ProgressAndTextChanged, text ));
		}

		/// <summary>
		/// Indica al gestor de procesos pesados el texto a mostrar en el progreso.
		/// </summary>
		public void Progress(string text)
		{
			Worker.ReportProgress(0, new Tuple<ReportProgressCommand, string>( ReportProgressCommand.TextChanged, text ));
		}

		/// <summary>
		/// Incrementa en una unidad el progreso indicado, según el máximo indicado.
		/// Si se ha iniciado el proceso en modo SinControl, este método no hace nada.
		/// </summary>
		public void Increment(string text)
		{
			Worker.ReportProgress(1, new Tuple<ReportProgressCommand, string>( ReportProgressCommand.ProgressAndTextChanged, text ));
		}

		/// <summary>
		/// Incrementa en una unidad el progreso indicado, según el máximo indicado.
		/// Si se ha iniciado el proceso en modo sin control, este método no hace nada.
		/// </summary>
		public void Increment()
		{
			Worker.ReportProgress(1, new Tuple<ReportProgressCommand, string>(ReportProgressCommand.ProgressChanged, string.Empty));
		}

		/// <summary>
		/// Cambia el máximo predeterminado del progreso.
		/// Si se ha iniciado el proceso en modo sin control, este método no hace nada.
		/// </summary>
		public void ChangeMaxProgress(int value)
		{
			Worker.ReportProgress(value, new Tuple<ReportProgressCommand, string>(  ReportProgressCommand.MaximumProgressChanged, string.Empty ));
		}

		/// <summary>
		/// Modifica el modo de la carga del proceso pesado.
		/// </summary>
		public void ChangeWithControl(bool value)
		{
			Worker.ReportProgress(0, new Tuple<ReportProgressCommand, string>( ReportProgressCommand.WithControlChanged, "" ));
		}

		#endregion
	}

	#endregion
}