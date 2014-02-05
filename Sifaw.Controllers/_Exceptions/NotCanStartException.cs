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
	/// Excepción producida por no cumplirse las condiciones necesarias para que se 
	/// inicie una controladora.
	/// </summary>
	public class NotCanStartException : Exception
	{
        /// <summary>
        /// Devuelve la lista de errores por los que no se puede iniciar la controladora.
        /// </summary>
        public readonly List<string> Errors;

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="NotCanStartException"/>.
		/// </summary>
		public NotCanStartException(List<string> errors)
			: base("La controladora no cumple las condiciones necesarias para su inicio.")
		{
            Errors = new List<string>(errors);
		}
	}
}
