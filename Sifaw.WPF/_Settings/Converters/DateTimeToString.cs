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
                return ((DateTime)value).ToString("dd/MM/yyyy");

            return string.Empty;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
            if (value == null)
                return null;

            if (string.IsNullOrEmpty((string)value))
                return null;

            DateTime date;

            if (DateTime.TryParse((string)value, out date))
            {
                if ((date != DateTime.MinValue) && (date != DateTime.MaxValue))
                    return date;
            }

            return null;
		}

		#endregion
	}
}