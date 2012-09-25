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
	public class UIFrameBrushToBorderBrush : IValueConverter
	{
		#region IValueConverter Members

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			Brush brush = null;

			if (value != null)
			{
				brush = (Brush)SettingsOperationsManager.UIBrushToBrush.Convert(((UIFrameBrush)value).Left, null, null, null);
			}

			return brush;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			UIFrameBrush fbrush = null;

			if (value != null)
			{
                fbrush = new UIFrameBrush((UIBrush)SettingsOperationsManager.UIBrushToBrush.ConvertBack((Brush)value, null, null, null));
			}

            return fbrush;
		}

		#endregion
	}
}