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
using Sifaw.Core;


namespace Sifaw.Controllers
{
	/// <summary>
	/// Controladora base que provee de un patrón e infraestructura común a aquellas controladoras
	/// donde interviene una vista que actúa como shell, es decir, a modo de contenedor de componentes
    /// <see cref="UIComponentController{TInput, TOutput, TComponent}"/> con el fin de confirmar o cancelar una operación.
	/// </summary>
    /// <typeparam name="TInput">
    /// Tipo para establecer los parámetros de inicio de la controladora. Ha de ser serializable y 
    /// derivar de <see cref="UIShellViewController{TInput, TOutput, TGuest}.Input"/>.
    /// </typeparam>
    /// <typeparam name="TOutput">
    /// Tipo para establcer los parametros de retorno cuando finaliza la controladora. Ha de ser serializable y 
    /// derivar de <see cref="UIShellViewController{TInput, TOutput, TGuest}.Output"/>.
    /// </typeparam>
    /// <typeparam name="TGuest">
    /// Tipo de los componentes que puede alojar la shell. Ha de implementar <see cref="UIComponent"/>.
    /// </typeparam>
	public abstract class UIShellConfirmViewController<TInput, TOutput, TGuest> : UIViewController
		< TInput
		, TOutput
		, ShellConfirmView>
        where TInput  : UIShellConfirmViewController<TInput, TOutput, TGuest>.Input
        where TOutput : UIShellConfirmViewController<TInput, TOutput, TGuest>.Output
		where TGuest  : UIComponent
	{
		#region Input / Output

		/// <summary>
		/// Parámetros de entrada de las controladora.
		/// </summary>
		[Serializable]
        public abstract new class Input : UIViewController<TInput, TOutput, ShellConfirmView>.Input
		{
			#region Constructors

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIShellViewController{TInput, TOutput, TGuest}.Input"/>, 
            /// estableciendo la propiedad <see cref="UIViewController{TInput, TOutput, TView}.Input.ShowView"/> a <c>true</c>
            /// </summary>
			protected Input()
				: this(true, true)
			{
			}

            /// <summary>
            /// Inicializa una nueva instancia de <see cref="UIShellViewController{TInput, TOutput, TGuest}.Input"/>, 
            /// estableciendo un valor a la propiedad <see cref="UIViewController{TInput, TOutput, TView}.Input.ShowView"/>.
            /// </summary>
            /// <param name="showView">Indica si se muestra la vista al iniciar la controladora.</param>
            /// <param name="isModal">Indica si la vista es modal.</param>
            protected Input(bool showView, bool isModal)
				: base(showView:showView, isModal:isModal)
			{
			}

			#endregion
		}

		/// <summary>
		/// Parámetros de retorno de la controladora.
		/// </summary>
		[Serializable]
        public abstract new class Output : UIViewController<TInput, TOutput, ShellConfirmView>.Output
		{
            #region Fields

            private bool _confirmed;

            #endregion

            #region Properties

            /// <summary>
            /// Flag que indica si la operación ha sido confirmada.
            /// </summary>
            public bool Confirmed
            {
                get
                {
                    return _confirmed;
                }
            }

            #endregion

            #region Constructor

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIShellViewController{TInput, TOutput, TGuest}.Output"/>.
            /// </summary>
            /// <param name="confirmed">Flag que indica si se ha confirmado la acción.</param>
            protected Output(bool confirmed)
            {
                _confirmed = confirmed;
            }

            #endregion
		}

		#endregion

        #region Fields

        /// <summary>
        /// Lista de componetnes <see cref="Sifaw.Views.UIComponent"/> embebidos en la shell.
        /// </summary>
        [CLReseteable(null)]
        protected ReadOnlyCollection<TGuest> Guests = null;

        /// <summary>
        /// Flag que se activa cuando la operación ha sido confirmada.
        /// </summary>
        [CLReseteable(false)]
        private bool _confirmed = false;

        #endregion

        #region Properties

        /// <summary>
        /// Devuelve un valor que indica si se ha confirmado o cancelado la acción.
        /// </summary>
        protected bool Confirmed
        {
            get { return _confirmed;  }
            private set { _confirmed = value; }
        }

        #endregion

        #region Events

        /*
		 * Desencadenadores privados.
		 *  • Solo son lanzados por la controladora padre.
		 */

        /// <summary>
        /// Se produce cuando se quiere confirmar una operación.
        /// </summary>
        public event SFCancelEventHandler Confirm;

        /// <summary>
        /// Provoca el evento <see cref="Confirm"/>.
        /// </summary>
        /// <param name="e"><see cref="Sifaw.Core.SFCancelEventArgs"/> que contiene los datos del evento.</param>
        private void OnConfirm(SFCancelEventArgs e)
        {
            if (Confirm != null)
                Confirm(this, e);
        }

        /// <summary>
        /// Se produce cuando se va a cancelar una operación.
        /// </summary>
        public event SFCancelEventHandler Cancel;

        /// <summary>
        /// Provoca el evento <see cref="Cancel"/>.
        /// </summary>
        /// <param name="e"><see cref="Sifaw.Core.SFCancelEventArgs"/> que contiene los datos del evento.</param>
        private void OnCancel(SFCancelEventArgs e)
        {
            if (Cancel != null)
                Cancel(this, e);
        }

        /*
         * Desencadenadores protegidos.
         *  • Pueden ser lanzados por controladoras hijas.
         */

        /// <summary>
        /// Provoca el evento <see cref="Confirm"/>.
        /// </summary>
        /// <param name="cancel">Flag que indica si la confirmación se cancela.</param>
        protected virtual void OnConfirm(out bool cancel)
        {
            cancel = false;
        }

        /// <summary>
        /// Provoca el evento <see cref="Cancel"/>.
        /// </summary>
        /// <param name="cancel">Flag que indica si la cancelación se cancela.</param>
        protected virtual void OnCancel(out bool cancel)
        {
            cancel = false;
        }

        #endregion

		#region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UIShellConfirmViewController{TInput, TOutput, TGuest}"/>.
        /// Establece como <see cref="UILinker{TUIElement}"/> aquel establecido por defecto a través de 
        /// <see cref="UILinkersManager"/>.
        /// </summary>
		protected UIShellConfirmViewController()
			: base()
		{
		}

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UIShellConfirmViewController{TInput, TOutput, TGuest}"/>, 
		/// estableciendo el <see cref="UILinker{TUIElement}"/> especificado como valor de la propiedad 
		/// <see cref="UIElementController{TInput, TOutput, TUIElement}.Linker"/>
        /// donde <c>TUIElement</c> implementa <see cref="ShellConfirmView"/>.
        /// </summary>
        protected UIShellConfirmViewController(UILinker<ShellConfirmView> linker)
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
            UIElement.Confirm += UIElement_Confirm;
            UIElement.Cancel += UIElement_Cancel;
        }

