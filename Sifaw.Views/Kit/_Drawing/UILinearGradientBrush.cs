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
    /// Clase abstracta que describe un degradado, formado por puntos de degradado. Las
    /// clases que heredan de <see cref="UIGradientBrush"/> describen las diferentes
    /// formas de interpretar los puntos de degradado.
    /// </summary>
    [Serializable]
    public class UILinearGradientBrush : UIGradientBrush
    {
        #region Fields

		private double _angle = 0.0f;

        #endregion

        #region Properties

		/// <summary>
		/// Obtiene o devuelve el ángulo, en grados, del delgradado. Un
		/// valor de 0.0 crea un degradado horizontal, y un valor de 90.0 crea
		/// un degradado vertical.
		/// </summary>
		public double Angle
		{
			get { return _angle; }
			set { _angle = value; }
		}

        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UILinearGradientBrush"/>.
        /// </summary>
        public UILinearGradientBrush()
            : base()
        {
        }

        #endregion

        #region Override Methods

        /// <summary>
        /// Devuelve la representación de cadena de un objeto <see cref="UIGradientBrush"/>.
        /// </summary>
        public override string ToString()
        {
            return base.ToString();
        }

        /// <summary>
        /// Determina si un objeto <see cref="UILinearGradientBrush"/> proporcionado es equivalente al objeto <see cref="UILinearGradientBrush"/> actual.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is UILinearGradientBrush))
                return false;

            return base.Equals(obj) && Angle.Equals(((UILinearGradientBrush)obj).Angle);
        }

        /// <summary>
        /// Obtiene un código hash de este objeto <see cref="UILinearGradientBrush"/>.
        /// </summary>
        public override int GetHashCode()
        {
            return base.GetHashCode() ^ Angle.GetHashCode();
        }

        #endregion

        #region Operator Overloading

        /// <summary>
        /// Comprueba si dos estructuras <see cref="UILinearGradientBrush"/> no son idénticas.
        /// </summary>
        /// <param name="brush1"> Primera estructura <see cref="UILinearGradientBrush"/> que se va a comparar.</param>
        /// <param name="brush2"> Segunda estructura <see cref="UILinearGradientBrush"/> que se va a comparar.</param>
        /// <returns> Es true si brush1 y brush2 no son iguales; en caso contrario, es false.</returns>
        public static bool operator !=(UILinearGradientBrush brush1, UILinearGradientBrush brush2)
        {
            return !brush1.Equals(brush2);
        }

        /// <summary>
        /// Comprueba si dos estructuras <see cref="UILinearGradientBrush"/> son idénticas.
        /// </summary>
        /// <param name="brush1"> Primera estructura <see cref="UILinearGradientBrush"/> que se va a comparar.</param>
        /// <param name="brush2"> Segunda estructura <see cref="UILinearGradientBrush"/> que se va a comparar.</param>
        /// <returns>
        /// Es true si brush1 y brush2 son totalmente idénticos; en caso contrario, es
        /// false.
        /// </returns>
        public static bool operator ==(UILinearGradientBrush brush1, UILinearGradientBrush brush2)
        {
            return brush1.Equals(brush2);
        }

        #endregion
    }
}