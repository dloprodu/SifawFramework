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
	 * Argumento y manejador para los eventos que comunican el una excepción.
	 */

	/// <summary>
	/// Proporciona datos para eventos que informan de una excepción.
	/// </summary>
	public class SFExceptionEventArgs : EventArgs
	{
		public readonly Exception Exception;

		public SFExceptionEventArgs(Exception ex)
			: base()
		{
			this.Exception = ex;
		}
	}

	/// <summary>
	/// Representa el método que maneja el evento que informan de una excepción.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="SFExceptionEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void SFExceptionEventHandler(object sender, SFExceptionEventArgs e);
}