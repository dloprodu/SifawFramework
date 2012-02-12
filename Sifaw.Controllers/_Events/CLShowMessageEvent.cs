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
    /// Proporciona datos para eventos que solicitan mostrar un mensaje.
    /// </summary>
    public class CLShowMessageEventArgs : SFStringEventArgs
    {
        #region Auxiliary structures

        /// <summary>
        /// Define los tipos de mensajes contemplados.
        /// </summary>
        public enum MessagesLevels
        {
            /// <summary>
            /// Mensaje indeterminado.
            /// </summary>
            Unknown = 0,

            /// <summary>
            /// Mensaje de información.
            /// </summary>
            Info = 1,
            
            /// <summary>
            /// Mensaje de advertencia.
            /// </summary>
            Warning = 2, 

            /// <summary>
            /// Mensaje de error.
            /// </summary>
            Error = 3
        }

        #endregion

        /// <summary>
        /// Indica el nivel del mensaje a mostrar.
        /// </summary>
        public readonly MessagesLevels Level;
        public readonly string Title;

        public CLShowMessageEventArgs(MessagesLevels level, string message)
            : this(level, level.ToString(), message)
        {
        }

        public CLShowMessageEventArgs(MessagesLevels level, string title, string message)
            : base(message)
        {
            Level = level;
            Title = title;
        }
    }

    /// <summary>
    /// Representa el método que maneja el evento que solicita mostrar un mensaje.
    /// </summary>
    /// <param name="sender">Origen del evento.</param>
    /// <param name="e"><see cref="CLConfirmMessageEventArgs"/> que contiene los datos de eventos.</param>
    public delegate void CLShowMessageEventHandler(object sender, CLShowMessageEventArgs e);
}