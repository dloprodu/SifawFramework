/*
 * Sifaw.WPF
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 04/03/2012: Creación de la clase.
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

using Sifaw.Views.Kit;

using Sifaw.WPF.Filters;
using Sifaw.WPF.CCL;
using Sifaw.WPF.Converters;


namespace Sifaw.WPF
{
	/// <summary>
	/// Provee de métodos para la administración de ajustes de componentes.
	/// </summary>
	public static class SettingsOperationsManager
	{
		#region Converteres

        private static UIImageToImageSource _uiImageToImageSource = null;
        public static UIImageToImageSource UIImageToImageSource 
        {
            get
            {
                if (_uiImageToImageSource == null)
                    _uiImageToImageSource = new UIImageToImageSource();

                return _uiImageToImageSource;
            }
        }

		private static UIBrushToBrush _uiBrushToBrush = null;
		public static UIBrushToBrush UIBrushToBrush
		{
			get
			{
				if (_uiBrushToBrush == null)
					_uiBrushToBrush = new UIBrushToBrush();

				return _uiBrushToBrush;
			}
		}

		private static UIFrameToThickness _uiFrameToThickness = null;
		public static UIFrameToThickness UIFrameToThickness
		{
			get
			{
				if (_uiFrameToThickness == null)
					_uiFrameToThickness = new UIFrameToThickness();

				return _uiFrameToThickness;
			}
		}

		private static UIColorToColor _uiColorToColor = null;
		public static UIColorToColor UIColorToColor
		{
			get
			{
				if (_uiColorToColor == null)
					_uiColorToColor = new UIColorToColor();

				return _uiColorToColor;
			}
		}

		private static UIPointToPont _uiPointToPoint = null;
		public static UIPointToPont UIPointToPont
		{
			get
			{
				if (_uiPointToPoint == null)
					_uiPointToPoint = new UIPointToPont();

				return _uiPointToPoint;
			}
		}

		private static UIHAlignToHAlign _uiHAlignToHAlign = null;
		public static UIHAlignToHAlign UIHAlignToHAlign
		{
			get
			{
				if (_uiHAlignToHAlign == null)
					_uiHAlignToHAlign = new UIHAlignToHAlign();

				return _uiHAlignToHAlign;
			}
		}

		private static UIVAlignToVAlign _uiVAlignToVAlign = null;
		public static UIVAlignToVAlign UIVAlignToVAlign
		{
			get
			{
				if (_uiVAlignToVAlign == null)
					_uiVAlignToVAlign = new UIVAlignToVAlign();

				return _uiVAlignToVAlign;
			}
		}

		private static UIFrameBrushToBorderBrush _uiFrameBrushToBorderBrush = null;
		public static UIFrameBrushToBorderBrush UIFrameBrushToBorderBrush
		{
			get
			{
				if (_uiFrameBrushToBorderBrush == null)
					_uiFrameBrushToBorderBrush = new UIFrameBrushToBorderBrush();

				return _uiFrameBrushToBorderBrush;
			}
		}

		private static UIAutoSizeToSizeToContent _uiAutoSizeToSizeToContent = null;
		public static UIAutoSizeToSizeToContent UIAutoSizeToSizeToContent
		{
			get
			{
				if (_uiAutoSizeToSizeToContent == null)
					_uiAutoSizeToSizeToContent = new UIAutoSizeToSizeToContent();

				return _uiAutoSizeToSizeToContent;
			}
		}

		private static UIAllowResizeToResizeMode _uiAllowResizeToResizeMode = null;
		public static UIAllowResizeToResizeMode UIAllowResizeToResizeMode
		{
			get
			{
				if (_uiAllowResizeToResizeMode == null)
					_uiAllowResizeToResizeMode = new UIAllowResizeToResizeMode();

				return _uiAllowResizeToResizeMode;
			}
		}

        private static UIBoolToSearchMode _uiBoolToSearchMode = null;
        public static UIBoolToSearchMode UIBoolToSearchMode
        {
            get
            {
                if (_uiBoolToSearchMode == null)
                    _uiBoolToSearchMode = new UIBoolToSearchMode();

                return _uiBoolToSearchMode;
            }
        }

		#endregion
    }
}