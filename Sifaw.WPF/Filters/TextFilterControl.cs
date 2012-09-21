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

using Sifaw.Views.Components;
using Sifaw.Views;
using Sifaw.Views.Components.Filters;
using Sifaw.Views.Kit;

using Sifaw.WPF.CCL;


namespace Sifaw.WPF.Filters
{
	/// <summary>
	/// Representa un control que implementa el componente <see cref="TextFilterComponent"/>.
	/// </summary>
	public class TextFilterControl : SearchTextField, TextFilterComponent
	{
		#region Constructors

		static TextFilterControl()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(TextFilterControl), new FrameworkPropertyMetadata(typeof(TextFilterControl)));
		}

		public TextFilterControl()
			: base()
		{
			this.Mode = SearchMode.Delayed;
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

		#region Overrides Methods

		/// <summary>
		/// Último filtro válido aplicado.
		/// </summary>
		private string Former = string.Empty;

		protected override void OnSearch(RoutedEventArgs e)
		{
			base.OnSearch(e);

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

		#region FilterComponent<string> Members

		public string Filter
		{
			get { return Text; }
			set { Text = value; }
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
			Text = string.Empty;
		}

		public void SetLikeActive()
		{
			Focus();
		}

		#endregion

        #region UISettings

        private TextFilterSettings _uiSettings = null;
        public TextFilterSettings UISettings
        {
            get
            {
                if (_uiSettings == null)
                    _uiSettings = new TextFilterControlSettings(this);

                return _uiSettings;
            }
        }

        ComponentSettings UIComponent.UISettings
        {
            get { return UISettings; }
        }

        UISettings Views.UIElement.UISettings
        {
            get { return UISettings; }
        }

        #endregion

        #region Miscellany

        [Serializable]
        public class TextFilterControlSettings : ControlSettings, TextFilterSettings
        {
            #region Fields

            private string _placeholder = string.Empty;
            private bool _instantSearch = false;

            #endregion

            #region Properties

            /// <summary>
            /// Obtiene o establece el placeholder, o texto de entrada, para el componente.
            /// </summary>
            public string Placeholder
            {
                get { return _placeholder; }
                set
                {
                    if (_placeholder != value)
                    {
                        _placeholder = value;
                        OnPropertyChanged(() => Placeholder);
                    }
                }
            }

            /// <summary>
            /// Obtiene o establece un valor que india el módo de búsqueda del componente.
            /// </summary>
            public bool InstantSearch
            {
                get { return _instantSearch; }
                set
                {
                    if (_instantSearch != value)
                    {
                        _instantSearch = value;
                        OnPropertyChanged(() => InstantSearch);
                    }
                }
            }

            #endregion

            #region Constructor

            public TextFilterControlSettings(TextFilterControl control)
                : base(control)
            {
                control.Mode = ((_instantSearch) ? SearchTextField.SearchMode.Instant : SearchMode.Delayed);

                UtilWPF.BindField(this, "Placeholder",   control, TextFilterControl.PlaceholderProperty, BindingMode.TwoWay);
                UtilWPF.BindField(this, "InstantSearch", control, TextFilterControl.ModeProperty,        BindingMode.TwoWay, SettingsOperationsManager.UIBoolToSearchMode);
            }

            #endregion
        }

        #endregion
    }
}