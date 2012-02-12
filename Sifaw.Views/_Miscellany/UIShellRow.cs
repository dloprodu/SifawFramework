/*
 * Sifaw.Views
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 09/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sifaw.Views
{
	/// <summary>
	/// Almacena la altura, modo de ajuste y celdas de una fila de un 
	/// <see cref="ShellComponent"/> o <see cref="ShellView"/>.
	/// </summary>
	public struct UIShellRow
	{
		public readonly double Height;
		public readonly UILengthModes Mode;
		public readonly UIShellRowCell[] Cells;

		public UIShellRow(double height, UILengthModes mode, UIShellRowCell[] cells)
		{
			Height = height;
			Mode = mode;
			Cells = cells;
		}
	}
}