/*
 * Sifaw.WPF.CCL
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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Sifaw.WPF.CCL
{
    /// <summary>
    /// Representa un control <see cref="Button"/> personalizable.
    /// </summary>
    public class CustomButton : Button
    {
        #region Dependecy Properties

        public static DependencyProperty BackgroundHoverProperty =
            DependencyProperty.Register(
                "BackgroundHover",
                typeof(Brush),
                typeof(CustomButton),
                new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        public static DependencyProperty BackgroundPressedProperty =
            DependencyProperty.Register(
                "BackgroundPressed",
                typeof(Brush),
                typeof(CustomButton),
                new PropertyMetadata(new SolidColorBrush(Colors.Transparent)));

        #endregion

        #region Properties

        /// <summary>
        /// Obtiene o estableceun el pincel que describe el fondo del control cuando el ratón esta sobre él.
        /// </summary>
        [Category("Brush")]
        public Brush BackgroundHover
        {
            get { return (Brush)GetValue(BackgroundHoverProperty); }
            set { SetValue(BackgroundHoverProperty, value); }
        }

        /// <summary>
        /// Obtiene o estableceun el pincel que describe el fondo del control cuando se hace click sobre él.
        /// </summary>
        [Category("Brush")]
        public Brush BackgroundPressed
        {
            get { return (Brush)GetValue(BackgroundPressedProperty); }
            set { SetValue(BackgroundPressedProperty, value); }
        }

        #endregion

        #region Constructor

        public CustomButton()
			: base()
		{
        }

        static CustomButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomButton), new FrameworkPropertyMetadata(typeof(CustomButton)));
        }

        #endregion
    }
}
