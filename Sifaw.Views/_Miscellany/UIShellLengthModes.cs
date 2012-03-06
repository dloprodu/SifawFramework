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


namespace Sifaw.Views.Kit
{
	/// <summary>
	/// Modos de ajuste de un elemento de interfaz de usuario en un elemento de tipo <c>Shell</c> .
	/// </summary>
	public enum UIShellLengthModes
	{
		/// <summary>
		/// Indica que el elemento ha de ajustarse a la longitud indicada en pixels.
		/// </summary>
		Pixel,

		/// <summary>
		/// Indica que el elemento ha de ajustarse a su contenido.
		/// </summary>
		Auto,

		/// <summary>
		/// Indica que el elemento ha de ajustarse como proporción ponderada de espacio disponible.
		/// </summary>
		WeightedProportion
	}
}