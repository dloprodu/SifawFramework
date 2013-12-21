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
using System.Windows;

using Sifaw.Views.Kit;


namespace Sifaw.WPF.Converters
{
    public class DateTimeToString : IValueConverter
	{
		#region IValueConverter Members

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
            if ((value != null) && (((DateTime)value) != DateTime.MinValue)  && (((DateTime)value) != DateTime.MaxValue)) 
                return ((DateTime)value).ToString(culture.DateTimeFormat.ShortDatePattern);

            return string.Empty;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
            DateTime date;

            if (DateTime.TryParse((string)value, culture.DateTimeFormat, DateTimeStyles.None, out date))
                return date;
            else
                return null;
		}

		#endregion
	}
}