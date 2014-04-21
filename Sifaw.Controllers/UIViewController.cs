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
 * 
 * Observaciones:
 * 
 * Temas a considerar:
 *  1. Gestionar pila de vistas activas. <=> ¿Controladora ppal?
 *  
 *  2. Mecanismo para asegurar que las vistas (UI Controls) se abren y cierran en el hilo
 *     principal. Por si un subropceso lanza una UIViewController.
 *      • Implementar un ViewDispatcher que proporciones servicios para administrar mensajes 
 *        de las vistas en el proceso principal.
 *        
 */



using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Threading;

using Sifaw.Views;
using Sifaw.Core;
using Sifaw.Views.Kit;


namespace Sifaw.Controllers
{
    /// <summary>
    /// Controladora base que provee de un patrón e infraestructura común a aquellas controladoras
    /// donde intervienen una vista.
    /// </summary>
    /// <remarks>
    /// <para>
    /// La vistas solo deben de actuar a modo de contenedor de componentes <see cref="UIComponentController{TInput, TOutput, TComponent}"/>
    /// </para>
    /// <para>
    /// Esto implica que un <see cref="UIViewController{TInput, TOutput, TView}"/> actúa a modo de shell
    /// sobre uno o varios componentes <see cref="UIComponentController{TInput, TOutput, TComponent}"/> que se comunican entre si para
    /// dar forma a un componente mas complejo.
    /// </para>
    /// </remarks>
    /// <typeparam name="TInput">
    /// Tipo para establecer los parámetros de inicio de la controladora. Ha de ser serializable y 
    /// derivar de <see cref="UIViewController{TInput, TOutput, TView}.Input"/>.
    /// </typeparam>
    /// <typeparam name="TOutput">
    /// Tipo para establcer los parametros de retorno cuando finaliza la controladora. Ha de ser serializable y 
    /// derivar de <see cref="UIViewController{TInput, TOutput, TView}.Output"/>.
    /// </typeparam>
    /// <typeparam name="TView">
    /// Tipo para establecer el elemento de interfaz de usuario de la controladora. Ha de implementar <see cref="UIView"/>.
    /// </typeparam>
    public abstract class UIViewController<TInput, TOutput, TView> : UIElementController
        < TInput
        , TOutput
        , TView>
        , IUIViewController
        where TInput  : UIViewController<TInput, TOutput, TView>.Input
        where TOutput : UIViewController<TInput, TOutput, TView>.Output
        where TView   : UIView
    {
        #region Input / Output

        /// <summary>
        /// Parámetros de entrada de la controladora.
        /// </summary>
        [Serializable]
        public new abstract class Input : UIElementController<TInput, TOutput, TView>.Input
        {
            #region Fields

            private bool _showView = true;
            private bool _isModal = true;

            #endregion

            #region Properties

            /// <summary>
            /// Devuelve un valor que indica si se ha de mostrar la vista
            /// al iniciar la controladora.
            /// </summary>
            public bool ShowView
            {
                get { return _showView; }
            }

            /// <summary>
            /// Devuelve un valor que indica si la vista se muestra como modal, es decir, que hasta que no se
            /// cierre la aplicación no continua.
            /// </summary>
            public bool IsModal
            {
                get { return _isModal; }
            }

            #endregion

            #region Constructors

            /// <summary>
            /// Inicializa una nueva instancia de <see cref="UIViewController{TInput, TOutput, TView}.Input"/>, 
            /// estableciendo la propiedad <see cref="ShowView"/> a <c>true</c>.
            /// </summary>
            protected Input()
                : this(true, true)
            {
            }

            /// <summary>
            /// Inicializa una nueva instancia de <see cref="UIViewController{TInput, TOutput, TView}.Input"/>, 
            /// estableciendo un valor a la propiedad <see cref="ShowView"/>.
            /// </summary>
            /// <param name="showView">Indica si se muestra la vista al iniciar la controladora.</param>
            /// <param name="isModal">Indica si la vista es modal.</param>
            protected Input(bool showView, bool isModal)
                : base()
            {
                this._showView = showView;
                this._isModal = isModal;
            }

            #endregion
        }

        /// <summary>
        /// Parámetros de retorno de la controladora.
        /// </summary>
        [Serializable]
        public new abstract class Output : UIElementController<TInput, TOutput, TView>.Output
        {
            #region Constructor

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIViewController{TInput, TOutput, TView}.Output"/>.
            /// </summary>
            protected Output()
            {
            }

            #endregion
        }

        #endregion

        #region Fields

        [CLReseteable(false)]
        private bool autoClosing = false;

        [CLReseteable(0)]
        private int waiteStates = 0;

        #endregion

        #region Events

        /*
		 * Desencadenadores privados.
		 *  • Solo son lanzados por la controladora padre.
		 */

        /// <summary>
        /// Se produce cuando el usuario solicita desde la
        /// interfaz de usuario finalizar la controladora
        /// </summary>
        public event SFCancelEventHandler BeforeUIClose;

        /// <summary>
        /// <para>
        /// Se llama al método <see cref="OnBeforeUIClose"/> cuando el usuario solicita desde la
        /// interfaz de usuario finalizar la controladora. El método permite que las clases derivadas 
        /// controlen el evento sin asociar un delegado.
        /// </para>
        /// <para>
        /// El comportamiento por defecto no cancela la finalización de la controladora.
        /// </para>
        /// </summary>
        /// <remarks>
        /// Al reemplazar <see cref="OnBeforeUIClose"/> en una clase derivada, asegúrese de llamar al
        /// método <see cref="OnBeforeUIClose"/> de la clase base para que los delegados registrados 
        /// reciban el evento si desea mantener el comportamiento por defecto.
        /// </remarks>
        /// <param name="e">Valor que indica si la solicitud de finalización es cancelada.</param>
        private void OnBeforeUIClose(SFCancelEventArgs e)
        {
            if (BeforeUIClose != null)
                BeforeUIClose(this, e);
        }

        /*
         * Desencadenadores protegidos.
         *  • Pueden ser lanzados por controladoras hijas.
         */

        /* Empty */

        /*
         * Desencadenadores protegidos virtuales sin manejadores asociados.
         *  • Pueden ser sobreescritos por controladoras hijas para
         *    completar funcionalidad.
         */

        /// <summary>
        /// <para>
        /// Se llama al método <see cref="OnBeforeUIShow"/> justo antes de que la vista sea mostrada. 
        /// El método permite que las clases derivadas controlen el evento sin asociar un delegado.
        /// </para>
        /// </summary>
        /// <remarks>
        /// Al reemplazar <see cref="OnBeforeUIShow"/> en una clase derivada, asegúrese de llamar al
        /// método <see cref="OnBeforeUIShow"/> de la clase base para que los delegados registrados 
        /// reciban el evento si desea mantener el comportamiento por defecto.
        /// </remarks>
        protected virtual void OnBeforeUIShow()
        {
            /* Empty */
        }

        /// <summary>
        /// <para>
        /// Se llama al método <see cref="OnAfterUIShow"/> justo después de que la vista sea mostrada. 
        /// El método permite que las clases derivadas controlen el evento sin asociar un delegado.
        /// </para>
        /// </summary>
        /// <remarks>
        /// Al reemplazar <see cref="OnAfterUIShow"/> en una clase derivada, asegúrese de llamar al
        /// método <see cref="OnAfterUIShow"/> de la clase base para que los delegados registrados 
        /// reciban el evento si desea mantener el comportamiento por defecto.
        /// </remarks>
        protected virtual void OnAfterUIShow()
        {
            UIViewManagerExtension.SetActiveView(UIElement);
        }

        /// <summary>
        /// <para>
        /// Se llama al método <see cref="OnBeforeUIClose"/> cuando el usuario solicita desde la
        /// interfaz de usuario finalizar la controladora. El método permite que las clases derivadas 
        /// controlen el evento sin asociar un delegado.
        /// </para>
        /// <para>
        /// El comportamiento por defecto no cancela la finalización de la controladora.
        /// </para>
        /// </summary>
        /// <remarks>
        /// Al reemplazar <see cref="OnBeforeUIClose"/> en una clase derivada, asegúrese de llamar al
        /// método <see cref="OnBeforeUIClose"/> de la clase base para que los delegados registrados 
        /// reciban el evento si desea mantener el comportamiento por defecto.
        /// </remarks>
        /// <param name="cancel">Valor que indica si la solicitud de finalización es cancelada.</param>
        protected virtual void OnBeforeUIClose(out bool cancel)
        {
            cancel = false;
        }

        /// <summary>
        /// <para>
        /// Se llama al método <see cref="OnAfterUIClose"/> justo después de que la vista sea cerrada. 
        /// El método permite que las clases derivadas controlen el evento sin asociar un delegado.
        /// </para>
        /// </summary>
        /// <remarks>
        /// Al reemplazar <see cref="OnAfterUIClose"/> en una clase derivada, asegúrese de llamar al
        /// método <see cref="OnAfterUIClose"/> de la clase base para que los delegados registrados 
        /// reciban el evento si desea mantener el comportamiento por defecto.
        /// </remarks>
        private void OnAfterUIClose()
        {
            /* En este punto no podemo hacer referencia al elemento UIElement porque ya ha sido reseteado. */
            /* UIViewManagerExtension.RemoveActiveView(UIElement);                                         */
            /* Empty                                                                                       */
        }

        #endregion

        #region Properties

        /// <summary>
        /// Devuelve el contenedor de ajustes del elemento de interfaz a través
        /// del cual se puede modificar la configuración predeterminada.
        /// </summary>
        public new ViewSettings UISettings
        {
            get { return UIElement.UISettings; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UIViewController{TInput, TOutput, TView}"/>.
        /// Establece como <see cref="UILinker{TUIElement}"/> aquel establecido por defecto a través de 
        /// <see cref="UILinkersManager"/>.
        /// </summary>
        protected UIViewController()
            : base()
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UIViewController{TInput, TOutput, TView}"/>, 
        /// estableciendo el <see cref="UILinker{TUIElement}"/> especificado como valor de la propiedad 
        /// <see cref="UIElementController{TInput, TOutput, TUIElement}.Linker"/> donde <c>TUIElement</c> implementa
        /// <see cref="UIView"/>.
        /// </summary>
        protected UIViewController(UILinker<TView> linker)
            : base(linker)
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Muestra la vista.
        /// </summary>
        /// <remarks>
        /// Para invocar este método la controladora ha de estar iniciada, 
        /// en otro caso, devolverá una excepcion.
        /// </remarks>
        /// <exception cref="NotValidStateException">La controladora no está iniciada.</exception>
        public void Show()
        {
            CheckState(CLStates.Started);
            UIElement.Show(Parameters.IsModal);
        }

        /// <summary>
        /// Devuelve una referencia del <see cref="UIView"/> de la controladora.
        /// </summary>
        public UIView GetUIView()
        {
            return UIElement;
        }

        #endregion

        #region UIElement Methods

        /// <summary>
        /// Invoca al método sobrescirto <see cref="UIElementController{TInput, TOutput, TView}.OnAfterUIElementCreate()"/> y
        /// posteriormente se subscribe a eventos de <see cref="UIView"/>.
        /// </summary>
        protected override void OnAfterUIElementCreate()
        {
            base.OnAfterUIElementCreate();

            /* Default Settings... */
            UISettings.Header = "Sifaw Framework Application";
            UISettings.AllowResize = true;
            UISettings.Thumbnail = UIViewManagerExtension.Thumbnail;

            /* Subscripción a eventos de la vista... */
            UIElement.BeforeShow += new EventHandler(UIElement_BeforeShow);
            UIElement.AfterShow += new EventHandler(UIElement_AfterShow);
            UIElement.BeforeClose += new UIFinishRequestEventHandler(UIElement_BeforeClose);
            UIElement.AfterClose += new EventHandler(UIElement_AfterClose);
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
                    (controller as IUIComponentController).BeginWaitState += new EventHandler(UIViewController_BeginWaitSate);
                    (controller as IUIComponentController).FinalizeWaitState += new EventHandler(UIViewController_FinalizeWaitSate);
                    (controller as IUIComponentController).ShowMessage += new CLShowInfoEventHandler(UIComponentController_ShowMessage);
                    (controller as IUIComponentController).ShowWarning += new CLShowWarningEventHandler(UIComponentController_ShowWarning);
                    (controller as IUIComponentController).ShowError += new CLShowErrorEventHandler(UIComponentController_ShowError);
                    (controller as IUIComponentController).ConfirmMessage += new CLConfirmMessageEventHandler(UIComponentController_ConfirmMessage);
                }
            }
        }

        /// <summary>
        /// Invoca al método sobrescirto <see cref="Controller{TInput, TOutput}.OnAfterStartController()"/> y
        /// posteriormente muestra la vistá si <see cref="UIViewController{TInput, TOutput, TView}.Input.ShowView"/> 
        /// es <c>true</c>.
        /// </summary>
        protected override void OnAfterStartController()
        {
            base.OnAfterStartController();

            if (Parameters.ShowView)
                UIElement.Show(Parameters.IsModal);
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
                    (controller as IUIComponentController).BeginWaitState -= new EventHandler(UIViewController_BeginWaitSate);
                    (controller as IUIComponentController).FinalizeWaitState -= new EventHandler(UIViewController_FinalizeWaitSate);
                    (controller as IUIComponentController).ShowMessage -= new CLShowInfoEventHandler(UIComponentController_ShowMessage);
                    (controller as IUIComponentController).ShowWarning -= new CLShowWarningEventHandler(UIComponentController_ShowWarning);
                    (controller as IUIComponentController).ShowError -= new CLShowErrorEventHandler(UIComponentController_ShowError);
                    (controller as IUIComponentController).ConfirmMessage -= new CLConfirmMessageEventHandler(UIComponentController_ConfirmMessage);
                }
            }

