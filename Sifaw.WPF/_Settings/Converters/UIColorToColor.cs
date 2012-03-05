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


namespace Sifaw.WPF.Converters
{
	public class UIColorToColor : IValueConverter
	{
		#region IValueConverter Members

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
				return Color.FromArgb(((UIColor)value).A, ((UIColor)value).R, ((UIColor)value).G, ((UIColor)value).B);

			return Colors.White;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
				return UIColor.FromArgb(((Color)value).A, ((Color)value).R, ((Color)value).G, ((Color)value).B);

			return UIColors.WhiteColors.White;
		}

		#endregion
	}
}