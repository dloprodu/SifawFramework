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
using System.Collections;
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
	/// El componente muestra el elemento <see cref="IFilterable"/> seleccionado pudiendo 
	/// desplegar la lista y cambiar la selección.
	/// </para>
	/// </remarks>
	public class UIDropDownListFilterController : UIListFilterBaseController
        < UIDropDownListFilterController.Input
        , UIDropDownListFilterController.Output
        , IFilterable
		, IList<IFilterable>
		, DropDownListFilterComponent>
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
            , DropDownListFilterComponent>.Input
        {
            #region Constructors

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIDropDownListFilterController.Input"/>,
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
            , DropDownListFilterComponent>.Output
        {
            #region Constructors

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIDropDownListFilterController.Output"/>,
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
		/// Inicializa una nueva instancia de la clase <see cref="UIDropDownListFilterController"/>.
		/// Establece como <see cref="UILinker{TUIElement}"/> aquel establecido por defecto a través de 
		/// <see cref="UILinkersManager"/>.
		/// </summary>
		public UIDropDownListFilterController()
			: base()
		{
		}

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIDropDownListFilterController"/>, 
		/// estableciendo el <see cref="UILinker{TUIElement}"/> como valor de la propiedad 
		/// <see cref="UIElementController{TInput, TOutput, TUIElement}.Linker"/> donde <c>TUIElement</c>
		/// implementa <see cref="DropDownListFilterComponent"/>.
		/// </summary>
		public UIDropDownListFilterController(UILinker<DropDownListFilterComponent> linker)
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
            UISettings.Height = 21;
            UISettings.Width = 120;
            //UISettings.MinSize = new Views.Kit.UISize(0, 21);

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