            if (!autoClosing)
                UIElement.Close();
        }

        /// <summary>
        /// Invoca al método sobrescirto <see cref="Controller{TInput, TOutput}.OnBeforeResetController()"/> y
        /// posteriormente se elimina la vista del registro de vistas activas, antes de que sea reseteada.
        /// </summary>
        protected override void OnBeforeResetController()
        {
            base.OnBeforeResetController();

            UIViewManagerExtension.RemoveActiveView(UIElement);
        }

        #endregion

        #region UIElement Events Handlers

        private void UIElement_BeforeShow(object sender, EventArgs e)
        {
            OnBeforeUIShow();
        }

        private void UIElement_AfterShow(object sender, EventArgs e)
        {
            OnAfterUIShow();
        }

        private void UIElement_BeforeClose(object sender, UIFinishRequestEventArgs e)
        {
            SFCancelEventArgs args = new SFCancelEventArgs();
            OnBeforeUIClose(args);
            bool cancel = false;
            OnBeforeUIClose(out cancel);

            e.Cancel = args.Cancel || cancel;

            if (!e.Cancel)
            {
                autoClosing = e.IsClosing;
                Finish();
            }
        }

        private void UIElement_AfterClose(object sender, EventArgs e)
        {
            OnAfterUIClose();
        }

        #endregion

        #region Controllers Events Handler

        private void UIViewController_BeginWaitSate(object sender, EventArgs e)
        {
            this.waiteStates++;
            UIElement.BeginWaitState();
        }

        private void UIViewController_FinalizeWaitSate(object sender, EventArgs e)
        {
            if (this.waiteStates > 1)
            {
                this.waiteStates--;
                return;
            }

            this.waiteStates--;
            UIElement.FinalizeWaitState();
        }

        private void UIComponentController_ConfirmMessage(object sender, CLConfirmMessageEventArgs e)
        {
            e.Confirmed = UIElement.ConfirmMessage(e.Value);
        }

        private void UIComponentController_ShowMessage(object sender, CLShowInfoEventArgs e)
        {
            UIElement.ShowMessage(e.Value);
        }

        private void UIComponentController_ShowWarning(object sender, CLShowWarningEventArgs e)
        {
            UIElement.ShowWarning(e.Value);
        }

        private void UIComponentController_ShowError(object sender, CLShowErrorEventArgs e)
        {
            UIElement.ShowError(e.Value);
        }

        #endregion
    }
}