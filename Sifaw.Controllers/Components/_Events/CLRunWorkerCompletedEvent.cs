/*
 * Sifaw.Controllers.Components
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


namespace Sifaw.Controllers.Components
{
    /*
     * Argumento y manejador para los eventos que comunican la finalización del proceso pesado.
     */

    /// <summary>
    /// Proporciona datos para un evento que comunica la finalización del proceso pesado de la controladora <see cref="UIBackgroundWorkerController"/>.
    /// </summary>
    public class CLRunWorkerCompletedEventArgs : EventArgs
    {
        private readonly object Result;
        private readonly bool Cancelled;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CLSateChangedEventArgs"/>.
        /// </summary>
        public CLRunWorkerCompletedEventArgs(object result, bool cancelled)
            : base()
        {
            this.Result = result;
            this.Cancelled = cancelled;
        }
    }

    /// <summary>
    /// Representa el método que controla un evento que comunica la finalización del proceso pesado de la controladora <see cref="UIBackgroundWorkerController"/>.
    /// </summary>
    /// <param name="sender">Origen del evento.</param>
    /// <param name="e"><see cref="CLRunWorkerCompletedEventArgs"/> que contiene los datos de eventos.</param>
    public delegate void CLRunWorkerCompletedEventHandler(object sender, CLRunWorkerCompletedEventArgs e);
}
