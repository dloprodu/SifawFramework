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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sifaw.Views.Components
{
	[Serializable]
	public class UITable
	{
		#region Fields

        private UITableCellCollection _header;
        private UITableRowCollection _rows;
        private UITableCellCollection _footer;

		#endregion

        #region Properties

        public UITableCellCollection Header
        {
            get
            {
                if (_header == null)
                    _header = new UITableCellCollection();

                return _header;
            }
        }

        public UITableRowCollection Rows
        {
            get
            {
                if (_rows == null)
                    _rows = new UITableRowCollection();

                return _rows;
            }
        }

        public UITableCellCollection Footer
        {
            get
            {
                if (_footer == null)
                    _footer = new UITableCellCollection();

                return _footer;
            }
        }

        #endregion

        #region Constructros

        public UITable()
		{
		}

		#endregion

		#region Miscellany

		public class UITableRowCollection : CollectionBase
		{
		}

		#endregion
	}
}
