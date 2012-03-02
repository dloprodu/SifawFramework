using System;
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
		, UIGroupFiltersTestViewController.UISettingsContainer
		, ShellComponent>
	{
		#region Input / Output

		/// <summary>
		/// Parámetros de entrada de las controladora.
		/// </summary>
		[Serializable]
		public new class Input : UIShellViewController<Input, Output, UISettingsContainer, ShellComponent>.Input
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
		public new class Output : UIShellViewController<Input, Output, UISettingsContainer, ShellComponent>.Output
		{
			#region Constructors

			public Output()
				: base()
			{
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
			, ShellComponent>.UISettingsContainer
		{
			#region Constructors

			public UISettingsContainer()
				: base()
			{
				this.SizeToContent = true;
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

		public UIGroupFiltersTestViewController(AbstractUILinker<ShellView> linker)
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

		protected override void GetRowSettings(uint row, out double height, out UILengthModes mode)
		{
			height = 0;
			mode = UILengthModes.Auto;
		}

		protected override void GetRowCellSettings(uint row, uint cell, out double width, out UILengthModes mode, out ShellComponent guest)
		{
			width = 0;
			mode = UILengthModes.Auto;
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