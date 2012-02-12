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
		public NotCanStartException()
			: base("La controladora no cumple las condiciones necesarias para su inicio.")
		{
		}
	}
}
