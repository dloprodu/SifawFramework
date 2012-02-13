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
	 * Argumento y manejador para los eventos que comunican un valor string.
	 */

	/// <summary>
	/// Proporciona datos para eventos que comunican un valor string.
	/// </summary>
	public class SFStringEventArgs : EventArgs
	{
		/// <summary>
		/// Devuelve una cadena de texto.
		/// </summary>
		public readonly string Value = string.Empty;

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="SFStringEventArgs"/>, estableciendo un valor a la propiedad <see cref="Value"/>.
		/// </summary>
		/// <param name="value">Cadena de texto.</param>
		public SFStringEventArgs(string value)
			: base()
		{
			Value = value;
		}
	}

	/// <summary>
	/// Representa el método que maneja el evento que comunica un valor string.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="SFStringEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void SFStringEventHandler(object sender, SFStringEventArgs e);
}