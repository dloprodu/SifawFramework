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

		public UITableColumnCollection Header;
		public UITableRowCollection Rows;
		public UITableColumnCollection Footer;

		#endregion

		#region Constructros

		public UITable()
		{
			Header = new UITableColumnCollection();
			Rows = new UITableRowCollection();
			Footer = new UITableColumnCollection();
		}

		#endregion

		#region Miscellany

		public class UITableColumnCollection : CollectionBase
		{			
		}

		public class UITableRowCollection : CollectionBase
		{
		}

		#endregion
	}
}
