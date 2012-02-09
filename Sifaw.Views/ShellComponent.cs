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
///   - 09/02/2012 -- Creación de la clase.
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
	/// Representa un componente tipo shell, con layout configurable, que
	/// permite alojar elementos <see cref="UIComponent"/>.
	/// </para>
	/// </summary>
	public interface ShellComponent : UIComponent
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
}