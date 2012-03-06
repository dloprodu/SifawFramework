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
	public interface BackgroundWorkerSettings : ComponentSettings
	{
		/// <summary>
		/// Obtiene o establece un valor que indica si el proceso
		/// se ejecuta con o sin control de seguimiento.
		/// </summary>
		bool WithControl { get; set; }

		/// <summary>
		/// Obtiene o establece un valor que indica si se permite
		/// cancelar el proceso.
		/// </summary>
		bool AllowCancel { get; set; }

		/// <summary>
		/// Obtiene o establece una descripción breve del proceso.
		/// </summary>
		string Summary { get; set; }

		/// <summary>
		/// Obtiene o establece una descripción del proceso.
		/// </summary>
		string ProcessDescription { get; set; }

		/// <summary>
		/// Obtiene o establece el texto a mostrar durante el progreso del
		/// proceso.
		/// </summary>
		string Progress { get; set; }

        /// <summary>
        /// Obtiene o establece un valor que indica el máximo progreso 
        /// del proceso.
        /// </summary>
		int MaxProgressPercentage { get; set; }
	}
}