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
	/// Excepción producida cuando una controladora de interfaz de usuario
    /// no obtiene una instancia válida del los ajustes del elemento de interfaz.
	/// </summary>
	public class UISettingsNullException : Exception
	{
		/// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UISettingsNullException"/>.
		/// </summary>
        public UISettingsNullException()
			: base("No se ha cargado una instancia válida de la configuración del elemento de interfaz de usuario.")
		{
		}
	}
}
