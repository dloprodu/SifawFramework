/*
 * Sifaw.Views.Components
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 08/03/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sifaw.Views.Components
{
	/// <summary>
	/// Almacena la información necesaria para identificar una fila de un objeto <see cref="UITable"/>.
	/// </summary>
	public struct UIIndexRowPath : IEquatable<UIIndexRowPath>
	{
		/// <summary>
		/// Obtiene una estructura <see cref="UIIndexRowPath"/> con valores vacíos.
		/// </summary>
		public readonly static UIIndexRowPath Empty;

		/// <summary>
		/// Obtiene el nombre de la tabla.
		/// </summary>
		public readonly string Table;

		/// <summary>
		/// Obtiene el índice de la sección.
		/// </summary>
		public readonly int Section;

		/// <summary>
		/// Obtiene el índice de la fila.
		/// </summary>
		public readonly int Row;

		#region Constructor

		static UIIndexRowPath()
		{
			Empty = new UIIndexRowPath(string.Empty, -1, -1);
		}

		/// <summary>
		/// Inicializa una nueva instancia de la estructura <see cref="UIIndexRowPath"/>.
		/// </summary>
		/// <param name="table">Nombre de la tabla.</param>
		/// <param name="section">Índice de la sección.</param>
		/// <param name="row">Índice de la fila.</param>
		public UIIndexRowPath(string table, int section, int row)
		{
			Table = table;
			Section = section;
			Row = row;
		}

		#endregion

		#region Override Methods

		/// <summary>
		/// Devuelve la representación de cadena de un objeto <see cref="UIIndexRowPath"/>.
		/// </summary>
		public override string ToString()
		{
			return string.Format("T:{0}; S:{1}; R:{2}", Table, Section, Row );
		}

		/// <summary>
		/// Determina si un objeto <see cref="UIIndexRowPath"/> proporcionado es equivalente al objeto <see cref="UIIndexRowPath"/> actual.
		/// </summary>
		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			if (!(obj is UIIndexRowPath))
				return false;

			return Table.Equals(((UIIndexRowPath)obj).Table)
				&& Section.Equals(((UIIndexRowPath)obj).Section)
				&& Row.Equals(((UIIndexRowPath)obj).Row);
		}

		/// <summary>
		/// Obtiene un código hash de este objeto <see cref="UIIndexRowPath"/>.
		/// </summary>
		public override int GetHashCode()
		{
			return Table.GetHashCode() ^ Section.GetHashCode() ^ Row.GetHashCode();
		}

		/// <summary>
		/// Determina si un objeto <see cref="UIIndexRowPath"/> proporcionado es equivalente al objeto <see cref="UIIndexRowPath"/> actual.
		/// </summary>
		public bool Equals(UIIndexRowPath other)
		{
			return Table.Equals(other.Table)
				&& Section.Equals(other.Section)
				&& Row.Equals(other.Row);
		}

		#endregion

		#region Operator Overloading

		/// <summary>
		/// Comprueba si dos estructuras <see cref="UIIndexRowPath"/> no son idénticas.
		/// </summary>
		/// <param name="color1"> Primera estructura <see cref="UIIndexRowPath"/> que se va a comparar.</param>
		/// <param name="color2"> Segunda estructura <see cref="UIIndexRowPath"/> que se va a comparar.</param>
		/// <returns> Es true si color1 y color2 no son iguales; en caso contrario, es false.</returns>
		public static bool operator !=(UIIndexRowPath color1, UIIndexRowPath color2)
		{
			return color1.Table != color2.Table
				|| color1.Section != color2.Section
				|| color1.Row != color2.Row;
		}

		/// <summary>
		///  Comprueba si dos estructuras <see cref="UIIndexRowPath"/> son idénticas.
		/// </summary>
		/// <param name="color1"> Primera estructura <see cref="UIIndexRowPath"/> que se va a comparar.</param>
		/// <param name="color2"> Segunda estructura <see cref="UIIndexRowPath"/> que se va a comparar.</param>
		/// <returns>
		/// Es true si color1 y color2 son totalmente idénticos; en caso contrario, es
		/// false.
		/// </returns>
		public static bool operator ==(UIIndexRowPath color1, UIIndexRowPath color2)
		{
			return color1.Table == color2.Table
				&& color1.Section == color2.Section
				&& color1.Row == color2.Row;
		}

		#endregion
	}
}
