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
		private UIBrush _background = new UISolidBrush(UIColors.WhiteColors.White);
		private UIBrush _foreground = new UISolidBrush(UIColors.GrayColors.Black);
		private UIFrame _margin = UIFrame.Empty;
		private UIFrame _padding = UIFrame.Empty;
		private double _width = -1;
		private double _height = -1;
		private UILengthModes _widthMode = UILengthModes.WeightedProportion;
		private UILengthModes _heightMode = UILengthModes.WeightedProportion;
		private UISize _minSize = UISize.Empty;
		private UISize _maxSize = UISize.Empty;

		#endregion

		#region Propiedades

        /// <summary>
        /// Obtiene o establece una denominación al elemento.
        /// </summary>
        public string Denomination
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
        public string Description
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
		/// Obtiene o establece el pincel que describe el fondo del elemento.
		/// </summary>
		public UIBrush Background
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
		public UIBrush Foreground
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
		public UIFrame Margin
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
		public UIFrame Padding
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
		public UISize MinSize
		{
			get { return _minSize; }
			set
            {
                if (_minSize != value)
                {
                    _minSize = value;
                    OnPropertyChanged(() => MinSize);
                }
            }
		}

		/// <summary>
		/// Obtiene o establece el tamaño máximo del elemento.
		/// </summary>
		public UISize MaxSize
		{
			get { return _maxSize; }
			set 
            {
                if (_maxSize != value)
                {
                    _maxSize = value;
                    OnPropertyChanged(() => MaxSize);
                }
            }
		}

		/// <summary>
		/// Obtiene o establece el ancho del elemento. El valor por defecto es -1, lo que sifnifica
		/// que se mantiene el ancho por defecto de la representación concreta del elemento.
		/// </summary>
		public double Width
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
		/// Obtiene o establece el modo de ajustar horizontalmente el elemento. El valor por defecto es 
		/// <see cref="UILengthModes.WeightedProportion"/>, lo que significa que intentará ocupar
		/// el ancho disponible del elemento primario;
		/// </summary>
		public UILengthModes WidthMode
		{
			get { return _widthMode; }
			set
            {
                if (_widthMode != value)
                {
                    _widthMode = value;
                    OnPropertyChanged(() => WidthMode);
                }
            }
		}

		/// <summary>
		/// Obtiene o establece el alto del elemento. El valor por defecto es -1, lo que sifnifica
		/// que se mantiene el alto por defecto de la representación concreta del elemento.
		/// </summary>
		public double Height
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
		/// Obtiene o establece el modo de ajustar verticalmente el elemento. El valor por defecto es 
		/// <see cref="UILengthModes.WeightedProportion"/>, lo que significa que intentará ocupar
		/// el alto disponible del elemento primario;
		/// </summary>
		public UILengthModes HeightMode
		{
			get { return _heightMode; }
			set 
            {
                if (_heightMode != value)
                {
                    _heightMode = value;
                    OnPropertyChanged(() => HeightMode);
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