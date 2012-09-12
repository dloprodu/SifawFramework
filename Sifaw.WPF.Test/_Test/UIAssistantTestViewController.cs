using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Controllers;

using Sifaw.Views;
using Sifaw.Views.Kit;


namespace Sifaw.WPF.Test
{
	public class UIAssistantTestViewController
		: UIShellViewController
		< UIAssistantTestViewController.Input
		, UIAssistantTestViewController.Output
		, UIComponent>
	{
		#region Input / Output

		/// <summary>
		/// Parámetros de entrada de las controladora.
		/// </summary>
		[Serializable]
		public new class Input : UIShellViewController<Input, Output, UIComponent>.Input
		{
			#region Constructors

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
		public new class Output : UIShellViewController<Input, Output, UIComponent>.Output
		{
			#region Fields

			private bool _cancelled;

			#endregion

			#region Properties

			/// <summary>
			/// Indica si el proceso fue cancelado
			/// </summary>
			public bool Cancelled
			{
				get { return _cancelled; }
			}

			#endregion

			#region Constructors

			public Output(bool cancelled)
				: base()
			{
				this._cancelled = cancelled;
			}

			#endregion
		}

		#endregion

		#region Inclusions

		private UIAssistantTestController _uiAssistantTestController = null;
		private UIAssistantTestController UIAssistantTestController
		{
			get
			{
				if (_uiAssistantTestController == null)
				{
					_uiAssistantTestController = new UIAssistantTestController();
					_uiAssistantTestController.Finished += new CLFinishedEventHandler<Test.UIAssistantTestController.Output>(_uiAssistantTestController_Finished);
				}

				return _uiAssistantTestController;
			}
		}

		#endregion

		#region Constructors

		public UIAssistantTestViewController()
			: base()
		{
		}

		public UIAssistantTestViewController(UILinker<ShellView> linker)
			: base(linker)
		{
		}

		#endregion

		#region Default Input / Output

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

		#region UIElement Methods

		protected override void OnAfterUIElementLoad()
		{
			base.OnAfterUIElementLoad();

			UISettings.SizeToContent = false;
			UISettings.AllowResize = false;
			UISettings.Width = 800;
			UISettings.Height = 600;
		}

		protected override void OnAfterUIShow()
		{
			base.OnAfterUIShow();

			UIAssistantTestController.RunWorker();
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

		protected override void GetRowSettings(uint row, out double height, out UIShellLengthModes mode)
		{
			height = 400;
			mode = UIShellLengthModes.WeightedProportion;
		}

		protected override void GetRowCellSettings(uint row, uint cell, out double width, out UIShellLengthModes mode, out Views.UIComponent component)
		{
			width = 400;
			mode = UIShellLengthModes.WeightedProportion;
			component = UIAssistantTestController.GetUIComponent();
		}

        #endregion

        #region Start Methods

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

		#region Inclusions Events Handlers

		private void _uiAssistantTestController_Finished(object sender, CLFinishedEventArgs<UIAssistantTestController.Output> e)
		{
			FinishController(new Output(e.Output.Cancelled));
		}

		#endregion
	}
}