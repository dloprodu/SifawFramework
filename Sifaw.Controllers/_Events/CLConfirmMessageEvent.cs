/*
 * Sifaw.Controllers
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 08/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



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
		/// <summary>
		/// Devuelve o establece un valor que indica si se ha confirmado la acción expuesta por
		/// por la propiedad <c>Value</c>.
		/// </summary>
		public bool Confirmed = false;

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="CLConfirmMessageEventArgs"/>, estableciendo la propiedad <see cref="Confirmed"/> en false.
		/// </summary>
		/// <param name="message">Mensaje que ha de confirmar el usuario.</param>
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