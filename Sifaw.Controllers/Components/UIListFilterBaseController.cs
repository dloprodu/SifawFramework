/*
 * Sifaw.Controllers.Components
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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Core.Utilities;

using Sifaw.Views;
using Sifaw.Views.Components;


namespace Sifaw.Controllers.Components
{
	/// <summary>
	/// Controladora base que da soporte a la implementación de componentes para realizar filtros sobre listas.
	/// </summary>
	/// <typeparam name="TFilter">
	/// Tipo del filtro que devolverá la controladora.
	/// </typeparam>
	/// <typeparam name="TSource">
	/// Tipo de la lista sobre la que se aplicarán los filtros. 
	/// Ha de implementar <see cref="IList{IFilterable}"/>.</typeparam>
	/// <typeparam name="TUISettings">
	/// Tipo para establecer el contenedor de ajustes encargado de establecer las configuración del elemento de interfaz de usuario. Ha de
	/// ser serializable, proveer de consturctor público y derivar de <see cref="UIListFilterBaseController{TFilter, TSource, TUISettings, TComponent}.UISettingsContainer"/>.
	/// </typeparam>
	/// <typeparam name="TComponent">
	/// Tipo para establecer el elemento de interfaz de usuario de la controladora. 
	/// Ha de implementar <see cref="ListFilterBaseComponent{TFilter, TSource}"/>.
	/// </typeparam>
	public abstract class UIListFilterBaseController<TFilter, TSource, TUISettings, TComponent> : UIFilterBaseController
		< TFilter
		, TUISettings
		, TComponent>
		where TSource : IList<IFilterable>
		where TUISettings : UIListFilterBaseController<TFilter, TSource, TUISettings, TComponent>.UISettingsContainer
						  , new()
		where TComponent : ListFilterBaseComponent<TFilter, TSource>
	{
		#region Settings

		/// <summary>
		/// Contenedor de ajustes de <see cref="UIListFilterBaseController{TFilter, TSource, TUISettings, TComponent}"/>.
		/// </summary>
		[Serializable]
		public new class UISettingsContainer : UIFilterBaseController
			< TFilter
			, TUISettings
			, TComponent>.UISettingsContainer
		{
			#region Fields

			private TSource _source;

			#endregion

			#region Properties

			/// <summary>
			/// Obtiene o establecela lista sobre la que se realizará el filtro.
			/// </summary>
			public TSource Source
			{
				get { return _source; }
				set
				{
					_source = (TSource)(new List<IFilterable>() as IList<IFilterable>);

					if (value != null)
					{
						(_source as List<IFilterable>).AddRange(value);
						(_source as List<IFilterable>).Sort();
					}
				}
			}

			#endregion

			#region Constructors

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UIListFilterBaseController{TFilter, TSource, TUISettings, TComponent}.UISettingsContainer"/>.
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
		/// Inicializa una nueva instancia de la clase <see cref="UIListFilterBaseController{TFilter, TSource, TUISettings, TComponent}"/>.
		/// Establece como <see cref="AbstractUILinker{TUIElement}"/> aquel establecido por defecto a través de 
		/// <see cref="AbstractUIProviderManager{TLinker}"/>.
		/// </summary>
		protected UIListFilterBaseController()
			: base()
		{
		}

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIListFilterBaseController{TFilter, TSource, TUISettings, TComponent}"/>, 
		/// estableciendo el <see cref="AbstractUILinker{TUIElement}"/> especificado como valor de la propiedad 
		/// <see cref="UIElementController{TInput, TOutput, TUISettings, TUIElement}.Linker"/> donde <c>TUIElement</c>
		/// implementa <see cref="ListFilterBaseComponent{TFilter, TSource}"/>.
		/// </summary>
		protected UIListFilterBaseController(AbstractUILinker<TComponent> linker)
			: base(linker)
		{
		}

		#endregion

        #region UIElement Methods

		/// <summary>
		/// Invoca al método sobrescirto <see cref="UIElementController{TInput, TOutput, TUISettings, TComponent}.OnApplyUISettings()"/> y
		/// posteriormente aplica la configuración al elemento <see cref="UIElementController{TInput, TOutput, TUISettings, TView}.UIElement"/> 
		/// del tipo <see cref="ListFilterBaseComponent{TFilter, TSource}"/>.
		/// </summary>
        protected override void OnApplyUISettings()
        {
            base.OnApplyUISettings();

            UIElement.Add(UISettings.Source);
        }

        #endregion
    }
}