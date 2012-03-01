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
			set { _rowSpan = value; }
		}

		/// <summary>
		/// Obtiene un valor que indica el número de columnas que ocupará la celda.
		/// Por defecto ocupa una sola columna.
		/// </summary>
		public int ColumnSpan
		{
			get { return _columnSpan; }
			set { _columnSpan = value; }
		}

		#endregion

		#region Constructor

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UITableCell"/>.
		/// </summary>
		/// <param name="name">Nombre de la celda.</param>
		protected UITableCell(string name)
		{
			this._name = name;
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
	}
}
