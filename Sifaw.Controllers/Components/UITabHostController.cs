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


namespace Sifaw.Controllers.Components
{
	/// <summary>
	/// Controladora base encargada de administrar un conjunto relacionado de 
	/// componentes de interfaz <see cref="Sifaw.Views.UIComponent"/> que comparten entre ellos
	/// el mismo espacio en pantalla pudiendo el usuario visualizarlos de forma arbitraria
	/// mediante un método de selección.
	/// </summary>
	/// <typeparam name="TInput">
	/// Tipo para establecer los parámetros de inicio de la controladora. Ha de ser serializable y 
	/// derivar de <see cref="UITabHostController{TInput, TOutput, TUISettings, TGuest}.Input"/>.
	/// </typeparam>
	/// <typeparam name="TOutput">
	/// Tipo para establcer los parametros de retorno cuando finaliza la controladora. Ha de ser serializable y 
	/// derivar de <see cref="UITabHostController{TInput, TOutput, TUISettings, TGuest}.Output"/>.
	/// </typeparam>
	/// <typeparam name="TUISettings">
	/// Tipo para establecer el contenedor de ajustes encargado de establecer las configuración del elemento de interfaz 
	/// de usuario o de componentes embebidos. Ha de ser serializable, proveer de consturctor público y derivar 
	/// de <see cref="UITabHostController{TInput, TOutput, TUISettings, TGuest}.UISettingsContainer"/>.
	/// </typeparam>
	/// <typeparam name="TGuest">
	/// Tipo de los componentes que puede alojar. Ha de implementar <see cref="UIComponent"/>.
	/// </typeparam>
	public abstract class UITabHostController<TInput, TOutput, TUISettings, TGuest> : UIActorController
		< TInput
		, TOutput
		, TUISettings
		, TabHostComponent
		, TGuest>
		where TInput      : UITabHostController<TInput, TOutput, TUISettings, TGuest>.Input
		where TOutput     : UITabHostController<TInput, TOutput, TUISettings, TGuest>.Output
		where TUISettings : UITabHostController<TInput, TOutput, TUISettings, TGuest>.UISettingsContainer
						  , new()
		where TGuest      : UIComponent
	{
		#region Input / Output

		/// <summary>
		/// Parámetros de entrada de las controladora.
		/// </summary>
		[Serializable]
		public abstract new class Input : UIActorController
			< TInput
			, TOutput
			, TUISettings
			, TabHostComponent
			, TGuest>.Input
		{
			#region Constructor

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UITabHostController{TInput, TOutput, TUISettings, TGuest}.Input"/>.
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
		public abstract new class Output : UIActorController
			< TInput
			, TOutput
			, TUISettings
			, TabHostComponent
			, TGuest>.Output
		{
			#region Constructor

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UITabHostController{TInput, TOutput, TUISettings, TGuest}.Output"/>.
			/// </summary>
			protected Output()
			{
			}

			#endregion
		}

		#endregion

		#region Settings

		/// <summary>
		/// Contenedor de ajustes de <see cref="UITabHostController{TInput, TOutput, TUISettings, TGuest}"/>.
		/// </summary>
		[Serializable]
		public new class UISettingsContainer : UIActorController
			< TInput
			, TOutput
			, TUISettings
			, TabHostComponent
			, TGuest>.UISettingsContainer
		{
			#region Constructors

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UITabHostController{TInput, TOutput, TUISettings, TGuest}.UISettingsContainer"/>.
			/// </summary>
			public UISettingsContainer()
				: base()
			{
			}

			#endregion
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UITabHostController{TInput, TOutput, TUISettings, TGuest}"/>.
        /// Establece como <see cref="AbstractUILinker{TUIElement}"/> aquel establecido por defecto a través de 
        /// <see cref="AbstractUIProviderManager{TLinker}"/>.
        /// </summary>
		protected UITabHostController()
			: base()
		{
		}

        /// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UITabHostController{TInput, TOutput, TUISettings, TGuest}"/>, 
		/// estableciendo el <see cref="AbstractUILinker{TUIElement}"/> especificado como valor de la propiedad 
		/// <see cref="UIElementController{TInput, TOutput, TUIStyle, TUIElement}.Linker"/> donde <c>TUIElement</c> 
		/// implementa <see cref="TabHostComponent"/>.
        /// </summary>
		protected UITabHostController(AbstractUILinker<TabHostComponent> linker)
			: base(linker)
		{
		}

		#endregion
		
		#region UIElement Methods

		/// <summary>
		/// Invoca al método sobrescirto <see cref="UIElementController{TInput, TOutput, TUIStyle, TComponent}.OnAfterUIElementLoad()"/>.
		/// </summary>
		protected override void OnAfterUIElementLoad()
		{
			base.OnAfterUIElementLoad();

			/* Subscripción a eventos del componente... */			
		}

		/// <summary>
		/// Invoca al método sobrescirto <see cref="UIElementController{TInput, TOutput, TUIStyle, TComponent}.OnApplyUISettings()"/> y
		/// posteriormente aplica la configuración al elemento <see cref="UIElementController{TInput, TOutput, TUIStyle, TView}.UIElement"/> 
		/// del tipo <see cref="TabHostComponent"/>.
		/// </summary>
		protected override void OnApplyUISettings()
		{
			base.OnApplyUISettings();
		}

		#endregion

		#region Start Methods

		/// <summary>
		/// Devuelve un valor que indica que, por defecto, se permite reiniciar un TabHost.
		/// </summary>
		protected override bool AllowReset()
		{
			return true;
		}

		#endregion
	}
}