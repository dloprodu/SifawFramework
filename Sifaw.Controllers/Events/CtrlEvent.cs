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
	public class CtrlEventArgs : EventArgs
	{
		public readonly Type CtrlType = null;
		public readonly object[] Parameters = null;

		public CtrlEventArgs(Type ctrlType, params object[] parameters)
		{
			CtrlType = ctrlType;
			Parameters = parameters;
		}
	}

	/// <summary>
	/// Representa el método que controla un evento que solicita el inicio de una controladora.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="CtrlEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void CtrlEventHandler(object sender, CtrlEventArgs e);
}
