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
	/// Proporciona datos para eventos que comunican un valor de tipo genérico.
	/// </summary>
	public class SFValueEventArgs<TValue> : EventArgs
	{
		/// <summary>
		/// Devuelve una cadena de texto.
		/// </summary>
		public readonly TValue Value = default(TValue);

		/// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SFValueEventArgs{TValue}"/>, estableciendo un valor a la propiedad <see cref="Value"/>.
		/// </summary>
		/// <param name="value">Cadena de texto.</param>
        public SFValueEventArgs(TValue value)
			: base()
		{
			Value = value;
		}
	}

	/// <summary>
	/// Representa el método que maneja el evento que comunica un valor genérico.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="SFStringEventArgs"/> que contiene los datos de eventos.</param>
    public delegate void SFValueEventHandler<TValue>(object sender, SFValueEventArgs<TValue> e);
}