/*
 * Sifaw.WPF.Converters
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 05/10/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

using Sifaw.Views.Kit;


namespace Sifaw.WPF.Converters
{
    public class UIFontStyleToFontStyle : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            FontStyle style = FontStyles.Normal;

            if (value != null)
                switch ((UIFontStyles)value)
                {
                    case UIFontStyles.Normal:
                        style = FontStyles.Normal;
                        break;

                    case UIFontStyles.Italic:
                        style = FontStyles.Italic;
                        break;

                    case UIFontStyles.Oblique:
                        style = FontStyles.Oblique;
                        break;
                }

            return style;   
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            UIFontStyles style = UIFontStyles.Normal;

            if (value != null)
            {
                if (((FontStyle)value) == FontStyles.Normal)
                {
                    style = UIFontStyles.Normal;
                }
                else if (((FontStyle)value) == FontStyles.Italic)
                {
                    style = UIFontStyles.Italic;
                }
                else if (((FontStyle)value) == FontStyles.Oblique)
                {
                    style = UIFontStyles.Oblique;
                }
            }

            return style;
        }
    }
}