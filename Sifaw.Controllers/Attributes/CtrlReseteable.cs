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
///   - 14/12/2011 -- Creación de la clase.
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
    /// Atributo para identificar las variables de la controladora que se quieren resetear al finalizar
	/// una controladora.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, Inherited = true, AllowMultiple = true)]
    public class CtrlReseteable : Attribute
    {
        #region Constantes

        /// <summary>
        /// Representa un Guid.Empty
        /// </summary>
        public const string GUID_EMPTY = "00000000-0000-0000-0000-000000000000";

        #endregion

        #region Variables

        private object _value;

        #endregion

        #region Propiedades

        /// <summary>
        /// Valor que se quiere asignar para el reset de la variable.
        /// </summary>
        public object Value
        {
            get { return _value; }
        }

        #endregion

        #region Constructores

        /// <summary>
        /// Atributo para identificar las variables de la controladora que se quieren resetear
        /// </summary>
        /// <param name="value">Valor quie se asignará al realizar un reset</param>
        public CtrlReseteable(object value)
            : base()
        {
            this._value = value;
        }

        /// <summary>
        /// Atributo para identificar las variables de la controladora que se quieren resetear
        /// </summary>
        public CtrlReseteable(Type valueType, object value)
            : base()
        {
			// TODO: Implementar un método de conversión mas intuitivo ...

			try
            {
                if (valueType == typeof(Guid))
                    this._value = new Guid(value.ToString ());
                else
                    this._value = Convert.ChangeType(value, valueType);
            }
            catch
            {
                this._value = null;
            }
        }

        #endregion
    }

	//public delegate T CtrlReseteableConvert<T>(object value);
}