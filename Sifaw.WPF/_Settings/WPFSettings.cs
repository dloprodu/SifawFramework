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

using Sifaw.Core;
using Sifaw.Views;
using Sifaw.Views.Kit;


namespace Sifaw.WPF
{
	[Serializable]
    public abstract class WPFSettings : ObservableBase, UISettings
    {
		#region Fields

        private string _denomination = string.Empty;
        private string _description = string.Empty;
        private UIFont _font = UIFonts.Sans_Serif.Verdana;
        private UIBrush _background = null;
		private UIBrush _foreground = new UISolidBrush(UIColors.GrayColors.Black);
		private UIFrame _margin = UIFrame.Empty;
		private UIFrame _padding = UIFrame.Empty;
		// Double.NaN means in this case the same like Auto in XAML
		private double _width = 300;
		private double _height = 300;
		private UISize _minSize = UISize.Empty;
        private UISize _maxSize = UISize.Infinity;
        private bool _sizeToContent = false;

		#endregion

		#region Propiedades

        /// <summary>
        /// Obtiene o establece una denominación al elemento.
        /// </summary>
        public virtual string Denomination
        {
            get { return _denomination; }
            set 
            {
                if (_denomination != value)
                {
                    _denomination = value;
                    OnPropertyChanged(() => Denomination);
                }
            } 
        }

