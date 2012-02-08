///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Librería de eventos de Sifaw.Core.
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

using Sifaw.Core;


namespace Sifaw.Controllers
{
	/*
	 * Argumento y manejador para los eventos que solicitan una confirmación sobre
	 * alguna acción.
	 */

	/// <summary>
	/// Proporciona datos para eventos que solicitan una confirmación sobre
	/// alguna acción.
	/// </summary>
	public class CLConfirmMessageEventArgs : SFStringEventArgs
	{
		public bool Confirmed = false;

		public CLConfirmMessageEventArgs(string message)
			: base(message)
		{
			Confirmed = false;
		}
	}

	/// <summary>
	/// Representa el método que maneja el evento que solicita una confirmación sobre
	/// alguna acción.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="CLConfirmMessageEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void CLConfirmMessageEventHandler(object sender, CLConfirmMessageEventArgs e);
}