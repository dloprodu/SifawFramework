/*
 * Sifaw.WPF
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 09/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



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
using Sifaw.Views.Kit;


namespace Sifaw.WPF.Filters
{
	/// <summary>
	/// Representa un control que implementa el componente <see cref="ListFilterComponent"/>.
	/// </summary>
	public class ListFilterControl : ListBox, ListFilterComponent
	{
		#region Constructors

		static ListFilterControl()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(ListFilterControl), new FrameworkPropertyMetadata(typeof(ListFilterControl)));
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
		private IList<IFilterable> Former = new IFilterable[] { /* Empty */ };

		protected override void OnSelectionChanged(SelectionChangedEventArgs e)
		{
			base.OnSelectionChanged(e);

			if (!filtering)
			{
				BeginFilter();

				try
				{
					UIFilterChangedEventArgs args = new UIFilterChangedEventArgs();

					OnFilterChanged(args);

					if (args.Cancel)
						Filter = new List<IFilterable>(Former != null ? Former : new IFilterable[] {});
					else 
						Former = new List<IFilterable>(Filter != null ? Filter : new IFilterable[] {});
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

		#region ComponentListFilterBase<IList<IFilterable>,IList<IFilterable>> Members

		public void Add(IList<IFilterable> source)
		{
			this.SelectionMode = SelectionMode.Extended;
			this.ItemsSource = source;
			this.DisplayMemberPath = "DisplayFilter";
		}

		#endregion

		#region ComponentFilterBase<IList<IFilterable>> Members

		public IList<IFilterable> Filter
		{
			get	
			{
				List<IFilterable> filter = new List<IFilterable>();
				
				foreach (IFilterable item in SelectedItems)
					filter.Add(item);
				
				return filter; 
			}
			set	{ SetSelectedItems(value); }
		}

		public event UIFilterChangedEventHandler FilterChanged;
		private void OnFilterChanged(UIFilterChangedEventArgs e)
		{
			if (FilterChanged != null)
				FilterChanged(this as TextFilterComponent, e);
		}

		#endregion

		#region UIComponent Members

		public new UIFrame Margin
		{
			get { return new UIFrame(base.Margin.Left, base.Margin.Top, base.Margin.Right, base.Margin.Bottom); }
			set { base.Margin = new Thickness(value.Left, value.Top, value.Right, value.Bottom); }
		}

		#endregion

		#region UIElement Members

		#region Properties

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

		#region Methods

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