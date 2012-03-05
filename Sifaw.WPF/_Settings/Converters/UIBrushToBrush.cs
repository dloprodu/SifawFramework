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
	public class UIBrushToBrush : IValueConverter
	{
		#region IValueConverter Members

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			Brush brush = null;

			if (value != null)
			{
				if (value is UISolidBrush)
				{
					brush = new SolidColorBrush((Color)SettingsOperationsManager.UIColorToColor.Convert(((UISolidBrush)value).Color, null, null, null));
				}
				else if (value is UILinearGradientBrush)
				{
					GradientStopCollection gradientStops = new GradientStopCollection();

					foreach (UIGradientStop gStop in ((UILinearGradientBrush)value).GradientStops)
						gradientStops.Add(new GradientStop((Color)SettingsOperationsManager.UIColorToColor.Convert(gStop.Color, null, null, null), gStop.Offset));

					brush = new LinearGradientBrush(gradientStops, ((UILinearGradientBrush)value).Angle);
				}
				else
				{
					throw new ArgumentException("UIBrush no soportada.", "value");
				}
			}

			return brush;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			UIBrush brush = null;

			if (value != null)
			{
				if (value is SolidColorBrush)
				{
					brush = new UISolidBrush((UIColor)SettingsOperationsManager.UIColorToColor.ConvertBack(((SolidColorBrush)value).Color, null, null, null));
				}
				else if (value is LinearGradientBrush)
				{
					UIGradientStopCollection gradientStops = new UIGradientStopCollection();

					foreach (GradientStop gStop in ((LinearGradientBrush)value).GradientStops)
						gradientStops.Add(new UIGradientStop((UIColor)SettingsOperationsManager.UIColorToColor.ConvertBack(gStop.Color, null, null, null), gStop.Offset));

					brush = new UILinearGradientBrush();
					(brush as UILinearGradientBrush).GradientStops = gradientStops;
					// ATan2(dy , dx) where dy = y2 - y1 and dx = x2 - x1, or ATan(dy / dx) 
					(brush as UILinearGradientBrush).Angle = Math.Atan2(
						((LinearGradientBrush)value).EndPoint.Y - ((LinearGradientBrush)value).StartPoint.Y,
						((LinearGradientBrush)value).EndPoint.X - ((LinearGradientBrush)value).StartPoint.X);
				}
				else
				{
					// Este error no se comunica.
					// throw new ArgumentException("Brush no soportada.", "value");
				}
			}

			return brush;
		}

		#endregion
	}
}