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

using Sifaw.Core;

using Sifaw.Views;
using Sifaw.Views.Kit;

using Sifaw.WPF.CCL;


namespace Sifaw.WPF
{
	[Serializable]
    public class ControlSettings : WPFSettings, ComponentSettings
    {
		#region Fields

		private UIFrame _border = new UIFrame(1);
		private UIFrameBrush _borderBrush = new UIFrameBrush(new UISolidBrush(UIColors.GrayColors.LightGray));
		private UIHorizontalAlignment _horizontalAlignment = UIHorizontalAlignment.Fill;
		private UIVerticalAlignment _verticalAlignment = UIVerticalAlignment.Fill;

		#endregion

		#region Properties

		/// <summary>
		/// Obtiene o establece el grosor del borde del componente.
		/// </summary>
		public UIFrame Border
		{
			get { return _border; }
			set
			{
				if (_border != value)
				{
					_border = value;
					OnPropertyChanged(() => Border);
				}
			}
		}

		/// <summary>
		/// Obtiene o establece un pincel que describe el fondo del borde del componente.
		/// </summary>
		public UIFrameBrush BorderBrush
		{
			get { return _borderBrush; }
			set
			{
				if (_borderBrush != value)
				{
					_borderBrush = value;
					OnPropertyChanged(() => BorderBrush);
				}
			}
		}

		/// <summary>
		/// Obtiene o establece la alineación horizontal que se aplican a este elemento
		/// cuando se aloja dentro de un elemento primario.
		/// </summary>
		public UIHorizontalAlignment HorizontalAlignment
		{
			get { return _horizontalAlignment; }
			set
			{
				if (_horizontalAlignment != value)
				{
					_horizontalAlignment = value;
					OnPropertyChanged(() => HorizontalAlignment);
				}
			}
		}

		/// <summary>
		/// Obtiene o establece la alineación vertical que se aplican a este elemento
		/// cuando se aloja dentro de un elemento primario.
		/// </summary>
		public UIVerticalAlignment VerticalAlignment
		{
			get { return _verticalAlignment; }
			set
			{
				if (_verticalAlignment != value)
				{
					_verticalAlignment = value;
					OnPropertyChanged(() => VerticalAlignment);
				}
			}
		}

		#endregion

		#region Constructor

		public ControlSettings(Control control)
        {
			UtilWPF.BindField(this, "Background",          control, Control.BackgroundProperty,          BindingMode.TwoWay, SettingsOperationsManager.UIBrushToBrush);
			UtilWPF.BindField(this, "Foreground",          control, Control.ForegroundProperty,          BindingMode.TwoWay, SettingsOperationsManager.UIBrushToBrush);
			UtilWPF.BindField(this, "BorderBrush",         control, Control.BorderBrushProperty,         BindingMode.TwoWay, SettingsOperationsManager.UIFrameBrushToBorderBrush);
			UtilWPF.BindField(this, "Margin",              control, Control.MarginProperty,              BindingMode.TwoWay, SettingsOperationsManager.UIFrameToThickness);
			UtilWPF.BindField(this, "Padding",             control, Control.PaddingProperty,             BindingMode.TwoWay, SettingsOperationsManager.UIFrameToThickness);
			UtilWPF.BindField(this, "Border",              control, Control.BorderThicknessProperty,     BindingMode.TwoWay, SettingsOperationsManager.UIFrameToThickness);
			UtilWPF.BindField(this, "Height",              control, Control.HeightProperty,              BindingMode.TwoWay);
			UtilWPF.BindField(this, "Width",               control, Control.WidthProperty,               BindingMode.TwoWay);
			UtilWPF.BindField(this, "HorizontalAlignment", control, Control.HorizontalAlignmentProperty, BindingMode.TwoWay, SettingsOperationsManager.UIHAlignToHAlign);
			UtilWPF.BindField(this, "VerticalAlignment",   control, Control.VerticalAlignmentProperty,   BindingMode.TwoWay, SettingsOperationsManager.UIVAlignToVAlign);
            UtilWPF.BindField(this, "MinWidth",            control, Control.MinWidthProperty,            BindingMode.TwoWay);
            UtilWPF.BindField(this, "MaxWidth",            control, Control.MaxWidthProperty,            BindingMode.TwoWay);
            UtilWPF.BindField(this, "MinHeight",           control, Control.MinHeightProperty,           BindingMode.TwoWay);
            UtilWPF.BindField(this, "MaxHeight",           control, Control.MaxHeightProperty,           BindingMode.TwoWay);			
		}

        #endregion
    }
}