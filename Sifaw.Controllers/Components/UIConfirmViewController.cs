/*
 * Sifaw.Controllers
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 14/12/2011: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

using Sifaw.Views;
using Sifaw.Views.Kit;


namespace Sifaw.Controllers.Components
{
	/// <summary>
	/// Controladora de vista que provee de la infraestructura para embeber un compontente
    /// <see cref="UIComponentController{TInput, TOutput, TComponent}"/>.
	/// </summary>
    public class UIConfirmViewController<TGuestController, TGuestInput, TGuestOutput, TGuestComponent> : UIShellConfirmViewController
        < UIConfirmViewController<TGuestController, TGuestInput, TGuestOutput, TGuestComponent>.Input
        , UIConfirmViewController<TGuestController, TGuestInput, TGuestOutput, TGuestComponent>.Output
		, UIComponent>
        where TGuestController : UIComponentController<TGuestInput, TGuestOutput, TGuestComponent>, new()
        where TGuestInput      : UIComponentController<TGuestInput, TGuestOutput, TGuestComponent>.Input
        where TGuestOutput     : UIComponentController<TGuestInput, TGuestOutput, TGuestComponent>.Output
        where TGuestComponent  : UIComponent
	{
		#region Input / Output

		/// <summary>
		/// Parámetros de entrada de las controladora.
		/// </summary>
		[Serializable]
        public new class Input : UIShellConfirmViewController<Input, Output, UIComponent>.Input
        {
            #region Fields

            private TGuestInput _gInput = default(TGuestInput);

            #endregion

            public TGuestInput GInput
            {
                get { return _gInput; }
            }

            #region Constructors

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIConfirmViewController{TGuestController, TGuestInput, TGuestOutput, TGuestComponent}.Input"/>.
            /// </summary>
            public Input()
                : this(default(TGuestInput))
            {
            }

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIConfirmViewController{TGuestController, TGuestInput, TGuestOutput, TGuestComponent}.Input"/>.
            /// </summary>
            /// <param name="input">Guest input.</param>
            public Input(TGuestInput input)
				: this(input, true, true)
			{
			}

            /// <summary>
            /// Inicializa una nueva instancia de <see cref="UIConfirmViewController{TGuestController, TGuestInput, TGuestOutput, TGuestComponent}.Input"/>
            /// </summary>
            /// <param name="input">Guest input.</param>
            /// <param name="showView">Indica si se muestra la vista al iniciar la controladora.</param>
            /// <param name="isModal">Indica si la vista es modal.</param>
            public Input(TGuestInput input, bool showView, bool isModal)
                : base(showView: showView, isModal: isModal)
            {
                _gInput = input;
            }

			#endregion
		}

		/// <summary>
		/// Parámetros de retorno de la controladora.
		/// </summary>
		[Serializable]
        public new class Output : UIShellConfirmViewController<Input, Output, UIComponent>.Output
		{
            #region Constructor

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIConfirmViewController{TGuestController}.Output"/>.
            /// </summary>
            /// <param name="confirmed">Flag que indica si se ha confirmado la acción.</param>
            public Output(bool confirmed) 
                : base(confirmed)
            {
            }

            #endregion
		}

		#endregion

        #region Inclusions

        private TGuestController _guest = default(TGuestController);
        private TGuestController Guest
        {
            get
            {
                if (_guest == null)
                {
                    _guest = new TGuestController();
                }

                return _guest;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UIConfirmViewController{TGuestController}"/>.
        /// Establece como <see cref="UILinker{TUIElement}"/> aquel establecido por defecto a través de 
        /// <see cref="UILinkersManager"/>.
        /// </summary>
		protected UIConfirmViewController()
			: base()
		{
		}

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UIConfirmViewController{TGuestController}"/>, 
		/// estableciendo el <see cref="UILinker{TUIElement}"/> especificado como valor de la propiedad 
		/// <see cref="UIElementController{TInput, TOutput, TUIElement}.Linker"/>
		/// donde <c>TUIElement</c> implementa <see cref="ShellView"/>.
        /// </summary>
        protected UIConfirmViewController(UILinker<ShellConfirmView> linker)
			: base(linker)
		{
		}

		#endregion

        #region UIElement Methods

        /// <summary>
        /// Invoca al método sobrescirto <see cref="UIViewController{TInput, TOutput, TView}.OnAfterUIElementCreate()"/> y
        /// posteriormente se subscribe a eventos de <see cref="UIView"/>.
        /// </summary>
        protected override void OnAfterUIElementCreate()
        {
            base.OnAfterUIElementCreate();

            /* Subscripción a eventos de la vista... */
        }

        #endregion

        #region Default Input / Output

        protected override Output GetDefaultOutput()
        {
            return new Output(Confirmed);
        }

        public override Input GetDefaultInput()
        {
            return new Input();
        }

        public override Input GetResetInput()
        {
            return null;
        }

        #endregion

        #region UIShell Methods

        protected override uint GetNumberOfRows()
        {
            return 1;
        }

        protected override uint GetNumberOfCellsAt(uint row)
        {
            return 1;
        }

        protected override void GetRowSettings(uint row, out double height, out UIShellLengthModes mode)
        {
            height = 400;
            mode = UIShellLengthModes.WeightedProportion;
        }

        protected override void GetRowCellSettings(uint row, uint cell, out double width, out UIShellLengthModes mode, out Sifaw.Views.UIComponent component)
        {
            width = 400;
            mode = UIShellLengthModes.WeightedProportion;
            component = Guest.GetUIComponent();
        }

        #endregion
        
        #region Start Methods

        #region Start Methods

        protected override void StartController()
        {
            if (Parameters.GInput != default(TGuestInput))
                Guest.Start(Parameters.GInput);
            else
                Guest.Start();
        }

        protected override bool AllowReset()
        {
            return false;
        }

        protected override void ResetController()
        {
            /* Empty */
        }

        #endregion

		#endregion
	}
}