/*
 * Sifaw.Controllers
 * 
 * Diseñador:   David López Rguez
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
	public class UILinkerNullException : Exception
	{
		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UILinkerNullException"/>.
		/// </summary>
		public UILinkerNullException()
            : base("No se ha establecido el UILinker que carga la instancia del elemento UI de la controladora.")
        {
		}
	}
}
