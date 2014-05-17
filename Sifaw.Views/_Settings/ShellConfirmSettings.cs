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


namespace Sifaw.Views
{
	/// <summary>
	/// Provee un conjunto de propiedades que permiten modificar la apariencia
	/// de un componente de interfaz de usuario.
	/// </summary>
    public interface ShellConfirmSettings : ComponentSettings
	{
        #region Properties

        /// <summary>
        /// Flag que permite indicar si se muestra la opción de cancelar la operación.
        /// </summary>
        bool IsCancelable { get; set; }

        #endregion
	}
}