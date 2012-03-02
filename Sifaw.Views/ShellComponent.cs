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
	/// <para>
	/// Representa un componente tipo shell, con layout configurable, que
	/// permite alojar elementos <see cref="UIComponent"/>.
	/// </para>
	/// </summary>
	public interface ShellComponent : UIComponent<ComponentStyle>
	{
		#region Methods

		/// <summary>
		/// Permite establecer la configuración y contenido 
		/// de la shell.
		/// </summary>
		/// <param name="rows">Array de filas de la Shell.</param>
		void SetSettings(UIShellRow[] rows);

		#endregion
	}
}