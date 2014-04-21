/*
 * Sifaw.Controllers.Components
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
using System.Linq;
using System.Text;

using Sifaw.Core;
using Sifaw.Views;


namespace Sifaw.Controllers.Components
{
    /// <summary>
    /// Representa un paquete con información del componente a alojar en una vista tipo shell.
    /// </summary>
    [Serializable]
    public class ShellPack<GInput, GOutput, GComponent>
        where GInput     : UIComponentController<GInput, GOutput, GComponent>.Input
        where GOutput    : UIComponentController<GInput, GOutput, GComponent>.Output
        where GComponent : UIComponent
    {
        #region Fields

        private UIComponentController<GInput, GOutput, GComponent> _guest = null;
        private GInput _input = null;

        #endregion

        #region Properties

        /// <summary>
        /// Devuelve el compomente embebido.
        /// </summary>
        public UIComponentController<GInput, GOutput, GComponent> Guest
        {
            get { return _guest; }
        }

        /// <summary>
        /// Devuelve la entrada para el componnete embebido.
        /// </summary>
        public GInput Input
        {
            get { return _input; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="ShellPack"/>.
        /// </summary>
        /// <param name="guest">Componente que se va a alojar en la vista shell.</param>
        /// <param name="input">Entrada del componente que se va a alojar en la vista shell.</param>
        public ShellPack(UIComponentController<GInput, GOutput, GComponent> guest, GInput input)
        {
            _guest = guest;
            _input = input;
        }

        #endregion
    }
}
