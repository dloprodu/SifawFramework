/*
 * Librería de eventos de Sifaw.Core.
 * 
 * Diseñador:     David López Rguez
 * Programadores: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 14/12/2011 -- Creación de la clase.
 * ===============================================================================================  
 * 
 * Observaciones:
 */




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sifaw.Core
{
	/*
	 * Argumento y manejador para los eventos cancelables.
	 */

	/// <summary>
	/// Proporciona datos para un evento cancelable.
	/// </summary>
	public class SFCancelEventArgs : EventArgs
	{
		/// <summary>
		/// Devuelve o establece un valor que indica si se debe cancelar el evento.
		/// </summary>
		public bool Cancel = false;

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="SFCancelEventArgs"/>, estableciendo un valor a la propiedad <see cref="Cancel"/>
		/// en <c>false</c>.
		/// </summary>
		public SFCancelEventArgs()
		{
			Cancel = false;
		}
	}

	/// <summary>
	/// Representa el método que controla un evento cancelable.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="SFCancelEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void SFCancelEventHandler(object sender, SFCancelEventArgs e);
}