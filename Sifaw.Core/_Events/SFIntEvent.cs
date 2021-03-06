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
	 * Argumento y manejador para los eventos que comunican el un valor entero.
	 */

	/// <summary>
	/// Proporciona datos para eventos que comunican un valor entero.
	/// </summary>
	public class SFIntEventArgs : EventArgs
	{
		/// <summary>
		/// Devuelve un valor entero de 32 bits con signo.
		/// </summary>
		public readonly int Value;

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="SFIntEventArgs"/>, estableciendo un valor a la propiedad <see cref="Value"/>.
		/// </summary>
		/// <param name="value">Entero de 32 bits.</param>
		public SFIntEventArgs(int value)
			: base()
		{
			this.Value = value;
		}
	}

	/// <summary>
	/// Representa el método que maneja el evento que comunica un valor entero.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="SFIntEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void SFIntEventHandler(object sender, SFIntEventArgs e);
}