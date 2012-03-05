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
	public class UIHAlignToHAlign : IValueConverter
	{
		#region IValueConverter Members

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
				switch ((UIHorizontalAlignment)value)
				{
					case UIHorizontalAlignment.Left:
						return HorizontalAlignment.Left;

					case UIHorizontalAlignment.Right:
						return HorizontalAlignment.Right;

					case UIHorizontalAlignment.Center:
						return HorizontalAlignment.Center;

					case UIHorizontalAlignment.Stretch:
					case UIHorizontalAlignment.Inherit:
						return HorizontalAlignment.Stretch;
				}

			return HorizontalAlignment.Stretch;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			if (value != null)
				switch ((HorizontalAlignment)value)
				{
					case HorizontalAlignment.Left:
						return UIHorizontalAlignment.Left;

					case HorizontalAlignment.Right:
						return UIHorizontalAlignment.Right;

					case HorizontalAlignment.Center:
						return UIHorizontalAlignment.Center;

					case HorizontalAlignment.Stretch:
						return UIHorizontalAlignment.Stretch;
				}

			return UIHorizontalAlignment.Stretch;
		}

		#endregion
	}
}