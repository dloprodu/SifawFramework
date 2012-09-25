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
	/// Controladora que permite realizar filtros de texto, devolviendo como
	/// filtro el texto introducido por el usuario.
	/// </summary>
	public class UITextFilterController : UIFilterBaseController
        < UITextFilterController.Input
        , UITextFilterController.Output
        , string
		, TextFilterComponent>
	{
        #region Input / Output

        /// <summary>
        /// Parámetros de entrada de la controladora.
        /// </summary>
        [Serializable]
        public new class Input : UIFilterBaseController
            < Input
            , Output
            , string
            , TextFilterComponent>.Input
        {
            #region Constructors

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UITextFilterController.Input"/>,
            /// estableciendo un valor en la propiedad <see cref="UIFilterBaseController{TInput, TOutput, TFilter, TComponent}.Filter"/>.
            /// </summary>
            /// <param name="filter">Filtro a aplicar al iniciar la controladora.</param>
            public Input(string filter)
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
            , string
            , TextFilterComponent>.Output
        {
            #region Constructors

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UITextFilterController.Output"/>,
            /// estableciendo un valor en la propiedad <see cref="UIFilterBaseController{TInput, TOutput, TFilter, TComponent}.Filter"/>.
            /// </summary>
            /// <param name="filter">Filtro al finalizar la controladora.</param>
            public Output(string filter)
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
        public new TextFilterSettings UISettings
        {
            get { return UIElement.UISettings; }
        }

		#endregion

		#region Constructors

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UITextFilterController"/>.
		/// Establece como <see cref="UILinker{TUIElement}"/> aquel establecido por defecto a través de 
		/// <see cref="UILinkersManager"/>.
		/// </summary>
		public UITextFilterController()
			: base()
		{
		}

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UITextFilterController"/>, 
		/// estableciendo el <see cref="UILinker{TUIElement}"/> como valor de la propiedad 
		/// <see cref="UIElementController{TInput, TOutput, TUIElement}.Linker"/> donde <c>TUIElement</c>
		/// implementa <see cref="TextFilterComponent"/>.
		/// </summary>
		public UITextFilterController(UILinker<TextFilterComponent> linker)
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

            /* Subscripción a eventos del componente... */
        }

        #endregion

		#region Default input / output

		/// <summary>
		/// Devuelve los parámetros de inicio por defecto.
		/// </summary>
		public override Input GetDefaultInput()
		{
			return new Input(string.Empty);
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