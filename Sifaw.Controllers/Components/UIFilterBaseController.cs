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
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Core.Utilities;

using Sifaw.Views;
using Sifaw.Views.Components;


namespace Sifaw.Controllers.Components
{
	/// <summary>
	/// Controladora base que da soporte a la implementación de componentes para realizar filtros.
	/// </summary>
	/// <typeparam name="TFilter">
	/// Tipo del filtro que devolverá la controladora.
	/// </typeparam>
	/// <typeparam name="TUISettings">
	/// Tipo para establecer el contenedor de ajustes encargado de establecer las configuración del elemento de interfaz de usuario. Ha de
	/// ser serializable, proveer de consturctor público y derivar de <see cref="UIFilterBaseController{TFilter, TUISettings, TComponent}.UISettingsContainer"/>.
	/// </typeparam>
	/// <typeparam name="TComponent">
	/// Tipo para establecer el elemento de interfaz de usuario de la controladora. Ha de implementar <see cref="FilterBaseComponent{TFilter}"/>.
	/// </typeparam>
	public abstract class UIFilterBaseController<TFilter, TUISettings, TComponent> : UIComponentController
		< UIFilterBaseController<TFilter, TUISettings, TComponent>.Input
		, UIFilterBaseController<TFilter, TUISettings, TComponent>.Output
		, TUISettings
		, TComponent>
		where TUISettings : UIFilterBaseController<TFilter, TUISettings, TComponent>.UISettingsContainer
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

			/// <summary>
			/// Devuelve el filtro a aplicar al iniciar la controladora.
			/// </summary>
			public TFilter Filter
			{
				get { return _filter; }
			}

			#endregion

			#region Constructors

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UIFilterBaseController{TFilter, TUISettings, TComponent}.Input"/>,
			/// estableciendo un valor en la propiedad <see cref="Filter"/>.
			/// </summary>
			/// <param name="filter">Filtro a aplicar al iniciar la controladora.</param>
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

			/// <summary>
			/// Devuelve el filtro establecido al finalizar la controladora.
			/// </summary>
			public TFilter Filter
			{
				get { return _filter; }
			}

			#endregion

			#region Constructors

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UIFilterBaseController{TFilter, TUISettings, TComponent}.Output"/>,
			/// estableciendo un valor en la propiedad <see cref="Filter"/>.
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

		/// <summary>
		/// Contenedor de ajustes de <see cref="UIFilterBaseController{TFilter, TUISettings, TComponent}"/>.
		/// </summary>
		[Serializable]
		public new class UISettingsContainer : UIComponentController
			< Input
			, Output
			, TUISettings
			, TComponent>.UISettingsContainer
		{
			#region Constructors

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UIFilterBaseController{TFilter, TUISettings, TComponent}.UISettingsContainer"/>.
			/// </summary>
			public UISettingsContainer()
				: base()
			{
			}

			#endregion
		}

		#endregion

		#region Events

		/*
		 * Desencadenadores privados.
		 *  • Solo son lanzados por la controladora padre.
		 */

		/// <summary>
		/// Se produce cuando cambia el valor de la propiedad <see cref="Filter"/>.
		/// </summary>
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

		/// <summary>
		/// Devuelve el filtro aplicado.
		/// </summary>
		public TFilter Filter
		{
			get { return (State == CLStates.Started) ? UIElement.Filter : default(TFilter); }
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIFilterBaseController{TFilter, TUISettings, TComponent}"/>.
		/// Establece como <see cref="AbstractUILinker{TUIElement}"/> aquel establecido por defecto a través de 
		/// <see cref="AbstractUIProviderManager{TLinker}"/>.
		/// </summary>
		protected UIFilterBaseController()
			: base()
		{
		}

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIFilterBaseController{TFilter, TUISettings, TComponent}"/>, 
		/// estableciendo el <see cref="AbstractUILinker{TUIElement}"/> especificado como valor de la propiedad 
		/// <see cref="UIElementController{TInput, TOutput, TUIStyle, TUIElement}.Linker"/> donde <c>TUIElement</c>
		/// implementa <see cref="FilterBaseComponent{TFilter}"/>.
		/// </summary>
		protected UIFilterBaseController(AbstractUILinker<TComponent> linker)
			: base(linker)
		{
		}

		#endregion

		#region UIElement Methods

		/// <summary>
		/// Invoca al método sobrescirto <see cref="UIElementController{TInput, TOutput, TUIStyle, TComponent}.OnAfterUIElementLoad()"/> y
		/// posteriormente se subscribe a los eventos del componente <see cref="FilterBaseComponent{TFilter}"/>.
		/// </summary>
		protected override void OnAfterUIElementLoad()
		{
			base.OnAfterUIElementLoad();

			/* Subscripción a eventos del componente... */
			UIElement.FilterChanged += new UIFilterChangedEventHandler(UIElement_FilterChanged);
		}

		/// <summary>
		/// Invoca al método sobrescirto <see cref="UIElementController{TInput, TOutput, TUIStyle, TComponent}.OnApplyUISettings()"/> y
		/// posteriormente aplica la configuración al elemento <see cref="UIElementController{TInput, TOutput, TUIStyle, TView}.UIElement"/> 
		/// del tipo <see cref="FilterBaseComponent{TFilter}"/>.
		/// </summary>
        protected override void OnApplyUISettings()
        {
            base.OnApplyUISettings();
        }

		#endregion

        #region Default Input / Output

		/// <summary>
		/// Devuelve los parámetros de reinicio por defecto.
		/// </summary>
        public override Input GetResetInput()
		{
			return new Input(Filter);
		}

		/// <summary>
		/// Devuelve los parámetros de retorno por defecto.
		/// </summary>
		protected override Output GetDefaultOutput()
		{
			return new Output(Filter);
		}

		#endregion

		#region Start Methods

		/// <summary>
		/// Devuelve un valor que indica que se puede reiniciar una controladora <see cref="UIFilterBaseController{TFilter, TUISettings, TComponent}"/>.
		/// </summary>
		/// <returns>true</returns>
		protected override bool AllowReset()
		{
			return true;
		}

		/// <summary>
		/// Invoca al método sobrescirto <see cref="Controller{TInput, TOutput}.OnAfterStartController()"/> y
		/// posteriormente establece la configuración inicial de <see cref="FilterBaseComponent{TFilter}"/>.
		/// </summary>
        protected override void OnAfterStartController()
        {
            base.OnAfterStartController();

            UIElement.Filter = Parameters.Filter;
        }

		/// <summary>
		/// Invoca al método sobrescirto <see cref="Controller{TInput, TOutput}.OnAfterResetController()"/> y
		/// posteriormente establece la configuración de reinicio de <see cref="FilterBaseComponent{TFilter}"/>.
		/// </summary>
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