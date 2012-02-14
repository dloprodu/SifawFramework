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
		/// <summary>
		/// Devuelve el ancho de la fila de la shell.
		/// </summary>
		public readonly double Height;
		
		/// <summary>
		/// Devuelve el modo de ajuste de la fila de la shell.
		/// </summary>
		public readonly UILengthModes Mode;
		
		/// <summary>
		/// Devuelve las celdas de la fila de la shell.
		/// </summary>
		public readonly UIShellRowCell[] Cells;

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIShellRow"/>, estableciendo un valor para los campos
		/// <see cref="Height"/>, <see cref="Mode"/> y <see cref="Cells"/>.
		/// </summary>
		public UIShellRow(double height, UILengthModes mode, UIShellRowCell[] cells)
		{
			Height = height;
			Mode = mode;
			Cells = cells;
		}
	}
}