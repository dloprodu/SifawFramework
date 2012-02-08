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
	 * Argumento y manejador para los eventos que comunican el estado de una controladora.
	 */

	/// <summary>
	/// Proporciona datos para un evento que comunica el estado de una controladora.
	/// </summary>
	public class CtrlSatesEventArgs : EventArgs
	{
		public readonly CtrlStates State;

		public CtrlSatesEventArgs(CtrlStates state)
			: base()
		{
			this.State = state;
		}
	}

	/// <summary>
	/// Representa el método que controla un evento que comunica el estado de una controladora.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="CtrlSatesEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void CtrlStatesEventHandler(object sender, CtrlSatesEventArgs e);
}
