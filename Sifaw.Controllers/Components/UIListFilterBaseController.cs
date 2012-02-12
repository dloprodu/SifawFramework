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
using Sifaw.Views.Components;


namespace Sifaw.Controllers.Components
{
	/// <summary>
	/// Controladora que da soporte a la implementación de filtros sobre listas.
	/// </summary>
	/// <typeparam name="TFilter">Tipo del filtro que devolverá la controladora.</typeparam>
	/// <typeparam name="TSource">Tipo de la lista sobre la que se aplicarán los filtros.</typeparam>
	/// <typeparam name="TUISettings">Tipo para establecer el proxy encargado de establecer los ajustes al elemento de interfaz de usuario.</typeparam>
	/// <typeparam name="TComponent">Tipo del componente de UI del controlador.</typeparam>
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
			/// Obtiene o establece la lista sobre la que se realizará el filtro.
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

			public UISettingsContainer()
				: base()
			{
			}

			#endregion
		}

		#endregion

		#region Constructors

		protected UIListFilterBaseController()
			: base()
		{
		}

		protected UIListFilterBaseController(AbstractUILinker<TComponent> linker)
			: base(linker)
		{
		}

		#endregion

        #region UIElement Methods

        protected override void OnApplyUISettings()
        {
            base.OnApplyUISettings();

            UIElement.Add(UISettings.Source);
        }

        #endregion
    }
}