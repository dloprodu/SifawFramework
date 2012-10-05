/*
 * Sifaw.Views
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 05/10/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sifaw.Views.Kit
{
    /// <summary>
    /// Especifica de la anchura que se aplica a la letra.
    /// </summary>
    [Flags]
    public enum UIFontWeights
    {
        /// <summary>
        /// Especifica un grosor de fuente normal.
        /// </summary>
        Normal = 0,

        /// <summary>
        /// Especifica un grosor de fuente negrita.
        /// </summary>
        Bold = 1,

        /// <summary>
        /// Especifica un grosor de fuente fino.
        /// </summary>
        Thin = 2,
    }
}