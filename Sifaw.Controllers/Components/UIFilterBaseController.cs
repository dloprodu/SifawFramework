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
	/// <typeparam name="TFilter">Tipo del filtro que devolverá la controladora.</typeparam>
	/// <typeparam name="TUISettings">Tipo para establecer el proxy encargado de establecer los ajustes al elemento de interfaz de usuario.</typeparam>
	/// <typeparam name="TComponent">Tipo del componente de UI del controlador.</typeparam>
	public abstract class UIFilterBaseController<TFilter, TUISettings, TComponent> : UIComponentController
		< UIFilterBaseController<TFilter, TUISettings, TComponent>.Input
		, UIFilterBaseController<TFilter, TUISettings, TComponent>.Output
		, TUISettings
		, TComponent>
		where TUISettings : UIFilterBaseController<TFilter, TUISettings, TComponent>.UISettingsContainer<TComponent>
						  , new()
		where TComponent  : FilterBaseComponent<TFilter>
	{
		#region Input / Output

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
			#region Fields

			private TFilter _filter;

			#endregion

			#region Properties

			public TFilter Filter
			{
				get { return _filter; }
			}

			#endregion

			#region Constructors

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
			#region Fields

			private TFilter _filter;

			#endregion

			#region Properties

			public TFilter Filter
			{
				get { return _filter; }
			}

			#endregion

			#region Constructors

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
			#region Constructors

			public UISettingsContainer()
				: base()
			{
			}

			#endregion

			#region Public Methods

			public override void Apply()
			{
				base.Apply();
			}

			#endregion
		}

		#endregion

		#region Events

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

		#region Properties

		public TFilter Filter
		{
			get { return UIElement.Filter; }
		}

		#endregion

		#region Constructors

		protected UIFilterBaseController()
			: base()
		{
		}

		protected UIFilterBaseController(AbstractUILinker<TComponent> linker)
			: base(linker)
		{
		}

		#endregion

		#region UIElement Methods

		protected override void OnAfterUIElementLoad()
		{
			base.OnAfterUIElementLoad();

			/* Subscripción a eventos del componente... */
			UIElement.FilterChanged += new UIFilterChangedEventHandler(UIElement_FilterChanged);
		}

		#endregion

        #region Default Input / Output

        public override Input GetResetInput()
		{
			return new Input(Filter);
		}

		protected override Output GetDefaultOutput()
		{
			return new Output(Filter);
		}

		#endregion

		#region Start Methods

        protected override void OnAfterStartController()
        {
            base.OnAfterStartController();

            UIElement.Filter = Parameters.Filter;
        }

        protected override void OnAfterResetController()
		{
            base.OnAfterResetController();

			UIElement.Filter = Parameters.Filter;
		}

		#endregion

		#region UIElement Events Handler

		private void UIElement_FilterChanged(object sender, UIFilterChangedEventArgs e)
		{
			CLFilterChangedEventArgs<TFilter> args = new CLFilterChangedEventArgs<TFilter>(UIElement.Filter);

			OnFilterChanged(args);

			e.Cancel = args.Cancel;
		}

		#endregion
	}
}