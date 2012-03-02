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
    public class UIGradientBrush : UIBrush
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
    }
}