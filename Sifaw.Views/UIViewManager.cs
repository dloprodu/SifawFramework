/*
 * Sifaw.Views
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 21/09/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Views;


namespace Sifaw.Views
{
    /// <summary>
    /// Administrador de vistas de la aplicación.
    /// </summary>
    public class UIViewManager
    {
        #region Fields

        /// <summary>
        /// Pila que actua a modo de registro de vistas activas.
        /// </summary>
        protected static Stack<UIView> Views = null;
        
        /// <summary>
        /// Almacena la refenrencia de la vista por defecto de la aplicación.
        /// </summary>
        private static UIView Default = null;
        
        #endregion

        #region Constructor

        static UIViewManager()
        {
            Views = new Stack<UIView>();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Establece la vista activa por defecto de la aplicación. Esta operación resetea la pila de vistas actual y establece
        /// la vista por defecto como primer elemento de la pila de vistas activas.
        /// </summary>
        /// <param name="view">Vista activa por defecto de la aplicación.</param>
        public static void SetDefaultView(UIView view)
        {
            Default = view;
            Views = new Stack<UIView>();
            
            if (Default != null)
                Views.Push(Default);
        }

        /// <summary>
        /// Devuelve la vista activa por defecto de la aplicación.
        /// </summary>
        public static UIView GetDefaultView()
        {
            return Default;        
        }

        /// <summary>
        /// Devuelve la vista activa actual de la aplicación.
        /// </summary>
        public static UIView GetCurrentView()
        {
            return Views.Peek();
        }

        #endregion
    }
}