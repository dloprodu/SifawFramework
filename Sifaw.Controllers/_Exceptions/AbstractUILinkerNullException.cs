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
	/// Excepción producida cuando una controladora de vista hace referencia
	/// a su vista y el ViewLinker no ha devuelto una instnacia válida de la misma.
	/// </summary>
	public class AbstractUILinkerNullException : Exception
	{
		public AbstractUILinkerNullException()
			: base("El AbstractUILinker no ha devuelto una instancia válida para el elemento de la interfaz de usuario.")
		{
		}
	}
}
