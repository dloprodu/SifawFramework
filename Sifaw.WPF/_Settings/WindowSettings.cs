/*
 * Sifaw.WPF
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 03/03/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

using Sifaw.Views;
using Sifaw.Views.Kit;

using Sifaw.WPF.CCL;


namespace Sifaw.WPF
{
	[Serializable]
    public class WindowSettings : WPFSettings, ViewSettings
    {
		#region Fields

        private UIImage _thumbnail = null;
		private string _header = string.Empty;
		private bool _alloResize = true;

		#endregion

		#region Properties
        
        /// <summary>
        /// Obtiene o establece el icono de la ventana.
        /// </summary>
        public virtual UIImage Thumbnail
        {
            get { return _thumbnail; }
            set
            {
                if (_thumbnail != value)
                {
                    _thumbnail = value;
                    OnPropertyChanged(() => Thumbnail);
                }
            }
        }

		/// <summary>
		/// Obtiene o establece la cabecera de la vista.
		/// </summary>
        public virtual string Header
		{
			get { return _header; }
			set
			{
				if (_header != value)
				{
					_header = value;
					OnPropertyChanged(() => Header);
				}
			}
		}

		/// <summary>
		/// Obtiene o establece un valor que indica si se permite redimensionar la vista.
		/// </summary>
        public virtual bool AllowResize
		{
			get { return _alloResize; }
			set
			{
				if (_alloResize != value)
				{
					_alloResize = value;
					OnPropertyChanged(() => AllowResize);
				}
			}
		}

		#endregion

        #region Constructor

        public WindowSettings(Window window)
        {
            try
            {
                window.Style = (Style)window.FindResource(window.GetType());
            }
            catch { /* No se encontró el estilo. */ }

			/* Initial values */
			this.Margin = (UIFrame)SettingsOperationsManager.UIFrameToThickness.ConvertBack(window.Margin, null, null, null);
			this.Padding = (UIFrame)SettingsOperationsManager.UIFrameToThickness.ConvertBack(window.Padding, null, null, null);
			this.Background = (UIBrush)SettingsOperationsManager.UIBrushToBrush.ConvertBack(window.Background, null, null, null);
			this.Foreground = (UIBrush)SettingsOperationsManager.UIBrushToBrush.ConvertBack(window.Foreground, null, null, null);
            
            // UISettings ...
            UtilWPF.BindField(this, "Background",    window, Window.BackgroundProperty,    BindingMode.TwoWay, SettingsOperationsManager.UIBrushToBrush);
            UtilWPF.BindField(this, "Foreground",    window, Window.ForegroundProperty,    BindingMode.TwoWay, SettingsOperationsManager.UIBrushToBrush);
            UtilWPF.BindField(this, "Margin",        window, Window.MarginProperty,        BindingMode.TwoWay, SettingsOperationsManager.UIFrameToThickness);
            UtilWPF.BindField(this, "Padding",       window, Window.PaddingProperty,       BindingMode.TwoWay, SettingsOperationsManager.UIFrameToThickness);
            UtilWPF.BindField(this, "Height",        window, Window.HeightProperty,        BindingMode.TwoWay);
            UtilWPF.BindField(this, "Width",         window, Window.WidthProperty,         BindingMode.TwoWay);
            UtilWPF.BindField(this, "MinWidth",      window, Window.MinWidthProperty,      BindingMode.TwoWay);
            UtilWPF.BindField(this, "MaxWidth",      window, Window.MaxWidthProperty,      BindingMode.TwoWay);
            UtilWPF.BindField(this, "MinHeight",     window, Window.MinHeightProperty,     BindingMode.TwoWay);
            UtilWPF.BindField(this, "MaxHeight",     window, Window.MaxHeightProperty,     BindingMode.TwoWay);
            UtilWPF.BindField(this, "SizeToContent", window, Window.SizeToContentProperty, BindingMode.TwoWay, SettingsOperationsManager.UIAutoSizeToSizeToContent);

            // ViewSettings ...
            UtilWPF.BindField(this, "Thumbnail",     window, Window.IconProperty,          BindingMode.TwoWay, SettingsOperationsManager.UIImageToImageSource);
            UtilWPF.BindField(this, "Header",        window, Window.TitleProperty,         BindingMode.TwoWay);
			UtilWPF.BindField(this, "AllowResize",   window, Window.ResizeModeProperty,    BindingMode.TwoWay, SettingsOperationsManager.UIAllowResizeToResizeMode);
		}

        #endregion
    }
}