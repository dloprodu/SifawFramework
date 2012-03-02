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
    public abstract class UIGradientBrush : UIBrush
    {
        #region Fields

        private UIGradientStopCollection _gradientStops = null;

        #endregion

        #region Properties

        /// <summary>
        ///  Obtiene o establece los puntos de degradado del pincel.
        /// </summary>
        public UIGradientStopCollection GradientStops
        {
            get
            {
                if (_gradientStops == null)
                    _gradientStops = new UIGradientStopCollection();

                return _gradientStops;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UIGradientBrush"/>.
        /// </summary>
        protected UIGradientBrush()
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
            return GradientStops.ToString();
        }

        /// <summary>
        /// Determina si un objeto <see cref="UIGradientBrush"/> proporcionado es equivalente al objeto <see cref="UIGradientBrush"/> actual.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is UIGradientBrush))
                return false;

            return GradientStops.Equals(((UIGradientBrush)obj).GradientStops);
        }

        /// <summary>
        /// Obtiene un código hash de este objeto <see cref="UIGradientBrush"/>.
        /// </summary>
        public override int GetHashCode()
        {
            return GradientStops.GetHashCode();
        }

        #endregion

        #region Operator Overloading

        /// <summary>
        /// Comprueba si dos estructuras <see cref="UIGradientBrush"/> no son idénticas.
        /// </summary>
        /// <param name="brush1"> Primera estructura <see cref="UIGradientBrush"/> que se va a comparar.</param>
        /// <param name="brush2"> Segunda estructura <see cref="UIGradientBrush"/> que se va a comparar.</param>
        /// <returns> Es true si brush1 y brush2 no son iguales; en caso contrario, es false.</returns>
        public static bool operator !=(UIGradientBrush brush1, UIGradientBrush brush2)
        {
            return brush1.GradientStops != brush2.GradientStops;
        }

        /// <summary>
        /// Comprueba si dos estructuras <see cref="UIGradientBrush"/> son idénticas.
        /// </summary>
        /// <param name="brush1"> Primera estructura <see cref="UIGradientBrush"/> que se va a comparar.</param>
        /// <param name="brush2"> Segunda estructura <see cref="UIGradientBrush"/> que se va a comparar.</param>
        /// <returns>
        /// Es true si brush1 y brush2 son totalmente idénticos; en caso contrario, es
        /// false.
        /// </returns>
        public static bool operator ==(UIGradientBrush brush1, UIGradientBrush brush2)
        {
            return brush1.GradientStops == brush2.GradientStops;
        }

        #endregion
    }
}