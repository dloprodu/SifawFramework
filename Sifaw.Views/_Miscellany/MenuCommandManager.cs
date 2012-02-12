/*
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
using System.Text;


namespace Sifaw.Views
{
    /// <summary>
    /// Patrón a usar para implementar los gestores de menús.
    /// </summary>
	public abstract class MenuCommandManager<TCommand> where TCommand : MenuCommand
    {
        /// <summary>
        /// Proporcionará el conjunto de comandos ejecutables para un caso de uso.
        /// </summary>
		public abstract TCommand[] GetMenuCommands();
    }
}