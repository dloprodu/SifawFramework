/* 
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 08/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sifaw.Controllers
{
	/// <summary>
	/// Excepción producida cuando una controladora de interfaz de usuario hace referencia
	/// a su vista y el ViewLinker no ha devuelto una instnacia válida de la misma.
	/// </summary>
	public class UIElementNullException : Exception
	{
		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIElementNullException"/>.
		/// </summary>
		public UIElementNullException()
			: base("El UILinker no ha devuelto una instancia válida para el elemento de la interfaz de usuario.")
		{
		}
	}
}
