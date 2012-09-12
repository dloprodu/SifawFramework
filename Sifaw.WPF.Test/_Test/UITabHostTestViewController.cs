using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Controllers;

using Sifaw.Views;
using Sifaw.Views.Components;
using Sifaw.Views.Kit;


namespace Sifaw.WPF.Test
{
	public class UITabHostTestViewController : UIShellViewController
		< UITabHostTestViewController.Input
		, UITabHostTestViewController.Output
		, TabHostComponent>
	{
		#region Input / Output

		/// <summary>
		/// Parámetros de entrada de las controladora.
		/// </summary>
		[Serializable]
		public new class Input : UIShellViewController<Input, Output, TabHostComponent>.Input
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
		public new class Output : UIShellViewController<Input, Output, TabHostComponent>.Output
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

		private UITabHostTestController _uiTabHostTestController = null;
		private UITabHostTestController UITabHostTestController
		{
			get
			{
				if (_uiTabHostTestController == null)
				{
					_uiTabHostTestController = new UITabHostTestController();
					_uiTabHostTestController.Finished += new CLFinishedEventHandler<Test.UITabHostTestController.Output>(_uiTabHostTestController_Finished);
				}

				return _uiTabHostTestController;
			}
		}

		#endregion

		#region Constructors

		public UITabHostTestViewController()
			: base()
		{
		}

		public UITabHostTestViewController(UILinker<ShellView> linker)
			: base(linker)
		{
		}

		#endregion

		#region Default Input / Output

		public override Input GetDefaultInput()
		{
			return new Input();
		}

		public override Input GetResetInput()
		{
			return null;
		}

		protected override Output GetDefaultOutput()
		{
			return new Output();
		}

		#endregion

		#region UIElement Methods

		protected override void OnAfterUIElementLoad()
		{
			base.OnAfterUIElementLoad();

			UISettings.SizeToContent = true;
			UISettings.AllowResize = false;
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
			height = 100;
			mode = UIShellLengthModes.WeightedProportion;
		}

		protected override void GetRowCellSettings(uint row, uint cell, out double width, out UIShellLengthModes mode, out TabHostComponent component)
		{
			width = 100;
			mode = UIShellLengthModes.WeightedProportion;
			component = UITabHostTestController.GetUIComponent() as TabHostComponent;
		}

        #endregion

        #region Start Methods

        protected override void StartController()
		{			
			UITabHostTestController.Start();
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

		private void _uiTabHostTestController_Finished(object sender, CLFinishedEventArgs<UITabHostTestController.Output> e)
		{			
			FinishController(new Output());
		}

		#endregion
	}
}