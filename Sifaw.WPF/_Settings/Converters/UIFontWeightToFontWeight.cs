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
    public class UIFontWeightToFontWeight : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            FontWeight weight = FontWeights.Normal;

            if (value != null)
                switch ((UIFontWeights)value)
                {
                    case UIFontWeights.Normal:
                        weight = FontWeights.Normal;
                        break;

                    case UIFontWeights.Bold:
                        weight = FontWeights.Bold;
                        break;

                    case UIFontWeights.Thin:
                        weight = FontWeights.Thin;
                        break;
                }

            return weight;  
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            UIFontWeights weight = UIFontWeights.Normal;

            if (value != null)
            {
                if (((FontWeight)value) == FontWeights.Normal)
                {
                    weight = UIFontWeights.Normal;
                }
                else if (((FontWeight)value) == FontWeights.Bold)
                {
                    weight = UIFontWeights.Bold;
                }
                else if (((FontWeight)value) == FontWeights.Thin)
                {
                    weight = UIFontWeights.Thin;
                }
            }

            return weight;
        }
    }
}