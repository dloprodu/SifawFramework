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
	 * Argumento y manejador para los eventos que comunican el un valor entero.
	 */

	/// <summary>
	/// Proporciona datos para eventos que comunican un valor entero.
	/// </summary>
	public class SFIntEventArgs : EventArgs
	{
		public readonly int Value;

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