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


namespace Sifaw.Core
{
	/*
	 * Argumento y manejador para los eventos cancelables.
	 */

	/// <summary>
	/// Proporciona datos para un evento cancelable.
	/// </summary>
	public class CancelEventArgs : EventArgs
	{
		/// <summary>
		/// Obtiene o establece un valor que indica si se debe cancelar el evento.
		/// </summary>
		public bool Cancel = false;

		public CancelEventArgs()
		{
			Cancel = false;
		}
	}

	/// <summary>
	/// Representa el método que controla un evento cancelable.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="CancelEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void CancelEventHandler(object sender, CancelEventArgs e);
}