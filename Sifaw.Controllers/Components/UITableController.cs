/*
 * Sifaw.Controllers.Components
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 29/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Views;
using Sifaw.Views.Components;


namespace Sifaw.Controllers.Components
{
	/// <summary>
	/// Controladora que gestiona la representacion de datos en forma de tabla.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <typeparam name="TInput">
	/// Tipo para establecer los parámetros de inicio de la controladora. Ha de ser serializable y 
	/// derivar de <see cref="UITableController{TInput, TOutput, TUISettings}.Input"/>.
	/// </typeparam>
	/// <typeparam name="TOutput">
	/// Tipo para establcer los parametros de retorno cuando finaliza la controladora. Ha de ser serializable y 
	/// derivar de <see cref="UITableController{TInput, TOutput, TUISettings}.Output"/>.
	/// </typeparam>
	/// <typeparam name="TUISettings">
	/// Tipo para establecer el contenedor de ajustes encargado de establecer las configuración del elemento de interfaz 
	/// de usuario o de componentes embebidos. Ha de ser serializable, proveer de consturctor público y derivar 
	/// de <see cref="UITableController{TInput, TOutput, TUISettings}.UISettingsContainer"/>.
	/// </typeparam>
	public abstract class UITableController<TInput, TOutput, TUISettings> : UIComponentController
		< TInput
		, TOutput
		, TUISettings
		, TableComponent>
		where TInput      : UITableController<TInput, TOutput, TUISettings>.Input
		where TOutput     : UITableController<TInput, TOutput, TUISettings>.Output
		where TUISettings : UITableController<TInput, TOutput, TUISettings>.UISettingsContainer
						  , new()
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
			, TableComponent>.Input
		{
			#region Constructor

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UITableController{TInput, TOutput, TUISettings}.Input"/>.
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
			, TableComponent>.Output
		{
			#region Constructor

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UITableController{TInput, TOutput, TUISettings}.Output"/>.
			/// </summary>
			protected Output()
			{
			}

			#endregion
		}

		#endregion

		#region Settings

		/// <summary>
		/// Contenedor de ajustes de <see cref="UITableController{TInput, TOutput, TUISettings}"/>.
		/// </summary>
		[Serializable]
		public new class UISettingsContainer : UIComponentController
			< TInput
			, TOutput
			, TUISettings
			, TableComponent>.UISettingsContainer
		{
			#region Constructors

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UITableController{TInput, TOutput, TUISettings}.UISettingsContainer"/>.
			/// </summary>
			public UISettingsContainer()
				: base()
			{
			}

			#endregion
		}

		#endregion

		#region Fileds


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

		/* Empty */

		/*
		 * Desencadenadores protegidos virtuales sin manejadores asociados.
		 *  • Pueden ser sobreescritos por controladoras hijas para
		 *    completar funcionalidad.
		 */

		/* Empty */	

		#endregion

		#region Properties

		#endregion

		#region Constructors

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UITableController{TInput, TOutput, TUISettings}"/>.
        /// Establece como <see cref="AbstractUILinker{TUIElement}"/> aquel establecido por defecto a través de 
        /// <see cref="AbstractUIProviderManager{TLinker}"/>.
        /// </summary>
		protected UITableController()
			: base()
		{
		}

        /// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UITableController{TInput, TOutput, TUISettings}"/>, 
		/// estableciendo el <see cref="AbstractUILinker{TUIElement}"/> especificado como valor de la propiedad 
		/// <see cref="UIElementController{TInput, TOutput, TUISettings, TUIElement}.Linker"/> donde <c>TUIElement</c> 
		/// implementa <see cref="TableComponent"/>.
        /// </summary>
		protected UITableController(AbstractUILinker<TableComponent> linker)
			: base(linker)
		{
		}

		#endregion
	}
}