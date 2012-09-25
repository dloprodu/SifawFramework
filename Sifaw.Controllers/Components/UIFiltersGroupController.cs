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
using System.Text;

using Sifaw.Core.Utilities;

using Sifaw.Views;
using Sifaw.Views.Components;


namespace Sifaw.Controllers.Components
{
	/// <summary>
	/// Controladora de tipo shell encargada de presentar un grupo de filtros.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Los componentes usados han de implementar el evento <see cref="FilterChanged"/> para ser
	/// considerados filtros válidos. Ejemplos de componentes que implementan este evento son todos aquellos
    /// que deriven de <see cref="FilterBaseComponent{TFilter}"/>.
	/// </para>
	/// </remarks>
	/// <exception cref="NotValidFilterException">Alguno de los componentes no implementa el evento <see cref="FilterChanged"/>.</exception>
    /// <typeparam name="TInput">
    /// Tipo para establecer los parámetros de inicio de la controladora. Ha de ser serializable y 
    /// derivar de <see cref="UIFiltersGroupController{TInput, TOutput, TFilter}.Input"/>.
    /// </typeparam>
    /// <typeparam name="TOutput">
    /// Tipo para establcer los parametros de retorno cuando finaliza la controladora. Ha de ser serializable y 
    /// derivar de <see cref="UIFiltersGroupController{TInput, TOutput, TFilter}.Output"/>.
    /// </typeparam>
    /// <typeparam name="TFilter">
	/// Tipo para establecer los datos de filtro que devolverá la controladora.
    /// Ha de ser serializable y derivar de <see cref="UIFiltersGroupController{TInput, TOutput, TFilter}.Filter"/>.
	/// </typeparam>
    public abstract class UIFiltersGroupController<TInput, TOutput, TFilter> : UIShellComponentController
		< TInput
		, TOutput
		, UIComponent >
        where TInput  : UIFiltersGroupController<TInput, TOutput, TFilter>.Input
        where TOutput : UIFiltersGroupController<TInput, TOutput, TFilter>.Output
		where TFilter : UIFiltersGroupController<TInput, TOutput, TFilter>.Filter
	{
		#region Input / Output

		/// <summary>
		/// Parámetros de entrada de la controladora.
		/// </summary>
		[Serializable]
		public abstract new class Input : UIShellComponentController
			< TInput
			, TOutput
			, UIComponent>.Input
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
		public abstract new class Output : UIShellComponentController
			< TInput
			, TOutput
			, UIComponent>.Output
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

		#region Filter

		/// <summary>
        /// Filtro de <see cref="UIFiltersGroupController{TInput, TOutput, TFilter}"/>.
		/// </summary>
		[Serializable]
		public abstract class Filter : ICloneable
		{
			#region ICloneable Members

			/// <summary>
			/// Devuelve una copia del filtro de la controladora.
			/// </summary>
			public object Clone()
			{
				return UtilIO.Clone<TFilter>(this as TFilter);
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
		/// Se produce cuando cambia el valor de la propiedad <see cref="Filter"/> de alguno de los
		/// filtros alojados en la shell.
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

		#region Constructors

		/// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UIFiltersGroupController{TInput, TOutput, TFilter}"/>.
		/// Establece como <see cref="UILinker{TUIElement}"/> aquel establecido por defecto a través de 
		/// <see cref="UILinkersManager"/>.
		/// </summary>
		protected UIFiltersGroupController()
			: base()
		{
		}

		/// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UIFiltersGroupController{TInput, TOutput, TFilter}"/>, 
		/// estableciendo el <see cref="UILinker{TUIElement}"/> especificado como valor de la propiedad 
		/// <see cref="UIElementController{TInput, TOutput, TUIElement}.Linker"/> dond <c>TUIElement</c>
		/// implementa <see cref="ShellComponent"/>.
		/// </summary>
		protected UIFiltersGroupController(UILinker<ShellComponent> linker)
			: base(linker)
		{
		}

		#endregion

		#region Abstract Methods

		/// <summary>
		/// Devuelve el filtro actualmente aplicado.
		/// </summary>
		/// <returns>Filtro.</returns>
		protected abstract TFilter GetFilter();
		
		#endregion

		#region UIElement Methods

		/// <summary>
        /// Invoca al método sobrescirto <see cref="UIShellComponentController{TInput, TOutput, UIComponent}.OnAfterUIElementCreate()"/>.
		/// </summary>
		protected override void OnAfterUIElementCreate()
		{
			base.OnAfterUIElementCreate();

			/* Subscripción a eventos del componente... */		
		}

        /// <summary>
        /// Invoca al método sobrescirto <see cref="UIShellComponentController{TInput, TOutput, TComponent, TGuest}.OnUIElementLoaded()"/> y
        /// posteriormente aplica la configuración por defecto al objeto <see cref="UIComponent"/>.
        /// </summary>
        protected override void OnUIElementLoaded()
        {
            base.OnUIElementLoaded();

            /* Default settings.. */
            UISettings.Border = new Views.Kit.UIFrame(1);
        }

		#endregion

		#region Default Input / Output

		/// <summary>
		/// Devuelve los parámetros de reinicio por defecto.
		/// </summary>
		public override TInput GetResetInput()
		{
			return GetDefaultInput();
		}

		#endregion

		#region Start Methods

		/// <summary>
		/// Invoca al método sobrescirto <see cref="Controller{TInput, TOutput}.OnBeforeStartController()"/> y
        /// posteriormente se subscribe a los eventos <see cref="UIFilterBaseController{TInput, TOutput, TFilter, TComponent}.FilterChanged"/>
		/// de los filtros alojados por la shell.
		/// </summary>
		protected override void OnBeforeStartController()
		{
			base.OnBeforeStartController();

			if (Guests != null)
			{
				for (int i = 0; i < Guests.Count; i++)
				{
					try
					{
						UtilReflection.SubscribeToEvent(
							  Guests[i]
							, "FilterChanged"
							, this
							, typeof(UIFiltersGroupController<TInput, TOutput, TFilter>)
							, "GuestComponentes_FilterChanged"
							, (Delegate)null);
					}
					catch
					{
						throw new NotValidFilterException();
					}
				}
			}
		}

		#endregion

		#region Inclusions Events Handlers 

		private void GuestComponentes_FilterChanged(object sender, EventArgs e)
		{
			OnFilterChanged(new CLFilterChangedEventArgs<TFilter>(GetFilter()));
		}

		#endregion
	}
}