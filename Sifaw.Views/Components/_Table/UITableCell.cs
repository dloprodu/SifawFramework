/*
 * Sifaw.Views.Components
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 29/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Core;
using Sifaw.Views.Kit;


namespace Sifaw.Views.Components
{
	/// <summary>
	/// Representa una celda de un objeto <see cref="UITableRow"/>.
	/// </summary>
	[Serializable]
	public abstract class UITableCell : IEquatable<UITableCell>
	{
		#region Fields

		private string _name;
		private int _rowSpan;
		private int _columnSpan;
		private UISettings _settings;

		#endregion

		#region Properties

		/// <summary>
		/// Obtiene el nombre de la celda.
		/// </summary>
		public string Name
		{
			get { return _name; }
		}

		/// <summary>
		/// Obtiene un valor que indica el número de filas que ocupará la celda. 
		/// Por defecto ocupa una sola fila.
		/// </summary>
		public int RowSpan
		{
			get { return _rowSpan; }
		}

		/// <summary>
		/// Obtiene un valor que indica el número de columnas que ocupará la celda.
		/// Por defecto ocupa una sola columna.
		/// </summary>
		public int ColumnSpan
		{
			get { return _columnSpan; }
		}

		/// <summary>
		/// Obtiene o establece los ajustes de la celda.
		/// </summary>
		public UISettings Settings
		{
			get { return _settings; }			
		}

		#endregion

		#region Constructor

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UITableCell"/>.
		/// </summary>
		/// <param name="name">Nombre de la celda.</param>
		protected UITableCell(string name)
			: this(name, UISettings.Default)
		{
		}

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UITableCell"/>.
		/// </summary>
		/// <param name="name">Nombre de la celda.</param>
		/// <param name="settings">Estilo visual de la celda.</param>
		/// <param name="rowSpan">Número de filas que ocupa la celda.</param>
		/// <param name="colSpan">Número de columnas que ocupa la celda.</param>
		protected UITableCell(string name, UISettings settings, int rowSpan = 1, int colSpan = 1)
		{
			this._name = name;
			this._settings = settings;
			this._rowSpan = rowSpan;
			this._columnSpan = colSpan;
		}

		#endregion

		#region Override Methods

		/// <summary>
		/// Devuelve la representación de cadena de un objeto <see cref="UITableCell"/>.
		/// </summary>
		public override string ToString()
		{
			return Name;
		}

		/// <summary>
		/// Determina si un objeto <see cref="UITableCell"/> proporcionado es equivalente al objeto <see cref="UITableCell"/> actual.
		/// </summary>
		public override bool Equals(object obj)
		{
			return ReferenceEquals(this, obj);
		}

		/// <summary>
		/// Obtiene un código hash de este objeto <see cref="UITableCell"/>.
		/// </summary>
		public override int GetHashCode()
		{
			return Name.GetHashCode();
		}

		#endregion

		#region IEquatable<UITableRow> Members

		/// <summary>
		/// Determina si un objeto <see cref="UITableCell"/> proporcionado es equivalente al objeto <see cref="UITableCell"/> actual.
		/// </summary>
		public bool Equals(UITableCell other)
		{
			return ReferenceEquals(this, other);
		}

		#endregion

		#region Miscellany

		/// <summary>
		/// Provee un conjunto de propiedades que permiten modificar la apariencia
		/// de un componente de interfaz de usuario.
		/// </summary>
		public struct UISettings
		{
			/// <summary>
			/// Obtiene un <see cref="UISettings"/> con unos valores por defecto.
			/// </summary>
			public static readonly UISettings Default;

			#region Fields

			/// <summary>
			/// Obtiene o establece el pincel que describe el fondo del elemento.
			/// </summary>
			public UIBrush Background;

			/// <summary>
			/// Obtiene o establece el pincel que describe el color de primer plano del elemento.
			/// </summary>
			public UIBrush Foreground;

			/// <summary>
			/// Obtiene o establece el grosor del borde del componente.
			/// </summary>
			public UIFrame Border;

			/// <summary>
			/// Obtiene o establece un pincel que describe el fondo del borde del componente.
			/// </summary>
			public UIFrameBrush BorderBrush;

			/// <summary>
			/// Obtiene o establece la alineación horizontal que se aplican a este elemento
			/// cuando se aloja dentro de un elemento primario.
			/// </summary>
			public UIHorizontalAlignment HorizontalAlignment;

			/// <summary>
			/// Obtiene o establece la alineación vertical que se aplican a este elemento
			/// cuando se aloja dentro de un elemento primario.
			/// </summary>
			public UIVerticalAlignment VerticalAlignment;

			/// <summary>
			/// Obtiene o establece el ancho de la celda.
			/// </summary>
			public double Width;

			/// <summary>
			/// Obtiene o establece el modo en el que se ajusta la celda.
			/// </summary>
			public UITableCellLengthModes WidthMode;

			#endregion

			#region Constructor

			static UISettings()
			{
				Default = new UISettings(
					  background: new UISolidBrush(UIColors.WhiteColors.White)
					, foreground: new UISolidBrush(UIColors.GrayColors.Black)
					, border: new UIFrame(1, 0, 1, 0)
					, borderBrush: new UIFrameBrush(new UISolidBrush(UIColors.WhiteColors.GhostWhite))
					, horizontalAlignment: UIHorizontalAlignment.Left
					, verticalAlignment:  UIVerticalAlignment.Center
					, width: 50
					, widthMode: UITableCellLengthModes.Pixel);
			}

			/// <summary>
			/// Inicializa una nueva instancia de la estructura <see cref="UISettings"/>.
			/// </summary>
			public UISettings(double width, UITableCellLengthModes widthMode) 
				: this(
				  background: Default.Background
				, foreground: Default.Foreground
				, border: Default.Border
				, borderBrush: Default.BorderBrush
				, horizontalAlignment: Default.HorizontalAlignment
				, verticalAlignment: Default.VerticalAlignment
				, width:width
				, widthMode:widthMode)
			{			
			}

			/// <summary>
			/// Inicializa una nueva instancia de la estructura <see cref="UISettings"/>.
			/// </summary>
			public UISettings(
				  UIBrush background
				, UIBrush foreground
				, UIFrame border
				, UIFrameBrush borderBrush
				, UIHorizontalAlignment horizontalAlignment
				, UIVerticalAlignment verticalAlignment
				, double width
				, UITableCellLengthModes widthMode)
			{
				Background = new UISolidBrush(UIColors.WhiteColors.White);
				Foreground = new UISolidBrush(UIColors.GrayColors.Black);
				Border = new UIFrame(1);
				BorderBrush = new UIFrameBrush(new UISolidBrush(UIColors.WhiteColors.GhostWhite));
				HorizontalAlignment = UIHorizontalAlignment.Left;
				VerticalAlignment = UIVerticalAlignment.Center;
				Width = 50;
				WidthMode = UITableCellLengthModes.Pixel;
			}

			#endregion
		}

		#endregion
	}
}