///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// Contiene la clase base a partir de la cual se deben implementar los gestores de menús de los
/// buscadores encargados de proporcionar los comandos ejecutables.
/// 
/// Diseñador:     David López Rguez
/// Programadores: David López Rguez
/// </sumary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 14/12/2011 -- Creación de la clase.
/// 
/// ===============================================================================================
/// Observaciones:
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



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