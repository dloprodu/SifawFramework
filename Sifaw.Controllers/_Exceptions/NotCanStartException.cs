///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Librería de excepciones de Sifaw.Controllers.
/// 
/// Diseñador:     David López Rguez
/// Programadores: David López Rguez
///	
/// </summary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 14/12/2011 -- Creación de la clase.
/// ===============================================================================================
/// Observaciones:
/// 
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



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
