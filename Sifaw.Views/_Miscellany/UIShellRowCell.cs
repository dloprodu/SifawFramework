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
	/// Almacena el ancho, modo de ajuste y el contenido de una celda de un 
	/// <see cref="ShellComponent"/> o <see cref="ShellView"/>.
	/// </summary>
	public struct UIShellRowCell
	{
		public readonly double Width;
		public readonly UILengthModes Mode;
		public readonly UIComponent Content;

		public UIShellRowCell(double width, UILengthModes mode, UIComponent content)
		{
			Width = width;
			Mode = mode;
			Content = content;
		}
	}
}