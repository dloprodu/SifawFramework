/*
 * Sifaw.Core
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


namespace Sifaw.Core
{
    /// <summary>
    /// Define los comandos que puede enviar un proceso pesado, mediante un objeto <see cref="BackgroundWorkerCommunicator"/>
    /// para actualizar la información mostrada al usuario.
    /// </summary>
    public enum ReportProgressCommands
    {
        /// <summary>
        /// Indica un cambio en el progreso del proceso pesado y un texto descriptivo.
        /// </summary>
        ProgressAndTextChanged,

        /// <summary>
        /// Indica un cambio del texto descriptivo.
        /// </summary>
        TextChanged,

        /// <summary>
        /// Indica un cambio en el progreso del proceso pesado.
        /// </summary>
        ProgressChanged,
        
        /// <summary>
        /// Indica un cambio del valor máximo para el progreso del proceso pesado.
        /// </summary>
        MaximumProgressChanged,

        /// <summary>
        /// Indica un cambio en el tipo de comunicación, con o sin control de progreso, del proceso pesado.
        /// </summary>
        WithControlChanged
    }
}
