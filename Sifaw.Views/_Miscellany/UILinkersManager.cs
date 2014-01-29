/*
 * Sifaw.Views
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 08/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Text;

using Sifaw.Views.Kit;


namespace Sifaw.Views
{
	/// <summary>
	/// Gestor encargado de almacenamiento y suministro del ViewLinker para las operaciones de 
	/// enlazado controlador - vista.
	/// </summary>
    public static class UILinkersManager
	{
        #region Fields

        private static List<object> _uiLinkers = new List<object>();

        #endregion

        #region Properties

        /// <summary>
        /// Devuelve el enlazador de vistas establecido por defecto para
        /// la aplicación.
        /// </summary>
        public static List<object> Linkers
        {
            get { return _uiLinkers; }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Establece el enlazador de elementos de interfaz de usuario.
        /// </summary>
        /// <param name="uiLinkers">Linker</param>
        public static void SetUIElementLinker(object uiLinkers)
        {
            _uiLinkers.Add(uiLinkers);
        }

        #endregion
	}
}