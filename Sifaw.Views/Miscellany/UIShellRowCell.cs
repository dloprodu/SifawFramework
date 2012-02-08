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
	/// Almacena el ancho, modo de ajuste y el contenido de una celda de una vista <see cref="UIShellView"/>.
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