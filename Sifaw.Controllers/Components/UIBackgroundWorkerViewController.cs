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
using System.Linq;
using System.Text;

using Sifaw.Views;
using Sifaw.Views.Components;
using Sifaw.Views.Kit;
using Sifaw.Core;


namespace Sifaw.Controllers.Components
{
	/// <summary>
	/// Controladora de vista que aloja el compomente <see cref="UIBackgroundWorkerController"/> y que
	/// permite ejecutar un proceso pesado en un nuevo hilo de ejecución.
	/// </summary>
	public class UIBackgroundWorkerViewController : UIShellViewController
		< UIBackgroundWorkerViewController.Input
		, UIBackgroundWorkerViewController.Output
		, BackgroundWorkerComponent>
	{
		#region Input / Output

		/// <summary>
		/// Parámetros de entrada de las controladora.
		/// </summary>
		[Serializable]
		public new class Input : UIShellViewController<Input, Output, BackgroundWorkerComponent>.Input
		{
			#region Fields

			private BackgroundWorkerPack _worker;

			#endregion

			#region Properties

			/// <summary>
			/// Paquete de ejecución
			/// </summary>
			public BackgroundWorkerPack Worker
			{
				get { return _worker; }
				set { _worker = value; }
			}

			#endregion

			#region Constructors

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UIBackgroundWorkerViewController.Input"/>,
			/// estableciendo la propiedad <see cref="UIViewController{TInput, TOutput, TView}.Input.ShowView"/> a <c>true</c>.
			/// </summary>
			/// <param name="worker">Paquete de ejecución</param>
			public Input(BackgroundWorkerPack worker)
				: this(worker:worker, showView:true, isModal:true)
			{
			}

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UIBackgroundWorkerViewController.Input"/>
			/// </summary>
			/// <param name="worker">Paquete de ejecución</param>
			/// <param name="showView">Indica si se muestra la vista al iniciar la controladora.</param>
			public Input(BackgroundWorkerPack worker, bool showView)
				: this(worker:worker, showView:showView, isModal:true)
			{
			}

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIBackgroundWorkerViewController.Input"/>
            /// </summary>
            /// <param name="worker">Paquete de ejecución</param>
            /// <param name="showView">Indica si se muestra la vista al iniciar la controladora.</param>
            /// <param name="isModal">Indica si la vista es modal.</param>
            public Input(BackgroundWorkerPack worker, bool showView, bool isModal)
                /* Esta vista siempre se muestra como modal. */
                : base(showView: showView, isModal: isModal)
            {
                this._worker = worker;
            }

			#endregion
		}

		/// <summary>
		/// Parámetros de retorno de la controladora.
		/// </summary>
		[Serializable]
		public new class Output : UIShellViewController<Input, Output, BackgroundWorkerComponent>.Output
		{
			#region Fields

			private object _result;
			private bool _cancelled;

			#endregion

			#region Properties

			/// <summary>
			/// Devuelve el resultado del proceso pesado.
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
			/// Inicializa una nueva instancia de la clase <see cref="UIBackgroundWorkerViewController.Output"/>.
			/// </summary>
			/// <param name="result">Resultado del proceso pesado.</param>
			/// <param name="cancelled">Valor que indica si el proceso ha sido cancelado.</param>
			public Output(object result, bool cancelled)
				: base()
			{
				this._result = result;
				this._cancelled = cancelled;
			}

			#endregion
		}

		#endregion

        #region Fields

        [CLDateTimeReseteable(true)]
        private DateTime startTime = DateTime.MinValue;

        #endregion

        #region Inclusions

        private UIBackgroundWorkerController _uiBackgroundWorkerController = null;
		private UIBackgroundWorkerController UIBackgroundWorkerController
		{
			get
			{
				if (_uiBackgroundWorkerController == null)
				{
					_uiBackgroundWorkerController = new UIBackgroundWorkerController();
                    _uiBackgroundWorkerController.RunWorkerProgressChanged += new CLRunWorkerProgressChangedEventHandler(_uiBackgroundWorkerController_RunWorkerProgressChanged);
					_uiBackgroundWorkerController.Finished += new CLFinishedEventHandler<Components.UIBackgroundWorkerController.Output>(_uiBackgroundWorkerController_Finished);
				}

				return _uiBackgroundWorkerController;
			}
		}

		#endregion

        #region Events

        /// <summary>
        /// Se produce cuando cambia el progreso del proceso pesado.
        /// </summary>
        public event CLRunWorkerProgressChangedEventHandler RunWorkerProgressChanged = null;

        /// <summary>
        /// Provoca el evento <see cref="RunWorkerProgressChanged"/>.
        /// </summary>
        private void OnRunWorkerProgressChanged(CLRunWorkerProgressChangedEventArgs e)
        {
            if (RunWorkerProgressChanged != null)
                RunWorkerProgressChanged(this, e);
        }

        #endregion

		#region Properties

		/// <summary>
		/// Obtiene el contenedor de ajustes del componente <see cref="UIBackgroundWorkerController"/>
		/// alojado.
		/// </summary>
        public BackgroundWorkerSettings UIBWSettings
		{
			get { return UIBackgroundWorkerController.UISettings; }
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIBackgroundWorkerViewController"/>.
		/// Establece como <see cref="UILinker{TUIElement}"/> aquel establecido por defecto a través de 
		/// <see cref="UILinkersManager"/>.
		/// </summary>
		public UIBackgroundWorkerViewController()
			: base()
		{			
		}

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIBackgroundWorkerViewController"/>, 
		/// estableciendo el <see cref="UILinker{TUIElement}"/> especificado como valor de la propiedad 
		/// <see cref="UIElementController{TInput, TOutput, TUIElement}.Linker"/> donde <c>TUIElement</c>
		/// implementa <see cref="ShellView"/>.
		/// </summary>
		public UIBackgroundWorkerViewController(UILinker<ShellView> linker)
			: base(linker)
		{
		}

		#endregion

		#region Default Input / Output

		/// <summary>
		/// Devuelve los parámetros de inicio por defecto.
		/// </summary>
		public override Input GetDefaultInput()
		{
			return new Input(new BackgroundWorkerPack(null, null));
		}

		/// <summary>
		/// Devuelve los parámetros de reinicio por defecto.
		/// </summary>
		public override Input GetResetInput()
		{
			return null;
		}

		/// <summary>
		/// Devuelve los parámetros de retorno por defecto.
		/// </summary>		
		protected override Output GetDefaultOutput()
		{
			return new Output(null, false);
		}		

		#endregion

		#region UIElement Methods

		/// <summary>
        /// Invoca al método sobrescirto <see cref="UIShellViewController{TInput, TOutput, TGuest}.OnAfterUIElementCreate()"/> y
		/// posteriormente establece una configuración por defecto a la vista.
		/// </summary>
		protected override void OnAfterUIElementCreate()
		{
			base.OnAfterUIElementCreate();

            /* Default Setiings... */
            UISettings.Header = "Espere ...";
            UISettings.AllowResize = false;
            UISettings.SizeToContent = true;
            UISettings.MinSize = new UISize(600, 0);
            UISettings.MaxSize = new UISize(600, 400);

            /* Subscripción a eventos del componente... */
        }
        
		/// <summary>
		/// Invoca al método sobrescirto <see cref="UIViewController{TInput, TOutput, TUIView}.OnBeforeUIClose(out bool)"/> y
		/// posteriormente solicita la cancelación del proceso al componente <see cref="UIBackgroundWorkerController"/>.
		/// </summary>
		/// <param name="cancel">Devuelve un valor que indica si se cancela el cierre de la vista.</param>
		protected override void OnBeforeUIClose(out bool cancel)
		{
			// Deshabilitamos el comportamiento por defecto y solicitamos la cancelación del proceso.
            // base.OnBeforeUIClose(out cancel);            

			// Cancelamos la finalización explicita
			// y solicitamos la cancelación del proceso.
			cancel = true;
			UIBackgroundWorkerController.CancelWorker();
		}

		/// <summary>
		/// Invoca al método sobrescirto <see cref="UIViewController{TInput, TOutput, TUIView}.OnAfterUIShow()"/> y
		/// posteriormente inicia la ejecución del proceso pesado.
		/// </summary>
		protected override void OnAfterUIShow()
		{
			base.OnAfterUIShow();

            startTime = DateTime.Now;
			UIBackgroundWorkerController.RunWorker();
		}

		#endregion

		#region UIShell Methods
				
		/// <summary>
		/// Establece en 1 el número de filas de la vista.
		/// </summary>
		/// <returns>1</returns>
		protected override uint GetNumberOfRows()
		{
			return 1;
		}

		/// <summary>
		/// Establece en 1 el número de celdas de la fila.
		/// </summary>
		/// <param name="row">Fila</param>
		/// <returns>1</returns>
		protected override uint GetNumberOfCellsAt(uint row)
		{
			return 1;
		}

		/// <summary>
		/// Establece que la fila se ajuste al contenido de la celda.
		/// </summary>
		protected override void GetRowSettings(uint row, out double height, out UIShellLengthModes mode)
		{
			height = 100;
			mode = UIShellLengthModes.WeightedProportion;
		}

		/// <summary>
		/// Establece que la celda se ajuste al componete <see cref="UIBackgroundWorkerController"/>.
		/// </summary>
		protected override void GetRowCellSettings(uint row, uint cell, out double width, out UIShellLengthModes mode, out BackgroundWorkerComponent component)
		{
			width = 100;
            mode = UIShellLengthModes.WeightedProportion;
			component = UIBackgroundWorkerController.GetUIComponent() as BackgroundWorkerComponent;
		}

		#endregion

		#region Start Methods

		/// <summary>
		/// Ejecuta los comandos de inicio de la controladora.
		/// </summary>
		protected override void StartController()
		{
			UIBackgroundWorkerController.Start(new UIBackgroundWorkerController.Input(Parameters.Worker, true));
		}

		/// <summary>
		/// Devuelve un valor que indica que no se puede reiniciar una controladora <see cref="UIBackgroundWorkerViewController"/>.
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
			/* Empty */
		}

		#endregion

        #region Helpers

        private string GetTimeRemaining(int progress, int maxProgress)
        {
            TimeSpan timespent = DateTime.Now - startTime;

            int secondsremaining = (int)(timespent.TotalSeconds / progress * (maxProgress - progress));

            TimeSpan remaining = TimeSpan.FromSeconds(secondsremaining);

            return (string.Format("{0:D2}h:{1:D2}m:{2:D2}s", remaining.Hours, remaining.Minutes, remaining.Seconds));
        }

        #endregion

        #region Inclusions Events Handlers

        private void _uiBackgroundWorkerController_RunWorkerProgressChanged(object sender, CLRunWorkerProgressChangedEventArgs e)
        {
            UISettings.Header = (e.WithControl) ? 
                Math.Round(((e.Progress / (float)e.MaxProgress) * 100.0f)).ToString().PadLeft(3) + " % completado ... " + "(" + GetTimeRemaining(e.Progress, e.MaxProgress) + ")" :
                "Espere ...";

            OnRunWorkerProgressChanged(e);
        }

		private void _uiBackgroundWorkerController_Finished(object sender, CLFinishedEventArgs<UIBackgroundWorkerController.Output> e)
		{
			FinishController(new Output(e.Output.Result, e.Output.Cancelled));
		}

		#endregion
	}
}