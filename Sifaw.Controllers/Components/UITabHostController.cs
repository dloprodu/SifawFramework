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
	/// derivar de <see cref="UITabHostController{TInput, TOutput, TGuest}.Input"/>.
	/// </typeparam>
	/// <typeparam name="TOutput">
	/// Tipo para establcer los parametros de retorno cuando finaliza la controladora. Ha de ser serializable y 
	/// derivar de <see cref="UITabHostController{TInput, TOutput, TGuest}.Output"/>.
	/// </typeparam>
	/// <typeparam name="TGuest">
	/// Tipo de los componentes que puede alojar. Ha de implementar <see cref="UIComponent"/>.
	/// </typeparam>
	public abstract class UITabHostController<TInput, TOutput, TGuest> : UIActorController
		< TInput
		, TOutput
		, TabHostComponent
		, TGuest>
		where TInput  : UITabHostController<TInput, TOutput, TGuest>.Input
		where TOutput : UITabHostController<TInput, TOutput, TGuest>.Output
    	where TGuest  : UIComponent
	{
		#region Input / Output

		/// <summary>
		/// Parámetros de entrada de las controladora.
		/// </summary>
		[Serializable]
		public abstract new class Input : UIActorController
			< TInput
			, TOutput
			, TabHostComponent
			, TGuest>.Input
		{
			#region Constructor

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UITabHostController{TInput, TOutput, TGuest}.Input"/>.
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
			, TabHostComponent
			, TGuest>.Output
		{
			#region Constructor

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UITabHostController{TInput, TOutput, TGuest}.Output"/>.
			/// </summary>
			protected Output()
			{
			}

			#endregion
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UITabHostController{TInput, TOutput, TGuest}"/>.
        /// Establece como <see cref="UILinker{TUIElement}"/> aquel establecido por defecto a través de 
        /// <see cref="UILinkersManager"/>.
        /// </summary>
		protected UITabHostController()
			: base()
		{
		}

        /// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UITabHostController{TInput, TOutput, TGuest}"/>, 
		/// estableciendo el <see cref="UILinker{TUIElement}"/> especificado como valor de la propiedad 
		/// <see cref="UIElementController{TInput, TOutput, TUIElement}.Linker"/> donde <c>TUIElement</c> 
		/// implementa <see cref="TabHostComponent"/>.
        /// </summary>
		protected UITabHostController(UILinker<TabHostComponent> linker)
			: base(linker)
		{
		}

		#endregion
		
		#region UIElement Methods

		/// <summary>
        /// Invoca al método sobrescirto <see cref="UIActorController{TInput, TOutput, TComponent, TGuest}.OnAfterUIElementCreate()"/>.
		/// </summary>
		protected override void OnAfterUIElementCreate()
		{
			base.OnAfterUIElementCreate();

            /* Default Settings... */            

			/* Subscripción a eventos del componente... */			
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