///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Contiene la librer�a de excepciones.
/// 
/// Dise�ador:     David L�pez Rguez
/// Programadores: David L�pez Rguez
///	
/// </summary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 14/12/2011 -- Creaci�n de la clase.
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
    /// Excepci�n producida por incoherencia en el estado de la controladora.
    /// </summary>
    public class NotValidCtrlStateException : Exception
    {
        public NotValidCtrlStateException()
            : base("La controladora se encuentra en un estado incorrecto.")
        {
        }
    }

	/// <summary>
	/// Excepci�n producida por no cumplirse las condiciones necesarias para que se 
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
	/// Excepci�n producida cuando la controladora no da soporte al reinicio.
	/// </summary>
	public class NotAllowResetException : Exception
	{
		public NotAllowResetException()
			: base("La controladora no soporta el reinicio.")
		{
		}
	}

	/// <summary>
	/// Excepci�n producida cuando una controladora de vista hace referencia
	/// a su vista y el ViewLinker no ha devuelto una instnacia v�lida de la misma.
	/// </summary>
	public class AbstractUILinkerNullException : Exception
	{
		public AbstractUILinkerNullException()
			: base("El AbstractUILinker no ha devuelto una instancia v�lida para el elemento de la interfaz de usuario.")
		{
		}
	}
}