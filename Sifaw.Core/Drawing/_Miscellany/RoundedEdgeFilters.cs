/*
 * Sifaw.Core.Drawing
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 14/12/2011: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sifaw.Core.Drawing
{
    [Flags()]
    public enum RoundedEdgeFilters
    {
        None = 0,
        TopLeft = 1,
        TopRight = 2,
        BottomLeft = 4,
        BottomRight = 8,
        TopLeftAndRight = TopLeft | TopRight,
        BottonLeftAndRight = BottomLeft | BottomRight,
        All = TopLeftAndRight | BottonLeftAndRight
    }
}
