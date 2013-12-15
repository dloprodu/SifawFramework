/*
 * Sifaw.Controllers
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 14/12/2011: Creación de la clase.
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
using Sifaw.Views.Components;
using Sifaw.Views.Kit;


namespace Sifaw.Controllers
{
    /// <summary>
    /// Controladora base que provee de un patrón e infraestructura común a aquellas controladoras
    /// donde interviene un componente de interfaz de usuario.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Un componente de interfaz de usuario no puede mostrarse por si solo, en su lugar,
    /// ha de ser embebido por un <see cref="UIViewController{TInput, TOutput, TView}"/>.
    /// </para>
    /// </remarks>
    /// <typeparam name="TInput">
    /// Tipo para establecer los parámetros de inicio de la controladora. Ha de ser serializable y 
    /// derivar de <see cref="UIComponentController{TInput, TOutput, TComponent}.Input"/>.
    /// </typeparam>
    /// <typeparam name="TOutput">
    /// Tipo para establcer los parametros de retorno cuando finaliza la controladora. Ha de ser serializable y 
    /// derivar de <see cref="UIComponentController{TInput, TOutput, TComponent}.Output"/>.
    /// </typeparam>
    /// <typeparam name="TComponent">
    /// Tipo para establecer el elemento de interfaz de usuario de la controladora. Ha de implementar <see cref="UIComponent"/>.
    /// </typeparam>
    public abstract class UIComponentController<TInput, TOutput, TComponent> : UIElementController
        < TInput
        , TOutput
        , TComponent>
        , IUIComponentController
        where TInput     : UIComponentController<TInput, TOutput, TComponent>.Input
        where TOutput    : UIComponentController<TInput, TOutput, TComponent>.Output
        where TComponent : UIComponent
    {
        #region Input / Output

        /// <summary>
        /// Parámetros de entrada de las controladora.
        /// </summary>
        [Serializable]
        public new abstract class Input : UIElementController<TInput, TOutput, TComponent>.Input
        {
            #region Constructor

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIComponentController{TInput, TOutput, TComponent}.Input"/>.
            /// </summary>
            protected Input()
            {
            }

            #endregion
        }

        /// <summary>
        /// Parámetros de retorno de la controladora.
        /// </summary>
        [Serializable]
        public new abstract class Output : UIElementController<TInput, TOutput, TComponent>.Output
        {
            #region Constructor

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIComponentController{TInput, TOutput, TComponent}.Output"/>.
            /// </summary>
            protected Output()
            {
            }

            #endregion
        }

        #endregion

        #region Events

        /*
		 * Desencadenadores privados.
		 *  • Solo son lanzados por la controladora padre.
		 */

        /* Empty */

        /*
         * Desencadenadores protegidos.
         *  • Pueden ser lanzados por controladoras hijas.
         */

        /// <summary>
        /// Se produce cuando la controladora solicita mostrar un estado de espera.
        /// </summary>
        public event EventHandler BeginWaitState;

        /// <summary>
        /// Provoca el evento <see cref="BeginWaitState"/>.
        /// </summary>
        protected void OnBeginWaitState()
        {
            if (BeginWaitState != null)
                BeginWaitState(this, EventArgs.Empty);
        }

        /// <summary>
        /// Se produce cuando la controladora solicita finalizar el estado de espera.
        /// </summary>
        public event EventHandler FinalizeWaitState;

        /// <summary>
        /// Provoca el evento <see cref="FinalizeWaitState"/>.
        /// </summary>
        protected void OnFinalizeWaitState()
        {
            if (FinalizeWaitState != null)
                FinalizeWaitState(this, EventArgs.Empty);
        }

        /// <summary>
        /// Se produce cuando la controladora solicita mostrar un mensaje al usuario.
        /// </summary>
        public event CLShowInfoEventHandler ShowMessage;

        /// <summary>
        /// Provoca el evento <see cref="ShowMessage"/>.
        /// </summary>
        /// <param name="e"><see cref="Sifaw.Controllers.CLShowInfoEventArgs"/> que contiene los datos del evento.</param>
        protected void OnShowMessage(CLShowInfoEventArgs e)
        {
            if (ShowMessage != null)
                ShowMessage(this, e);
        }

        /// <summary>
        /// Se produce cuando la controladora solicita mostrar una advertencia al usuario.
        /// </summary>
        public event CLShowWarningEventHandler ShowWarning;

        /// <summary>
        /// Provoca el evento <see cref="ShowWarning"/>.
        /// </summary>
        /// <param name="e"><see cref="Sifaw.Controllers.CLShowWarningEventArgs"/> que contiene los datos del evento.</param>
        protected void OnShowWarning(CLShowWarningEventArgs e)
        {
            if (ShowWarning != null)
                ShowWarning(this, e);
        }

        /// <summary>
        /// Se produce cuando la controladora solicita mostrar un error al usuario.
        /// </summary>
        public event CLShowErrorEventHandler ShowError;

        /// <summary>
        /// Provoca el evento <see cref="ShowError"/>.
        /// </summary>
        /// <param name="e"><see cref="Sifaw.Controllers.CLShowErrorEventArgs"/> que contiene los datos del evento.</param>
        protected void OnShowError(CLShowErrorEventArgs e)
        {
            if (ShowError != null)
                ShowError(this, e);
        }

        /// <summary>
        /// Se produce cuando la controladora solicita una confirmación al usuario.
        /// </summary>
        public event CLConfirmMessageEventHandler ConfirmMessage;

        /// <summary>
        /// Provoca el evento <see cref="ConfirmMessage"/>.
        /// </summary>
        /// <param name="e"><see cref="Sifaw.Controllers.CLConfirmMessageEventArgs"/> que contiene los datos del evento.</param>
        protected void OnConfirmMessage(CLConfirmMessageEventArgs e)
        {
            if (ConfirmMessage != null)
                ConfirmMessage(this, e);
        }

        /*
         * Desencadenadores protegidos virtuales sin manejadores asociados.
         *  • Pueden ser sobreescritos por controladoras hijas para
         *    completar funcionalidad.
         */

        /* Empty */

        #endregion

        #region Properties

        /// <summary>
        /// Devuelve el contenedor de ajustes del elemento de interfaz a través
        /// del cual se puede modificar la configuración predeterminada.
        /// </summary>
        public new ComponentSettings UISettings
        {
            get { return UIElement.UISettings; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UIComponentController{TInput, TOutput, TComponent}"/>.
        /// Establece como <see cref="UILinker{TUIElement}"/> aquel establecido por defecto a través de 
        /// <see cref="UILinkersManager"/>.
        /// </summary>
        protected UIComponentController()
            : base()
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UIComponentController{TInput, TOutput, TComponent}"/>, 
        /// estableciendo el <see cref="UILinker{TUIElement}"/> especificado como valor de la propiedad 
        /// <see cref="UIElementController{TInput, TOutput, TUIElement}.Linker"/> donde <c>TUIElement</c> 
        /// implementa <see cref="UIComponent"/>.
        /// </summary>
        protected UIComponentController(UILinker<TComponent> linker)
            : base(linker)
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Devuelve una referencia del <see cref="UIComponent"/> de la controladora.
        /// </summary>
        public UIComponent GetUIComponent()
        {
            return UIElement;
        }

        #endregion

        #region UIElement Methods

        /// <summary>
        /// Invoca al método sobrescirto <see cref="UIElementController{TInput, TOutput, TComponent}.OnAfterUIElementCreate()"/>.
        /// </summary>
        protected override void OnAfterUIElementCreate()
        {
            base.OnAfterUIElementCreate();

            /* Default Settings... */
            UISettings.HorizontalAlignment = UIHorizontalAlignment.Fill;
            UISettings.VerticalAlignment = UIVerticalAlignment.Fill;

            /* Campos que se inicializan con la representación concreta del componente ... */
            // UISettings.Border
            // UISettings.BorderBrush

            /* Subscripción a eventos del componente... */
        }

        #endregion

        #region Start Methods

        /// <summary>
        /// Invoca al método sobrescirto <see cref="Controller{TInput, TOutput}.OnBeforeStartController()"/> y
        /// posteriormente se subscribe a eventos genéricos de componentes embebidos.
        /// </summary>
        protected override void OnBeforeStartController()
        {
            base.OnBeforeStartController();

            // Nos enganchamos a eventos de la controladoras hijas para propagarlos.
            // • Los eventos ShowMessage, ShowWarning, ShowError y ConfirmMessage han de ser propagados hasta que sean
            //   capturados por una controladora UIViewController que los gestione.
            foreach (IController controller in GetControllers())
            {
                if (controller is IUIComponentController)
                {
                    (controller as IUIComponentController).ShowMessage += new CLShowInfoEventHandler(UIComponentController_ShowMessage);
                    (controller as IUIComponentController).ShowWarning += new CLShowWarningEventHandler(UIComponentController_ShowWarning);
                    (controller as IUIComponentController).ShowError += new CLShowErrorEventHandler(UIComponentController_ShowError);
                    (controller as IUIComponentController).ConfirmMessage += new CLConfirmMessageEventHandler(UIComponentController_ConfirmMessage);
                }
            }
        }

        #endregion

        #region Finish Methods

        /// <summary>
        /// Invoca al método sobrescirto <see cref="Controller{TInput, TOutput}.OnBeforeFinishControllers(List{IController})"/> y
        /// posteriormente, si no ha sido cerrada ya, cierra la vista.
        /// </summary>
        protected override void OnBeforeFinishControllers(List<IController> children)
        {
            base.OnBeforeFinishControllers(children);

            // Nos enganchamos a eventos de la controladoras hijas para propagarlos.
            // • Los eventos ShowMessage, ShowWarning, ShowError y ConfirmMessage han de ser propagados hasta que sean
            //   capturados por una controladora UIViewController que los gestione.
            foreach (IController controller in GetControllers())
            {
                if (controller is IUIComponentController)
                {
                    (controller as IUIComponentController).ShowMessage -= new CLShowInfoEventHandler(UIComponentController_ShowMessage);
                    (controller as IUIComponentController).ShowWarning -= new CLShowWarningEventHandler(UIComponentController_ShowWarning);
                    (controller as IUIComponentController).ShowError -= new CLShowErrorEventHandler(UIComponentController_ShowError);
                    (controller as IUIComponentController).ConfirmMessage -= new CLConfirmMessageEventHandler(UIComponentController_ConfirmMessage);
                }
            }
        }

        #endregion

        #region Inclusions Events Handlers

        private void UIComponentController_ConfirmMessage(object sender, CLConfirmMessageEventArgs e)
        {
            OnConfirmMessage(e);
        }

        private void UIComponentController_ShowMessage(object sender, CLShowInfoEventArgs e)
        {
            OnShowMessage(e);
        }

        private void UIComponentController_ShowWarning(object sender, CLShowWarningEventArgs e)
        {
            OnShowWarning(e);
        }

        private void UIComponentController_ShowError(object sender, CLShowErrorEventArgs e)
        {
            OnShowError(e);
        }

        #endregion
    }
}