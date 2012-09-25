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
	/// Controladora que por medio del componente de interfaz de usuario <see cref="BoolFilterComponent"/>
	/// permite realizar filtros sobre un campo booleanos, devolviendo como filtro <c>true</c> o <c>false</c>.
	/// </summary>
	public class UIBoolFilterController : UIFilterBaseController
        < UIBoolFilterController.Input
        , UIBoolFilterController.Output
        , bool
		, BoolFilterComponent >
	{
        #region Input / Output

        /// <summary>
        /// Parámetros de entrada de la controladora.
        /// </summary>
        [Serializable]
        public new class Input : UIFilterBaseController
            < Input
            , Output
            , bool
            , BoolFilterComponent>.Input
        {
            #region Constructors

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIBoolFilterController.Input"/>,
            /// estableciendo un valor en la propiedad <see cref="UIFilterBaseController{TInput, TOutput, TFilter, TComponent}.Filter"/>.
            /// </summary>
            /// <param name="filter">Filtro a aplicar al iniciar la controladora.</param>
            public Input(bool filter)
                : base(filter)
            {

            }

            #endregion
        }

        /// <summary>
        /// Parámetros de retorno de la controladora.
        /// </summary>
        [Serializable]
        public new class Output : UIFilterBaseController
            < Input
            , Output
            , bool
            , BoolFilterComponent>.Output
        {
            #region Constructors

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIBoolFilterController.Output"/>,
            /// estableciendo un valor en la propiedad <see cref="UIFilterBaseController{TInput, TOutput, TFilter, TComponent}.Filter"/>.
            /// </summary>
            /// <param name="filter">Filtro al finalizar la controladora.</param>
            public Output(bool filter)
                : base(filter)
            {
            }

            #endregion
        }

        #endregion

		#region Properties

		/// <summary>
		/// Devuelve el contenedor de ajustes del elemento de interfaz a través
		/// del cual se puede modificar la configuración predeterminada.
		/// </summary>
		public new BoolFilterSettings UISettings
		{
			get { return UIElement.UISettings; }
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIBoolFilterController"/>.
		/// Establece como <see cref="UILinker{TUIElement}"/> aquel establecido por defecto a través de 
		/// <see cref="UILinkersManager"/>.
		/// </summary>
		public UIBoolFilterController()
			: base()
		{
		}

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIBoolFilterController"/>, 
		/// estableciendo el <see cref="UILinker{TUIElement}"/> como valor de la propiedad 
		/// <see cref="UIElementController{TInput, TOutput, TUIElement}.Linker"/> donde <c>TUIElement</c>
		/// implementa <see cref="BoolFilterComponent"/>.
		/// </summary>
		public UIBoolFilterController(UILinker<BoolFilterComponent> linker)
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
			return new Input(false);
		}

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