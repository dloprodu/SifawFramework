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
using System.Threading;

using Sifaw.Core;

using Sifaw.Views;
using Sifaw.Views.Components;


namespace Sifaw.Controllers.Components
{
	/// <summary>
	/// Controladora encargada de ejecutar un proceso pesado en un nuevo hilo de ejecución
	/// permitiendo notificando el progreso en un componente que implemente <see cref="BackgroundWorkerComponent"/>.
	/// </summary>
	/// <remarks>
	/// <para>
	/// La descripción del proceso a ejecutar se ha de pasar mediante los parámetros de inicio en
	/// un objeto del tipo <see cref="BackgroundWorkerPack"/>.
	/// </para>
	/// <para>
	/// Haciendo uso del contenedor de ajustes de la controladora, <see cref="UIElementController{TInput, TOutput, TUIElement}.UISettings"/>,
	/// se puede indicar si el proceso permite la cancelación, realiza un control del progreso asi como datos de caracter general como una descipción del proceso
	/// que se va a ejecutar.
	/// </para>
	/// <para>
	/// La controladora tiene como precondición de inicio que se provea de un método de ejecución del tipo
	/// <see cref="BackgroundWorkerDelegate"/>.
	/// </para>
	/// </remarks>
	public class UIBackgroundWorkerController : UIComponentController
		< UIBackgroundWorkerController.Input
		, UIBackgroundWorkerController.Output
		, BackgroundWorkerComponent>
	{
		#region Input / Output

		/// <summary>
        /// Parámetros de entrada de las controladora.
        /// </summary>
		[Serializable]
		public new class Input : UIComponentController
			< Input
			, Output
			, BackgroundWorkerComponent>.Input
		{
			#region Fields

			private BackgroundWorkerPack _workerPack;
            private bool _finishToWorkerCompleted;

			#endregion

			#region Properties

			/// <summary>
			/// Obtiene el paquete de ejecución.
			/// </summary>
			public BackgroundWorkerPack WorkerPack
			{
				get { return _workerPack; }
			}

            /// <summary>
            /// Obtiene un valor que indica si se finaliza la controladora al completar la tarea de segundo plano.
            /// </summary>
            public bool FinishToWorkerCompleted
            {
                get { return _finishToWorkerCompleted; }
            }

			#endregion

			#region Constructors

			/// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIBackgroundWorkerController.Input"/>,
			/// estableciendo un valor a la propiedad <see cref="WorkerPack"/>.
			/// </summary>
			/// <param name="worker">Paquete de ejecución</param>
			public Input(BackgroundWorkerPack worker, bool finishToWorkerCompleted)
				: base()
			{
				this._workerPack = worker;
                this._finishToWorkerCompleted = finishToWorkerCompleted;
			}

			#endregion
		}

		/// <summary>
        /// Parámetros de retorno de las controladora.
        /// </summary>
		[Serializable]
		public new class Output : UIComponentController
			< Input
			, Output
			, BackgroundWorkerComponent>.Output
		{
			#region Fields

			private object _result;
			private bool _cancelled;

			#endregion

			#region Properties

			/// <summary>
			/// Devuelve el resultado del proceso.
			/// </summary>
			public object Result
			{
				get { return _result; }
			}

			/// <summary>
			/// Devuelve un valor que indica si el proceso fue cancelado
			/// </summary>
			public bool Cancelled
			{
				get { return _cancelled; }
			}

			#endregion

			#region Constructors

			/// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIBackgroundWorkerController.Output"/>
            /// </summary>
            /// <param name="result">Resultado del proceso</param>
            /// <param name="cancelled">Indica si el proceso fue cancelado</param>
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

        [CLReseteable(null)]
        private BackgroundWorkerCommunicator Communicator = null;

		#endregion

		#region Events

        /// <summary>
        /// Se produce antes de lanzar un proceso pesado en un nuevo hilo.
        /// </summary>
		public event SFCancelEventHandler BeforeBackgroundWorker = null;

		/// <summary>
        /// Provoca el evento <see cref="BeforeBackgroundWorker"/>.
		/// Permite ejecutar operaciones antes de iniciar el proceso pesado.
		/// </summary>
		protected virtual void OnBeforeBackgroundWorker(SFCancelEventArgs e)
		{
			if (BeforeBackgroundWorker != null)
				BeforeBackgroundWorker(this, e);
		}

        /// <summary>
        /// Se produce al finalizar el proceso pesado.
        /// </summary>
        public event CLRunWorkerCompletedEventHandler AfterBackgroundWorker = null;

		/// <summary>
        /// Provoca el evento <see cref="AfterBackgroundWorker"/>.
        /// Permite ejecutar operaciones al finalizar el proceso pesado.
		/// </summary>
        protected virtual void OnAfterBackgroundWorker(CLRunWorkerCompletedEventArgs e)
		{
			if (AfterBackgroundWorker != null)
				AfterBackgroundWorker(this, e);
		}

		#endregion

        #region Properties

        /// <summary>
        /// Devuelve el contenedor de ajustes del elemento de interfaz a través
        /// del cual se puede modificar la configuración predeterminada.
        /// </summary>
        public new BackgroundWorkerSettings UISettings
        {
            get { return UIElement.UISettings; }
        }

        #endregion

		#region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BackgroundWorkerComponent"/>.
        /// Establece como <see cref="UILinker{TUIElement}"/> aquel establecido por defecto a través de 
        /// <see cref="UILinkersManager"/>.
        /// </summary>
		public UIBackgroundWorkerController()
			: base()
		{
		}

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="BackgroundWorkerComponent"/>, 
		/// estableciendo el <see cref="UILinker{TUIElement}"/> especificado como valor de la propiedad 
		/// <see cref="UIElementController{TInput, TOutput, TUIElement}.Linker"/> donde <c>TUIElement</c>
		/// implementa <see cref="BackgroundWorkerComponent"/>.
        /// </summary>
		public UIBackgroundWorkerController(UILinker<BackgroundWorkerComponent> linker)
			: base(linker)
		{
		}

		#endregion

		#region UIElement Methods

        /// <summary>
        /// Invoca al método sobrescirto <see cref="UIElementController{TInput, TOutput, TComponent}.OnAfterUIElementLoad()"/> y
        /// posteriormente se subscribe a los eventos del componente <see cref="Sifaw.Views.Components.BackgroundWorkerComponent"/>.
        /// </summary>
		protected override void OnAfterUIElementLoad()
		{
			base.OnAfterUIElementLoad();

			UIElement.Cancel += new EventHandler(UIElement_Cancel);
		}

		#endregion

		#region Check Preconditions

        /// <summary>
        /// Implementa el proceso de chequeo de precondiciones de la controladora.
        /// </summary>
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

        /// <summary>
        /// Devuelve los parámetros de inicio por defecto.
        /// </summary>
		public override Input GetDefaultInput()
		{
			return new Input(null, true);
		}
        
        /// <summary>
        /// Devuelve los parámetros de reinicio por defecto.
        /// </summary>
        /// <returns></returns>
        public override Input GetResetInput()
        {
            return null;
        }

        /// <summary>
        /// Devuelve los parámetros de retorno por defecto.
        /// </summary>
        protected override Output GetDefaultOutput()
        {
            return new Output(null, true);
        }

		#endregion

		#region Public Methods

		/// <summary>
		/// Ejecuta el proceso pesado. Antes de ejecutar el proceso se lanza el evento <see cref="BeforeBackgroundWorker"/>
		/// que permite cancelar la ejecución.
		/// </summary>
        /// <remarks>
        /// Para invocar este método la controladora ha de estar iniciada, 
        /// en otro caso, devolverá una excepcion.
        /// </remarks>
        /// <exception cref="NotValidStateException">La controladora no está iniciada.</exception>
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

        /// <summary>
        /// Solicita la cancelación del proceso pesado.
        /// </summary>
        /// <remarks>
        /// Para invocar este método la controladora ha de estar iniciada, 
        /// en otro caso, devolverá una excepcion.
        /// </remarks>
        /// <exception cref="NotValidStateException">La controladora no está iniciada.</exception>
        public void CancelWorker()
		{
			CheckState(CLStates.Started);

			UIElement_Cancel(UIElement, EventArgs.Empty);
		}

		#endregion

        #region Start Methods

        /// <summary>
        /// Ejecuta los comandos de inicio de la controladora.
        /// </summary>
        protected override void StartController()
		{	
			// Inicializamos el worker
			worker = new System.ComponentModel.BackgroundWorker();
			worker.DoWork += new System.ComponentModel.DoWorkEventHandler(worker_DoWork);
			worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(worker_ProgressChanged);
			worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
			worker.WorkerReportsProgress = true;
			worker.WorkerSupportsCancellation = true;
		}

        /// <summary>
        /// Devuelve un valor que indica que no se puede reiniciar una controladora <see cref="UIBackgroundWorkerController"/>.
        /// </summary>
		/// <returns>false</returns>
		protected override bool AllowReset()
		{
			return false;
		}

        /// <summary>
        /// No realiza ninguna operación puesto que la controladora no permite el reinicio.
        /// </summary>
		protected override void ResetController()
		{
			/* Emtpy */
		}

		#endregion

		#region Finish Methods

        /// <summary>
        /// Invoca al método sobrescirto <see cref="UIElementController{TInput, TOutput, TUIElement}.OnBeforeFinishControllers(List{IController})"/>
        /// y posteriormente libera el objeto <see cref="System.ComponentModel.BackgroundWorker"/>.
        /// </summary>
		protected override void OnBeforeFinishControllers(List<IController> children)
		{
			base.OnBeforeFinishControllers(children);

			// Liberamos el worker
			if (worker != null)
			{
                worker.DoWork -= new System.ComponentModel.DoWorkEventHandler(worker_DoWork);
                worker.ProgressChanged -= new System.ComponentModel.ProgressChangedEventHandler(worker_ProgressChanged);
                worker.RunWorkerCompleted -= new System.ComponentModel.RunWorkerCompletedEventHandler(worker_RunWorkerCompleted);
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

			pack.Start(Communicator = new BackgroundWorkerCommunicator(work));
			e.Result = pack.Result;

			if (work.CancellationPending)
				e.Cancel = true;
		}

		private void worker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
		{
            object result = e.Cancelled ? null : e.Result;
            bool cancelled = e.Cancelled;

			OnAfterBackgroundWorker(new CLRunWorkerCompletedEventArgs(result, cancelled));

            if (Parameters.FinishToWorkerCompleted)
                FinishController(new UIBackgroundWorkerController.Output(result, cancelled));
		}

		private void worker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
		{
            lock (Communicator)
            {
                Tuple<ReportProgressCommands, string, object> arguments = (Tuple<ReportProgressCommands, string, object>)e.UserState;
                
                switch (arguments.Item1)
                {
                    case ReportProgressCommands.TextChanged:
                        UIElement.UpdateProgress(arguments.Item2);
                        break;

                    case ReportProgressCommands.ProgressAndTextChanged:
                        if (UISettings.WithControl)
                            UIElement.UpdateProgress(e.ProgressPercentage);

                        UIElement.UpdateProgress(arguments.Item2);
                        break;

                    case ReportProgressCommands.ProgressChanged:
                        if (UISettings.WithControl)
                            UIElement.UpdateProgress(e.ProgressPercentage);
                        break;

                    case ReportProgressCommands.MaximumProgressChanged:
                        if (UISettings.WithControl)
                            UIElement.UISettings.MaxProgressPercentage = (int)arguments.Item3;
                        break;

                    case ReportProgressCommands.WithControlChanged:
                        UIElement.UISettings.WithControl = (bool)arguments.Item3;
                        break;
                }

                Monitor.Pulse(Communicator);
            }
		}

		#endregion
	}
}