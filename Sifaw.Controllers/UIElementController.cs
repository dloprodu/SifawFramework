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
using System.Reflection;
using System.Diagnostics.Contracts;

using Sifaw.Core;
using Sifaw.Views;
using Sifaw.Views.Kit;


namespace Sifaw.Controllers
{
	/// <summary>
    /// Controladora base que provee de un patrón e infraestructura común para aquellas controladoras
    /// donde interviene un elemento de interfaz de usuario.
	/// </summary>
	/// <remarks>
	/// <para>
	/// La controladora obtiene la instancia de su elemento de interfaz de usuario a través de la interfaz
	/// <see cref="AbstractUILinker{TUIElement}"/>. Este enlazador de elementos de interfaz se le pasa a la 
	/// controladora cuando es instanciada.
	/// </para>
	/// <para>
	/// Los ajustes sobre el elemento de interfaz de usuario se establecen mediante la propiedad <see cref="UISettings"/> que actúa a
	/// modo de proxy entre la controladora y el <see cref="UIElement"/>.
	/// </para>
	/// <para>
	/// Como norma de buenas prácticas es deseable que las propiedades de <see cref="UISettings"/> sean seteables de modo que la configuración
	/// del elemento de interfaz de usuario pueda ser actualizada.
	/// </para>
	/// </remarks>
	/// <typeparam name="TInput">
	/// Tipo para establecer los parámetros de inicio de la controladora. Ha de ser serializable y 
	/// derivar de <see cref="UIElementController{TInput, TOutput, TUIElement}.Input"/>.
	/// </typeparam>
	/// <typeparam name="TOutput">
	/// Tipo para establcer los parametros de retorno cuando finaliza la controladora. Ha de ser serializable y 
	/// derivar de <see cref="UIElementController{TInput, TOutput, TUIElement}.Output"/>.
	/// </typeparam>
	/// <typeparam name="TUIElement">
	/// Tipo para establecer el elemento de interfaz de usuario de la controladora. Ha de implementar <see cref="UIElement"/>.
	/// </typeparam>
	public abstract class UIElementController<TInput, TOutput, TUIElement> 
		: Controller<TInput, TOutput>
		, IUIElementController
		where TInput      : UIElementController<TInput, TOutput, TUIElement>.Input
		where TOutput     : UIElementController<TInput, TOutput, TUIElement>.Output
		where TUIElement  : UIElement
	{
		#region Input / Output

		/// <summary>
		/// Parámetros de entrada de la controladora.
		/// </summary>
		[Serializable]
		public new abstract class Input : Controller<TInput, TOutput>.Input
		{
            #region Constructor

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIElementController{TInput, TOutput, TUIElement}.Input"/>.
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
		public new abstract class Output : Controller<TInput, TOutput>.Output
		{
            #region Constructor

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIElementController{TInput, TOutput, TUIElement}.Output"/>.
            /// </summary>
            protected Output()
            {
            }

            #endregion
        }

		#endregion

		#region Fields

		/*
		 * No reseteables
		 */

		// Enlazador para la carga de la vista.
        // No es un campo reseteable.
		private readonly AbstractUILinker<TUIElement> _linker = null;

		/*
		 * Reseteables
		 */

		// Elemento de UI
        [CLReseteable(null)]
        private TUIElement _uiElement = default(TUIElement);

		#endregion

		#region Events

		/*
		 * Desencadenadores privados.
		 *  • Solo son lanzados por la controladora padre.
		 */

		/// <summary>
		/// Se produce cuando <see cref="UIElement"/> se ha cargado.
		/// </summary>
		public event EventHandler UIElementLoaded;
		private void OnUIElementLoaded(EventArgs e)
		{
			if (UIElementLoaded != null)
				UIElementLoaded(this, e);
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
		/// Se llama al método <see cref="OnBeforeUIElementLoad"/> antes de cargar el elemento 
		/// gráfico por primera vez. El método permite que las clases derivadas 
		/// controlen el evento sin asociar un delegado.
		/// </summary>
		/// <remarks>
		/// Al reemplazar <see cref="OnBeforeUIElementLoad"/> en una clase derivada, asegúrese de llamar al
		/// método <see cref="OnBeforeUIElementLoad"/> de la clase base para que los delegados registrados 
		/// reciban el evento.
		/// </remarks>
		protected virtual void OnBeforeUIElementLoad()
		{
			/* Emtpy */
		}

		/// <summary>
		/// <para>
		/// Se llama al método <see cref="OnAfterUIElementLoad"/> después de cargar el elemento 
		/// gráfico por primera vez. El método permite que las clases derivadas 
		/// controlen el evento sin asociar un delegado.
		/// </para>
		/// <para>
		/// Este métodos permite que las clases derivadas realicen operaciones de 
		/// configuración tales como suscribirse a eventos de la vista.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Al reemplazar <see cref="OnAfterUIElementLoad"/> en una clase derivada, asegúrese de llamar al
		/// método <see cref="OnAfterUIElementLoad"/> de la clase base para que los delegados registrados 
		/// reciban el evento.
		/// </para>
		/// </remarks>
		protected virtual void OnAfterUIElementLoad()
		{
			/* Empty */
		}
        
		#endregion

		#region Properties

		/*
		 * Protected
		 */

		/// <summary>
		/// Devuelve el elemento de interfaz de usuario de la controladora.
		/// </summary>
		protected TUIElement UIElement
		{
			get
			{
				if (_uiElement == null)
				{
					OnBeforeUIElementLoad();
					Linker.Load(out _uiElement);

					if (_uiElement != null)
					{
						OnAfterUIElementLoad();
						OnUIElementLoaded(EventArgs.Empty);
					}
				}

				if (_uiElement == null)
					throw new AbstractUILinkerNullException();
				
				return _uiElement;
			}
		}

		/// <summary>
		/// Devuelve una instancia de <see cref="AbstractUILinker{TUIElement}"/> a través de la cual
		/// se carga la propiedad <see cref="UIElement"/>.
		/// </summary>
		protected AbstractUILinker<TUIElement> Linker
		{
			get { return _linker ?? AbstractUIProviderManager<AbstractUIProvider>.Linker as AbstractUILinker<TUIElement>; }
		}

		/*
		 * Public
		 */

		/// <summary>
		/// Devuelve el contenedor de ajustes del elemento de interfaz a través
		/// del cual se puede modificar la configuración predeterminada.
		/// </summary>
		public UISettings UISettings
		{
			get { return UIElement.UISettings; }
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIElementController{TInput, TOutput, TUIElement}"/>.
		/// Establece como <see cref="AbstractUILinker{TUIElement}"/> aquel establecido por defecto a través de 
		/// <see cref="AbstractUIProviderManager{TLinker}"/>.
		/// </summary>
		protected UIElementController()
			: this((AbstractUILinker<TUIElement>)null)
		{
		}

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIElementController{TInput, TOutput, TUIElement}"/>, 
		/// estableciendo el <see cref="AbstractUILinker{TUIElement}"/> especificado como valor de la propiedad <see cref="Linker"/>
		/// donde <c>TUIElement</c> implementa <see cref="UIElement"/>.
		/// </summary>
		protected UIElementController(AbstractUILinker<TUIElement> linker)
			: base()
		{
			this._linker = linker;
		}

		#endregion

        #region Public Methods

        /// <summary>
        /// Activa el elemento de UI de la controladora proporcionandole
        /// el foco.
        /// </summary>
        /// <remarks>
        /// Para invocar este método la controladora ha de estar iniciada, 
        /// en otro caso, devolverá una excepcion.
        /// </remarks>
		/// <exception cref="NotValidStateException">La controladora no está iniciada.</exception>
        public void SetLikeActive()
        {
            CheckState(CLStates.Started);
            UIElement.SetLikeActive();
        }

        #endregion

        #region Start Methods

		/// <summary>
		/// Invoca al método sobrescirto <see cref="Controller{TInput, TOutput}.OnBeforeStartController()"/> y
		/// posteriormente fuerza la carga de los ajustes del elemento de interfaz.
		/// </summary>
        protected override void OnBeforeStartController()
        {
            base.OnBeforeStartController();

            /* Forzamos la carga de la configuración. */
            if (UISettings == null)
                throw new UISettingsNullException();
        }

        #endregion

        #region Finish Methods

        /// <summary>
		/// Invoca al método sobrescirto <see cref="Controller{TInput, TOutput}.OnBeforeFinishControllers(List{IController})"/>
		/// y posteriormente al método <see cref="Sifaw.Views.UIElement.Reset()"/> de <see cref="UIElement"/>.
		/// </summary>
		protected override void OnBeforeFinishControllers(List<IController> children)
		{
			base.OnBeforeFinishControllers(children);

			UIElement.Reset();
		}

		/// <summary>
		/// Invoca al método sobrescirto <see cref="Controller{TInput, TOutput}.OnBeforeResetFields(List{FieldInfo})"/>.
		/// </summary>
		protected override void OnBeforeResetFields(List<FieldInfo> fields)
		{
			base.OnBeforeResetFields(fields);
			
			// No se permite mas de un elemento de UI por
			// controladora
		}

		#endregion
	}
}