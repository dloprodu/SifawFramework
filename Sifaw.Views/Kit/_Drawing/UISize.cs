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
    /// Almacena el ancho y el alto, normalmente de un rectángulo.
    /// </summary>
    [Serializable]
    public struct UISize : IEquatable<UISize>
    {
        /// <summary>
        /// Representa un <see cref="UISize"/> cuyos valores de ancho y alto son cero.
        /// </summary>
        public static readonly UISize Empty;

        /// <summary>
        /// Representa un <see cref="UISize"/> cuyos valores de ancho y alto son <see cref="double.PositiveInfinity"/>.
        /// </summary>
        public static readonly UISize Infinity;

        /// <summary>
		/// Obtiene o establece el componente horizontal de esta estructura <see cref="UISize"/>.
        /// </summary>
		public readonly double Width;
        
        /// <summary>
		/// Obtiene o establece el componente vertical de esta estructura <see cref="UISize"/>.
        /// </summary>
        public readonly double Height;

        #region Constructors

        static UISize()
        {
            Empty = new UISize(0.0f, 0.0f);
            Infinity = new UISize(double.PositiveInfinity, double.PositiveInfinity);
        }

        /// <summary>
        /// Inicializa una nueva instancia de la estructura <see cref="UISize"/>.
        /// </summary>
        /// <param name="width">Valor de la coordenada x.</param>
        /// <param name="height">Valor de la coordenada y.</param>
        public UISize(double width, double height)
        {
			Width = width;
            Height = height;
        }

        #endregion

        #region Override Methods

        /// <summary>
        /// Devuelve la representación de cadena de un objeto <see cref="UISize"/>.
        /// </summary>
        public override string ToString()
        {
			return string.Format("({0}, {1})", Width, Height);
        }

        /// <summary>
        /// Determina si un objeto <see cref="UISize"/> proporcionado es equivalente al objeto <see cref="UISize"/> actual.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is UISize))
                return false;

			return Width.Equals(((UISize)obj).Width)
                && Height.Equals(((UISize)obj).Height);
        }

        /// <summary>
        /// Obtiene un código hash de este objeto <see cref="UISize"/>.
        /// </summary>
        public override int GetHashCode()
        {
            return Width.GetHashCode() ^ Height.GetHashCode();
        }

        /// <summary>
        /// Determina si un objeto <see cref="UISize"/> proporcionado es equivalente al objeto <see cref="UISize"/> actual.
        /// </summary>
        public bool Equals(UISize other)
        {
			return Width.Equals(other.Width)
                && Height.Equals(other.Height);
        }

        #endregion

        #region Operator Overloading

        /// <summary>
        /// Comprueba si dos estructuras <see cref="UISize"/> no son idénticas.
        /// </summary>
        /// <param name="size1"> Primera estructura <see cref="UISize"/> que se va a comparar.</param>
        /// <param name="size2"> Segunda estructura <see cref="UISize"/> que se va a comparar.</param>
        /// <returns> Es true si color1 y color2 no son iguales; en caso contrario, es false.</returns>
        public static bool operator !=(UISize size1, UISize size2)
        {
            return size1.Width != size2.Width
                || size1.Height != size2.Height;
        }

        /// <summary>
        /// Comprueba si dos estructuras <see cref="UISize"/> son idénticas.
        /// </summary>
        /// <param name="size1"> Primera estructura <see cref="UISize"/> que se va a comparar.</param>
        /// <param name="size2"> Segunda estructura <see cref="UISize"/> que se va a comparar.</param>
        /// <returns>
        /// Es true si color1 y color2 son totalmente idénticos; en caso contrario, es
        /// false.
        /// </returns>
        public static bool operator ==(UISize size1, UISize size2)
        {
            return size1.Width == size2.Width
                && size1.Height == size2.Height;
        }

        #endregion
    }
}