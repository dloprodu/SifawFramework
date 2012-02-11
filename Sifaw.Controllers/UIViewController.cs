///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// Controladora base que provee de un patr�n e infraestructura com�n a aquellos casos de uso
/// con vistas.
/// 
/// Dise�ador:     David L�pez Rguez
/// Programadores: David L�pez Rguez
/// </sumary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 20/12/2011: Creaci�n de controladora.
/// 
/// ===============================================================================================
/// Observaciones:
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Threading;

using Sifaw.Views;
using Sifaw.Core;


namespace Sifaw.Controllers
{
    /*
     * Temas a considerar:
     *  1. Gestionar pila de vistas activas. <=> �Controladora ppal?
     *  
     *  2. Mecanismo para asegurar que las vistas (UI Controls) se abren y cierran en el hilo
     *     principal. Por si un subropceso lanza una UIViewController.
     *      � Implementar un ViewDispatcher que proporciones servicios para administrar mensajes 
     *        de las vistas en el proceso principal.
     *        
     *	3. �Como gestionar lo vistas modales, empotradas? 
     *	   �Seguir el esquema de 3 niveles (1� ppal, 2� sub, 3� edici�n)?
     *	    � En eKade ...
     *	      If TopLevel 
     *	         if Modal -> Cuadro de dialogo que no permite la interacci�n con otra vista
     *	            Show(vistaActiva)
     *	         else -> Si no es modal lo obligamos
     *	            ShowDialog(vistaActiva)
     *	      else -> No es un form de nivel superior
     *	         Show(vistaActiva)
     *	    � En Sifaw ...
     */


