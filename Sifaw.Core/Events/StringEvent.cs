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
	 * Argumento y manejador para los eventos que comunican un valor string.
	 */

	/// <summary>
	/// Proporciona datos para eventos que comunican un valor string.
	/// </summary>
	public class StringEventArgs : EventArgs
	{
		public readonly string Value = string.Empty;

		public StringEventArgs(string value)
			: base()
		{
			Value = value;
		}
	}

	/// <summary>
	/// Representa el método que maneja el evento que comunica un valor string.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="StringEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void StringEventHandler(object sender, StringEventArgs e);
}