///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Librería de eventos de Sifaw.Controllers.
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
	/*
	 * Argumento y manejador para los eventos que solicitan el inicio de una controladora.
	 */

	/// <summary>
	/// Proporciona datos para un evento que solicita el inicio de una controladora.
	/// </summary>
	public class CLEventArgs : EventArgs
	{
		public readonly Type CLType = null;
		public readonly object[] Parameters = null;

		public CLEventArgs(Type clType, params object[] parameters)
		{
			CLType = clType;
			Parameters = parameters;
		}
	}

	/// <summary>
	/// Representa el método que controla un evento que solicita el inicio de una controladora.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="CLEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void CLEventHandler(object sender, CLEventArgs e);
}
