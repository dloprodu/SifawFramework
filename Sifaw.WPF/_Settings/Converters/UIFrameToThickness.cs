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
	public class UIFrameToThickness : IValueConverter
	{
		#region IValueConverter Members

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
				return new Thickness(((UIFrame)value).Left, ((UIFrame)value).Top, ((UIFrame)value).Right, ((UIFrame)value).Bottom);

			return new Thickness(0);
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
				return new UIFrame(((Thickness)value).Left, ((Thickness)value).Top, ((Thickness)value).Right, ((Thickness)value).Bottom);

			return new UIFrame(0);
		}

		#endregion
	}
}