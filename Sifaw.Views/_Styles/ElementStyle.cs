/*
 * Sifaw.Views.Kit
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 01/03/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Views.Kit;


namespace Sifaw.Views
{
	/// <summary>
	/// Provee un conjunto de propiedades que permiten modificar la apariencia
	/// de un elemento de interfaz de usuario.
	/// </summary>
	[Serializable]
	public class ElementStyle
	{
		#region Fields

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
		/// Obtiene o establece el pincel que describe el fondo del elemento.
		/// </summary>
		public UIBrush Background
		{
			get { return _background; }
			set { _background = value; }
		}

		/// <summary>
		/// Obtiene o establece el pincel que describe el color de primer plano del elemento.
		/// </summary>
		public UIBrush Foreground
		{
			get { return _foreground; }
			set { _foreground = value; }
		}

		/// <summary>
		/// Obtiene o establece el margen exterior del elemento.
		/// </summary>
		public UIFrame Margin
		{
			get { return _margin; }
			set { _margin = value; }
		}

		/// <summary>
		/// Obtiene o establece el relleno interior del elemento.
		/// </summary>
		public UIFrame Padding
		{
			get { return _padding; }
			set { _padding = value; }
		}

		/// <summary>
		/// Obtiene o establece el tamaño mínimo del elemento.
		/// </summary>
		public UISize MinSize
		{
			get { return _minSize; }
			set { _minSize = value; }
		}

		/// <summary>
		/// Obtiene o establece el tamaño máximo del elemento.
		/// </summary>
		public UISize MaxSize
		{
			get { return _maxSize; }
			set { _maxSize = value; }
		}

		/// <summary>
		/// Obtiene o establece el ancho del elemento. El valor por defecto es -1, lo que sifnifica
		/// que se mantiene el ancho por defecto de la representación concreta del elemento.
		/// </summary>
		public double Width
		{
			get { return _width; }
			set { _width = value; }
		}

		/// <summary>
		/// Obtiene o establece el modo de ajustar horizontalmente el elemento. El valor por defecto es 
		/// <see cref="UILengthModes.WeightedProportion"/>, lo que significa que intentará ocupar
		/// el ancho disponible del elemento primario;
		/// </summary>
		public UILengthModes WidthMode
		{
			get { return _widthMode; }
			set { _widthMode = value; }
		}

		/// <summary>
		/// Obtiene o establece el alto del elemento. El valor por defecto es -1, lo que sifnifica
		/// que se mantiene el alto por defecto de la representación concreta del elemento.
		/// </summary>
		public double Height
		{
			get { return _height; }
			set { _height = value; }
		}

		/// <summary>
		/// Obtiene o establece el modo de ajustar verticalmente el elemento. El valor por defecto es 
		/// <see cref="UILengthModes.WeightedProportion"/>, lo que significa que intentará ocupar
		/// el alto disponible del elemento primario;
		/// </summary>
		public UILengthModes HeightMode
		{
			get { return _heightMode; }
			set { _heightMode = value; }
		}

		#endregion

		#region Constructor

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="ElementStyle"/>.
		/// </summary>
		public ElementStyle()
		{
		}

		#endregion
	}
}