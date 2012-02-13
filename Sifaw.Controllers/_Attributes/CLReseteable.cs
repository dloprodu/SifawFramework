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
    /// Atributo que permite establecer un valor de reseteo a los campos de una controladora cuando ésta
    /// se finaliza.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
    public class CLReseteable : Attribute
    {
        #region Fields

		/// <summary>
		/// Valor de reseteo.
		/// </summary>
        protected object _value;

        #endregion

        #region Properties

        /// <summary>
        /// Devuelve el valor que se quiere asignar al reiniciar un campo.
        /// </summary>
        public object Value
        {
            get { return _value; }
        }

        #endregion

        #region Constructors

        /// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="CLReseteable"/>.
        /// </summary>
        /// <param name="value">Valor que se asignará a un campo al finalizar la controladora.</param>
        public CLReseteable(object value)
            : base()
        {
            this._value = value;
        }

        #endregion
    }
}