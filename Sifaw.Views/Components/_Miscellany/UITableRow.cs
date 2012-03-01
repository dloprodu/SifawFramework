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
	public class UITableRow
	{
		#region Fileds

        private UITableCellCollection _cells = null;
		private UITable _childTable = null;

		#endregion

		#region Properties

        public UITableCellCollection Cells
        {
            get
            {
                if (_cells == null)
                    _cells = new UITableCellCollection();

                return _cells;
            }
        }

		/// <summary>
		/// Obtiene la tabla secundaria asociada a la fila.
		/// </summary>
		public UITable ChildTable
		{
			get { return _childTable; }
		}

		#endregion

		#region Constructor



		#endregion
	}
}
