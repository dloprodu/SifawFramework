///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// Controladora base que provee de un patrón e infraestructura común a aquellos casos de uso
/// con que interactuan con un elemento de interfaz de usuario.
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
using System.Reflection;
using System.Diagnostics.Contracts;

using Sifaw.Views;
using Sifaw.Core;


namespace Sifaw.Controllers
{
	/// <summary>
	/// Define el método para enlazar el componente de interfaz de usuario con su correspondiente instancia
	/// en la capa de presentación.
	/// </summary>
	/// <remarks>
	/// Sigue el patrón de diseño 'Abstract Factory (Fábrica abstractra)' para crear
	/// interfaces gráficas.
	/// </remarks>
	public interface AbstractUILinker<TUIElement>
		where TUIElement : UIElement
	{
		void Get(out TUIElement ui);
	}

	/// <summary>
	/// Controladora base que provee de un patrón y funcionalidad para aquellos casos de uso
	/// donde intervienen elementos de interfaz de usuario.
	/// </summary>
	/// <remarks>
	/// <para>
	/// La controladora al finalizar reseteará automáticamente los elementos de
	/// interfaz de usuario.
	/// </para>
	/// </remarks>
	/// <typeparam name="TInput">Tipo para establecer los parámetros de inicio de la controladora. Ha de ser serializable.</typeparam>
	/// <typeparam name="TOutput">Tipo para establcer los parametros de retorno cuando finaliza la controladora. Ha de ser serializable.</typeparam>
	/// <typeparam name="TUISettings">Tipo para establecer el proxy encargado de establecer los ajustes al elemento de interfaz de usuario.</typeparam>
	/// <typeparam name="TUIElement">Tipo para establecer el elemento de UI de la controladora.</typeparam>
	public abstract class UIElementController<TInput, TOutput, TUISettings, TUIElement> 
		: Controller<TInput, TOutput>
		, IUIElementController
		where TInput      : UIElementController<TInput, TOutput, TUISettings, TUIElement>.Input
		where TOutput     : UIElementController<TInput, TOutput, TUISettings, TUIElement>.Output
		where TUISettings : UIElementController<TInput, TOutput, TUISettings, TUIElement>.UISettingsContainer<TUIElement>
						  , new()
		where TUIElement  : UIElement
	{
		#region Entrada / Salida

		/// <summary>
		/// Parámetros de entrada de la controladora.
		/// </summary>
		[Serializable]
		public new abstract class Input : Controller<TInput, TOutput>.Input
		{
			#region Constructor

			protected Input()
				: base()
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

			protected Output()
				: base()
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
		/// del <see cref="TUIElement"/> que se quiere que sean visibles desde fuera
		/// de la controladora.
		/// </para>
		/// <para>
		/// Las clases derivadas también pueden ocultar propiedades heredadas reemplazandolas con el 
		/// modificador de visibilidad private.
		/// </para>
		/// </remarks>
		[Serializable]
		public class UISettingsContainer<TUI>
			where TUI : TUIElement
		{
			/// <summary>
			/// Referencia a la vista de la controladora.
			/// </summary>
			protected TUI UIElement = default(TUI);

			#region Variables

			private string _denomination;
			private string _description;
			private double _minWidth;
			private double _maxWidth;
			private double _minHeight;
			private double _maxHeight;

			#endregion

			#region Propiedades

			public string Denomination
			{
				get { return _denomination; }
				set { _denomination = value; }
			}

			public string Description
			{
				get { return _description; }
				set { _description = value; }
			}

			public double MinWidth
			{
				get { return _minWidth; }
				set { _minWidth = value; }
			}

			public double MaxWidth
			{
				get { return _maxWidth; }
				set { _maxWidth = value; }
			}

			public double MinHeight
			{
				get { return _minHeight; }
				set { _minHeight = value; }
			}

			public double MaxHeight
			{
				get { return _maxHeight; }
				set { _maxHeight = value; }
			}

			#endregion

			#region Eventos

			public event EventHandler UISettingsApplied = null;
			private void OnUISettingsApplied(EventArgs e)
			{
				if (UISettingsApplied != null)
					UISettingsApplied(this, e);
			}

			#endregion

			#region Constructor

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

			#region Métodos públicos

			protected internal void SetUIElement(TUI uiElement)
			{
				UIElement = uiElement;
			}

			public virtual void Apply()
			{
				OnUISettingsApplied(EventArgs.Empty);

				this.UIElement.Denomination = Denomination;
				this.UIElement.Description = Description;
				
				if (MinWidth >= 0.0f)
					this.UIElement.MinWidth = MinWidth;
				
				if (MaxHeight >= 0.0f)
					this.UIElement.MaxWidth = MaxWidth;
				
				if (MinHeight >= 0.0f)
					this.UIElement.MinHeight = MinHeight;
				
				if (MaxHeight >= 0.0f)
					this.UIElement.MaxHeight = MaxHeight;
			}

			#endregion
		}

		#endregion

		#region Variables

		/*
		 * No reseteables
		 */

		// Enlazador para la carga de la vista.
		private readonly AbstractUILinker<TUIElement> _linker = null;

		/*
		 * Reseteables
		 */

		// Vista de la controladora.
		// No hace falta marcarlos como CtrlReseteable porque
		// la controladora resetea automaticamente todas las vistas
		// declaradas.
		private TUIElement _uiElement = default(TUIElement);

		// Contenedor de configuración de la vista.
		[CtrlReseteable(null)]
		private TUISettings _uiSettings = default(TUISettings);

		#endregion

		#region Eventos

		/*
		 * Desencadenadores privados.
		 *  • Solo son lanzados por la controladora padre.
		 */

		/// <summary>
		/// Evento lanzado cuando se carga la vista por primera vez.
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
		/// Se llama al método <see cref="OnUISettingsApplied"/> cuando se aplican los ajustes establecidos
		/// al elemento de interfaz de usuario.
		/// </para>
		/// <para>
		/// El método permite aplicar estos ajustes a elementos de interfaz
		/// de usuario de controladoras incluidas.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Al reemplazar <see cref="OnUISettingsApplied"/> en una clase derivada, asegúrese de llamar al
		/// método <see cref="OnUISettingsApplied"/> de la clase base para que los delegados registrados 
		/// reciban el evento.
		/// </para>
		/// </remarks>
		protected virtual void OnUISettingsApplied()
		{
			/* Empty */
		}

		#endregion

		#region UIElement

		/// <summary>
		/// Devuelve el elemento UI de la controladora.
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
					_uiSettings.SetUIElement(UIElement);
					_uiSettings.UISettingsApplied += new EventHandler(_uiSettings_UISettingsApplied);
				}

				return _uiSettings;
			}
		}

		/// <summary>
		/// Devuelve una instancia de <see cref="AbstractUIElementLinker"/> a través de la cual
		/// se carga la vista.
		/// </summary>
		protected AbstractUILinker<TUIElement> Linker
		{
			get { return _linker ?? AbstractUIProviderManager<AbstractUIProvider>.Linker as AbstractUILinker<TUIElement>; }
		}

		#endregion

		#region Constructor

		protected UIElementController()
			: this((AbstractUILinker<TUIElement>)null)
		{
		}

		protected UIElementController(AbstractUILinker<TUIElement> linker)
			: base()
		{
			this._linker = linker;
		}

		#endregion

		#region Métodos públicos

		/// <summary>
		/// Activa el elemento de UI de la controladora proporcionandole
		/// el foco.
		/// 
		/// Para invocar este método la controladora ha de estar iniciada, 
		/// en otro caso, devolverá una excepcion.
		/// </remarks>
		/// <exception cref="NotValidCtrlStateException">La controladora no está iniciada.</exception>
		public void SetLikeActive()
		{
			CheckState(CtrlStates.Started);
			UIElement.SetLikeActive();
		}

		#endregion

		#region Gestión de finalización

		protected override void OnBeforeFinishControllers(List<IController> children)
		{
			base.OnBeforeFinishControllers(children);

			UIElement.Reset();
		}

		protected override void OnBeforeResetFields(List<FieldInfo> fields)
		{
			base.OnBeforeResetFields(fields);

			_uiElement = default(TUIElement);

			// No se permite mas de un elemento de UI por
			// controladora
		}

		#endregion

		#region Gestión de eventos

		private void _uiSettings_UISettingsApplied(object sender, EventArgs e)
		{
			OnUISettingsApplied();
		}

		#endregion
	}
}