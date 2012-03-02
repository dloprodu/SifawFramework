﻿/*
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
    }
}