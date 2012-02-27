using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Controllers;
using Sifaw.Controllers.Components;

using Sifaw.Views;
using Sifaw.Views.Components;


namespace Sifaw.WPF.Test
{
	public class UITabHostTestController : UITabHostController
		< UITabHostTestController.Input
		, UITabHostTestController.Output
		, UITabHostTestController.UISettingsContainer
		, UIComponent >
	{
		#region Input / Output

		[Serializable]
		public new class Input : UITabHostController
			< Input
			, Output
			, UISettingsContainer
			, UIComponent>.Input
		{
			#region Constructor

			public Input()
			{
			}

			#endregion
		}

		[Serializable]
		public new class Output : UITabHostController
			< Input
			, Output
			, UISettingsContainer
			, UIComponent>.Output
		{
			#region Constructor

			public Output()
			{
			}

			#endregion
		}

		#endregion

		#region Settings

		[Serializable]
		public new class UISettingsContainer : UITabHostController
			< Input
			, Output
			, UISettingsContainer
			, UIComponent>.UISettingsContainer
		{
			#region Constructors

			public UISettingsContainer()
				: base()
			{
			}

			#endregion
		}

		#endregion

		#region Constructors

		protected UITabHostTestController()
			: base()
		{
		}

		protected UITabHostTestController(AbstractUILinker<TabHostComponent> linker)
			: base(linker)
		{
		}

		#endregion

		#region UITabHost Methods

		protected override string[] GetGuestsDescriptors()
		{
			return new string[] 
			{
				"Component 1",
				"Component 2",
				"Component 3"
			};
		}

		protected override UIComponent GetGuestAt(int key, UIComponent current)
		{
			return null;
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
			/* Empty */
		}

		protected override void ResetController()
		{
			/* Empty */
		}

		#endregion
	}
}
