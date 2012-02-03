using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Views;


namespace Sifaw.Controllers.Test
{
	public class UIAssistantTestViewController
		: UIShellViewController
		< UIAssistantTestViewController.Input
		, UIAssistantTestViewController.Output
		, UIAssistantTestViewController.UISettingsContainer>
	{
		#region Entrada / Salida

		/// <summary>
		/// Parámetros de entrada de las controladora.
		/// </summary>
		[Serializable]
		public new class Input : UIShellViewController<Input, Output, UISettingsContainer>.Input
		{
			#region Constructor

			public Input()
				: this(true)
			{
			}

			public Input(bool showView)
				: base(showView:showView)
			{
			}

			#endregion
		}

		/// <summary>
		/// Parámetros de retorno de la controladora.
		/// </summary>
		[Serializable]
		public new class Output : UIShellViewController<Input, Output, UISettingsContainer>.Output
		{
			#region Variables

			private bool _cancelled;

			#endregion

			#region Propiedades

			/// <summary>
			/// Indica si el proceso fue cancelado
			/// </summary>
			public bool Cancelled
			{
				get { return _cancelled; }
			}

			#endregion

			#region Constructor

			public Output(bool cancelled)
				: base()
			{
				this._cancelled = cancelled;
			}

			#endregion
		}

		#endregion

		#region Settings

		[Serializable]
		public new class UISettingsContainer : UIShellViewController<Input, Output, UISettingsContainer>.UISettingsContainer
		{
			#region Constructor

			public UISettingsContainer()
				: base()
			{
			}

			#endregion

			#region Métodos públicos

			public override void Apply()
			{
				base.Apply();
			}

			#endregion
		}

		#endregion

		#region Inclusiones

		private UIAssistantTestController _uiAssistantTestController = null;
		private UIAssistantTestController UIAssistantTestController
		{
			get
			{
				if (_uiAssistantTestController == null)
				{
					_uiAssistantTestController = new UIAssistantTestController();
					_uiAssistantTestController.Finished += new CtrlFinishedEventHandler<Test.UIAssistantTestController.Output>(_uiAssistantTestController_Finished);
				}

				return _uiAssistantTestController;
			}
		}

		#endregion

		#region Constructor

		public UIAssistantTestViewController()
			: base()
		{
		}

		public UIAssistantTestViewController(AbstractUILinker<UIShellView> linker)
			: base(linker)
		{
		}

		#endregion

		#region Gestión de parámetros

		protected override Output GetDefaultOutput()
		{
			return new Output(true);
		}

		public override Input GetDefaultInput()
		{
			return new Input();
		}

		public override Input GetResetInput()
		{
			return null;
		}

		#endregion

		#region Métodos sobreescritos

		protected override void OnUISettingsApplied()
		{
			base.OnUISettingsApplied();

			// Aplicamos configuración a componentes internos ...
			UIAssistantTestController.UISettings.Apply();
		}

		protected override void OnAfterUIShow()
		{
			base.OnAfterUIShow();

			UIAssistantTestController.RunWorker();
		}

		#endregion

		#region UIShellController Members
		
		protected override uint GetNumberOfRows()
		{
			return 1;
		}

		protected override uint GetNumberOfCellsAt(uint row)
		{
			return 1;
		}

		protected override void GetRowSettings(uint row, out double height, out Views.UIShellGridLengthModes mode)
		{
			height = 400;
			mode = Views.UIShellGridLengthModes.WeightedProportion;
		}

		protected override void GetCellSettings(uint row, uint cell, out double width, out Views.UIShellGridLengthModes mode, out Views.UIComponent component)
		{
			width = 400;
			mode = Views.UIShellGridLengthModes.WeightedProportion;
			component = UIAssistantTestController.GetUIComponent();
		}

		protected override void StartController()
		{			
			UIAssistantTestController.Start();
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

		#region Gestión de eventos de inclusiones

		private void _uiAssistantTestController_Finished(object sender, CtrlFinishedEventArgs<UIAssistantTestController.Output> e)
		{
			FinishController(new Output(e.Output.Cancelled));
		}

		#endregion
	}
}