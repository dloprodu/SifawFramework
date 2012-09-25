using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Controllers;
using Sifaw.Controllers.Components;
using Sifaw.Controllers.Components.Filters;

using Sifaw.Views;
using Sifaw.Views.Components;
using Sifaw.Views.Kit;


namespace Sifaw.WPF.Test
{
	public class UITabHostTestController : UITabHostController
		< UITabHostTestController.Input
		, UITabHostTestController.Output
		, UIComponent >
	{
		#region Input / Output

		[Serializable]
		public new class Input : UITabHostController
			< Input
			, Output
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
			, UIComponent>.Output
		{
			#region Constructor

			public Output()
			{
			}

			#endregion
		}

		#endregion

		#region Filtrs

		[Serializable]
		public class Filterable : IFilterable
		{
			private string Value;

			#region Constructors

			public Filterable(string value)
			{
				Value = value;
			}

			#endregion

			#region IFilterable Members

			public string DisplayFilter
			{
				get { return Value; }
			}

			#endregion

			#region IComparable Members

			public int CompareTo(object obj)
			{
				return CompareTo(obj as IFilterable);
			}

			#endregion

			#region IComparable<IFilterable> Members

			public int CompareTo(IFilterable other)
			{
				return DisplayFilter.CompareTo(other.DisplayFilter);
			}

			#endregion

			#region IEquatable<IFilterable> Members

			public bool Equals(IFilterable other)
			{
				return DisplayFilter.Equals(other.DisplayFilter);
			}

			#endregion

			#region System Override

			public override bool Equals(object obj)
			{
				if (obj is Filterable)
					return Equals(obj as Filterable);
				else
					return false;
			}

			public override int GetHashCode()
			{
				return DisplayFilter.GetHashCode();
			}

			public override string ToString()
			{
				return DisplayFilter;
			}

			#endregion
		}

		public static class Filters
		{
			public static readonly Filterable Filter1;
			public static readonly Filterable Filter2;
			public static readonly Filterable Filter3;
			public static readonly Filterable Filter4;
			public static readonly Filterable Filter5;
			public static readonly Filterable Filter6;

			static Filters()
			{
				Filter1 = new Filterable("Filtro 1");
				Filter2 = new Filterable("Filtro 2");
				Filter3 = new Filterable("Filtro 3");
				Filter4 = new Filterable("Filtro 4");
				Filter5 = new Filterable("Filtro 5");
				Filter6 = new Filterable("Filtro 6");
			}
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

		private UIEnumFilterController _enumFilter = null;
		private UIEnumFilterController EnumFilter
		{
			get
			{
				if (_enumFilter == null)
				{
					_enumFilter = new UIEnumFilterController();
				}

				return _enumFilter;
			}
		}

		private UIListFilterController _listFilter = null;
		private UIListFilterController ListFilter
		{
			get
			{
				if (_listFilter == null)
				{
					_listFilter = new UIListFilterController();
				}

				return _listFilter;
			}
		}

		#endregion

		#region Constructors

		public UITabHostTestController()
			: base()
		{
		}

		public UITabHostTestController(UILinker<TabHostComponent> linker)
			: base(linker)
		{
		}

		#endregion

        #region UIElement Methods

        protected override void OnUIElementLoaded()
        {
            base.OnUIElementLoaded();

            EnumFilter.UISettings.Margin = new UIFrame(3);

            ListFilter.UISettings.Margin = new UIFrame(3);
        }

        #endregion

        #region UITabHost Methods

        protected override string[] GetDescriptors()
		{
			return new string[] 
			{
				"Component 1",
				"Component 2",
				"Component 3"
			};
		}

		protected override UIComponent GetGuestAt(int key)
		{
			switch (key)
			{
				case 0:
					return GroupFilterTest.GetUIComponent();

				case 1:
					return EnumFilter.GetUIComponent();

				case 2:
					return ListFilter.GetUIComponent();

				default:
					return null;
			}
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

			EnumFilter.Start(new UIEnumFilterController.Input(
                  new Filterable[] { Filters.Filter1, Filters.Filter2, Filters.Filter3, Filters.Filter4, Filters.Filter5, Filters.Filter6 }
                , Filters.Filter2));

			ListFilter.Start(new UIListFilterController.Input(
                  new Filterable[] { Filters.Filter1, Filters.Filter2, Filters.Filter3, Filters.Filter4, Filters.Filter5, Filters.Filter6 }
                , new Filterable[] { Filters.Filter1, Filters.Filter2 }));
		}

		protected override void ResetController()
		{
			/* Empty */
		}

		#endregion
	}
}
