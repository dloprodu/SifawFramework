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
    /// Representa el callbak que es invocado cuando se solicita iniciar una controladora de componente de interfaz huésped.
    /// </summary>
    [Serializable]
    public delegate void StartGuestDelegate<TGuestController>(TGuestController guest) where TGuestController : IUIComponentController, new();
}
