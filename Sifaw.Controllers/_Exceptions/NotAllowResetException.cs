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
	/// Excepción producida cuando la controladora no da soporte al reinicio.
	/// </summary>
	public class NotAllowResetException : Exception
	{
		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="NotAllowResetException"/>.
		/// </summary>
		public NotAllowResetException()
			: base("La controladora no soporta el reinicio.")
		{
		}
	}
}