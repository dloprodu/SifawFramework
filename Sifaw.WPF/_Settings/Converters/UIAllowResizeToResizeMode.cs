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
using System.Windows;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Media;

using Sifaw.Views.Kit;


namespace Sifaw.WPF.Converters
{
	public class UIAllowResizeToResizeMode : IValueConverter
	{
		#region IValueConverter Members

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
				return ((bool)value) ? ResizeMode.CanResize : ResizeMode.NoResize;

			return ResizeMode.CanResize;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
				switch ((ResizeMode)value)
				{
					case ResizeMode.NoResize:
						return false;

					default:
						return true;
				}

			return true;
		}

		#endregion
	}
}