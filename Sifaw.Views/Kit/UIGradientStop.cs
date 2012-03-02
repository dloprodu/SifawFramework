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
        public readonly float Offset;

        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la estructura <see cref="UIGradientStop"/>.
        /// </summary>
        /// <param name="color">Color del punto de degradado.</param>
        /// <param name="offset">Punto de degradado dentro del vector de degradado.</param>
        public UIGradientStop(UIColor color, float offset)
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
        /// Determina si un objeto <see cref="UIColor"/> proporcionado es equivalente al objeto <see cref="UIColor"/> actual.
        /// </summary>
        public bool Equals(UIGradientStop other)
        {
            return Color.Equals(other.Color)
                && Offset.Equals(other.Offset);
        }

        #endregion
    }
}