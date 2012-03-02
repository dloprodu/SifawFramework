/*
 * Sifaw.Views
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
	/// Describe los pinceles para dibujar un marco situado alrededor de un rectángulo. 
    /// Cuatro valores <see cref="UIBrush"/> describen los pinceles de los lados Left, Top, Right y Bottom del rectángulo, respectivamente.
	/// </summary>
	public struct UIFrameBrush
	{
		/// <summary>
		/// Obtiene o establece el pincel del lado izquierdo del rectángulo delimitador.
		/// </summary>
        public UIBrush Left;

		/// <summary>
		/// Obtiene o establece el pincel del lado superior del rectángulo delimitador.
		/// </summary>
        public UIBrush Top;

		/// <summary>
		/// Obtiene o establece el pincel del lado derecho del rectángulo delimitador.
		/// </summary>
        public UIBrush Right;

		/// <summary>
		/// Obtiene o establece el pincel del lado menor del rectángulo delimitador.
		/// </summary>
        public UIBrush Bottom;

		#region Constructors

		/// <summary>
		/// Inicializa una nueva instancia de la estructura <see cref="UIFrameBrush"/> que tiene los pinceles 
		/// específicos (se proporcionan como valor de tipo <c>UIColor</c>) aplicadas a cada lado del rectángulo.
		/// </summary>
        public UIFrameBrush(UIBrush left, UIBrush top, UIBrush right, UIBrush bottom)
		{
			Left = left;
			Top = top;
			Right = right;
			Bottom = bottom;
		}

		/// <summary>
		/// Inicializa una nueva instancia de la estructura <see cref="UIFrameBrush"/> que tiene el pincel 
		/// uniforme especificado en cada lado.
		/// </summary>
        public UIFrameBrush(UIBrush all)
			: this(all, all, all, all)
		{
		}

		#endregion

        #region Override Methods

        /// <summary>
        /// Devuelve la representación de cadena de un objeto <see cref="UIFrame"/>.
        /// </summary>
        public override string ToString()
        {
            return string.Format("Left: {0}; Top: {1}; Right: {2}; Bottom: {3}", Left, Top, Right, Bottom);
        }

        /// <summary>
        /// Determina si un objeto <see cref="UIFrame"/> proporcionado es equivalente al objeto <see cref="UIFrame"/> actual.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is UIFrame))
                return false;

            return Left.Equals(((UIFrame)obj).Left)
                && Top.Equals(((UIFrame)obj).Top)
                && Right.Equals(((UIFrame)obj).Right)
                && Bottom.Equals(((UIFrame)obj).Bottom);
        }

        /// <summary>
        /// Obtiene un código hash de este objeto <see cref="UIFrame"/>.
        /// </summary>
        public override int GetHashCode()
        {
            return Left.GetHashCode() ^ Top.GetHashCode() ^ Right.GetHashCode() ^ Bottom.GetHashCode();
        }

        /// <summary>
        /// Determina si un objeto <see cref="UIFrame"/> proporcionado es equivalente al objeto <see cref="UIFrame"/> actual.
        /// </summary>
        public bool Equals(UIFrame other)
        {
            return Left.Equals(other.Left)
               && Top.Equals(other.Top)
               && Right.Equals(other.Right)
               && Bottom.Equals(other.Bottom);
        }

        #endregion

        #region Operator Overloading

        /// <summary>
        /// Comprueba si dos estructuras <see cref="UIFrameBrush"/> no son idénticas.
        /// </summary>
        /// <param name="frame1"> Primera estructura <see cref="UIFrameBrush"/> que se va a comparar.</param>
        /// <param name="frame2"> Segunda estructura <see cref="UIFrameBrush"/> que se va a comparar.</param>
        /// <returns> Es true si color1 y color2 no son iguales; en caso contrario, es false.</returns>
        public static bool operator !=(UIFrameBrush frame1, UIFrameBrush frame2)
        {
            return frame1.Left != frame2.Left
                || frame1.Top != frame2.Top
                || frame1.Right != frame2.Right
                || frame1.Right != frame2.Right;
        }

        /// <summary>
        /// Comprueba si dos estructuras <see cref="UIFrameBrush"/> son idénticas.
        /// </summary>
        /// <param name="frame1"> Primera estructura <see cref="UIFrameBrush"/> que se va a comparar.</param>
        /// <param name="frame2"> Segunda estructura <see cref="UIFrameBrush"/> que se va a comparar.</param>
        /// <returns>
        /// Es true si color1 y color2 son totalmente idénticos; en caso contrario, es
        /// false.
        /// </returns>
        public static bool operator ==(UIFrameBrush frame1, UIFrameBrush frame2)
        {
            return frame1.Left == frame2.Left
                && frame1.Top == frame2.Top
                && frame1.Right == frame2.Right
                && frame1.Bottom == frame2.Bottom;
        }

        #endregion
    }
}
