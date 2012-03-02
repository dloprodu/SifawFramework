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
	/// <typeparam name="TFilter">
	/// Tipo para establecer los datos de filtro que devolverá la controladora.
	/// Ha de ser serializable y derivar de <see cref="UIFiltersGroupController{TFilter}.Filter"/>.
	/// </typeparam>
	public abstract class UIFiltersGroupController<TFilter> : UIShellComponentController
		< UIFiltersGroupController<TFilter>.Input
		, UIFiltersGroupController<TFilter>.Output
		, UIFiltersGroupController<TFilter>.UISettingsContainer
		, UIComponent>
		where TFilter : UIFiltersGroupController<TFilter>.Filter
	{
		#region Input / Output

		/// <summary>
		/// Parámetros de entrada de la controladora.
		/// </summary>
		[Serializable]
		public new class Input : UIShellComponentController
			< Input
			, Output
			, UISettingsContainer
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
			/// Inicializa una nueva instancia de la clase <see cref="UIFiltersGroupController{TFilter}.Input"/>,
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
		public new class Output : UIShellComponentController
			< Input
			, Output
			, UISettingsContainer
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
			/// Inicializa una nueva instancia de la clase <see cref="UIFiltersGroupController{TFilter}.Output"/>,
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

		#region Filter

		/// <summary>
		/// Filtro de <see cref="UIFiltersGroupController{TFilter}"/>.
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

		#region Settings

		/// <summary>
		/// Contenedor de ajustes de <see cref="UIFiltersGroupController{TFilter}"/>.
		/// </summary>
		[Serializable]
		public new class UISettingsContainer : UIShellComponentController
			< Input
			, Output
			, UISettingsContainer
			, UIComponent>.UISettingsContainer
		{
			#region Constructors

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UIFiltersGroupController{TFilter}.UISettingsContainer"/>.
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
		/// Inicializa una nueva instancia de la clase <see cref="UIFiltersGroupController{TFilter}"/>.
		/// Establece como <see cref="AbstractUILinker{TUIElement}"/> aquel establecido por defecto a través de 
		/// <see cref="AbstractUIProviderManager{TLinker}"/>.
		/// </summary>
		protected UIFiltersGroupController()
			: base()
		{
		}

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIFiltersGroupController{TFilter}"/>, 
		/// estableciendo el <see cref="AbstractUILinker{TUIElement}"/> especificado como valor de la propiedad 
		/// <see cref="UIElementController{TInput, TOutput, TUIStyle, TUIElement}.Linker"/> dond <c>TUIElement</c>
		/// implementa <see cref="ShellComponent"/>.
		/// </summary>
		protected UIFiltersGroupController(AbstractUILinker<ShellComponent> linker)
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
		/// Invoca al método sobrescirto <see cref="UIElementController{TInput, TOutput, TUIStyle, TComponent}.OnAfterUIElementLoad()"/>.
		/// </summary>
		protected override void OnAfterUIElementLoad()
		{
			base.OnAfterUIElementLoad();

			/* Subscripción a eventos del componente... */		
		}

		/// <summary>
		/// Invoca al método sobrescirto <see cref="UIElementController{TInput, TOutput, TUIStyle, TComponent}.OnApplyUISettings()"/> y
		/// posteriormente aplica la configuración al elemento <see cref="UIElementController{TInput, TOutput, TUIStyle, TView}.UIElement"/> 
		/// del tipo <see cref="ShellComponent"/>.
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
			return GetDefaultInput();
		}

		/// <summary>
		/// Devuelve los parámetros de retorno por defecto.
		/// </summary>
		protected override Output GetDefaultOutput()
		{
			return new Output(GetFilter());
		}

		#endregion

		#region Start Methods

		/// <summary>
		/// Invoca al método sobrescirto <see cref="Controller{TInput, TOutput}.OnBeforeStartController()"/> y
		/// posteriormente se subscribe a los eventos <see cref="UIFilterBaseController{TFilter, TUISettings, TComponent}.FilterChanged"/>
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
							, typeof(UIFiltersGroupController<TFilter>)
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