    /// <summary>
    /// Controladora base que provee de un patr�n e infraestructura com�n a aquellos casos de uso
    /// donde intervienen vistas.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Un <see cref="UIViewController"/> implementa un caso de uso donde interviene
    /// una vista. La vistas solo deben de actuar a modo de contenedor de componentes <see cref="UIComponentController"/>
    /// </para>
    /// <para>
    /// Esto implica que un <see cref="UIViewController"/> act�a a modo de shell
    /// sobre uno o varios componentes <see cref="UIComponentController"/> que se comunican entre si para
    /// componer un caso de uso mas complejo.
    /// </para>
    /// </remarks>
    /// <typeparam name="TInput">Tipo para establecer los par�metros de inicio de la controladora.</typeparam>
    /// <typeparam name="TOutput">Tipo para establcer los parametros de retorno cuando finaliza la controladora.</typeparam>
    /// <typeparam name="TUISettings">Tipo para establecer el proxy encargado de establecer los ajustes al elemento de interfaz de usuario.</typeparam>
    /// <typeparam name="TView">Tipo de la vista del controlador.</typeparam>
    public abstract class UIViewController<TInput, TOutput, TUISettings, TView>
        : UIElementController<TInput, TOutput, TUISettings, TView>
        , IUIViewController
        where TInput      : UIViewController<TInput, TOutput, TUISettings, TView>.Input
        where TOutput     : UIViewController<TInput, TOutput, TUISettings, TView>.Output
        where TUISettings : UIViewController<TInput, TOutput, TUISettings, TView>.UISettingsContainer
                          , new()
        where TView       : UIView
    {
        #region Input / Output

        /// <summary>
        /// Par�metros de entrada de la controladora.
        /// </summary>
        [Serializable]
        public new abstract class Input : UIElementController<TInput, TOutput, TUISettings, TView>.Input
        {
            #region Fields

            private bool _showView = true;

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

            #endregion

            #region Constructors

            protected Input()
                : this(true)
            {
            }

            protected Input(bool showView)
                : base()
            {
                this._showView = showView;
            }

            #endregion
        }

        /// <summary>
        /// Par�metros de retorno de la controladora.
        /// </summary>
        [Serializable]
        public new abstract class Output : UIElementController<TInput, TOutput, TUISettings, TView>.Output
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
        public new class UISettingsContainer : UIElementController<TInput, TOutput, TUISettings, TView>.UISettingsContainer
        {
            #region Fields

            private string _header;
            private double _width;
            private double _height;
            private bool _sizeToContent;

            #endregion

            #region Properties

            public string Header
            {
                get { return _header; }
                set { _header = value; }
            }

            public double Width
            {
                get { return _width; }
                set { _width = value; }
            }

            public double Height
            {
                get { return _height; }
                set { _height = value; }
            }

            public bool SizeToContent
            {
                get { return _sizeToContent; }
                set { _sizeToContent = value; }
            }

            #endregion

            #region Constructors

            public UISettingsContainer()
                : base()
            {
                this._header = "SifaWake Application";
                this._sizeToContent = false;
                this._width = -1.0f;
                this._height = -1.0f;
            }

            #endregion
        }

        #endregion

        #region Fields

        [CLReseteable(false)]
        private bool autoClosing = false;

        #endregion

        #region Events

        /*
		 * Desencadenadores privados.
		 *  � Solo son lanzados por la controladora padre.
		 */

        /* Empty */

        /*
         * Desencadenadores protegidos.
         *  � Pueden ser lanzados por controladoras hijas.
         */

        /* Empty */

        /*
         * Desencadenadores protegidos virtuales sin manejadores asociados.
         *  � Pueden ser sobreescritos por controladoras hijas para
         *    completar funcionalidad.
         */

        /// <summary>
        /// <para>
        /// Se llama al m�todo <see cref="OnBeforeUIShow"/> justo antes de que la vista sea mostrada. 
        /// El m�todo permite que las clases derivadas controlen el evento sin asociar un delegado.
        /// </para>
        /// </summary>
        /// <remarks>
        /// Al reemplazar <see cref="OnBeforeUIShow"/> en una clase derivada, aseg�rese de llamar al
        /// m�todo <see cref="OnBeforeUIShow"/> de la clase base para que los delegados registrados 
        /// reciban el evento si desea mantener el comportamiento por defecto.
        /// </remarks>
        protected virtual void OnBeforeUIShow()
        {
            /* Empty */
        }

        /// <summary>
        /// <para>
        /// Se llama al m�todo <see cref="OnAfterUIShow"/> justo despu�s de que la vista sea mostrada. 
        /// El m�todo permite que las clases derivadas controlen el evento sin asociar un delegado.
        /// </para>
        /// </summary>
        /// <remarks>
        /// Al reemplazar <see cref="OnAfterUIShow"/> en una clase derivada, aseg�rese de llamar al
        /// m�todo <see cref="OnAfterUIShow"/> de la clase base para que los delegados registrados 
        /// reciban el evento si desea mantener el comportamiento por defecto.
        /// </remarks>
        protected virtual void OnAfterUIShow()
        {
            /* Empty */
        }

        /// <summary>
        /// <para>
        /// Se llama al m�todo <see cref="OnBeforeUIClose"/> cuando el usuario solicita desde la
        /// interfaz de usuario finalizar la controladora. El m�todo permite que las clases derivadas 
        /// controlen el evento sin asociar un delegado.
        /// </para>
        /// <para>
        /// El comportamiento por defecto no cancela la finalizaci�n de la controladora.
        /// </para>
        /// </summary>
        /// <remarks>
        /// Al reemplazar <see cref="OnBeforeUIClose"/> en una clase derivada, aseg�rese de llamar al
        /// m�todo <see cref="OnBeforeUIClose"/> de la clase base para que los delegados registrados 
        /// reciban el evento si desea mantener el comportamiento por defecto.
        /// </remarks>
        /// <param name="cancel">Valor que indica si la solicitud de finalizaci�n es cancelada.</param>
        protected virtual void OnBeforeUIClose(out bool cancel)
        {
            cancel = false;
        }

        /// <summary>
        /// <para>
        /// Se llama al m�todo <see cref="OnAfterUIClose"/> justo despu�s de que la vista sea cerrada. 
        /// El m�todo permite que las clases derivadas controlen el evento sin asociar un delegado.
        /// </para>
        /// </summary>
        /// <remarks>
        /// Al reemplazar <see cref="OnAfterUIClose"/> en una clase derivada, aseg�rese de llamar al
        /// m�todo <see cref="OnAfterUIClose"/> de la clase base para que los delegados registrados 
        /// reciban el evento si desea mantener el comportamiento por defecto.
        /// </remarks>
        private void OnAfterUIClose()
        {
            /* Empty */
        }

        #endregion

        #region Constructors

        protected UIViewController()
            : base()
        {
        }

        protected UIViewController(AbstractUILinker<TView> linker)
            : base(linker)
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Muestra la vista.
        /// </summary>
        /// <remarks>
        /// Para invocar este m�todo la controladora ha de estar iniciada, 
        /// en otro caso, devolver� una excepcion.
        /// </remarks>
        /// <exception cref="NotValidStateException">La controladora no est� iniciada.</exception>
        public void Show()
        {
            CheckState(CLStates.Started);
            UIElement.Show();
        }

        #endregion

        #region UIElement Methods

        protected override void OnAfterUIElementLoad()
        {
            base.OnAfterUIElementLoad();

            /* Subscripci�n a eventos de la vista... */
            UIElement.BeforeShow += new EventHandler(UIElement_BeforeShow);
            UIElement.AfterShow += new EventHandler(UIElement_AfterShow);
            UIElement.BeforeClose += new UIFinishRequestEventHandler(UIElement_BeforeClose);
            UIElement.AfterClose += new EventHandler(UIElement_AfterClose);
        }

        protected override void OnApplyUISettings()
        {
            base.OnApplyUISettings();

            UIElement.Header = UISettings.Header;

            if (UISettings.Width >= 0)
                UIElement.Width = UISettings.Width;

            if (UISettings.Height >= 0)
                UIElement.Height = UISettings.Height;

            UIElement.SizeToContent = UISettings.SizeToContent;
        }

        #endregion

        #region Start Methods

        protected override void OnBeforeStartController()
        {
            base.OnBeforeStartController();

            // Nos enganchamos a eventos de la controladoras hijas para propagarlos.
            // � Los eventos ShowMessage, ShowWarning, ShowError y ConfirmMessage han de ser propagados hasta que sean
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

        protected override void OnAfterStartController()
        {
            base.OnAfterStartController();

            if (Parameters.ShowView)
                UIElement.Show();
        }

        #endregion

        #region Finish Methods

        protected override void OnBeforeFinishControllers(List<IController> children)
        {
            base.OnBeforeFinishControllers(children);

            if (!autoClosing)
                UIElement.Close();
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
            OnBeforeUIClose(out e.Cancel);

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