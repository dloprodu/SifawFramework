/*
 * Sifaw.Views.Components.Filters
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


namespace Sifaw.Views.Components.Filters
{
    /// <summary>
    /// Representa un componente para realizar filtros sobre un campo 
    /// de texto.
    /// </summary>
    public interface TextFilterComponent : FilterBaseComponent<string>
    {
        /// <summary>
        /// Obtiene el <see cref="TextFilterSettings"/> del <see cref="FilterBaseComponent{T}"/>.
        /// </summary>
        new TextFilterSettings UISettings { get; }
    }
}