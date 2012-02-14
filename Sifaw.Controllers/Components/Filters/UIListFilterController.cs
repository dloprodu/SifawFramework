/*
 * Sifaw.Controllers.Components.Filters
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 08/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Views.Components;
using Sifaw.Views.Components.Filters;


namespace Sifaw.Controllers.Components.Filters
{
	/// <summary>
	/// Controladora que permite realizar filtros sobre una lista de objetos <see cref="IFilterable"/>, 
	/// devolviendo como filtro una sublista de objetos seleccioandos.
	/// </summary>
	/// <remarks>
	/// <para>
	/// El componente muestra toda la lista de elementos <see cref="IFilterable"/> al usuario. 
	/// elegir uno o varios elementos de la lista.
	/// </para>
	/// </remarks>
	public class UIListFilterController : UIListFilterBaseController
		< IList<IFilterable>
		, IList<IFilterable>
		, UIListFilterController.UISettingsContainer
		, ListFilterComponent>
	{
		#region Settings

		/// <summary>
		/// Contenedor de ajustes de <see cref="UIListFilterController"/>.
		/// </summary>
		[Serializable]
		public new class UISettingsContainer : UIListFilterBaseController
			< IList<IFilterable>
			, IList<IFilterable>
			, UISettingsContainer
			, ListFilterComponent>.UISettingsContainer
		{
			#region Constructors

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UIListFilterController.UISettingsContainer"/>.
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
		/// Inicializa una nueva instancia de la clase <see cref="UIListFilterController"/>.
		/// Establece como <see cref="AbstractUILinker{TUIElement}"/> aquel establecido por defecto a través de 
		/// <see cref="AbstractUIProviderManager{TLinker}"/>.
		/// </summary>
		public UIListFilterController()
			: base()
		{
		}

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIListFilterController"/>, 
		/// estableciendo el <see cref="AbstractUILinker{TUIElement}"/> como valor de la propiedad 
		/// <see cref="UIElementController{TInput, TOutput, TUISettings, TUIElement}.Linker"/> donde <c>TUIElement</c>
		/// implementa <see cref="ListFilterComponent"/>.
		/// </summary>
		public UIListFilterController(AbstractUILinker<ListFilterComponent> linker)
			: base(linker)
		{
		}

		#endregion

		#region Default input / output

		/// <summary>
		/// Devuelve los parámetros de inicio por defecto.
		/// </summary>
		public override Input GetDefaultInput()
		{
			return new Input(new List<IFilterable>());
		}

		#endregion

        #region UIElement Methods

		/// <summary>
		/// Invoca al método sobrescirto <see cref="UIElementController{TInput, TOutput, TUISettings, TComponent}.OnApplyUISettings()"/> y
		/// posteriormente aplica la configuración al elemento <see cref="UIElementController{TInput, TOutput, TUISettings, TView}.UIElement"/> 
		/// del tipo <see cref="ListFilterComponent"/>.
		/// </summary>
        protected override void OnApplyUISettings()
        {
            base.OnApplyUISettings();
        }

        #endregion

		#region Start Methods

		/// <summary>
		/// Ejecuta los comandos de inicio de la controladora.
		/// </summary>
		protected override void StartController()
		{
			/* Empty */
		}

		/// <summary>
		/// Ejecuta los comandos de reinicio de la controladora.
		/// </summary>
		protected override void ResetController()
		{
			/* Empty */
		}

		#endregion
	}
}