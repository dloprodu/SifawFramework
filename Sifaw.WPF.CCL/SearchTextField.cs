///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// SearchTextField.cs
/// 
/// Diseñador: David López Rguez
/// Programador: David López Rguez
/// </sumary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 30/01/2012: Creación de controladora.
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
using System.ComponentModel;


namespace Sifaw.WPF.CCL
{
    /// <summary>
    /// Representa un control que puede ser usado para mostrar o editar texto sin formato
    /// con el que ejecutar filtros o búsquedas.
    /// </summary>
    [TemplatePart(Name = "PART_SearchButton", Type = typeof(Border))]
    [TemplatePart(Name = "PART_SearchIcon", Type = typeof(Image))]
    public class SearchTextField : TextField
    {
        #region Dependecy Properties

        public static DependencyProperty SearchModeProperty =
            DependencyProperty.Register(
                "SearchMode",
                typeof(SearchMode),
                typeof(SearchTextField),
                new PropertyMetadata(SearchMode.Instant));

        private static DependencyPropertyKey HasTextPropertyKey =
            DependencyProperty.RegisterReadOnly(
                "HasText",
                typeof(bool),
                typeof(SearchTextField),
                new PropertyMetadata());

        public static DependencyProperty HasTextProperty = HasTextPropertyKey.DependencyProperty;

        private static DependencyPropertyKey IsSearchButtonTouchedPropertyKey =
            DependencyProperty.RegisterReadOnly(
                "IsSearchButtonTouched",
                typeof(bool),
                typeof(SearchTextField),
                new PropertyMetadata());

        public static DependencyProperty IsSearchButtonTouchedProperty = IsSearchButtonTouchedPropertyKey.DependencyProperty;

        #endregion

        #region Propiedades

        /// <summary>
        /// Obtiene o establece un valor que indica el módo en el que se ejecutan las búsquedas.
        /// </summary>
        [Category("Common")]
        public SearchMode SearchMode
        {
            get { return (SearchMode)GetValue(SearchModeProperty); }
            set { SetValue(SearchModeProperty, value); }
        }

        /// <summary>
        /// Obtiene un valor que indica si el control tiene una cadena de búsqueda.
        /// </summary>
        public bool HasText
        {
            get { return (bool)GetValue(HasTextProperty); }
            private set { SetValue(HasTextPropertyKey, value); }
        }

        /// <summary>
        /// Obtiene un valor que indica si se ha hecho click sobre el
        /// botón de búsqueda / reseteo.
        /// </summary>
        public bool IsSearchButtonTouched
        {
            get { return (bool)GetValue(IsSearchButtonTouchedProperty); }
            private set { SetValue(IsSearchButtonTouchedPropertyKey, value); }
        }

        #endregion

        #region Eventos

        public static readonly RoutedEvent SearchEvent =
            EventManager.RegisterRoutedEvent(
                "Search",
                RoutingStrategy.Bubble,
                typeof(RoutedEventHandler),
                typeof(SearchTextField));

        public event RoutedEventHandler Search
        {
            add { AddHandler(SearchEvent, value); }
            remove { RemoveHandler(SearchEvent, value); }
        }

        #endregion

        #region Elements

        private Border searchButtonBorder = null;
        private Image searchIconImage = null;

        #endregion

        #region Constructores

        static SearchTextField()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchTextField), new FrameworkPropertyMetadata(typeof(SearchTextField)));
        }

        #endregion

        #region Override Methods

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            base.OnTextChanged(e);
            HasText = (!string.IsNullOrEmpty(Text)) && (Text.Length != 0);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (searchButtonBorder == null)
            {
                searchButtonBorder = Template.FindName("PART_SearchButton", this) as Border;

                if (searchButtonBorder != null)
                {
                    searchButtonBorder.MouseLeftButtonDown += new MouseButtonEventHandler(searchButtonBorder_MouseLeftButtonDown);
                    searchButtonBorder.MouseLeftButtonUp += new MouseButtonEventHandler(searchButtonBorder_MouseLeftButtonUp);
                    searchButtonBorder.MouseLeave += new MouseEventHandler(searchButtonBorder_MouseLeave);
                }
            }

            if (searchIconImage == null)
            {
                searchIconImage = Template.FindName("PART_SearchIcon", this) as Image;

                if (searchIconImage != null)
                {
                    /* Empty */
                }
            }
        }

        #endregion

        #region Gestión de eventos

        private void searchButtonBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            IsSearchButtonTouched = true;
        }

        private void searchButtonBorder_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            IsSearchButtonTouched = false;
        }

        private void searchButtonBorder_MouseLeave(object sender, MouseEventArgs e)
        {
            IsSearchButtonTouched = false;
        }

        #endregion
    }

    #region Estructuras auxiliares

    public enum SearchMode
    {
        Instant,
        Delayed,
    }

    #endregion
}