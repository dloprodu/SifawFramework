/*
 * Sifaw.Views.Kit
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 02/03/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sifaw.Views.Components
{
	/// <summary>
	/// Provee un conjunto de propiedades que permiten modificar la apariencia
	/// de un componente de interfaz de usuario.
	/// </summary>
	public interface TextFilterSettings : ComponentSettings
	{
        /// <summary>
        /// Obtiene o establece un valor que indica si se lanza el evento de búsquda de forma instantanea ante cualquier
        /// cambio o se retrasa hasta que se solicite de forma explícita.
        /// </summary>
        bool InstantSearch { get; set; }

        /// <summary>
        /// Obtiene o establece el placeholder, o texto de entrada, para el componente.
        /// </summary>
		string Placeholder { get; set; }
	}
}