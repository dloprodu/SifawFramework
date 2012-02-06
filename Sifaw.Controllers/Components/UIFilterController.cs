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
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Core.Utilities;
using Sifaw.Views.Components;


namespace Sifaw.Controllers.Components
{
	/// <summary>
	/// Controladora que da soporte a la implementación de filtros.
	/// </summary>
	/// <typeparam name="TFilter">Tipo para establecer los datos de filtro que devolverá la controladora.</typeparam>
	/// <typeparam name="TUISettings">Tipo para establecer el proxy encargado de establecer los ajustes al elemento de interfaz de usuario.</typeparam>
	/// <typeparam name="TComponent">Tipo del componente de UI del controlador.</typeparam>
	public abstract class UIFilterController<TFilter, TUISettings, TComponent> : UIComponentController
		< UIFilterController<TFilter, TUISettings, TComponent>.Input
		, UIFilterController<TFilter, TUISettings, TComponent>.Output
		, TUISettings
		, TComponent>
		//where TFilter     : IComparable, IComparable<TFilter>, IEquatable<TFilter>
		where TUISettings : UIFilterController<TFilter, TUISettings, TComponent>.UISettingsContainer<TComponent>
						  , new()
		where TComponent  : ComponentFilter<TFilter>
	{
		#region Parametros de inicio / finalización

		/// <summary>
		/// Parámetros de entrada de la controladora.
		/// </summary>
		[Serializable]
		public new class Input : UIComponentController
			< Input
			, Output
			, TUISettings
			, TComponent>.Input
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
		public new class Output : UIComponentController
			< Input
			, Output
			, TUISettings
			, TComponent>.Output
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

			/// <summary>
			/// Clase que engloba los parámetros de finalización de la controladora de procesos pesados
			/// </summary>
			/// <param name="filter">Filtro al finalizar la controladora.</param>
			public Output(TFilter filter)
				: base()
			{
				_filter = filter;
			}

			#endregion
		}

		#endregion

		#region Settings

		[Serializable]
		public new class UISettingsContainer<TUI> : UIComponentController
			< Input
			, Output
			, TUISettings
			, TComponent>.UISettingsContainer<TUI>
			where TUI : TComponent
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

		public event CtrlFilterChangedEventHandler<TFilter> FilterChanged;
		private void OnFilterChanged(CtrlFilterChangedEventArgs<TFilter> e)
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

		protected UIFilterController()
			: base()
		{
		}

		protected UIFilterController(AbstractUILinker<TComponent> linker)
			: base(linker)
		{
		}

		#endregion

		#region Componente

		protected override void OnAfterUIElementLoad()
		{
			base.OnAfterUIElementLoad();

			/* Subscripción a eventos del componente... */
			UIElement.FilterChanged += new Views.UIFilterChangedEventHandler<TFilter>(UIElement_FilterChanged);
		}

		#endregion

		#region Default input / output

		public override Input GetResetInput()
		{
			return new Input(UIElement.Filter);
		}

		protected override Output GetDefaultOutput()
		{
			return new Output(UIElement.Filter);
		}

		#endregion

		#region StartController

		protected override void OnBeforeStartController()
		{
			base.OnBeforeStartController();

			UIElement.Filter = Parameters.Filter;
		}

		protected override void OnBeforeResetController()
		{
			base.OnBeforeResetController();

			UIElement.Filter = Parameters.Filter;
		}

		#endregion

		#region Gestión de eventos del componente

		private void UIElement_FilterChanged(object sender, Views.UIFilterChangedEventArgs<TFilter> e)
		{
			OnFilterChanged(new CtrlFilterChangedEventArgs<TFilter>(e.OldValue, e.NewValue));
		}

		#endregion
	}
}