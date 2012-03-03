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
	/// Representa un control que implementa el componente <see cref="DropDownListFilterComponent"/>.
	/// </summary>
	public class DropDownListFilterControl : ComboBox, DropDownListFilterComponent
	{
		#region Constructors

		static DropDownListFilterControl()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(DropDownListFilterControl), new FrameworkPropertyMetadata(typeof(DropDownListFilterControl)));
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
		private IFilterable Former = null;

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
						Filter = Former;
					else
						Former = Filter;
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
			set { this.SelectedItem = value; }
		}

		public event UIFilterChangedEventHandler FilterChanged;
		private void OnFilterChanged(UIFilterChangedEventArgs e)
		{
			if (FilterChanged != null)
				FilterChanged(this as TextFilterComponent, e);
		}

		#endregion

		#region UIElement Members

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

        #region UISettings

        private ComponentSettings _uiSettings = null;
        public ComponentSettings UISettings
        {
            get
            {
                if (_uiSettings == null)
                    _uiSettings = new ControlSettings(this);

                return _uiSettings;
            }
        }

        UISettings Views.UIElement.UISettings
        {
            get { return UISettings; }
        }

        #endregion
    }
}
