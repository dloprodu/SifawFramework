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
    /// Representa el callbak que es invocado cuando se solicita la construcción de resultado que devuelve una controladora al finalizar.
    /// </summary>
    [Serializable]
    public delegate object GetResultGuestDelegate<TGuestController>(TGuestController guest) where TGuestController : IUIComponentController, new();
}
