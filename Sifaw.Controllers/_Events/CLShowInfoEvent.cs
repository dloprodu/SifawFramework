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
    /// Proporciona datos para eventos que solicitan mostrar un mensaje informativo.
    /// </summary>
    public class CLShowInfoEventArgs : CLShowMessageEventArgs
    {
        public CLShowInfoEventArgs(string message)
            : base(MessagesLevels.Info, message)
        {
        }

        public CLShowInfoEventArgs(string title, string message)
            : base(MessagesLevels.Info, title, message)
        {
        }
    }

    /// <summary>
    /// Representa el método que maneja el evento que solicita mostrar un mensaje informativo.
    /// </summary>
    /// <param name="sender">Origen del evento.</param>
    /// <param name="e"><see cref="CLConfirmMessageEventArgs"/> que contiene los datos de eventos.</param>
    public delegate void CLShowInfoEventHandler(object sender, CLShowInfoEventArgs e);
}