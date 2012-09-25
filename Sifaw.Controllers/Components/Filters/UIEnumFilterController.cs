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
	/// devolviendo como filtro el item seleccionado.
	/// </summary>
	/// <remarks>
	/// <para>
	/// El componente muestra toda la lista de elementos <see cref="IFilterable"/> al usuario. 
	/// </para>
	/// <para>
	/// Si la lista de filtro tiene demasiados items es recomendable usar un componente mas
	/// adecuado como <see cref="UIDropDownListFilterController"/> que muestra solo el elemento
	/// seleccioando.
	/// </para>
	/// </remarks>
	public class UIEnumFilterController : UIListFilterBaseController
        < UIEnumFilterController.Input
        , UIEnumFilterController.Output 
        , IFilterable
		, IList<IFilterable>
		, EnumFilterComponent>
	{
        #region Input / Output

        /// <summary>
        /// Parámetros de entrada de la controladora.
        /// </summary>
        [Serializable]
        public new class Input : UIListFilterBaseController
            < Input
            , Output
            , IFilterable
            , IList<IFilterable>
            , EnumFilterComponent>.Input
        {
            #region Constructors

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIEnumFilterController.Input"/>,
            /// estableciendo un valor en la propiedad <see cref="UIFilterBaseController{TInput, TOutput, TFilter, TComponent}.Filter"/>.
            /// </summary>
            /// <param name="source">Lista de filtrado.</param>
            /// <param name="filter">Filtro a aplicar al iniciar la controladora.</param>
            public Input(IList<IFilterable> source, IFilterable filter)
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
            , IFilterable
            , IList<IFilterable>
            , EnumFilterComponent>.Output
        {
            #region Constructors

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIEnumFilterController.Output"/>,
            /// estableciendo un valor en la propiedad <see cref="UIFilterBaseController{TInput, TOutput, TFilter, TComponent}.Filter"/>.
            /// </summary>
            /// <param name="filter">Filtro al finalizar la controladora.</param>
            public Output(IFilterable filter)
                : base(filter)
            {
            }

            #endregion
        }

        #endregion

		#region Constructors

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIEnumFilterController"/>.
		/// Establece como <see cref="UILinker{TUIElement}"/> aquel establecido por defecto a través de 
		/// <see cref="UILinkersManager"/>.
		/// </summary>
		public UIEnumFilterController()
			: base()
		{
		}

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIEnumFilterController"/>, 
		/// estableciendo el <see cref="UILinker{TUIElement}"/> como valor de la propiedad 
		/// <see cref="UIElementController{TInput, TOutput, TUIElement}.Linker"/> donde <c>TUIElement</c>
		/// implementa <see cref="EnumFilterComponent"/>.
		/// </summary>
		public UIEnumFilterController(UILinker<EnumFilterComponent> linker)
			: base(linker)
		{
		}

		#endregion

        #region UIElement Methods

        /// <summary>
        /// Invoca al método sobrescirto <see cref="UIFilterBaseController{TInput, TOutput, TFilter, TComponent}.OnAfterUIElementCreate()"/>.
        /// </summary>
        protected override void OnAfterUIElementCreate()
        {
            base.OnAfterUIElementCreate();

            /* Default settings.. */
            UISettings.Height = 42;
            UISettings.Width = 120;

            /* Subscripción a eventos del componente... */
        }

        #endregion

		#region Default input / output

		/// <summary>
		/// Devuelve los parámetros de inicio por defecto.
		/// </summary>
		public override Input GetDefaultInput()
		{
            return new Input(new List<IFilterable>(), null);
		}

        /// <summary>
        /// Devuelve los parámetros de reinicio por defecto.
        /// </summary>
        public override Input GetResetInput()
        {
            return new Input(Parameters.Source, Filter);
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