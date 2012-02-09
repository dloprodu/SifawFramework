///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Librería de estructuras y clases miscelaneas de Sifaw.View.
/// 
/// Diseñador:     David López Rguez
/// Programadores: David López Rguez
///	
/// </summary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 09/01/2012 -- Creación de la clase.
/// ===============================================================================================
/// Observaciones:
/// 
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sifaw.Views
{
	/// <summary>
	/// Almacena la altura, modo de ajuste y celdas de una fila de una vista <see cref="ShellView"/>.
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