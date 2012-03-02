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
    public class UILinearGradientBrush : UIGradientBrush
    {
        #region Fields

        private UIPoint _startPoint;
        private UIPoint _endPoint;

        #endregion

        #region Properties

        /// <summary>
        /// Obtiene o establece las coordenadas bidimensionales iniciales del degradado
        /// lineal. El valor predeterminado es (0, 0).
        /// </summary>
        public UIPoint StartPoint
        {
            get { return _startPoint; }
            set { _startPoint = value; }
        }

        /// <summary>
        /// Obtiene o establece las coordenadas bidimensionales finales del degradado
        /// lineal. El valor predeterminado es (1,1).
        /// </summary>
        public UIPoint EndPoint
        {
            get { return _endPoint; }
            set { _endPoint = value; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UILinearGradientBrush"/>.
        /// </summary>
        protected UILinearGradientBrush()
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

            return base.Equals(obj) 
                && StartPoint.Equals(((UILinearGradientBrush)obj).StartPoint)
                && EndPoint.Equals(((UILinearGradientBrush)obj).EndPoint);
        }

        /// <summary>
        /// Obtiene un código hash de este objeto <see cref="UILinearGradientBrush"/>.
        /// </summary>
        public override int GetHashCode()
        {
            return base.GetHashCode() ^ StartPoint.GetHashCode() ^ EndPoint.GetHashCode();
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