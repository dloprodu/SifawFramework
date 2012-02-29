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
	[Serializable]
	public abstract class UITableCell
	{
		#region Fields

		private int _rowSpan;
		private int _columnSpan;

		#endregion

		#region Properties

		/// <summary>
		/// Obtiene o valor que indica el número de filas que ocupará la celda. 
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

		#endregion
	}
}
