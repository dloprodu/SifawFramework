///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// DropDownFilter.cs
/// 
/// Diseñador: David López Rguez
/// Programador: David López Rguez
/// </sumary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 06/02/2012: Creación de controladora.
/// 
/// ===============================================================================================
/// Observaciones:
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Sifaw.Views;
using Sifaw.Views.Components;
using Sifaw.Views.Components.Filters;


namespace Sifaw.WPF
{
	/// <summary>
	/// Representa un control que implementa el componente <see cref="DropDownListComponentFilter"/>.
	/// </summary>
	public class DropDownListFilter : ComboBox, DropDownListComponentFilter
	{
		#region Constructor

		static DropDownListFilter()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(DropDownListFilter), new FrameworkPropertyMetadata(typeof(DropDownListFilter)));
		}

		#endregion

		#region Helpers

		/// <summary>
		/// Flag que indica si se está aplicando un filtro.
		/// </summary>
		private bool filtering = false;

		private void BeginFilter()
		{
			filtering = true;
		}

		private void EndFilter()
		{
			filtering = false;
		}

		#endregion
		
		#region Override Methods

		/// <summary>
		/// Último filtro válido aplicado.
		/// </summary>
		private IFilterable LastFilter = null;

		protected override void OnSelectionChanged(SelectionChangedEventArgs e)
		{
			base.OnSelectionChanged(e);

			if (!filtering)
			{
				BeginFilter();

				try
				{
					UIFilterChangedEventArgs<IFilterable> args = new UIFilterChangedEventArgs<IFilterable>(LastFilter, Filter);

					OnFilterChanged(args);

					if (args.Cancel)
						Filter = LastFilter;
					else
						LastFilter = Filter;
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					EndFilter();
				}
			}
		}

		#endregion

		#region ComponentListFilterBase<IFilterable,IList<IFilterable>> Members

		public void Add(IList<IFilterable> source)
		{
			this.ItemsSource = source;
			this.DisplayMemberPath = "DisplayFilter";
		}

		#endregion

		#region ComponentFilterBase<IFilterable> Members

		public IFilterable Filter
		{
			get { return SelectedItem as IFilterable; }
			set	{ SelectedItem = value;	}
		}

		public event UIFilterChangedEventHandler<IFilterable> FilterChanged;
		private void OnFilterChanged(UIFilterChangedEventArgs<IFilterable> e)
		{
			if (FilterChanged != null)
				FilterChanged(this as ListComponentFilter, e);
		}

		#endregion

		#region UIElement Members

		#region Propiedades

		private string _denomination = string.Empty;
		public string Denomination
		{
			get { return _denomination; }
			set { _denomination = value; }
		}

		private string _description = string.Empty;
		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}

		#endregion

		#region Métodos

		public void Refresh()
		{
			/* Emtpy */
		}

		public void Reset()
		{
			ItemsSource = null;
		}

		public void SetLikeActive()
		{
			Focus();
		}

		#endregion

		#endregion
	}
}
