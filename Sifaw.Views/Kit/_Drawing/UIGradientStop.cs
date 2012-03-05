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
    ///  Describe la ubicación y el color de un punto de la transición en un degradado.
    /// </summary>
    public struct UIGradientStop : IEquatable<UIGradientStop>
    {
        /// <summary>
        /// Obtiene el color del punto de degradado.
        /// </summary>
        public readonly UIColor Color;

        /// <summary>
        /// Obtiene la ubicación del punto de degradado dentro del vector de degradado.
        /// </summary>
        public readonly double Offset;

        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la estructura <see cref="UIGradientStop"/>.
        /// </summary>
        /// <param name="color">Color del punto de degradado.</param>
        /// <param name="offset">Punto de degradado dentro del vector de degradado.</param>
        public UIGradientStop(UIColor color, double offset)
        {
            Color = color;
            Offset = offset;
        }

        #endregion

        #region Override Methods

        /// <summary>
        /// Devuelve la representación de cadena de un objeto <see cref="UIGradientStop"/>.
        /// </summary>
        public override string ToString()
        {
            return string.Format("Color: {0}; Offset: {1}", Color.ToString(), Offset.ToString());
        }

        /// <summary>
        /// Determina si un objeto <see cref="UIGradientStop"/> proporcionado es equivalente al objeto <see cref="UIGradientStop"/> actual.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is UIGradientStop))
                return false;

            return Color.Equals(((UIGradientStop)obj).Color)
                && Offset.Equals(((UIGradientStop)obj).Offset);
        }

        /// <summary>
        /// Obtiene un código hash de este objeto <see cref="UIGradientStop"/>.
        /// </summary>
        public override int GetHashCode()
        {
            return Color.GetHashCode() ^ Offset.GetHashCode();
        }

        /// <summary>
        /// Determina si un objeto <see cref="UIGradientStop"/> proporcionado es equivalente al objeto <see cref="UIGradientStop"/> actual.
        /// </summary>
        public bool Equals(UIGradientStop other)
        {
            return Color.Equals(other.Color)
                && Offset.Equals(other.Offset);
        }

        #endregion

        #region Operator Overloading

        /// <summary>
        /// Comprueba si dos estructuras <see cref="UIGradientStop"/> no son idénticas.
        /// </summary>
        /// <param name="brush1"> Primera estructura <see cref="UIGradientStop"/> que se va a comparar.</param>
        /// <param name="brush2"> Segunda estructura <see cref="UIGradientStop"/> que se va a comparar.</param>
        /// <returns> Es true si brush1 y brush2 no son iguales; en caso contrario, es false.</returns>
        public static bool operator !=(UIGradientStop brush1, UIGradientStop brush2)
        {
            return brush1.Color != brush2.Color
                || brush1.Offset != brush2.Offset;
        }

        /// <summary>
        /// Comprueba si dos estructuras <see cref="UIGradientStop"/> son idénticas.
        /// </summary>
        /// <param name="brush1"> Primera estructura <see cref="UIGradientStop"/> que se va a comparar.</param>
        /// <param name="brush2"> Segunda estructura <see cref="UIGradientStop"/> que se va a comparar.</param>
        /// <returns>
        /// Es true si brush1 y brush2 son totalmente idénticos; en caso contrario, es
        /// false.
        /// </returns>
        public static bool operator ==(UIGradientStop brush1, UIGradientStop brush2)
        {
            return brush1.Color == brush2.Color
                || brush1.Offset == brush2.Offset;
        }

        #endregion
    }
}