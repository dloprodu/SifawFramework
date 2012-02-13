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
	/// </remarks>
	/// <typeparam name="TInput">
	/// Tipo para establecer los parámetros de inicio de la controladora. Ha de ser serializable y 
	/// derivar de <see cref="UIElementController{TInput, TOutput, TUISettings, TUIElement}.Input"/>.
	/// </typeparam>
	/// <typeparam name="TOutput">
	/// Tipo para establcer los parametros de retorno cuando finaliza la controladora. Ha de ser serializable y 
	/// derivar de <see cref="UIElementController{TInput, TOutput, TUISettings, TUIElement}.Output"/>.
	/// </typeparam>
	/// <typeparam name="TUISettings">
	/// Tipo para establecer el proxy encargado de establecer los ajustes en el elemento de interfaz de usuario. Ha de
	/// ser serializable, proveer de consturctor público y derivar de <see cref="UIElementController{TInput, TOutput, TUISettings, TUIElement}.UISettingsContainer"/>.
	/// </typeparam>
	/// <typeparam name="TUIElement">
	/// Tipo para establecer el elemento de interfaz de usuario de la controladora. Ha de implementar <see cref="UIElement"/>.
	/// </typeparam>
	public abstract class UIElementController<TInput, TOutput, TUISettings, TUIElement> 
		: Controller<TInput, TOutput>
		, IUIElementController
		where TInput      : UIElementController<TInput, TOutput, TUISettings, TUIElement>.Input
		where TOutput     : UIElementController<TInput, TOutput, TUISettings, TUIElement>.Output
		where TUISettings : UIElementController<TInput, TOutput, TUISettings, TUIElement>.UISettingsContainer
						  , new()
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
            /// Inicializa una nueva instancia de la clase <see cref="UIElementController{TInput, TOutput, TUISettings, TUIElement}.Input"/>.
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
            /// Inicializa una nueva instancia de la clase <see cref="UIElementController{TInput, TOutput, TUISettings, TUIElement}.Output"/>.
            /// </summary>
            protected Output()
            {
            }

            #endregion
        }

		#endregion

		#region Settings

		/// <summary>
		/// Contenedor de ajustes que hace de proxy entre controladoras y elementos de
		/// interfaz de usuario.
		/// </summary>
		/// <remarks>
		/// <para>
		/// El proxy es un intermediario que implica un recubrimiento de elementos de UI para
		/// evitar accesos a éstos desde fuera de la controladora.
		/// </para>
		/// <para> 
		/// Sigue el patón de diseño de Inyección de Dependencias (Dependency Injection, DI) para
		/// establecer los ajustes en la vista. Es un patrón de diseño en el que se suministran 
		/// objetos a una clase en lugar de ser la propia clase quien cree el objeto.
		/// </para>
		/// <para>
		/// En este contenedor se han de publicar aquellas propiedades
		/// del <see cref="UIElement"/> que se quiere que sean visibles desde fuera
		/// de la controladora.
		/// </para>
		/// <para>
		/// Las clases derivadas también pueden ocultar propiedades heredadas reemplazandolas con el 
		/// modificador de visibilidad private.
		/// </para>
		/// </remarks>
		[Serializable]
		public class UISettingsContainer
		{
			#region Fields

			private string _denomination;
			private string _description;
			private double _minWidth;
			private double _maxWidth;
			private double _minHeight;
			private double _maxHeight;

			#endregion

			#region Properties

			/// <summary>
			/// Devuelve o establece una denominación al componente.
			/// </summary>
			public string Denomination
			{
				get { return _denomination; }
				set { _denomination = value; }
			}

			/// <summary>
			/// Devuelve o establece una descripción al componente.
			/// </summary>
			public string Description
			{
				get { return _description; }
				set { _description = value; }
			}

			/// <summary>
			/// Devuelve o establece el ancho mínimo del componente.
			/// </summary>
			public double MinWidth
			{
				get { return _minWidth; }
				set { _minWidth = value; }
			}

			/// <summary>
			/// Devuelve o establece el ancho máximo del componente.
			/// </summary>
			public double MaxWidth
			{
				get { return _maxWidth; }
				set { _maxWidth = value; }
			}

			/// <summary>
			/// Devuelve o establece el alto mínimo del componente.
			/// </summary>
			public double MinHeight
			{
				get { return _minHeight; }
				set { _minHeight = value; }
			}

			/// <summary>
			/// Devuelve o establece el alto máximo del componente.
			/// </summary>
			public double MaxHeight
			{
				get { return _maxHeight; }
				set { _maxHeight = value; }
			}

			#endregion

			#region Events

			/// <summary>
			/// Se produce cuando se llama al método <see cref="UIElementController{TInput, TOutput, TUISettings, TUIElement}.UISettingsContainer.Apply()"/>
			/// </summary>
			public event EventHandler ApplyUISettings = null;
            private void OnApplyUISettings(EventArgs e)
			{
                if (ApplyUISettings != null)
                    ApplyUISettings(this, e);
			}

			#endregion

			#region Constructors

			/// <summary>
			/// Inicializa una nueva instancia de <see cref="UIElementController{TInput, TOutput, TUISettings, TUIElement}.UISettingsContainer"/>.
			/// </summary>
			public UISettingsContainer()
			{
				this._denomination = string.Empty;
				this._description = string.Empty;
				this._maxWidth = -1.0f;
				this._maxWidth = -1.0f;
				this._minHeight = -1.0f;
				this._maxHeight = -1.0f;
			}

			#endregion

			#region Public Methods

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UIElementController{TInput, TOutput, TUISettings, TUIElement}.UISettingsContainer"/>.
			/// </summary>
			public void Apply()
			{
                OnApplyUISettings(EventArgs.Empty);
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

		// Contenedor de configuración de la vista.
		[CLReseteable(null)]
		private TUISettings _uiSettings = default(TUISettings);

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

        /// <summary>
        /// <para>
        /// Se llama al método <see cref="OnBeforeApplyUISettings"/> antes de aplicar la 
        /// configuración al elemento de interfaz <see cref="UIElement"/>. 
        /// El método permite que las clases derivadas controlen el evento sin asociar un delegado.
        /// </para>
        /// <para>
        /// Este métodos permite que las clases derivadas realicen operaciones de 
        /// configuración tales como suscribirse a eventos de la vista.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Al reemplazar <see cref="OnBeforeApplyUISettings"/> en una clase derivada, asegúrese de llamar al
        /// método <see cref="OnBeforeApplyUISettings"/> de la clase base para que los delegados registrados 
        /// reciban el evento.
        /// </para>
        /// </remarks>
        protected virtual void OnBeforeApplyUISettings()
        {
            /* Empty */
        }

        /// <summary>
        /// <para>
        /// Se llama al método <see cref="OnApplyUISettings"/> cuando se aplican los ajustes establecidos
        /// al elemento de interfaz de usuario.
        /// </para>
        /// <para>
        /// El método permite aplicar los ajustes de <see cref="UISettings"/> a la interfaz de usuario y a 
        /// elementos de interfaz de usuario de controladoras embebidas.
        /// </para>
        /// </summary>
        /// <remarks>
        /// <para>
        /// Al reemplazar <see cref="OnApplyUISettings"/> en una clase derivada, asegúrese de llamar al
        /// método <see cref="OnApplyUISettings"/> de la clase base para que los delegados registrados 
        /// reciban el evento.
        /// </para>
        /// </remarks>
        protected virtual void OnApplyUISettings()
        {
            this.UIElement.Denomination = UISettings.Denomination;
            this.UIElement.Description = UISettings.Description;

            if (UISettings.MinWidth >= 0.0f)
                this.UIElement.MinWidth = UISettings.MinWidth;

            if (UISettings.MaxHeight >= 0.0f)
                this.UIElement.MaxWidth = UISettings.MaxWidth;

            if (UISettings.MinHeight >= 0.0f)
                this.UIElement.MinHeight = UISettings.MinHeight;

            if (UISettings.MaxHeight >= 0.0f)
                this.UIElement.MaxHeight = UISettings.MaxHeight;
        }

        /// <summary>
		/// <para>
        /// Se llama al método <see cref="OnAfterApplyUISettings"/> después de aplicar la 
        /// configuración al elemento de interfaz <see cref="UIElement"/>. 
        /// El método permite que las clases derivadas controlen el evento sin asociar un delegado.
		/// </para>
		/// <para>
		/// Este métodos permite que las clases derivadas realicen operaciones de 
		/// configuración tales como suscribirse a eventos de la vista.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
        /// Al reemplazar <see cref="OnAfterApplyUISettings"/> en una clase derivada, asegúrese de llamar al
        /// método <see cref="OnAfterApplyUISettings"/> de la clase base para que los delegados registrados 
		/// reciban el evento.
		/// </para>
		/// </remarks>
		protected virtual void OnAfterApplyUISettings()
        {
            /* Empty */
        }

		#endregion

		#region Properties

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
					Linker.Get(out _uiElement);

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
		/// Devuelve el contenedor de ajustes de la vista a través
		/// del cual se puede modificar la configuración predeterminada.
		/// </summary>
		public TUISettings UISettings
		{
			get
			{
				if (_uiSettings == null)
				{
					_uiSettings = new TUISettings();
					_uiSettings.ApplyUISettings += new EventHandler(_uiSettings_ApplyUISettings);
				}

				return _uiSettings;
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

		#endregion

		#region Constructors

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIElementController{TInput, TOutput, TUISettings, TUIElement}"/>.
		/// Establece como <see cref="AbstractUILinker{TUIElement}"/> aquel establecido por defecto a través de 
		/// <see cref="AbstractUIProviderManager{TLinker}"/>.
		/// </summary>
		protected UIElementController()
			: this((AbstractUILinker<TUIElement>)null)
		{
		}

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIElementController{TInput, TOutput, TUISettings, TUIElement}"/>, 
		/// estableciendo un valor en la propiedad <see cref="Linker"/>.
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
		/// Invoca al método sobrescirto <see cref="Controller{TInput, TOutput}.OnAfterStartController()"/>
		/// y posteriormente al método <see cref="UISettingsContainer.Apply()"/> del contenedor de ajustes
		/// <see cref="UISettings"/> applicando la configuración sobre <see cref="UIElement"/>.
		/// </summary>
        protected override void OnAfterStartController()
        {
            base.OnAfterStartController();

            // Se aplica la configuración inicial despues de iniciar el componente.
            UISettings.Apply();
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

        #region UISettings Events Handlers

        private void _uiSettings_ApplyUISettings(object sender, EventArgs e)
		{
            OnBeforeApplyUISettings();
			OnApplyUISettings();
            OnAfterApplyUISettings();
		}

		#endregion
	}
}