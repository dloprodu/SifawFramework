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

using Sifaw.Views.Kit;


namespace Sifaw.Views
{
	/// <summary>
	/// Almacena el ancho, modo de ajuste y el contenido de una celda de un 
	/// <see cref="ShellComponent"/> o <see cref="ShellView"/>.
	/// </summary>
	public struct UIShellRowCell
	{
		/// <summary>
		/// Devuelve el ancho de la celda de la shell.
		/// </summary>
		public readonly double Width;

		/// <summary>
		/// Devuelve el modo de ajuste de la celda de la shell.
		/// </summary>
		public readonly UIShellLengthModes Mode;

		/// <summary>
		/// Devuelve el contenido de la celda de la shell.
		/// </summary>
		public readonly UIComponent Content;

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIShellRowCell"/>, estableciendo un valor para los campos
		/// <see cref="Width"/>, <see cref="Mode"/> y <see cref="Content"/>.
		/// </summary>
		public UIShellRowCell(double width, UIShellLengthModes mode, UIComponent content)
		{
			Width = width;
			Mode = mode;
			Content = content;
		}
	}
}