///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Librería de eventos de Sifaw.Controllers.
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

using Sifaw.Core;


namespace Sifaw.Controllers
{
	/*
	 * Argumento y manejador para los eventos ProgressChanged.
	 */

	/// <summary>
	/// Proporciona datos para un evento ProgressChanged.
	/// </summary>
	public class CLProgressChangedEventArgs : SFByteEventArgs
	{
        public readonly string Message;

        public CLProgressChangedEventArgs(byte progress)
            : this(progress, string.Empty)
        {
        }

        public CLProgressChangedEventArgs(byte progress, string message)
			: base(progress)
		{
            if (progress > 100)
                throw new ArgumentException("progress ha de ser un número entre 0 y 100.", "progress");

            Message = message;
		}
	}

	/// <summary>
    /// Representa el método que controla un evento ProgressChanged.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="CtrlFilterChangedEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void CLProgressChangedEventHandler(object sender, CLProgressChangedEventArgs e);
}