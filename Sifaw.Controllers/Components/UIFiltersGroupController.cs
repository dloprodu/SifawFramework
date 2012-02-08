///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// Controladora encargada de presentar un grupo de filtros.
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
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Views.Components;
using Sifaw.Core.Utilities;


namespace Sifaw.Controllers.Components
{
	/// <summary>
	/// Controladora encargada de presentar un grupo de filtros.
	/// </summary>
	/// <typeparam name="TInput">Tipo para establecer los parámetros de inicio de la controladora.</typeparam>
	/// <typeparam name="TOutput">Tipo para establcer los parametros de retorno cuando finaliza la controladora.</typeparam>
	/// <typeparam name="TFilter">Tipo para establecer los datos de filtro que devolverá la controladora.</typeparam>
	public abstract class UIFiltersGroupController<TInput, TOutput, TFilter> : UIComponentController
		< TInput
		, TOutput
		, UIFiltersGroupController<TInput, TOutput, TFilter>.UISettingsContainer
		, FiltersGroupComponent>
		where TInput  : UIFiltersGroupController<TInput, TOutput, TFilter>.Input
		where TOutput : UIFiltersGroupController<TInput, TOutput, TFilter>.Output
		where TFilter : UIFiltersGroupController<TInput, TOutput, TFilter>.Filter
	{
		#region Parametros de inicio / finalización

		/// <summary>
		/// Parámetros de entrada de la controladora.
		/// </summary>
		[Serializable]
		public new abstract class Input : UIComponentController
			< TInput
			, TOutput
			, UISettingsContainer
			, FiltersGroupComponent>.Input
		{
			#region Variables

			TFilter _filter;

			#endregion

			#region Propiedades

			public TFilter Filter
			{
				get { return _filter; }
			}

			#endregion

			#region Constructor

			public Input(TFilter filter)
				: base()
			{
				_filter = filter;
			}

			#endregion
		}

		/// <summary>
		/// Parámetros de retorno de la controladora.
		/// </summary>
		[Serializable]
		public new abstract class Output : UIComponentController
			< TInput
			, TOutput
			, UISettingsContainer
			, FiltersGroupComponent>.Output
		{
			#region Constructor

			/// <summary>
			/// Clase que engloba los parámetros de finalización de la controladora de procesos pesados
			/// </summary>
			/// <param name="cancelado">Indica si el proceso fue cancelado</param>
			public Output()
				: base()
			{
			}

			#endregion
		}

		#endregion

		#region Filter

		[Serializable]
		public abstract class Filter : ICloneable
		{
			#region ICloneable Members

			public object Clone()
			{
				return UtilIO.Clone<TFilter>(this as TFilter);
			}

			#endregion
		}

		#endregion

		#region Settings

		[Serializable]
		public class UISettingsContainer : UIComponentController
			< TInput
			, TOutput
			, UISettingsContainer
			, FiltersGroupComponent>.UISettingsContainer<FiltersGroupComponent>
		{
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
			}

			#endregion
		}

		#endregion

		#region Eventos

		/*
		 * Desencadenadores privados.
		 *  • Solo son lanzados por la controladora padre.
		 */
		
		public event CLFilterChangedEventHandler<TFilter> FilterChanged;
		private void OnFilterChanged(CLFilterChangedEventArgs<TFilter> e)
		{
			if (FilterChanged != null)
				FilterChanged(this, e);
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

		/* Empty */

		#endregion

		#region Constructor

		protected UIFiltersGroupController()
			: base()
		{
		}

		protected UIFiltersGroupController(AbstractUILinker<FiltersGroupComponent> linker)
			: base(linker)
		{
		}

		#endregion

		#region Componente

		protected override void OnAfterUIElementLoad()
		{
			base.OnAfterUIElementLoad();

			/* Empty */
		}

		#endregion

		#region StartController

		protected override void OnBeforeStartController()
		{
			base.OnBeforeStartController();

			// TODO: Obtener filtros

			// TODO: Cargar filtros en componente

			// TODO: Enganchar eventos filtros
		}

		#endregion
	}
}