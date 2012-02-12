/*
 * Sifaw.Views
 * 
 * Dise�ador:   David L�pez Rguez
 * Programador: David L�pez Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 09/02/2012: Creaci�n de la clase.
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
    /// Patr�n a usar para implementar los gestores de men�s.
    /// </summary>
	public abstract class MenuCommandManager<TCommand> where TCommand : MenuCommand
    {
        /// <summary>
        /// Proporcionar� el conjunto de comandos ejecutables para un caso de uso.
        /// </summary>
		public abstract TCommand[] GetMenuCommands();
    }
}