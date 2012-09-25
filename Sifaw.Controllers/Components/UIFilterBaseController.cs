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
    /// <typeparam name="TInput">
    /// Tipo para establecer los parámetros de inicio de la controladora. Ha de ser serializable y 
    /// derivar de <see cref="UIFilterBaseController{TInput, TOutput, TFilter, TComponent}.Input"/>.
    /// </typeparam>
    /// <typeparam name="TOutput">
    /// Tipo para establcer los parametros de retorno cuando finaliza la controladora. Ha de ser serializable y 
    /// derivar de <see cref="UIFilterBaseController{TInput, TOutput, TFilter, TComponent}.Output"/>.
    /// </typeparam>
    /// <typeparam name="TFilter">
	/// Tipo del filtro que devolverá la controladora.
	/// </typeparam>
	/// <typeparam name="TComponent">
	/// Tipo para establecer el elemento de interfaz de usuario de la controladora. Ha de implementar <see cref="FilterBaseComponent{TFilter}"/>.
	/// </typeparam>
	public abstract class UIFilterBaseController<TInput, TOutput, TFilter, TComponent> : UIComponentController
		< TInput
        , TOutput
		, TComponent>
        where TInput     : UIFilterBaseController<TInput, TOutput, TFilter, TComponent>.Input
        where TOutput    : UIFilterBaseController<TInput, TOutput, TFilter, TComponent>.Output
        where TComponent : FilterBaseComponent<TFilter>
	{
		#region Input / Output

		/// <summary>
		/// Parámetros de entrada de la controladora.
		/// </summary>
		[Serializable]
		public abstract new class Input : UIComponentController
			< TInput
			, TOutput
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
            /// Inicializa una nueva instancia de la clase <see cref="UIFilterBaseController{TInput, TOutput, TFilter, TComponent}.Input"/>,
			/// estableciendo un valor en la propiedad <see cref="Filter"/>.
			/// </summary>
			/// <param name="filter">Filtro a aplicar al iniciar la controladora.</param>
            protected Input(TFilter filter)
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
		public abstract new class Output : UIComponentController
			< TInput
			, TOutput
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
            /// Inicializa una nueva instancia de la clase <see cref="UIFilterBaseController{TInput, TOutput, TFilter, TComponent}.Output"/>,
			/// estableciendo un valor en la propiedad <see cref="Filter"/>.
			/// </summary>
			/// <param name="filter">Filtro al finalizar la controladora.</param>
            protected Output(TFilter filter)
				: base()
			{
				_filter = filter;
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
        /// Inicializa una nueva instancia de la clase <see cref="UIFilterBaseController{TInput, TOutput, TFilter, TComponent}"/>.
		/// Establece como <see cref="UILinker{TUIElement}"/> aquel establecido por defecto a través de 
		/// <see cref="UILinkersManager"/>.
		/// </summary>
		protected UIFilterBaseController()
			: base()
		{
		}

		/// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UIFilterBaseController{TInput, TOutput, TFilter, TComponent}"/>, 
		/// estableciendo el <see cref="UILinker{TUIElement}"/> especificado como valor de la propiedad 
		/// <see cref="UIElementController{TInput, TOutput, TUIElement}.Linker"/> donde <c>TUIElement</c>
		/// implementa <see cref="FilterBaseComponent{TFilter}"/>.
		/// </summary>
		protected UIFilterBaseController(UILinker<TComponent> linker)
			: base(linker)
		{
		}

		#endregion

		#region UIElement Methods

		/// <summary>
        /// Invoca al método sobrescirto <see cref="UIComponentController{TInput, TOutput, TComponent}.OnAfterUIElementCreate()"/> y
		/// posteriormente se subscribe a los eventos del componente <see cref="FilterBaseComponent{TFilter}"/>.
		/// </summary>
		protected override void OnAfterUIElementCreate()
		{
			base.OnAfterUIElementCreate();
                  
			/* Subscripción a eventos del componente... */
			UIElement.FilterChanged += new UIFilterChangedEventHandler(UIElement_FilterChanged);
		}

        /// <summary>
        /// Invoca al método sobrescirto <see cref="UIComponentController{TInput, TOutput, TComponent}.OnUIElementLoaded()"/> y
        /// posteriormente aplica la configuración por defecto al objeto <see cref="UIView"/>.
        /// </summary>
        protected override void OnUIElementLoaded()
        {
            base.OnUIElementLoaded();

            /* Default settings.. */
            //UISettings.Border = new Views.Kit.UIFrame(1);
        }

		#endregion

		#region Start Methods

		/// <summary>
        /// Devuelve un valor que indica que se puede reiniciar una controladora <see cref="UIFilterBaseController{TInput, TOutput, TFilter, TComponent}"/>.
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