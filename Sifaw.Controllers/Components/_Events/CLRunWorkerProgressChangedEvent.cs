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
     * Argumento y manejador para los eventos que comunican el progreso del proceso pesado.
     */

    /// <summary>
    /// Proporciona datos para un evento que comunica el progreso del proceso pesado de la controladora <see cref="UIBackgroundWorkerController"/>.
    /// </summary>
    public class CLRunWorkerProgressChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Obtiene un valor que indica si el proceso comunica el progreso.
        /// </summary>
        public readonly bool WithControl;

        /// <summary>
        /// Obtiene el valor del progreso máximo del proceso.
        /// </summary>
        public readonly int MaxProgress;
        
        /// <summary>
        /// Obtiene el valor del progreso actual del proceso.
        /// </summary>
        public readonly int Progress;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CLRunWorkerProgressChangedEventArgs"/>.
        /// </summary>
        public CLRunWorkerProgressChangedEventArgs(bool withControl, int maxProgress, int progress)
            : base()
        {
            this.WithControl = withControl;
            this.MaxProgress = maxProgress;
            this.Progress = progress;
        }
    }

    /// <summary>
    /// Representa el método que controla un evento que comunica el progreso del proceso pesado de la controladora <see cref="UIBackgroundWorkerController"/>.
    /// </summary>
    /// <param name="sender">Origen del evento.</param>
    /// <param name="e"><see cref="CLRunWorkerProgressChangedEventArgs"/> que contiene los datos de eventos.</param>
    public delegate void CLRunWorkerProgressChangedEventHandler(object sender, CLRunWorkerProgressChangedEventArgs e);
}
