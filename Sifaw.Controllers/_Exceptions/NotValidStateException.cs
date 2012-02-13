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
	/// Excepción producida por incoherencia en el estado de la controladora.
	/// </summary>
	public class NotValidStateException : Exception
	{
		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="NotValidStateException"/>.
		/// </summary>
		public NotValidStateException()
			: base("La controladora se encuentra en un estado incorrecto.")
		{
		}
	}
}
