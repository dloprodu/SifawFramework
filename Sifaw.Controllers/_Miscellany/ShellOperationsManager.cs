/*
 * Sifaw.Controllers
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 08/02/2012: Creación de la clase.
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


namespace Sifaw.Controllers
{
	/// <summary>
	/// Provee de métodos para la administración de un componente tipo Shell.
	/// </summary>
	internal static class ShellOperationsManager
	{
		/// <summary>
		/// Método que dado los correspondientes métodos callback devuelve la configuración
		/// ha aplicar a la shell por fila.
		/// </summary>
		/// <typeparam name="TGuest">Tipo de los componentes que puede alojar la shell.</typeparam>
		/// <param name="GetNumberOfRows">Callbak invocado cuando se solicita el número de filas.</param>
		/// <param name="GetNumberOfCellsAt">Callbak invocado cuando se solicita el número de celdas de una fila.</param>
		/// <param name="GetRowSettings">Callbak invocado cuando se solicita la configuración de una fila de la shell.</param>
		/// <param name="GetRowCellSettings">Callbak invocado cuando se solicita la configuración de una celda de la shell.</param>
		internal static UIShellRow[] BuildLayout<TGuest>(
			  GetNumberOfRowsShellCallback GetNumberOfRows
			, GetNumberOfCellsAtShellCallback GetNumberOfCellsAt
			, GetRowSettingsShellCallback GetRowSettings
			, GetRowCellSettingsShellCallback<TGuest> GetRowCellSettings)
			where TGuest : UIComponent
		{
			UIShellRow[] rows = new UIShellRow[Math.Max(1, GetNumberOfRows())];

			for (uint row = 0; row < rows.Length; row++)
			{
				double height = 0.0f;
				UIShellLengthModes heightMode = UIShellLengthModes.Auto;
				GetRowSettings(row, out height, out heightMode);

				UIShellRowCell[] columns = new UIShellRowCell[Math.Max(1, GetNumberOfCellsAt(row))];

				for (uint column = 0; column < columns.Length; column++)
				{
					double width = 0.0f;
					UIShellLengthModes widthMode = UIShellLengthModes.Auto;
					TGuest component = default(TGuest);

					GetRowCellSettings(row, column, out width, out widthMode, out component);

					columns[column] = new UIShellRowCell(width, widthMode, component);
				}

				rows[row] = new UIShellRow(height, heightMode, columns);
			}

			return rows;
		}
	}
}