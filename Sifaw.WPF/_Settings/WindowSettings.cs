/*
 * Sifaw.WPF
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 03/03/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

using Sifaw.Views;


namespace Sifaw.WPF
{
    public class WindowSettings : ViewSettings
    {
        #region Constructor

        public WindowSettings(Window window)
        {
            SettingsOperationsManager.SettingsDataBinding(this, window);
        }

        #endregion

    }
}