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
	 * Argumento y manejador para los eventos que comunican la finalización de una controladora.
	 */

	/// <summary>
	/// Proporciona datos para un evento de finalización de controladora.
	/// </summary>
	public class CLFinishedEventArgs<T> : EventArgs
	{
		public readonly T Output;

		public CLFinishedEventArgs(T output)
			: base()
		{
			this.Output = output;
		}
	}

	/// <summary>
	/// Representa el método que controla un evento de finalización de controladora.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="CtrlFinishedEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void CLFinishedEventHandler<T>(object sender, CLFinishedEventArgs<T> e);
}
