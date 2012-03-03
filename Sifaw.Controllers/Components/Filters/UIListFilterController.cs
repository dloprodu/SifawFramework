/*
 * Sifaw.Controllers.Components.Filters
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

using Sifaw.Views;
using Sifaw.Views.Components;
using Sifaw.Views.Components.Filters;


namespace Sifaw.Controllers.Components.Filters
{
	/// <summary>
	/// Controladora que permite realizar filtros sobre una lista de objetos <see cref="IFilterable"/>, 
	/// devolviendo como filtro una sublista de objetos seleccioandos.
	/// </summary>
	/// <remarks>
	/// <para>
	/// El componente muestra toda la lista de elementos <see cref="IFilterable"/> al usuario. 
	/// elegir uno o varios elementos de la lista.
	/// </para>
	/// </remarks>
	public class UIListFilterController : UIListFilterBaseController
		< UIListFilterController.Input
        , UIListFilterController.Output
        , IList<IFilterable>
		, IList<IFilterable>
		, ListFilterComponent>
	{
        #region Input / Output

        /// <summary>
        /// Parámetros de entrada de la controladora.
        /// </summary>
        [Serializable]
        public new class Input : UIListFilterBaseController
            < Input
            , Output
            , IList<IFilterable>
            , IList<IFilterable>
            , ListFilterComponent>.Input
        {
            #region Constructors

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIListFilterController.Input"/>,
            /// estableciendo un valor en la propiedad <see cref="UIFilterBaseController{TInput, TOutput, TFilter, TComponent}.Filter"/>.
            /// </summary>
            /// <param name="source">Lista de filtrado.</param>
            /// <param name="filter">Filtro a aplicar al iniciar la controladora.</param>
            public Input(IList<IFilterable> source, IList<IFilterable> filter)
                : base(source, filter)
            {

            }

            #endregion
        }

        /// <summary>
        /// Parámetros de retorno de la controladora.
        /// </summary>
        [Serializable]
        public new class Output : UIListFilterBaseController
            < Input
            , Output
            , IList<IFilterable>
            , IList<IFilterable>
            , ListFilterComponent>.Output
        {
            #region Constructors

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIListFilterController.Output"/>,
            /// estableciendo un valor en la propiedad <see cref="UIFilterBaseController{TInput, TOutput, TFilter, TComponent}.Filter"/>.
            /// </summary>
            /// <param name="filter">Filtro al finalizar la controladora.</param>
            public Output(IList<IFilterable> filter)
                : base(filter)
            {
            }

            #endregion
        }

        #endregion

		#region Constructors

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIListFilterController"/>.
		/// Establece como <see cref="AbstractUILinker{TUIElement}"/> aquel establecido por defecto a través de 
		/// <see cref="AbstractUIProviderManager{TLinker}"/>.
		/// </summary>
		public UIListFilterController()
			: base()
		{
		}

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIListFilterController"/>, 
		/// estableciendo el <see cref="AbstractUILinker{TUIElement}"/> como valor de la propiedad 
		/// <see cref="UIElementController{TInput, TOutput, TUIElement}.Linker"/> donde <c>TUIElement</c>
		/// implementa <see cref="ListFilterComponent"/>.
		/// </summary>
		public UIListFilterController(AbstractUILinker<ListFilterComponent> linker)
			: base(linker)
		{
		}

		#endregion

		#region Default input / output

		/// <summary>
		/// Devuelve los parámetros de inicio por defecto.
		/// </summary>
		public override Input GetDefaultInput()
		{
			return new Input(new List<IFilterable>(), new List<IFilterable>());
		}

        /// <summary>
        /// Devuelve los parámetros de reinicio por defecto.
        /// </summary>
        public override Input GetResetInput()
        {
            return new Input(GetInitialParameters().Source, Filter);
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
		/// Ejecuta los comandos de inicio de la controladora.
		/// </summary>
		protected override void StartController()
		{
			/* Empty */
		}

		/// <summary>
		/// Ejecuta los comandos de reinicio de la controladora.
		/// </summary>
		protected override void ResetController()
		{
			/* Empty */
		}

		#endregion
	}
}