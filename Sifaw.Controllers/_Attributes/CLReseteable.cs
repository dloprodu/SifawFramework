///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Librer�a de atributos de Sifaw.Controllers.
/// 
/// Dise�ador:     David L�pez Rguez
/// Programadores: David L�pez Rguez
///	
/// </summary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 14/12/2011 -- Creaci�n de la clase.
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
    /// Atributo que permite establecer un valor de reseteo a los campos de una controladora cuando �sta
    /// se finaliza.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
    public class CLReseteable : Attribute
    {
        #region Fields

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
        /// Atributo para identificar las variables de la controladora que se quieren resetear.
        /// </summary>
        /// <param name="value">Valor que se asignar� a un campo al finalizar la controladora.</param>
        public CLReseteable(object value)
            : base()
        {
            this._value = value;
        }

        #endregion
    }
}