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
    /// Atributo que permite establecer un valor de reseteo a objetos <see cref="System.DateTime"/>.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
    public class CLDateTimeReseteable : CLReseteable
    {
        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CLDateTimeReseteable"/> estableciendo el valor de
        /// reseteo a la fecha actual.
        /// </summary>
        public CLDateTimeReseteable()
            : base(Convert.ToDateTime(DateTime.Today.ToString()))
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CLDateTimeReseteable"/> estableciendo el valor de
        /// reseteo a la fecha vacía.
        /// </summary>
        public CLDateTimeReseteable(bool emptyIsMin)
            : base(Convert.ToDateTime(emptyIsMin ? DateTime.MinValue.ToString() : DateTime.MaxValue.ToString()))
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="CLDateTimeReseteable"/> estableciendo el valor de 
        /// reseteo a la cadena indicada por parámetro.
        /// </summary>
        public CLDateTimeReseteable(string dateTime)
            : base(Convert.ToDateTime(dateTime))
        {
        }

        #endregion
    }
}