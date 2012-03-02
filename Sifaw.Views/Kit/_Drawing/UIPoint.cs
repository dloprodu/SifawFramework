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
    /// Representa un par de coordenadas x e y en un espacio bidimensional.
    /// </summary>
    public struct UIPoint : IEquatable<UIPoint>
    {
        /// <summary>
        /// Representa un <see cref="UIPoint"/> cuyas coordenadas x e y valen cero.
        /// </summary>
        public static readonly UIPoint Empty;

        /// <summary>
        /// Obtiene o establece el valor de la coordenada <see cref="UIPoint"/> de esta
        /// estructura System.Windows.Point. El valor predeterminado es 0.
        /// </summary>
        public double X;
        
        /// <summary>
        /// Obtiene o establece el valor de la coordenada System.Windows.Point.Y de esta
        /// estructura System.Windows.Point.
        /// </summary>
        public double Y;

        #region Constructors

        static UIPoint()
        {
            Empty = new UIPoint(0.0f, 0.0f);
        }

        /// <summary>
        /// Inicializa una nueva instancia de la estructura <see cref="UIPoint"/>.
        /// </summary>
        /// <param name="x">Valor de la coordenada x.</param>
        /// <param name="y">Valor de la coordenada y.</param>
        public UIPoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        #endregion

        #region Méotods públicos
         
        /// <summary>
        /// Desplaza las coordenadas <see cref="UIPoint.X"/> e <see cref="UIPoint.Y"/>
        /// de un punto según las magnitudes especificadas.
        /// </summary>
        /// <param name="offsetX">Magnitud según la que se va a desplazarla coordenada <see cref="UIPoint.X"/> del punto.</param>
        /// <param name="offsetY">Magnitud según la que se va a desplazarla coordenada <see cref="UIPoint.Y"/> del punto.</param>
        public void Offset(double offsetX, double offsetY)
        {
            X += offsetX;
            Y += offsetY;
        }

        #endregion

        #region Override Methods

        /// <summary>
        /// Devuelve la representación de cadena de un objeto <see cref="UIPoint"/>.
        /// </summary>
        public override string ToString()
        {
            return string.Format("({0}, {1})", X, Y);
        }

        /// <summary>
        /// Determina si un objeto <see cref="UIPoint"/> proporcionado es equivalente al objeto <see cref="UIPoint"/> actual.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is UIPoint))
                return false;

            return X.Equals(((UIPoint)obj).X)
                && Y.Equals(((UIPoint)obj).Y);
        }

        /// <summary>
        /// Obtiene un código hash de este objeto <see cref="UIPoint"/>.
        /// </summary>
        public override int GetHashCode()
        {
            return X.GetHashCode() ^ Y.GetHashCode();
        }

        /// <summary>
        /// Determina si un objeto <see cref="UIPoint"/> proporcionado es equivalente al objeto <see cref="UIPoint"/> actual.
        /// </summary>
        public bool Equals(UIPoint other)
        {
            return X.Equals(other.X)
                && Y.Equals(other.Y);
        }

        #endregion

        #region Operator Overloading

        /// <summary>
        /// Comprueba si dos estructuras <see cref="UIPoint"/> no son idénticas.
        /// </summary>
        /// <param name="point1"> Primera estructura <see cref="UIPoint"/> que se va a comparar.</param>
        /// <param name="point2"> Segunda estructura <see cref="UIPoint"/> que se va a comparar.</param>
        /// <returns> Es true si point1 y point2 no son iguales; en caso contrario, es false.</returns>
        public static bool operator !=(UIPoint point1, UIPoint point2)
        {
            return point1.X != point2.X
                || point1.Y != point2.Y;
        }

        /// <summary>
        /// Comprueba si dos estructuras <see cref="UIPoint"/> son idénticas.
        /// </summary>
        /// <param name="point1"> Primera estructura <see cref="UIPoint"/> que se va a comparar.</param>
        /// <param name="point2"> Segunda estructura <see cref="UIPoint"/> que se va a comparar.</param>
        /// <returns>
        /// Es true si point1 y point2 son totalmente idénticos; en caso contrario, es
        /// false.
        /// </returns>
        public static bool operator ==(UIPoint point1, UIPoint point2)
        {
            return point1.X == point2.X
                && point1.Y == point2.Y;
        }

        #endregion
    }
}