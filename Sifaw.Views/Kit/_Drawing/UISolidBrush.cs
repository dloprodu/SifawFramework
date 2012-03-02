/*
 * Sifaw.Views.Kit
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 09/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sifaw.Views.Kit
{
    /// <summary>
    /// Define un pincel de un solo color.
    /// </summary>
    public sealed class UISolidBrush : UIBrush
    {
        #region Fields

        private UIColor _color;

        #endregion

        #region Properties

        /// <summary>
        /// Obtiene el color de este objeto SolidBrush.
        /// </summary>
        public UIColor Color
        {
            get { return _color; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UISolidBrush"/>.
        /// </summary>
        /// <param name="color">Color del pincel.</param>
        public UISolidBrush(UIColor color)
             : base()
        {
            this._color = color;
        }

        #endregion

        #region Override Methods

        /// <summary>
        /// Devuelve la representación de cadena de un objeto <see cref="UISolidBrush"/>.
        /// </summary>
        public override string ToString()
        {
            return Color.ToString();
        }

        /// <summary>
        /// Determina si un objeto <see cref="UISolidBrush"/> proporcionado es equivalente al objeto <see cref="UISolidBrush"/> actual.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is UISolidBrush))
                return false;

            return Color.Equals(((UISolidBrush)obj).Color);
        }

        /// <summary>
        /// Obtiene un código hash de este objeto <see cref="UISolidBrush"/>.
        /// </summary>
        public override int GetHashCode()
        {
            return Color.GetHashCode();
        }

        #endregion

        #region Operator Overloading

        /// <summary>
        /// Comprueba si dos estructuras <see cref="UISolidBrush"/> no son idénticas.
        /// </summary>
        /// <param name="brush1"> Primera estructura <see cref="UISolidBrush"/> que se va a comparar.</param>
        /// <param name="brush2"> Segunda estructura <see cref="UISolidBrush"/> que se va a comparar.</param>
        /// <returns> Es true si brush1 y brush2 no son iguales; en caso contrario, es false.</returns>
        public static bool operator !=(UISolidBrush brush1, UISolidBrush brush2)
        {
            return brush1.Color != brush2.Color;
        }

        /// <summary>
        /// Comprueba si dos estructuras <see cref="UISolidBrush"/> son idénticas.
        /// </summary>
        /// <param name="brush1"> Primera estructura <see cref="UISolidBrush"/> que se va a comparar.</param>
        /// <param name="brush2"> Segunda estructura <see cref="UISolidBrush"/> que se va a comparar.</param>
        /// <returns>
        /// Es true si brush1 y brush2 son totalmente idénticos; en caso contrario, es
        /// false.
        /// </returns>
        public static bool operator ==(UISolidBrush brush1, UISolidBrush brush2)
        {
            return brush1.Color == brush2.Color;
        }

        #endregion
    }
}