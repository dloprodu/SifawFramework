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
    /// <summary>
    /// Representa el callbak que es invocado cuando se solicita lanzar
    /// un proceso en un nuevo hilo.
    /// </summary>
    /// <param name="BackgroundWorkerCommunicator">Comunicador que usa el proceso para comunicarse con el hilo padre.</param>
    /// <param name="arg">Argumentos del proceso.</param>
    /// <returns>Número de celdas de la fila <see cref="row"/>.</returns>
    [Serializable]
    public delegate object BackgroundWorkerDelegate(BackgroundWorkerCommunicator comunicador, object[] arg);
}
