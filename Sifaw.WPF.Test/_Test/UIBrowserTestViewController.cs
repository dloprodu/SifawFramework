using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Controllers;

using Sifaw.Views;
using Sifaw.Views.Kit;


namespace Sifaw.WPF.Test
{
	public class UIBrowserTestViewController : UIShellViewController
        < UIBrowserTestViewController.Input
        , UIBrowserTestViewController.Output
		, ShellComponent>
	{
		#region Input / Output

		/// <summary>
		/// Parámetros de entrada de las controladora.
		/// </summary>
		[Serializable]
		public new class Input : UIShellViewController<Input, Output, ShellComponent>.Input
		{
			#region Constructors

			public Input()
				: this(true, true)
			{
			}

            public Input(bool showView, bool isModal)
                : base(showView: showView, isModal: isModal)
            {
			}

			#endregion
		}

		/// <summary>
		/// Parámetros de retorno de la controladora.
		/// </summary>
		[Serializable]
		public new class Output : UIShellViewController<Input, Output, ShellComponent>.Output
		{
			#region Constructors

			public Output()
				: base()
			{
			}

			#endregion
		}

		#endregion

		#region Inclusions

        private UIBrowserTestController _browserTest = null;
        private UIBrowserTestController BrowserTest
		{
			get
			{
				if (_browserTest == null)
				{
                    _browserTest = new UIBrowserTestController();
				}

				return _browserTest;
			}
		}

		#endregion

		#region Constructors

		public UIBrowserTestViewController()
			: base()
		{
		}

        public UIBrowserTestViewController(UILinker<ShellView> linker)
			: base(linker)
		{
		}

		#endregion
        
		#region Shell Methods

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
			height = 800;
			mode = UIShellLengthModes.WeightedProportion;
		}

		protected override void GetRowCellSettings(uint row, uint cell, out double width, out UIShellLengthModes mode, out ShellComponent guest)
		{
			width = 600;
            mode = UIShellLengthModes.WeightedProportion;
			guest = BrowserTest.GetUIComponent() as ShellComponent;
		}

		#endregion

		#region Default Input / Output

		public override Input GetDefaultInput()
		{
			return new Input();
		}

		public override Input GetResetInput()
		{
			return new Input();
		}

		protected override Output GetDefaultOutput()
		{
			return new Output();
		}

		#endregion

		#region UIElement Members

		protected override void OnAfterUIElementCreate()
		{
			base.OnAfterUIElementCreate();

            UISettings.SizeToContent = false;
            UISettings.AllowResize = true;
            UISettings.Width = 800;
            UISettings.Height = 600;
            UISettings.Header = "Browser Test";
		}

		#endregion

		#region Start Methods

		protected override void StartController()
		{
			BrowserTest.Start();
		}

		protected override void OnAfterStartController()
		{
			base.OnAfterStartController();
		}

		protected override bool AllowReset()
		{
			return true;
		}

		protected override void ResetController()
		{
			BrowserTest.Reset();
		}

		#endregion
	}
}