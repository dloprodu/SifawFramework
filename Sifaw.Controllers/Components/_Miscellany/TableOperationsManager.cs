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
		/// <param name="GetNumberOfHeaderRows">Callbak invocado cuando se solicita el número de filas que componen la cabecera.</param>
		/// <param name="GetHeaderAt">Callbak invocado cuando se solicita la configuración de celdas que componen una fila de la cabecera.</param>
		/// <param name="GetNumberOfFooterRows">Callbak invocado cuando se solicita el número de filas que componene el pie de tabla.</param>
		/// <param name="GetFooterAt">Callbak invocado cuando se solicita la configuración de celdas que componen una fila del piel de tabla.</param>
		/// <param name="GetNumberOfSectionsAt">Callbak invocado cuando se solicita el número de secciones del cuerpo de la tabla.</param>
		/// <param name="GetNumberOfRowsAt">Callbak invocado cuando se solicita el número filas de una sección de la tabla.</param>
		/// <param name="GetCellsAt">Callbak invocado cuando se solicita la configuración de celdas de una fila de la tabla.</param>
		/// <param name="RowContainChildTable">Callbak invocado cuando se solicita un valor que indique si una fila contendrá una tabla hija asociada.</param>		
		/// <param name="GetChildTableNameAt">Callbak invocado cuando se solicita el nombre de la tabla hija asociada a una fila dada.</param>
		/// <param name="name">Nombre de la tabla.</param>		
		internal static UITable BuildTable(
			  GetNumberOfHeaderRows GetNumberOfHeaderRows
			, GetHeaderAt GetHeaderAt
			, GetNumberOfFooterRows GetNumberOfFooterRows
			, GetFooterAt GetFooterAt
			, GetNumberOfSectionsAt GetNumberOfSectionsAt
			, GetNumberOfRowsAt GetNumberOfRowsAt
			, GetCellsAt GetCellsAt
			, RowContainChildTable RowContainChildTable
			, GetChildTableNameAt GetChildTableNameAt
			, string name)
		{
			UITable table = new UITable(name);

			/* Header */
			for (int row = 0; row < GetNumberOfHeaderRows(name); row++)
				table.Header.Add(string.Format("T:{0}; H:{1}", name, row), GetHeaderAt(name, row));

			/* Body */
			UITableSection.UISettings settings;
			for (int section = 0; section < GetNumberOfSectionsAt(name, out settings); section++)
			{
				table.Body.Add(string.Format("T:{0}; S:{1}", name, section), settings);

				for (int row = 0; row < GetNumberOfRowsAt(name, section); row++)
				{
					UIIndexRowPath path = new UIIndexRowPath(name, section, row);

					table.Body[section].Rows.Add(
						  string.Format("T:{0}; S:{1}; R:{2}", name, section, row)
						, GetCellsAt(path)
						, !RowContainChildTable(path) ? null : BuildTable(
							  GetNumberOfHeaderRows
							, GetHeaderAt
							, GetNumberOfFooterRows
							, GetFooterAt
							, GetNumberOfSectionsAt
							, GetNumberOfRowsAt
							, GetCellsAt
							, RowContainChildTable
							, GetChildTableNameAt
							, GetChildTableNameAt(path)));
				}
			}

			/* Footer */
			for (int row = 0; row < GetNumberOfFooterRows(name); row++)
				table.Footer.Add(string.Format("T:{0}; F:{1}", name, row), GetFooterAt(name, row));

			return table;
		}
	}
}