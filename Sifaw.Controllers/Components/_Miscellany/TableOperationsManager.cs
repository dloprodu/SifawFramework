/*
 * Sifaw.Controllers.Components
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 07/03/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Views;
using Sifaw.Views.Kit;

using Sifaw.Views.Components;


namespace Sifaw.Controllers.Components
{
	/// <summary>
	/// Provee de métodos para la administración de componentes que representan graficamente objetos <see cref="UITable"/>.
	/// </summary>
	internal static class TableOperationsManager
	{
		/// <summary>
		/// Método que dado los correspondientes métodos callback construye un objeto <see cref="UITable"/>.
		/// </summary>
		internal static UITable BuildTable(
			  GetNumberOfHeaderRows GetNumberOfHeaderRows
			, GetHeaderAt GetHeaderAt
			, GetNumberOfFooterRows GetNumberOfFooterRows
			, GetFooterAt GetFooterAt
			, GetNumberOfSectionsAt GetNumberOfSectionsAt
			, GetNumberOfRowsAt GetNumberOfRowsAt
			, GetCellsAt GetCellsAt
			, RowContainChildTable RowContainChildTable
			, string name)
		{
			UITable table = new UITable(name);

			for (int row = 0; row < GetNumberOfHeaderRows(name); row++)
			{
				/* Header */
				UITableCell[] header = GetHeaderAt(name, row);
				for (int cell = 0; cell < header.Length; cell++)
				{
					// TODO: ...
				}
			}

			/* Body */
			UITableSection.UISettings settings;
			for (int section = 0; section < GetNumberOfSectionsAt(name, out settings); section++)
			{
				table.Body.Add(string.Format("{0}; S:{1}", name, section), settings);

				for (int row = 0; row < GetNumberOfRowsAt(name, section); row++)
				{
					table.Body[section].Rows.Add(string.Format("{0}; S:{1}; R:{2}", name, section, row));

					UITableCell[] cells = GetCellsAt(name, section, row);
					for (int cell = 0; cell < cells.Length; cell++)
					{
						table.Body[section].Rows[row].Cells.Add(cells[cell]);

						if (RowContainChildTable(name, section, row))
							table.Body[section].Rows[row].ChildTable = BuildTable(
								  GetNumberOfHeaderRows
								, GetHeaderAt
								, GetNumberOfFooterRows
								, GetFooterAt
								, GetNumberOfSectionsAt
								, GetNumberOfRowsAt
								, GetCellsAt
								, RowContainChildTable
								, string.Format("T[{0}; S:{1}; R:{2}]", name, section, row));
					}
				}
			}

			for (int row = 0; row < GetNumberOfFooterRows(name); row++)
			{
				/* Footer */
				UITableCell[] footer = GetFooterAt(name, row);
				for (int cell = 0; cell < footer.Length; cell++)
				{
					// TODO: ...
				}
			}

			return table;
		}
	}
}