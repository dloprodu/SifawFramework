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
        #region Constructors

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="CLGuidReseteable"/> estableciendo <see cref="T:System.Guid.Empty"/>
		/// como valor de reseteo.
		/// </summary>
        public CLGuidReseteable()
            : base(Guid.Empty)
        {
        }

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="CLGuidReseteable"/> estableciendo una cadena que representa un Guid
		/// como valor de reseteo.
		/// </summary>
        public CLGuidReseteable(string guid)
            : base(new Guid(guid))
        {
        }

        #endregion
    }
}