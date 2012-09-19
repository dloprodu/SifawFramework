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
using System.Windows.Media.Imaging;
using System.IO;

using Sifaw.Views.Kit;


namespace Sifaw.WPF.Converters
{
    public class UIImageToImageSource : IValueConverter
	{
		#region IValueConverter Members

		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
            BitmapImage image = null;
            
            if ((value != null) && ((value as UIImage).Bytes != null))
            {
                image = new BitmapImage();                
                image.BeginInit();
                //image.CacheOption = BitmapCacheOption.OnLoad;
                image.StreamSource = new MemoryStream((value as UIImage).Bytes);
                image.EndInit();
            }

            return image;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
            UIImage image = null;

            if (value != null)
            {
                BitmapImage iSource = value as BitmapImage;

                using (BinaryReader ms = new BinaryReader(iSource.StreamSource))
                {
                    image = new UIImage(ms.ReadBytes((Int32)iSource.StreamSource.Length));
                }
            }

            return image;
		}

		#endregion
	}
}