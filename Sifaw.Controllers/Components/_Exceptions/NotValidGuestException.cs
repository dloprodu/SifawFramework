/*
 * Sifaw.Controllers.Components
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


namespace Sifaw.Controllers.Components
{
	/// <summary>
	/// Excepción producida al pasar como huésped una controladora no válida.
	/// </summary>
	public class NotValidGuestException : Exception
	{
		/// <summary>
        ///  Inicializa una nueva instancia de la clase <see cref="NotValidGuestException"/>.
		/// </summary>
        public NotValidGuestException()
            : base("El huésped no es una controladora válida.")
		{
		}
	}
}
