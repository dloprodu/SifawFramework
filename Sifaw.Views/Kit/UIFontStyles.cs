/*
 * Sifaw.Views
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 04/10/2012: Creación de la clase.
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
    /// Especifica la información de estilo que se aplica al texto.
    /// </summary>
    [Flags]
    public enum UIFontStyles
    {
        /// <summary>
        /// Texto normal.
        /// </summary>
        Regular = 0,

        /// <summary>
        /// Texto en negrita.
        /// </summary>
        Bold = 1,

        /// <summary>
        /// Texto en cursiva.
        /// </summary>
        Italic = 2,

        /// <summary>
        /// Texto subrayado.
        /// </summary>
        Underline = 4,

        /// <summary>
        /// Texto con una línea que lo tacha.
        /// </summary>
        Strikeout = 8
    }
}