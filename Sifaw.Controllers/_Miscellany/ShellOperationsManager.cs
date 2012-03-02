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
	public static class ShellOperationsManager
	{
		/// <summary>
		/// Método que dado los correspondientes métodos callback devuelve la configuración
		/// ha aplicar a la shell por fila.
		/// </summary>
		/// <typeparam name="TGuest">Tipo de los componentes que puede alojar la shell.</typeparam>
		/// <param name="getNumberOfRows">Callbak invocado cuando se solicita el número de filas.</param>
		/// <param name="getNumberOfCellsAt">Callbak invocado cuando se solicita el número de celdas de una fila.</param>
		/// <param name="getRowSettings">Callbak invocado cuando se solicita la configuración de una fila de la shell.</param>
		/// <param name="getRowCellSettings">Callbak invocado cuando se solicita la configuración de una celda de la shell.</param>
		public static UIShellRow[] GetSettings<TGuest>(
			  GetNumberOfRowsShellCallback getNumberOfRows
			, GetNumberOfCellsAtShellCallback getNumberOfCellsAt
			, GetRowSettingsShellCallback getRowSettings
			, GetRowCellSettingsShellCallback<TGuest> getRowCellSettings)
			where TGuest : UIComponent
		{
			UIShellRow[] rows = new UIShellRow[Math.Max(1, getNumberOfRows())];

			for (uint row = 0; row < rows.Length; row++)
			{
				double height = 0.0f;
				UILengthModes heightMode = UILengthModes.Auto;
				getRowSettings(row, out height, out heightMode);

				UIShellRowCell[] columns = new UIShellRowCell[Math.Max(1, getNumberOfCellsAt(row))];

				for (uint column = 0; column < columns.Length; column++)
				{
					double width = 0.0f;
					UILengthModes widthMode = UILengthModes.Auto;
					TGuest component = default(TGuest);

					getRowCellSettings(row, column, out width, out widthMode, out component);

					columns[column] = new UIShellRowCell(width, widthMode, component);
				}

				rows[row] = new UIShellRow(height, heightMode, columns);
			}

			return rows;
		}
	}
}