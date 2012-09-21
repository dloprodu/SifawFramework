/*
 * Sifaw.WPF.Converters
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 05/03/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Media;

using Sifaw.Views.Kit;

using Sifaw.WPF.CCL;


namespace Sifaw.WPF.Converters
{
    public class UIBoolToSearchMode : IValueConverter
	{
		#region IValueConverter Members

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
            SearchTextField.SearchMode mode = SearchTextField.SearchMode.Delayed;

            if (value != null)
                mode = ((bool)value) ? SearchTextField.SearchMode.Instant : SearchTextField.SearchMode.Delayed;

            return mode;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
            bool instant = false;

            if (value != null)
                instant = ((SearchTextField.SearchMode)value == SearchTextField.SearchMode.Instant);

            return instant;
		}

		#endregion
	}
}