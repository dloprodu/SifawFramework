///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Librería de excepciones de Sifaw.Controllers.Components
/// 
/// Diseñador:     David López Rguez
/// Programadores: David López Rguez
///	
/// </summary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 10/02/2012 -- Creación de la clase.
/// ===============================================================================================
/// Observaciones:
/// 
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sifaw.Controllers.Components
{
	/// <summary>
	/// Excepción producida por incoherencia al tratar un <see cref="UIComponent"/> como un <see cref="FilterBaseComponent"/>.
	/// </summary>
	public class NotValidFilterException : Exception
	{
		public NotValidFilterException()
			: base("El componente no es un filtro válido.")
		{
		}
	}
}
