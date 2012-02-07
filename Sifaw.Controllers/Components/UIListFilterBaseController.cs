///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// Controladora que permite realizar algún tipo de filtro.
/// 
/// Diseñador: David López Rguez
/// Programador: David López Rguez
/// </sumary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 27/01/2012: Creación de controladora.
/// 
/// ===============================================================================================
/// Observaciones:
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



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
		where TSource     : IList<IFilterable>
		where TUISettings : UIListFilterBaseController<TFilter, TSource, TUISettings, TComponent>.UISettingsContainer<TComponent>
						  , new()
		where TComponent  : ComponentListFilterBase<TFilter, TSource>
	{
		#region Settings

		[Serializable]
		public new class UISettingsContainer<TUI> : UIFilterBaseController
			< TFilter
			, TUISettings
			, TComponent>.UISettingsContainer<TUI>
			where TUI : TComponent
		{
			#region Variables

			private TSource _source;

			#endregion

			#region Propiedades

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

			#region Constructor

			public UISettingsContainer()
				: base()
			{
			}

			#endregion

			#region Métodos públicos

			public override void Apply()
			{
				base.Apply();
								
				UIElement.Add(Source);
			}

			#endregion
		}

		#endregion

		#region Constructor

		protected UIListFilterBaseController()
			: base()
		{
		}

		protected UIListFilterBaseController(AbstractUILinker<TComponent> linker)
			: base(linker)
		{
		}

		#endregion
	}
}