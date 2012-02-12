/*
 * Sifaw.Controllers.Components
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 08/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



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
		#region Input / Output

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
			#region Fields

			private BackgroundWorkerPack _workerPack;

			#endregion

			#region Properties

			/// <summary>
			/// Paquete de ejecución
			/// </summary>
			public BackgroundWorkerPack WorkerPack
			{
				get { return _workerPack; }
				set { _workerPack = value; }
			}

			#endregion

			#region Constructors

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
			#region Fields

			private object _result;
			private bool _cancelled;

			#endregion

			#region Properties

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

			#region Constructors

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

		#region Fields

		// TODO: Mover el BackgroundWorker a la vista puesto que es un componente de System.Components o implementar un componente similar.

		/// <summary>
		/// Comunicador de procesos
		/// </summary>
		[CLReseteable(null)]
		private System.ComponentModel.BackgroundWorker worker = null;
		
		#endregion

		#region Events

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
		public new class UISettingsContainer : UIComponentController
			< Input
			, Output
			, UISettingsContainer
			, BackgroundWorkerComponent>.UISettingsContainer
		{
			#region Fields

			private bool _withControl = true;
			private bool _allowCancel = false;
			private string _summary = string.Empty;
			private string _processDescription = string.Empty;
			private string _progress = string.Empty;

			#endregion

			#region Properties

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

			#region Constructors

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
		}		

		#endregion

		#region Constructors

		public UIBackgroundWorkerController()
			: base()
		{
		}

		public UIBackgroundWorkerController(AbstractUILinker<BackgroundWorkerComponent> linker)
			: base(linker)
		{
		}

		#endregion

		#region UIElement Methods

		protected override void OnAfterUIElementLoad()
		{
			base.OnAfterUIElementLoad();

			UIElement.Cancel += new EventHandler(UIElement_Cancel);
		}

        protected override void OnApplyUISettings()
		{
			base.OnApplyUISettings();

            UIElement.Summary = UISettings.Summary;
            UIElement.ProcessDescription = UISettings.ProcessDescription;
            UIElement.AllowCancel = UISettings.AllowCancel;
            UIElement.WithControl = UISettings.WithControl;
            UIElement.Progress = UISettings.Progress;
		}

        protected override void OnAfterApplyUISettings()
        {
            base.OnAfterApplyUISettings();

            if (worker != null)
                worker.WorkerSupportsCancellation = UISettings.AllowCancel;
        }

		#endregion

		#region Check Preconditions

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

		#region Default Input / Output

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

		#region Public Methods

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

        #region Start Methods

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

		#region Finish Methods

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

		#region UIElement Events Handlers

		private void UIElement_Cancel(object sender, EventArgs e)
		{
			if (worker.IsBusy && UISettings.AllowCancel && !worker.CancellationPending)
			{
				worker.CancelAsync();
				
				UIElement.UpdateProgress("Cancelando la operación. Este proceso puede tardar varios segundos...", true);
			}
		}

		#endregion

		#region Worker Events Handlers 

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
			Tuple<ReportProgressCommands, string> argumentos = (Tuple<ReportProgressCommands, string>)e.UserState;
			
			switch (argumentos.Item1)
			{
				case ReportProgressCommands.TextChanged:
					UIElement.UpdateProgress(argumentos.Item2);
					break;

				case ReportProgressCommands.ProgressAndTextChanged:
					if (UISettings.WithControl)
						UIElement.UpdateProgress(e.ProgressPercentage);
					
					UIElement.UpdateProgress(argumentos.Item2);
					break;

				case ReportProgressCommands.ProgressChanged:
					if (UISettings.WithControl)
						UIElement.UpdateProgress(e.ProgressPercentage);
					break;

				case ReportProgressCommands.MaximumProgressChanged:
					if (UISettings.WithControl)
						UIElement.MaxProgressPercentage = e.ProgressPercentage;
					break;

				case ReportProgressCommands.WithControlChanged:
					UIElement.WithControl = !UIElement.WithControl;
					break;
			}
		}

		#endregion
	}
}