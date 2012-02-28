/*
 * Sifaw.Controllers.Components
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 17/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Sifaw.Views;
using Sifaw.Views.Components;


namespace Sifaw.Controllers
{
	/// <summary>
	/// Controladora base encargada de administrar un conjunto relacionado de 
	/// componentes de interfaz <see cref="Sifaw.Views.UIComponent"/> que comparten entre ellos
	/// el mismo espacio en pantalla.
	/// </summary>
	/// <typeparam name="TInput">
	/// Tipo para establecer los parámetros de inicio de la controladora. Ha de ser serializable y 
	/// derivar de <see cref="UIActorController{TInput, TOutput, TUISettings, TComponent, TGuest}.Input"/>.
	/// </typeparam>
	/// <typeparam name="TOutput">
	/// Tipo para establcer los parametros de retorno cuando finaliza la controladora. Ha de ser serializable y 
	/// derivar de <see cref="UIActorController{TInput, TOutput, TUISettings, TComponent, TGuest}.Output"/>.
	/// </typeparam>
	/// <typeparam name="TUISettings">
	/// Tipo para establecer el contenedor de ajustes encargado de establecer las configuración del elemento de interfaz 
	/// de usuario o de componentes embebidos. Ha de ser serializable, proveer de consturctor público y derivar 
	/// de <see cref="UIActorController{TInput, TOutput, TUISettings, TComponent, TGuest}.UISettingsContainer"/>.
	/// </typeparam>
	/// <typeparam name="TComponent">
	/// Tipo para establecer el elemento de interfaz de usuario de la controladora. Ha de implementar <see cref="UIActorComponent"/>.
	/// </typeparam>
	/// <typeparam name="TGuest">
	/// Tipo de los componentes que puede alojar. Ha de implementar <see cref="UIComponent"/>.
	/// </typeparam>
	public abstract class UIActorController<TInput, TOutput, TUISettings, TComponent, TGuest> : UIComponentController
		< TInput
		, TOutput
		, TUISettings
		, TComponent >
		where TInput      : UIActorController<TInput, TOutput, TUISettings, TComponent, TGuest>.Input
		where TOutput     : UIActorController<TInput, TOutput, TUISettings, TComponent, TGuest>.Output
		where TUISettings : UIActorController<TInput, TOutput, TUISettings, TComponent, TGuest>.UISettingsContainer
						  , new()
		where TComponent  : UIActorComponent
		where TGuest      : UIComponent
	{
		#region Input / Output

		/// <summary>
		/// Parámetros de entrada de las controladora.
		/// </summary>
		[Serializable]
		public abstract new class Input : UIComponentController
			< TInput
			, TOutput
			, TUISettings
			, TComponent>.Input
		{
			#region Constructor

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UIActorController{TInput, TOutput, TUISettings, TComponent, TGuest}.Input"/>.
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
		public abstract new class Output : UIComponentController
			< TInput
			, TOutput
			, TUISettings
			, TComponent>.Output
		{
			#region Constructor

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UIActorController{TInput, TOutput, TUISettings, TComponent, TGuest}.Output"/>.
			/// </summary>
			protected Output()
			{
			}

			#endregion
		}

		#endregion

		#region Settings

		/// <summary>
		/// Contenedor de ajustes de <see cref="UIActorController{TInput, TOutput, TUISettings, TComponent, TGuest}"/>.
		/// </summary>
		[Serializable]
		public new class UISettingsContainer : UIComponentController
			< TInput
			, TOutput
			, TUISettings
			, TComponent>.UISettingsContainer
		{
			#region Constructors

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UIActorController{TInput, TOutput, TUISettings, TComponent, TGuest}.UISettingsContainer"/>.
			/// </summary>
			public UISettingsContainer()
				: base()
			{
			}

			#endregion
		}

		#endregion

		#region Fileds

		[CLReseteable(null)]
		private string[] _descriptors = null;

		[CLReseteable(null)]
		private TGuest _guest = default(TGuest);

		[CLReseteable(0)]
		private int _key = 0;

		#endregion

		#region Events

		/*
		 * Desencadenadores privados.
		 *  • Solo son lanzados por la controladora padre.
		 */

		/// <summary>
		/// Se produce antes de cambiar el componente a mostrar, permitiendo que un controlador cancele el cambio de
		/// componente.
		/// </summary>
		public event CLComponentChangingEventHandler GuestChanging;

		/// <summary>
		/// Provoca el evento <see cref="GuestChanging"/>. 
		/// </summary>
		/// <param name="e"><see cref="Sifaw.Controllers.CLComponentChangingEventArgs"/> que contiene los datos del evento.</param>
		private void OnGuestChanging(CLComponentChangingEventArgs e)
		{
			if (GuestChanging != null)
				GuestChanging(this, e);
		}

		/// <summary>
		/// Se produce cuando ha cambiado el componente a mostrar.
		/// </summary>
		public event CLComponentChangedEventHandler GuestChanged;

		/// <summary>
		/// Provoca el evento <see cref="GuestChanged"/>. 
		/// </summary>
		/// <param name="e"><see cref="Sifaw.Controllers.CLComponentChangedEventArgs"/> que contiene los datos del evento.</param>
		private void OnGuestChanged(CLComponentChangedEventArgs e)
		{
			if (GuestChanged != null)
				GuestChanged(this, e);
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
		/// Se llama al método <see cref="OnBeforeUpdateGuest"/> antes de actualizar el
		/// componente a mostrar. El método permite que las clases derivadas controlen
		/// el evento sin asociar un delegado.
		/// </summary>
		/// <remarks>
		/// Al reemplazar <see cref="OnBeforeUpdateGuest"/> en una clase derivada, asegúrese de llamar al
		/// método <see cref="OnBeforeUpdateGuest"/> de la clase base para que los delegados registrados 
		/// reciban el evento.
		/// </remarks>
		protected virtual void OnBeforeUpdateGuest()
		{
			/* Emtpy */
		}

		/// <summary>
		/// Se llama al método <see cref="OnAfterUpdateGuest"/> después de actualizar el
		/// componente a mostrar. El método permite que las clases derivadas controlen 
		/// el evento sin asociar un delegado.
		/// </summary>
		/// <remarks>
		/// Al reemplazar <see cref="OnAfterUpdateGuest"/> en una clase derivada, asegúrese de llamar al
		/// método <see cref="OnAfterUpdateGuest"/> de la clase base para que los delegados registrados
		/// reciban el evento.
		/// </remarks>
		protected virtual void OnAfterUpdateGuest()
		{
			/* Emtpy */
		}	

		#endregion

		#region Properties

		/// <summary>
		/// Devuelve el array que informa del número de componentes a hospedar conteniendo
		/// para cada uno de ellos una cadena de texto susceptible de ser usada como identificador
		/// en la interfaz de usuario.
		/// </summary>
		protected string[] Descriptors
		{
			get { return _descriptors; }
		}

		/// <summary>
		/// Devuelve el componente de interfaz visible.
		/// </summary>
		protected TGuest Guest
		{
			get { return _guest; }
		}

		/// <summary>
		/// Devuelve la clave que indica la posición del componete de interfaz visible dentro del conjunto de componentes.
		/// </summary>
		protected int Key
		{
			get { return _key; }
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIActorController{TInput, TOutput, TUISettings, TComponent, TGuest}"/>.
        /// Establece como <see cref="AbstractUILinker{TUIElement}"/> aquel establecido por defecto a través de 
        /// <see cref="AbstractUIProviderManager{TLinker}"/>.
        /// </summary>
		protected UIActorController()
			: base()
		{
		}

        /// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIActorController{TInput, TOutput, TUISettings, TComponent, TGuest}"/>, 
		/// estableciendo el <see cref="AbstractUILinker{TUIElement}"/> especificado como valor de la propiedad 
		/// <see cref="UIElementController{TInput, TOutput, TUISettings, TUIElement}.Linker"/> donde <c>TUIElement</c> 
		/// implementa <see cref="UIActorComponent"/>.
        /// </summary>
		protected UIActorController(AbstractUILinker<TComponent> linker)
			: base(linker)
		{
		}

		#endregion
		
		#region Abstract Methods

		/// <summary>		
		/// Devuelve un array que informará del número de componentes a hospedar, conteniendo
		/// para cada uno de ellos una cadena de texto susceptible de ser usada como identificador
		/// en la interfaz de usuario.
		/// </summary>
		protected abstract string[] GetDescriptors();

		/// <summary>
		/// Devuelve el componente a mostrar según la posición y componente mostrado actualmente.
		/// </summary>
		/// <param name="key">Clave que indica la posición del componente dentro del conjunto de componentes.</param>
		protected abstract TGuest GetGuestAt(int key);

		#endregion

		#region UIElement Methods

		/// <summary>
		/// Invoca al método sobrescirto <see cref="UIElementController{TInput, TOutput, TUISettings, TComponent}.OnAfterUIElementLoad()"/>.
		/// </summary>
		protected override void OnAfterUIElementLoad()
		{
			base.OnAfterUIElementLoad();

			/* Subscripción a eventos del componente... */
			UIElement.GuestSelecting += new UIGuestSelectingEventHandler(UIElement_UpdateGuest);
		}

		/// <summary>
		/// Invoca al método sobrescirto <see cref="UIElementController{TInput, TOutput, TUISettings, TComponent}.OnApplyUISettings()"/> y
		/// posteriormente aplica la configuración al elemento <see cref="UIElementController{TInput, TOutput, TUISettings, TView}.UIElement"/> 
		/// del tipo <see cref="UIActorComponent"/>.
		/// </summary>
		protected override void OnApplyUISettings()
		{
			base.OnApplyUISettings();
		}

		#endregion

		#region Start Methods

		/// <summary>
		/// Invoca al método sobrescirto <see cref="Controller{TInput, TOutput}.OnBeforeStartController()"/>.
		/// </summary>
		protected override void OnAfterStartController()
		{
			base.OnAfterStartController();

			_descriptors = GetDescriptors();
			_guest = GetGuestAt(_key);

			UIElement.Descriptors = _descriptors;
			UIElement.Update(_guest, _key);
		}

		#endregion

		#region UIElement Event Handlers

		private void UIElement_UpdateGuest(object sender, UIGuestSelectingEventArgs e)
		{
			CLComponentChangingEventArgs args = new CLComponentChangingEventArgs(e.Key);
			OnGuestChanging(args);
			e.Cancel = args.Cancel;

			if (!args.Cancel)
			{
				TGuest new_guest = GetGuestAt(e.Key);

				if (new_guest != null)
				{
					OnBeforeUpdateGuest();
					UIElement.Update(new_guest, e.Key);

					_guest = new_guest;
					_key = e.Key;					

					OnAfterUpdateGuest();
					OnGuestChanged(new CLComponentChangedEventArgs(e.Key));
				}
			}
		}

		#endregion
	}
}