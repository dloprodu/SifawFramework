﻿/*
 * Sifaw.Views
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

using Sifaw.Views.Kit;


namespace Sifaw.Views
{
	/// <summary>
	/// <para>
	/// Representa un componente tipo shell, con layout configurable, que
    /// permite alojar elementos <see cref="UIComponent"/> y permite al usario confirmar o cancelar
    /// una operación..
	/// </para>
	/// </summary>
    public interface ShellConfirmComponent : ShellComponent
    {
        #region Properties

        /// <summary>
        /// Obtiene el <see cref="ShellConfirmSettings"/> del <see cref="ShellConfirmComponent"/>.
        /// </summary>
        new ShellConfirmSettings UISettings { get; }

        #endregion

        #region Events

        /// <summary>
        /// Se produce cuando se solicita confirmar la acción.
        /// </summary>
        event EventHandler Confirm;

        /// <summary>
        /// Se produce cuando se solicita cancelar la acción.
        /// </summary>
        event EventHandler Cancel;

        #endregion
    }
}