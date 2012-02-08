///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Librería de atributos de Sifaw.Controllers.
/// 
/// Diseñador:     David López Rguez
/// Programadores: David López Rguez
///	
/// </summary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 08/02/2012 -- Creación de la clase.
/// ===============================================================================================
/// Observaciones:
/// 
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;
using System.Text;


namespace Sifaw.Controllers
{
    /// <summary>
    /// Atributo que permite establecer un valor de reseteo a los campos de tipo Guid de una controladora cuando es
    /// finalizada.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
    public class CLGuidReseteable : CLReseteable
    {
        #region Constructores

        public CLGuidReseteable()
            : base(Guid.Empty)
        {
        }

        public CLGuidReseteable(string guid)
            : base(new Guid(guid))
        {
        }

        #endregion
    }
}