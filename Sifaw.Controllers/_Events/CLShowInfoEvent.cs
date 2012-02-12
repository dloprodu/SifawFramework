/*
 * Sifaw.Controllers
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 08/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



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