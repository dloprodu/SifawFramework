/*
 * Sifaw.WPF.CCL
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 14/05/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sifaw.WPF.CCL
{
    /// <summary>
    /// Define los tipos de comportamiento a la hora de aplicar un
    /// tamaño a una columna de un objeto <see cref="DataTable"/>.
    /// </summary>
    public enum DataTableColumnTypesLenght
    {
        /// <summary>
        /// Columna de longitud fija.
        /// </summary>
        Fixed,

        /// <summary>
        /// Columna de longitud variable según el porcentaje indicado y el espacio disponible.
        /// </summary>
        Percentage
    }
}