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

using Sifaw.Views;
using Sifaw.WPF.CCL;


namespace Sifaw.WPF
{
	[Serializable]
    public class WindowSettings : WPFSettings, ViewSettings
    {
		#region Fields

		private string _header = "SifaWake Application";

		#endregion

		#region Properties

		/// <summary>
		/// Obtiene o establece la cabecera de la vista.
		/// </summary>
		public string Header
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

		#endregion

        #region Constructor

        //public new bool SizeToContent
        //{
        //    get { return base.SizeToContent == System.Windows.SizeToContent.WidthAndHeight; }
        //    set
        //    {
        //        base.SizeToContent = value ? System.Windows.SizeToContent.WidthAndHeight : System.Windows.SizeToContent.Manual;
        //        base.ResizeMode = value ? System.Windows.ResizeMode.NoResize : System.Windows.ResizeMode.CanResize;
        //    }
        //}

        public WindowSettings(Window window)
        {            
			UtilWPF.BindField(this, "Background", window, Window.BackgroundProperty, BindingMode.TwoWay, SettingsOperationsManager.UIBrushToBrush);
			UtilWPF.BindField(this, "Foreground", window, Window.ForegroundProperty, BindingMode.TwoWay, SettingsOperationsManager.UIBrushToBrush);
			UtilWPF.BindField(this, "Margin",     window, Window.MarginProperty,     BindingMode.TwoWay, SettingsOperationsManager.UIFrameToThickness);
			UtilWPF.BindField(this, "Padding",    window, Window.PaddingProperty,    BindingMode.TwoWay, SettingsOperationsManager.UIFrameToThickness);
			UtilWPF.BindField(this, "Height",     window, Window.HeightProperty,     BindingMode.TwoWay);
			UtilWPF.BindField(this, "Width",      window, Window.WidthProperty,      BindingMode.TwoWay);
            UtilWPF.BindField(this, "MinWidth",   window, Window.MinWidthProperty,   BindingMode.TwoWay);
            UtilWPF.BindField(this, "MaxWidth",   window, Window.MaxWidthProperty,   BindingMode.TwoWay);
            UtilWPF.BindField(this, "MinHeight",  window, Window.MinHeightProperty,  BindingMode.TwoWay);
            UtilWPF.BindField(this, "MaxHeight",  window, Window.MaxHeightProperty,  BindingMode.TwoWay);
            UtilWPF.BindField(this, "Header",     window, Window.TitleProperty,      BindingMode.TwoWay);

            //settings.HeightMode ...
            //settings.WidthMode ...
        }

        #endregion
    }
}