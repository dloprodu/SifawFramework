///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// Controladora base que provee de un patrón e infraestructura común a aquellos casos de uso
/// que trabajan con componentes de interfaz de usuario.
/// 
/// Diseñador:     David López Rguez
/// Programadores: David López Rguez
/// </sumary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 20/12/2011: Creación de controladora.
/// 
/// ===============================================================================================
/// Observaciones:
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Views;
using Sifaw.Views.Components;
using Sifaw.Core;


namespace Sifaw.Controllers
{
    /// <summary>
    /// Controladora base que provee de un patrón e infraestructura común a aquellos casos de uso
    /// donde intervienen componentes de interfaz de usuario.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Un <see cref="UIComponentController<TInput, TOutput, TComponent>"/> implementa un caso de uso
    /// donde interviene un componente de UI. El componente de UI no puede mostrarse por si solo, en su lugar,
    /// ha de ser usado en un <see cref="UIViewController"/>.
    /// </para>
    /// </remarks>
    /// <typeparam name="TInput">Tipo para establecer los parámetros de inicio de la controladora.</typeparam>
    /// <typeparam name="TOutput">Tipo para establcer los parametros de retorno cuando finaliza la controladora.</typeparam>
    /// <typeparam name="TUISettings">Tipo para establecer el proxy encargado de establecer los ajustes al elemento de interfaz de usuario.</typeparam>
    /// <typeparam name="TComponent">Tipo del componente de UI del controlador.</typeparam>
    public abstract class UIComponentController<TInput, TOutput, TUISettings, TComponent>
        : UIElementController<TInput, TOutput, TUISettings, TComponent>
        , IUIComponentController
        where TInput      : UIComponentController<TInput, TOutput, TUISettings, TComponent>.Input
        where TOutput     : UIComponentController<TInput, TOutput, TUISettings, TComponent>.Output
        where TUISettings : UIComponentController<TInput, TOutput, TUISettings, TComponent>.UISettingsContainer
                          , new()
        where TComponent  : UIComponent
    {
        #region Input / Output

        /// <summary>
        /// Parámetros de entrada de las controladoras
        /// </summary>
        [Serializable]
        public new abstract class Input : UIElementController<TInput, TOutput, TUISettings, TComponent>.Input
        {
            #region Constructors

            protected Input()
                : base()
            {
            }

            #endregion
        }

        /// <summary>
        /// Parámetros de retorno de las controladoras
        /// </summary>
        [Serializable]
        public new abstract class Output : UIElementController<TInput, TOutput, TUISettings, TComponent>.Output
        {
            #region Constructors

            protected Output()
                : base()
            {
            }

            #endregion
        }

        #endregion

        #region Settings

        [Serializable]
        public new class UISettingsContainer : UIElementController
            < TInput
            , TOutput
            , TUISettings
            , TComponent>.UISettingsContainer
        {
            #region Constructors

            public UISettingsContainer()
                : base()
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
        /// Evento para comunicar que se debe mostrar un mensaje.
        /// </summary>
        public event CLShowInfoEventHandler ShowMessage;
        protected void OnShowMessage(CLShowInfoEventArgs e)
        {
            if (ShowMessage != null)
                ShowMessage(this, e);
        }

        /// <summary>
        /// Evento para comunicar que se debe mostrar una advertencia.
        /// </summary>
        public event CLShowWarningEventHandler ShowWarning;
        protected void OnShowWarning(CLShowWarningEventArgs e)
        {
            if (ShowWarning != null)
                ShowWarning(this, e);
        }

        /// <summary>
        /// Evento para comunicar un error.
        /// </summary>
        public event CLShowErrorEventHandler ShowError;
        protected void OnShowError(CLShowErrorEventArgs e)
        {
            if (ShowError != null)
                ShowError(this, e);
        }

        /// <summary>
        /// Evento para solicitar una confirmación para un mensaje dado.
        /// </summary>
        public event CLConfirmMessageEventHandler ConfirmMessage;
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

        #region Constructors

        protected UIComponentController()
            : base()
        {
        }

        protected UIComponentController(AbstractUILinker<TComponent> linker)
            : base(linker)
        {
        }

        #endregion

        #region Public Methods

        public UIComponent GetUIComponent()
        {
            return UIElement as UIComponent;
        }

        #endregion

        #region UIElement Methods

        protected override void OnAfterUIElementLoad()
        {
            base.OnAfterUIElementLoad();

            /* Subscripción a eventos del componente... */
        }

        protected override void OnApplyUISettings()
        {
            base.OnApplyUISettings();
        }

        #endregion

        #region Start Methods

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