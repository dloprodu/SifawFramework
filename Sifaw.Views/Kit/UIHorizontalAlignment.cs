/*
 * Sifaw.Views.Components
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 02/03/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sifaw.Views.Kit
{
	/// <summary>
	/// Describe cómo se coloca o ajusta un elemento secundario horizontalmente dentro de un elemento primario.
	/// </summary>
	public enum UIHorizontalAlignment
	{
		/// <summary>
		/// El elemento se alinea en la parte izquierda del elemento padre.
		/// </summary>
		Left,

		/// <summary>
		/// El elemento se alinea en la parte central del elemento padre.
		/// </summary>
		Center,

		/// <summary>
		/// El elemento se alinea en la parte derecha del elemento padre.
		/// </summary>
		Right,

		/// <summary>
		/// El elemento se ajusta para rellenar el elemento padre.
		/// </summary>
		Fill
	}
}