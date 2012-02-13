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
	/// <summary>
	/// Define los bordes de un rectángulo donde se aplicará el redondeo.
	/// </summary>
    [Flags()]
    public enum RoundedEdgeFilters
    {
		/// <summary>
		/// No se aplica redondeo a ningún borde.
		/// </summary>
        None = 0,

		/// <summary>
		/// Se redondea la esquina superior izquierda.
		/// </summary>
        TopLeft = 1,

		/// <summary>
		/// Se redondea la esquina superior derecha.
		/// </summary>
        TopRight = 2,

		/// <summary>
		/// Se redondea la esquina inferior izquierda.
		/// </summary>
        BottomLeft = 4,

		/// <summary>
		/// Se redondea la esquina inferior derecha.
		/// </summary>
        BottomRight = 8,

		/// <summary>
		/// Se redondean las esquina superior izquierda y derecha.
		/// </summary>
        TopLeftAndRight = TopLeft | TopRight,

		/// <summary>
		/// Se redondean las esquinas inferior izquierda y derecha.
		/// </summary>
        BottonLeftAndRight = BottomLeft | BottomRight,

		/// <summary>
		/// Se redondean todas las esquinas del rectángulo.
		/// </summary>
        All = TopLeftAndRight | BottonLeftAndRight
    }
}
