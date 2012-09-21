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

using Sifaw.Core;


namespace Sifaw.Controllers.Components
{
    /// <summary>
    /// Representa el callbak que es invocado cuando se solicita lanzar
    /// un proceso en un nuevo hilo.
    /// </summary>
	/// <param name="comunicador">Comunicador que usa el proceso para comunicarse con el hilo padre.</param>
    /// <param name="arg">Argumentos del proceso.</param>
    [Serializable]
    public delegate object BackgroundWorkerDelegate(BackgroundWorkerCommunicator comunicador, object[] arg);
}
