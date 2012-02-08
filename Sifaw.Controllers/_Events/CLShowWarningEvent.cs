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

using Sifaw.Core;


namespace Sifaw.Controllers
{
    /*
     * Argumento y manejador para los eventos que solicitan mostrar un mensaje
     * al usuario.
     */

    /// <summary>
    /// Proporciona datos para eventos que solicitan mostrar un mensaje de advertencia.
    /// </summary>
    public class CLShowWarningEventArgs : CLShowMessageEventArgs
    {
        public CLShowWarningEventArgs(string message)
            : base(MessagesLevels.Warning, message)
        {
        }

        public CLShowWarningEventArgs(string title, string message)
            : base(MessagesLevels.Warning, title, message)
        {
        }
    }

    /// <summary>
    /// Representa el método que maneja el evento que solicita mostrar un mensaje de advertencia.
    /// </summary>
    /// <param name="sender">Origen del evento.</param>
    /// <param name="e"><see cref="CLConfirmMessageEventArgs"/> que contiene los datos de eventos.</param>
    public delegate void CLShowWarningEventHandler(object sender, CLShowWarningEventArgs e);
}