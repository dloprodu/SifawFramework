///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Interfaz base con los métodos generales para una vista tipo Shell.
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
	/// <para>
	/// Representa un vista tipo shell, con layout configurable, que
	/// permite alojar elementos <see cref="UIComponent"/>.
	/// </para>
	/// </summary>
	public interface UIShellView : UIView
	{
		#region Métodos

		/// <summary>
		/// Permite establecer la configuración y contenido 
		/// de la shell.
		/// </summary>
		/// <param name="rows">Array de filas de la Shell.</param>
		void SetSettings(UIShellRow[] rows);

		#endregion
	}

	#region Misc

	/// <summary>
	/// Modos de ajuste de un elemento del grid de la <see cref="UIShellView"/>.
	/// </summary>
	public enum UIShellGridLengthModes
	{
		/// <summary>
		/// Indica que el elemento del grid ha de ajustarse a la longitud indicada en pixels.
		/// </summary>
		Pixel,

		/// <summary>
		/// Indica que el elemento del grid ha de ajustarse a su contenido.
		/// </summary>
		Auto,

		/// <summary>
		/// Indica que el elemento del grid ha de ajustarse como proporción ponderada de espacio disponible.
		/// </summary>
		WeightedProportion
	}

	/// <summary>
	/// Almacena la altura, modo de ajuste y celdas de una fila de una vista <see cref="UIShellView"/>.
	/// </summary>
	public struct UIShellRow
	{
		public readonly double Height;
		public readonly UIShellGridLengthModes Mode;
		public readonly UIShellRowCell[] Cells;

		public UIShellRow(double height, UIShellGridLengthModes mode, UIShellRowCell[] cells)
		{
			Height = height;
			Mode = mode;
			Cells = cells;
		}
	}

	/// <summary>
	/// Almacena el ancho, modo de ajuste y el contenido de una celda de una vista <see cref="UIShellView"/>.
	/// </summary>
	public struct UIShellRowCell
	{
		public readonly double Width;
		public readonly UIShellGridLengthModes Mode;
		public readonly UIComponent Content;

		public UIShellRowCell(double width, UIShellGridLengthModes mode, UIComponent content)
		{
			Width = width;
			Mode = mode;
			Content = content;
		}
	}

	#endregion
}