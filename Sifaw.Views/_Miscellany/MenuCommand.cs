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
    /// Se encargada de soportar los datos necesarios para una opción de menú a ser usada por
    /// la capa de presentación.
    /// </summary>
    public class MenuCommand
    {
        #region Fields
        
        /// <summary>
        /// Identificador usado para agrupar en conjuntos de comandos.
        /// </summary>
        public readonly int IdGroup;

        /// <summary>
        /// Identificador unívoco del comando asociado.
        /// </summary>
		public readonly int IdCommand;

        /// <summary>
        /// Descripción a mostrar asociada al comando.
        /// </summary>
		public readonly string Command;
        
        #endregion

        #region Constructors

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="MenuCommand"/>, estableciendo
		/// valores para los campos <see cref="IdGroup"/>, <see cref="IdCommand"/> y <see cref="Command"/>.
		/// </summary>
		/// <param name="idGroup">Valor que indica la agrupación del comando.</param>
		/// <param name="idCommand">Valor que indica el identificador del comando.</param>
		/// <param name="command">Nombre del comando.</param>
        public MenuCommand(int idGroup, int idCommand, string command)
        {
            IdGroup = idGroup;
            IdCommand = idCommand;
            Command = command;
        }

        #endregion
    }
}
