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
	/// que deriven de <see cref="FilterBaseComponent"/>.
	/// </para>
	/// </remarks>
	/// <exception cref="NotValidFilterException">Alguno de los componentes no implementa el evento <see cref="FilterChanged"/>.</exception>
	/// <typeparam name="TFilter">Tipo para establecer los datos de filtro que devolverá la controladora.</typeparam>
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
		public new class UISettingsContainer : UIShellComponentController
			< Input
			, Output
			, UISettingsContainer
			, UIComponent>.UISettingsContainer
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

		#region Constructors

		protected UIFiltersGroupController()
			: base()
		{
		}

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

		protected override void OnAfterUIElementLoad()
		{
			base.OnAfterUIElementLoad();

			/* Subscripción a eventos del componente... */		
		}

		#endregion

		#region Default Input / Output

		public override Input GetResetInput()
		{
			return GetDefaultInput();
		}

		protected override Output GetDefaultOutput()
		{
			return new Output(GetFilter());
		}

		#endregion

		#region Start Methods

		[CLReseteable(null)]
		private Delegate[] FilterChangedCallbaks = null;

		protected override void OnBeforeStartController()
		{
			base.OnBeforeStartController();

			if (GuestComponentes != null)
			{
				FilterChangedCallbaks = new Delegate[GuestComponentes.Count];

				for (int i = 0; i < GuestComponentes.Count; i++)
				{
					try
					{
						UtilReflection.SubscribeToEvent(
							  GuestComponentes[i]
							, "FilterChanged"
							, this
							, typeof(UIFiltersGroupController<TFilter>)
							, "GuestComponentes_FilterChanged"
							, FilterChangedCallbaks[i]);
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