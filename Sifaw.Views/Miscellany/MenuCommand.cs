///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// Contiene el conjunto de estructuras encargadas de dar soporte a la generaci�n din�mica de 
/// opciones de men�s en los buscadores/selectores.
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
    /// Se encargada de soportar los datos necesarios para una opci�n de men� a ser usada por
    /// la capa de presentaci�n.
    /// </summary>
    public class MenuCommand
    {
        #region Variables
        
        /// <summary>
        /// Identificador usado para agrupar en conjuntos de comandos.
        /// </summary>
        public readonly int IdGroup;

        /// <summary>
        /// Identificador un�voco del comando asociado.
        /// </summary>
		public readonly int IdCommand;

        /// <summary>
        /// Descripci�n a mostrar asociada al comando.
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
