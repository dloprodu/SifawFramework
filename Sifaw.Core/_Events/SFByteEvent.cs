﻿/*
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
	 * Argumento y manejador para los eventos que comunican el un valor entero de 8 bits sin signo.
	 */

	/// <summary>
    /// Proporciona datos para eventos que comunican un valor entero de 8 bits sin signo.
	/// </summary>
	public class SFByteEventArgs : EventArgs
	{
		/// <summary>
		/// Devuelve un valor entero de 8 bits sin signo.
		/// </summary>
		public readonly byte Value;

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="SFByteEventArgs"/>, estableciendo un valor a la propiedad <see cref="Value"/>.
		/// </summary>
        public SFByteEventArgs(byte value)
			: base()
		{
			this.Value = value;
		}
	}

	/// <summary>
    /// Representa el método que maneja el evento que comunica un valor entero de 8 bits sin signo.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="SFIntEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void SFByteEventHandler(object sender, SFByteEventArgs e);
}