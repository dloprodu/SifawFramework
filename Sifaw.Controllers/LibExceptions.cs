///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Contiene la librería de excepciones.
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
	
	/// <summary>
	/// Excepción producida cuando la controladora no da soporte al reinicio.
	/// </summary>
	public class NotAllowResetException : Exception
	{
		public NotAllowResetException()
			: base("La controladora no soporta el reinicio.")
		{
		}
	}

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