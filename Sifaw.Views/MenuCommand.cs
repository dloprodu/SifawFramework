///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// Contiene el conjunto de estructuras encargadas de dar soporte a la generación dinámica de 
/// opciones de menús en los buscadores/selectores.
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
    /// Se encargada de soportar los datos necesarios para una opción de menú a ser usada por
    /// la capa de presentación.
    /// </summary>
    public class MenuCommand
    {
        #region Variables
        
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

        #region Constructor

        public MenuCommand(int idGroup, int idCommand, string command)
        {
            IdGroup = idGroup;
            IdCommand = idCommand;
            Command = command;
        }

        #endregion
    }
}
