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
	/// Excepción producida por incoherencia en el estado de la controladora.
	/// </summary>
	public class NotValidCtrlStateException : Exception
	{
		public NotValidCtrlStateException()
			: base("La controladora se encuentra en un estado incorrecto.")
		{
		}
	}
}
