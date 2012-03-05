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
	public class UIVAlignToVAlign : IValueConverter
	{
		#region IValueConverter Members

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
				switch ((UIVerticalAlignment)value)
				{
					case UIVerticalAlignment.Top:
						return VerticalAlignment.Top;

					case UIVerticalAlignment.Bottom:
						return VerticalAlignment.Bottom;

					case UIVerticalAlignment.Center:
						return VerticalAlignment.Center;

					case UIVerticalAlignment.Stretch:
					case UIVerticalAlignment.Inherit:
						return VerticalAlignment.Stretch;
				}

			return VerticalAlignment.Stretch;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
				switch ((VerticalAlignment)value)
				{
					case VerticalAlignment.Top:
						return UIVerticalAlignment.Top;

					case VerticalAlignment.Bottom:
						return UIVerticalAlignment.Bottom;

					case VerticalAlignment.Center:
						return UIVerticalAlignment.Center;

					case VerticalAlignment.Stretch:
						return UIVerticalAlignment.Stretch;
				}

			return UIVerticalAlignment.Stretch;
		}

		#endregion
	}
}