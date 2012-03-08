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
	public class UITableTestViewController : UIShellViewController
		< UITableTestViewController.Input
		, UITableTestViewController.Output
		, TableComponent>
	{
		#region Input / Output

		/// <summary>
		/// Parámetros de entrada de las controladora.
		/// </summary>
		[Serializable]
		public new class Input : UIShellViewController<Input, Output, TableComponent>.Input
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
		public new class Output : UIShellViewController<Input, Output, TableComponent>.Output
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

		private UITableTestController _uiTableTestController = null;
		private UITableTestController UITableTestController
		{
			get
			{
				if (_uiTableTestController == null)
				{
					_uiTableTestController = new UITableTestController();
					_uiTableTestController.Finished += new CLFinishedEventHandler<Test.UITableTestController.Output>(_uiTableTestController_Finished);
				}

				return _uiTableTestController;
			}
		}

		#endregion

		#region Constructors

		public UITableTestViewController()
			: base()
		{
		}

		public UITableTestViewController(AbstractUILinker<ShellView> linker)
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

			UISettings.SizeToContent = false;
			UISettings.AllowResize = true;
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

		protected override void GetRowCellSettings(uint row, uint cell, out double width, out UIShellLengthModes mode, out TableComponent component)
		{
			width = 100;
			mode = UIShellLengthModes.WeightedProportion;
			component = UITableTestController.GetUIComponent() as TableComponent;
		}

        #endregion

        #region Start Methods

        protected override void StartController()
		{			
			UITableTestController.Start();
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

		private void _uiTableTestController_Finished(object sender, CLFinishedEventArgs<UITableTestController.Output> e)
		{			
			FinishController(new Output());
		}

		#endregion
	}
}