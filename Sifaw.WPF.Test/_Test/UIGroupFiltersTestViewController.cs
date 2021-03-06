﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Controllers;

using Sifaw.Views;
using Sifaw.Views.Kit;


namespace Sifaw.WPF.Test
{
	public class UIGroupFiltersTestViewController : UIShellViewController
		< UIGroupFiltersTestViewController.Input
		, UIGroupFiltersTestViewController.Output
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

		private UIGroupFiltersTestController _groupFilterTest = null;
		private UIGroupFiltersTestController GroupFilterTest
		{
			get
			{
				if (_groupFilterTest == null)
				{
					_groupFilterTest = new UIGroupFiltersTestController();
				}

				return _groupFilterTest;
			}
		}

		#endregion

		#region Constructors

		public UIGroupFiltersTestViewController()
			: base()
		{
		}

		public UIGroupFiltersTestViewController(UILinker<ShellView> linker)
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
			height = 0;
			mode = UIShellLengthModes.Auto;
		}

		protected override void GetRowCellSettings(uint row, uint cell, out double width, out UIShellLengthModes mode, out ShellComponent guest)
		{
			width = 0;
			mode = UIShellLengthModes.Auto;
			guest = GroupFilterTest.GetUIComponent() as ShellComponent;
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

            UISettings.SizeToContent = true;
            UISettings.AllowResize = false;
            UISettings.Header = "Group Filter Test";
		}

		#endregion

		#region Start Methods

		protected override void StartController()
		{
			GroupFilterTest.Start();
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
			GroupFilterTest.Reset();
		}

		#endregion
	}
}