        /// <summary>
        /// Obtiene o establece una descripción al elemento.
        /// </summary>
        public virtual string Description
        {
            get { return _description; }
            set
            {
                if (_description != value)
                {
                    _description = value;
                    OnPropertyChanged(() => Description);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece la fuente.
        /// </summary>
        public virtual UIFont Font
        {
            get { return _font; }
            set
            {
                if (_font != value)
                {
                    _font = value;
                    OnPropertyChanged(() => FontFamily);
                    OnPropertyChanged(() => FontSize);
                    OnPropertyChanged(() => FontStyle);
                    OnPropertyChanged(() => FontWeight);
                }
            }
        }

		/// <summary>
		/// Obtiene o establece el pincel que describe el fondo del elemento.
		/// </summary>
        public virtual UIBrush Background
		{
			get { return _background; }
			set
            {
                if (_background != value)
                {
                    _background = value;
                    OnPropertyChanged(() => Background);
                }
            }
		}

		/// <summary>
		/// Obtiene o establece el pincel que describe el color de primer plano del elemento.
		/// </summary>
        public virtual UIBrush Foreground
		{
			get { return _foreground; }
			set 
            {
                if (_foreground != value)
                {
                    _foreground = value;
                    OnPropertyChanged(() => Foreground);
                }
            }
		}

		/// <summary>
		/// Obtiene o establece el margen exterior del elemento.
		/// </summary>
        public virtual UIFrame Margin
		{
			get { return _margin; }
			set 
            {
                if (_margin != value)
                {
                    _margin = value;
					OnPropertyChanged(() => Margin);
                }
            }
		}

		/// <summary>
		/// Obtiene o establece el relleno interior del elemento.
		/// </summary>
        public virtual UIFrame Padding
		{
			get { return _padding; }
			set
            {
                if (_padding != value)
                {
                    _padding = value;
                    OnPropertyChanged(() => Padding);
                }
            }
		}

		/// <summary>
		/// Obtiene o establece el tamaño mínimo del elemento.
		/// </summary>
        public virtual UISize MinSize
		{
			get { return _minSize; }
			set
            {
                if (_minSize != value)
                {
                    _minSize = value;
                    OnPropertyChanged(() => MinHeight);
                    OnPropertyChanged(() => MinWidth);
                }
            }
		}

		/// <summary>
		/// Obtiene o establece el tamaño máximo del elemento.
		/// </summary>
        public virtual UISize MaxSize
		{
			get { return _maxSize; }
			set 
            {
                if (_maxSize != value)
                {
                    _maxSize = value;
                    OnPropertyChanged(() => MaxHeight);
                    OnPropertyChanged(() => MaxWidth);
                }
            }
		}

		/// <summary>
		/// Obtiene o establece el ancho del elemento. El valor por defecto es -1, lo que sifnifica
		/// que se mantiene el ancho por defecto de la representación concreta del elemento.
		/// </summary>
        public virtual double Width
		{
			get { return _width; }
			set
            {
                if (_width != value)
                {
                    _width = value;
                    OnPropertyChanged(() => Width);
                }
            }
		}

		/// <summary>
		/// Obtiene o establece el alto del elemento. El valor por defecto es -1, lo que sifnifica
		/// que se mantiene el alto por defecto de la representación concreta del elemento.
		/// </summary>
        public virtual double Height
		{
			get { return _height; }
			set
            {
                if (_height != value)
                {
                    _height = value;
                    OnPropertyChanged(() => Height);
                }
            }
		}
        
        /// <summary>
        /// Obtiene o establece un valor que indica si el elemento se ha de ajustar a su contenido.
        /// </summary>
        public virtual bool SizeToContent
        {
            get { return _sizeToContent; }
            set
            {
                if (_sizeToContent != value)
                {
                    _sizeToContent = value;
                    OnPropertyChanged(() => SizeToContent);
                }
            }
        }

		#endregion

        #region WPF Properties MinWidth, MaxWidth, MinHeight, MaxHeight

        /// <summary>
        /// Obtiene o establece el ancho mínimo.
        /// </summary>
        public double MinWidth
        {
            get { return MinSize.Width; }
            set
            {
                if (MinSize.Width != value)
                {
                    MinSize = new UISize(value, MinSize.Height);
                    OnPropertyChanged(() => MinWidth);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece el ancho máximo.
        /// </summary>
        public double MaxWidth
        {
            get { return MaxSize.Width; }
            set
            {
                if (MaxSize.Width != value)
                {
                    MaxSize = new UISize(value, MaxSize.Height);
                    OnPropertyChanged(() => MaxWidth);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece el alto mínimo.
        /// </summary>
        public double MinHeight
        {
            get { return MinSize.Height; }
            set
            {
                if (MinSize.Height != value)
                {
                    MinSize = new UISize(MinSize.Width, value);
                    OnPropertyChanged(() => MinHeight);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece el alto máximo.
        /// </summary>
        public double MaxHeight
        {
            get { return MaxSize.Height; }
            set
            {
                if (MaxSize.Height != value)
                {
                    MaxSize = new UISize(MaxSize.Width, value);
                    OnPropertyChanged(() => MaxHeight);
                }
            }
        }

        #endregion

        #region WPF Font

        /// <summary>
        /// Obtiene o establece el tipo de letra.
        /// </summary>
        public string FontFamily
        {
            get { return Font.Name; }
            set
            {
                if (Font.Name != value)
                {
                    Font = new UIFont(value, FontSize, FontStyle, FontWeight);
                    OnPropertyChanged(() => FontFamily);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece el tamaño de la letra.
        /// </summary>
        public double FontSize
        {
            get { return Font.Size; }
            set
            {
                if (Font.Size != value)
                {
                    Font = new UIFont(FontFamily, value, FontStyle, FontWeight);
                    OnPropertyChanged(() => FontSize);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece el estilo de la letra.
        /// </summary>
        public UIFontStyles FontStyle
        {
            get { return Font.Style; }
            set
            {
                if (Font.Style != value)
                {
                    Font = new UIFont(FontFamily, FontSize, value, FontWeight);
                    OnPropertyChanged(() => FontStyle);
                }
            }
        }

        /// <summary>
        /// Obtiene o establece el grosor de la letra.
        /// </summary>
        public UIFontWeights FontWeight
        {
            get { return Font.Weight; }
            set
            {
                if (Font.Weight != value)
                {
                    Font = new UIFont(FontFamily, FontSize, FontStyle, value);
                    OnPropertyChanged(() => FontWeight);
                }
            }
        }

        #endregion

        #region Constructor

        protected WPFSettings()
		{            
        }

        #endregion
    }
}