        /// <summary>
        /// Invoca al método sobrescirto <see cref="UIViewController{TInput, TOutput, TView}.OnBeforeUIClose(SFCancelEventArgs)"/> y
        /// posteriormente se subscribe a eventos de <see cref="UIView"/>.
        /// </summary>
        protected override void OnBeforeUIClose(out bool cancel)
        {
            base.OnBeforeUIClose(out cancel);
        }

        #endregion

		#region Abstract Methods

		/// <summary>
		/// Deuvelve el número de filas de la shell.
		/// </summary>		
		protected abstract uint GetNumberOfRows();

		/// <summary>
		/// Devuelve el número de celdas por fila de la shell.
		/// </summary>
		/// <param name="row">Fila.</param>
		/// <returns>Número de columnas.</returns>
		protected abstract uint GetNumberOfCellsAt(uint row);

		/// <summary>
		/// Devuelve la configuración de una fila de la shell.
		/// </summary>
		/// <param name="row">Fila</param>
		/// <param name="height">Aultura de la fila.</param>
        /// <param name="mode">Mode de ajuste de la fila.</param>
		protected abstract void GetRowSettings(uint row, out double height, out UIShellLengthModes mode);

		/// <summary>
		/// Devuelve la configuracion de una celda de la shell.
		/// </summary>
		/// <param name="row">Fila de columna.</param>
		/// <param name="cell">Celda.</param>
		/// <param name="width">Ancho de la celda.</param>
        /// <param name="mode">Modo de ajuste de la celda.</param>
        /// <param name="guest">Contenido de la celda.</param>
		protected abstract void GetRowCellSettings(uint row, uint cell, out double width, out UIShellLengthModes mode, out TGuest guest);

		#endregion
        
        #region Start Methods

        /// <summary>
        /// Método que inyecta los componentes de interfaz en la shell.
        /// </summary>
        protected void BuildLayout()
        {
            UIShellRow[] rows = ShellOperationsManager.BuildLayout<TGuest>(
                  GetNumberOfRows
                , GetNumberOfCellsAt
                , GetRowSettings
                , GetRowCellSettings);

            List<TGuest> guests = new List<TGuest>();

            foreach (UIShellRow row in rows)
            {
                foreach (UIShellRowCell cell in row.Cells)
                {
                    if (cell.Content != null)
                    {
                        guests.Add((TGuest)cell.Content);

                        /* Default Settings... */
                        cell.Content.UISettings.HorizontalAlignment = UIHorizontalAlignment.Fill;
                        cell.Content.UISettings.VerticalAlignment = UIVerticalAlignment.Fill;
                        cell.Content.UISettings.Margin = UIFrame.Empty;
                    }
                }
            }

            Guests = guests.AsReadOnly();

            UIElement.SetLayout(rows);
        }

        /// <summary>
        /// Invoca al método sobrescirto <see cref="UIViewController{TInput, TOutput, TView}.OnBeforeStartController()"/> y
        /// posteriormente aplica la configuración de la shell, configuración como el número de filas, celdas por fila y componentes embebidos.
        /// </summary>
        protected override void OnBeforeStartController()
		{
			base.OnBeforeStartController();

            BuildLayout();
		}

		#endregion

        #region UIElement events handles

        private void UIElement_Confirm(object sender, EventArgs e)
        {
            SFCancelEventArgs args = new SFCancelEventArgs();
            OnConfirm(args);

            bool cancel = false;
            OnConfirm(out cancel);

            Confirmed = !args.Cancel && !cancel;

            if (Confirmed)
                Finish();
        }

        private void UIElement_Cancel(object sender, EventArgs e)
        {
            SFCancelEventArgs args = new SFCancelEventArgs();
            OnCancel(args);

            bool cancel = false;
            OnCancel(out cancel);

            if (!args.Cancel && !cancel)
                Finish();
        }

        #endregion
	}
}