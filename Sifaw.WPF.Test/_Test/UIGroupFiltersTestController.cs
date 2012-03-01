using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Controllers.Components;
using Sifaw.Controllers.Components.Filters;

using Sifaw.Views;
using Sifaw.Views.Components.Filters;
using Sifaw.Views.Components;


namespace Sifaw.WPF.Test
{
	public class UIGroupFiltersTestController : UIFiltersGroupController<UIGroupFiltersTestController.Filter>
	{
		#region Inclusions

		private UITextFilterController _textFilter = null;
		private UITextFilterController TextFilter
		{
			get
			{
				if (_textFilter == null)
				{
					_textFilter = new UITextFilterController();
				}

				return _textFilter;
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

		private UIBoolFilterController _boolFilter = null;
		private UIBoolFilterController BoolFilter
		{
			get
			{
				if (_boolFilter == null)
				{
					_boolFilter = new UIBoolFilterController();
				}

				return _boolFilter;
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

		private UIDropDownListFilterController _DropDownListFilter = null;
		private UIDropDownListFilterController DropDownListFilter
		{
			get
			{
				if (_DropDownListFilter == null)
				{
					_DropDownListFilter = new UIDropDownListFilterController();
				}

				return _DropDownListFilter;
			}
		}

		#endregion

		#region Filter

		[Serializable]
		public new class Filter : UIFiltersGroupController<Filter>.Filter
		{
			private readonly string TextFilter;
			private readonly bool BoolFilter;
			private readonly Filterable EnumFilter;
			private readonly IList<Filterable> ListFilter;
			private readonly Filterable DropDownFilter;

			public Filter(string textFilter, bool boolFilter, Filterable enumFilter, IList<Filterable> listFilter, Filterable dropDownFilter)
			{
				TextFilter = textFilter;
				BoolFilter = boolFilter;
				EnumFilter = enumFilter;
				ListFilter = listFilter;
				DropDownFilter = dropDownFilter;
			}
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

			static Filters()
			{
				Filter1 = new Filterable("Filtro 1");
				Filter2 = new Filterable("Filtro 2");
				Filter3 = new Filterable("Filtro 3");
				Filter4 = new Filterable("Filtro 4");
			}
		}

		#endregion

		#region Constructors

		public UIGroupFiltersTestController()
			: base()
		{
		}

		public UIGroupFiltersTestController(AbstractUILinker<ShellComponent> linker)
			: base(linker)
		{
		}

		#endregion

		#region Input / Output

		public override Input GetDefaultInput()
		{
			return new Input(new Filter(string.Empty, false, Filters.Filter1, new Filterable[] { Filters.Filter1 }, Filters.Filter1));
		}
				
		#endregion

		#region Filters Group Members

		protected override Filter GetFilter()
		{
			return new Filter(
				TextFilter.Filter,
				BoolFilter.Filter,
				EnumFilter.Filter as Filterable,
				ListFilter.Filter as List<Filterable>,
				DropDownListFilter.Filter as Filterable);
		}

		#endregion

		#region Shell Members

		protected override uint GetNumberOfRows()
		{
			return 5;
		}

		protected override uint GetNumberOfCellsAt(uint row)
		{
			return 1;
		}

		protected override void GetRowSettings(uint row, out double height, out UILengthModes mode)
		{
			// Todas las filas se ajustan al contenido.
			height = 0;
			mode = UILengthModes.Auto;
		}

		protected override void GetRowCellSettings(uint row, uint cell, out double width, out UILengthModes mode, out UIComponent guest)
		{
			// Todas las celdas se ajustan al ancho disponible.
			width = 100;
			mode = UILengthModes.WeightedProportion;

			switch (row)
			{
				case 0:
					guest = TextFilter.GetUIComponent();
					break;

				case 1:
					guest = EnumFilter.GetUIComponent();
					break;

				case 2:
					guest = ListFilter.GetUIComponent();
					break;

				case 3:
					guest = BoolFilter.GetUIComponent();
					break;

				case 4:
					guest = DropDownListFilter.GetUIComponent();
					break;

				default:
					throw new NotSupportedException(string.Format("No se ha espcificado componente para la fila {0}.", row));
			}
		}

		#endregion
				
		#region Start Members

		protected override void StartController()
		{
			TextFilter.UISettings.Margin = new UIFrame(3);
			TextFilter.UISettings.Placeholder = "Introduzca un texto...";
			TextFilter.Start(new UITextFilterController.Input("prueba"));

			BoolFilter.UISettings.Margin = new UIFrame(3);
			BoolFilter.UISettings.Text = "Mostrar algo al chequear ...";
			BoolFilter.Start(new UIBoolFilterController.Input(true));

			EnumFilter.UISettings.Margin = new UIFrame(3);
			EnumFilter.UISettings.Source = new Filterable[] { Filters.Filter1, Filters.Filter2, Filters.Filter3, Filters.Filter4 };
			EnumFilter.Start(new UIEnumFilterController.Input(Filters.Filter2));

			ListFilter.UISettings.Margin = new UIFrame(3);
			ListFilter.UISettings.Source = new Filterable[] { Filters.Filter1, Filters.Filter2, Filters.Filter3, Filters.Filter4 };
			ListFilter.Start(new UIListFilterController.Input(new Filterable[] { Filters.Filter1, Filters.Filter2 }));

			DropDownListFilter.UISettings.Margin = new UIFrame(3);
			DropDownListFilter.UISettings.Source = new Filterable[] { Filters.Filter1, Filters.Filter2, Filters.Filter3, Filters.Filter4 };
			DropDownListFilter.Start(new UIDropDownListFilterController.Input(Filters.Filter3));
		}

		protected override bool AllowReset()
		{
			return true;
		}

		protected override void ResetController()
		{
			TextFilter.Reset();
			EnumFilter.Reset();
			ListFilter.Reset();
			BoolFilter.Reset();
			DropDownListFilter.Reset();
		}

		#endregion
	}
}