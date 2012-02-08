///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// Contiene la clase base a partir de la cual se deben implementar los gestores de men�s de los
/// buscadores encargados de proporcionar los comandos ejecutables.
/// 
/// Dise�ador:     David L�pez Rguez
/// Programadores: David L�pez Rguez
/// </sumary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 14/12/2011 -- Creaci�n de la clase.
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