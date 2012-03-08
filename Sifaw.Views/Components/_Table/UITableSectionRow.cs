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
using System.Collections;


namespace Sifaw.Views.Components
{
	/// <summary>
	/// Representa una fila de un objeto <see cref="UITableSection"/>.
	/// </summary>
	/// <remarks>
	/// Una fila viene definida por una colección de celdas.
	/// </remarks>
	[Serializable]
	public class UITableSectionRow : UITableRow
	{
		#region Fileds

		private UITable _childTable = null;

		#endregion

		#region Properties

		/// <summary>
		/// Obtiene la tabla secundaria asociada a la fila.
		/// </summary>
		public UITable ChildTable
		{
			get { return _childTable; }
		}

		#endregion

		#region Constructor

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UITableSectionRow"/>, estableciendo un valor
		/// en la propiedad <see cref="UITableRow.Name"/>.
		/// </summary>
		/// <param name="name">Nombre de la fila.</param>
		public UITableSectionRow(string name)
			: base(name)
		{
		}

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UITableSectionRow"/>, estableciendo valores
		/// en las propiedades <see cref="UITableRow.Name"/> y <see cref="UITableRow.Cells"/>.
		/// </summary>
		/// <param name="name">Nombre de la fila.</param>
		/// <param name="cells">Configuración de celdas de la fila.</param>
		public UITableSectionRow(string name, UITableCell[] cells)
			: base(name, cells)
		{
		}

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UITableSectionRow"/>, estableciendo valores
		/// en las propiedades <see cref="UITableRow.Name"/>, <see cref="UITableRow.Cells"/> y <see cref="ChildTable"/>.
		/// </summary>
		/// <param name="name">Nombre de la fila.</param>
		/// <param name="cells">Configuración de celdas de la fila.</param>
		/// <param name="child">Tabla hija asociada a la fila.</param>
		public UITableSectionRow(string name, UITableCell[] cells, UITable child)
			: base(name, cells)
		{
			this._childTable = child;
		}

		#endregion
	}
}