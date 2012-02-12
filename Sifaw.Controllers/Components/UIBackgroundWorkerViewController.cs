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


namespace Sifaw.Controllers.Components
{
	public class UIBackgroundWorkerViewController
		: UIShellViewController
		< UIBackgroundWorkerViewController.Input
		, UIBackgroundWorkerViewController.Output
		, UIBackgroundWorkerViewController.UISettingsContainer
		, BackgroundWorkerComponent>
	{
		#region Input / Output

		/// <summary>
		/// Parámetros de entrada de las controladora.
		/// </summary>
		[Serializable]
		public new class Input : UIShellViewController<Input, Output, UISettingsContainer, BackgroundWorkerComponent>.Input
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

			public Input(BackgroundWorkerPack worker)
				: this(worker, true)
			{
			}

			public Input(BackgroundWorkerPack worker, bool showView)
				: base(showView:showView)
			{
				this._worker = worker;
			}

			#endregion
		}

		/// <summary>
		/// Parámetros de retorno de la controladora.
		/// </summary>
		[Serializable]
		public new class Output : UIShellViewController<Input, Output, UISettingsContainer, BackgroundWorkerComponent>.Output
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

			public Output(object result, bool cancelled)
				: base()
			{
				this._result = result;
				this._cancelled = cancelled;
			}

			#endregion
		}

		#endregion

		#region Settings

		[Serializable]
		public new class UISettingsContainer : UIShellViewController
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

				// El comportamiento por defecto es que la vista se ajuste a su contenido.
				this.Height = double.NaN;
				this.Width = double.NaN;
				this.SizeToContent = true;
			}

			#endregion
		}

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
					_uiBackgroundWorkerController.Finished += new CLFinishedEventHandler<Components.UIBackgroundWorkerController.Output>(_uiBackgroundWorkerController_Finished);
				}

				return _uiBackgroundWorkerController;
			}
		}

		#endregion

		#region Constructors

		public UIBackgroundWorkerViewController()
			: base()
		{
		}

		public UIBackgroundWorkerViewController(AbstractUILinker<ShellView> linker)
			: base(linker)
		{
		}

		#endregion

		#region Default Input / Output

		protected override Output GetDefaultOutput()
		{
			return new Output(null, false);
		}

		public override Input GetDefaultInput()
		{
			return new Input(new BackgroundWorkerPack(null, null));
		}

		public override Input GetResetInput()
		{
			return null;
		}

		#endregion

		#region UIElement Methods

		protected override void OnAfterApplyUISettings()
        {
            base.OnAfterApplyUISettings();

			// Aplicamos configuración a componentes internos ...
			UIBackgroundWorkerController.UISettings.AllowCancel = UISettings.AllowCancel;
			UIBackgroundWorkerController.UISettings.WithControl = UISettings.WithControl;
			UIBackgroundWorkerController.UISettings.Summary = UISettings.Summary;
			UIBackgroundWorkerController.UISettings.ProcessDescription = UISettings.ProcessDescription;
			UIBackgroundWorkerController.UISettings.Progress = UISettings.Progress;
			UIBackgroundWorkerController.UISettings.Apply();
		}

		protected override void OnBeforeUIClose(out bool cancel)
		{
			// Deshabilitamos el comportamiento por defecto y solicitamos la cancelación del proceso.
			// base.OnUIFinish();

			// Cancelamos la finalización explicita
			// y solicitamos la cancelación del proceso.
			cancel = true;
			UIBackgroundWorkerController.CancelWorker();
		}

		protected override void OnAfterUIShow()
		{
			base.OnAfterUIShow();

			UIBackgroundWorkerController.RunWorker();
		}

		#endregion

		#region UIShell Methods
		
		protected override uint GetNumberOfRows()
		{
			return 1;
		}

		protected override uint GetNumberOfCellsAt(uint row)
		{
			return 1;
		}

		protected override void GetRowSettings(uint row, out double height, out Views.UILengthModes mode)
		{
			height = 0;
			mode = Views.UILengthModes.Auto;
		}

		protected override void GetRowCellSettings(uint row, uint cell, out double width, out UILengthModes mode, out BackgroundWorkerComponent component)
		{
			width = 0;
			mode = Views.UILengthModes.Auto;
			component = UIBackgroundWorkerController.GetUIComponent() as BackgroundWorkerComponent;
		}

		#endregion

		#region Start Methods

		protected override void StartController()
		{
			UIBackgroundWorkerController.Start(new UIBackgroundWorkerController.Input(Parameters.Worker));
		}

		protected override bool AllowReset()
		{
			return false;
		}

		protected override void ResetController()
		{
			/* Empty */
		}

		#endregion

		#region Inclusions Events Handlers

		private void _uiBackgroundWorkerController_Finished(object sender, CLFinishedEventArgs<UIBackgroundWorkerController.Output> e)
		{
			FinishController(new Output(e.Output.Result, e.Output.Cancelled));
		}

		#endregion
	}
}