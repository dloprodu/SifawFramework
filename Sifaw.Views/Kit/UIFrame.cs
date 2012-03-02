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
	/// Describe el grosor de un marco situado alrededor de un rectángulo. 
	/// Cuatro valores <c>Double</c> describen los lados Left, Top, Right y Bottom del rectángulo, respectivamente.
	/// </summary>
	public struct UIFrame : IEquatable<UIFrame>
	{
		/// <summary>
		/// Representa una estructura <see cref="UIFrame"/> con longitudes definidas a 0.
		/// </summary>
		public static readonly UIFrame Empty;

		/// <summary>
		/// Obtiene o establece el ancho, en píxeles, del lado izquierdo del rectángulo delimitador.
		/// </summary>
		public double Left;

		/// <summary>
		/// Obtiene o establece el ancho, en píxeles, del lado superior del rectángulo delimitador.
		/// </summary>
		public double Top;

		/// <summary>
		/// Obtiene o establece el ancho, en píxeles, del lado derecho del rectángulo delimitador.
		/// </summary>
		public double Right;

		/// <summary>
		/// Obtiene o establece el ancho, en píxeles, del lado menor del rectángulo delimitador.
		/// </summary>
		public double Bottom;

		#region Constructors

		static UIFrame()
		{
			Empty = new UIFrame(0.0f, 0.0f, 0.0f, 0.0f);
		}

		/// <summary>
		/// Inicializa una nueva instancia de la estructura <see cref="UIFrame"/> que tiene las longitudes 
		/// específicas (se proporcionan como valor de tipo <c>Double</c>) aplicadas a cada lado del rectángulo.
		/// </summary>
		public UIFrame(double left, double top, double right, double bottom)
		{
			Left = left;
			Top = top;
			Right = right;
			Bottom = bottom;
		}

		/// <summary>
		/// Inicializa una nueva instancia de la estructura <see cref="UIFrame"/> que tiene la longitud 
		/// uniforme especificada en cada lado.
		/// </summary>
		public UIFrame(double all)
			: this(all, all, all, all)
		{
		}

		/// <summary>
		/// Inicializa una nueva instancia de la estructura <see cref="UIFrame"/> que tiene las longitudes 
		/// específicas (se proporcionan como valor de tipo <c>Double</c>) aplicadas a cada lado del rectángulo.
		/// </summary>
		public UIFrame(int left, int top, int right, int bottom)
			: this(Convert.ToSingle(left), Convert.ToSingle(top), Convert.ToSingle(right), Convert.ToSingle(bottom))
		{
		}

		/// <summary>
		/// Inicializa una nueva instancia de la estructura <see cref="UIFrame"/> que tiene la longitud 
		/// uniforme especificada en cada lado.
		/// </summary>
		public UIFrame(int all)
			: this(Convert.ToSingle(all))
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
	}
}