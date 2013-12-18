/*
 * Sifaw.Controllers.Components
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 22/09/2013: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Core;
using Sifaw.Core.Utilities;

using Sifaw.Views;
using Sifaw.Views.Components;
using Sifaw.Views.Kit;


namespace Sifaw.Controllers.Components
{
    /// <summary>
    /// Controladora que permite la exploración de una lista de datos a través de un grupo de filtros.
    /// </summary>
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
    /// <typeparam name="TValue">
    /// Tipo que usa el objeto a listar para el campo que identifica de forma única como <see cref="System.Guid"/>, <see cref="System.Int32"/> o <see cref="System.String"/>.
    /// </typeparam>
    public abstract class UIBrowserController<TInput, TOutput, TFilter, TValue> : UIFiltersGroupController
        < TInput
        , TOutput
        , TFilter >
        where TInput  : UIBrowserController<TInput, TOutput, TFilter, TValue>.Input
        where TOutput : UIBrowserController<TInput, TOutput, TFilter, TValue>.Output
        where TFilter : UIBrowserController<TInput, TOutput, TFilter, TValue>.Filter
	{
        #region Input / Output

        /// <summary>
        /// Parámetros de entrada de la controladora.
        /// </summary>
        [Serializable]
        public abstract new class Input : UIFiltersGroupController
            < TInput
            , TOutput
            , TFilter>.Input
        {
            #region Constructors

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIBrowserController{TInput, TOutput, TFilter, TValue}.Input"/>.
            /// </summary>
            /// <param name="filter">Filtro a aplicar al iniciar la controladora.</param>
            protected Input(TFilter filter)
                : base(filter)
            {
            }

            #endregion
        }

        /// <summary>
        /// Parámetros de retorno de la controladora.
        /// </summary>
        [Serializable]
        public abstract new class Output : UIFiltersGroupController
            < TInput
            , TOutput
            , TFilter>.Output
        {
            #region Constructors

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIBrowserController{TInput, TOutput, TFilter, TValue}.Output"/>.
            /// </summary>
            /// <param name="filter">Filtro a aplicar al iniciar la controladora.</param>
            protected Output(TFilter filter)
                : base(filter)
            {
            }

            #endregion
        }

        #endregion

        #region Properties

        /// <summary>
        /// Devuelve el valor del elemento seleccionado.
        /// </summary>
        public TValue SelectedValue
        {
            get
            {
                return FilterableList.SelectedValue;
            }
        }

        #endregion

        #region Events

        /*
		 * Desencadenadores privados.
		 *  • Solo son lanzados por la controladora padre.
		 */

        /// <summary>
        /// Se produce cuando cambia el valor seleccionado.
        /// </summary>
        public event SFValueEventHandler<TValue> SelectedValueChanged;

        /// <summary>
        /// Provoca el evento <see cref="SelectedValueChanged"/>. 
        /// </summary>
        /// <param name="e"><see cref="Sifaw.Core.SFValueEventHandler{TValue}"/> que contiene los datos del evento.</param>
        protected void OnSelectedValueChanged(SFValueEventArgs<TValue> e)
        {
            if (SelectedValueChanged != null)
                SelectedValueChanged(this, e);
        }

        /// <summary>
        /// Provoca el evento <see cref="UIFiltersGroupController{TInput, TOutput, TFilter}.FilterChanged"/>.
        /// </summary>
        /// <param name="e"><see cref="Sifaw.Controllers.Components.CLFilterChangedEventArgs{TFilter}"/> que contiene los datos del evento.</param>
        protected override void OnFilterChanged(CLFilterChangedEventArgs<TFilter> e)
        {
            if (FilterableList.State == CLStates.Started)
                FilterableList.SetDataList(GetList());

            base.OnFilterChanged(e);
        }

        /*
         * Desencadenadores protegidos.
         *  • Pueden ser lanzados por controladoras hijas.
         */

        /*
         * Desencadenadores protegidos virtuales sin manejadores asociados.
         *  • Pueden ser sobreescritos por controladoras hijas para
         *    completar funcionalidad.
         */

        #endregion

        #region Inclusions

        private UIDataListController<TValue> _filterableList = null;
        private UIDataListController<TValue> FilterableList
        {
            get
            {
                if (_filterableList == null)
                {
                    _filterableList = new UIDataListController<TValue>();
                    _filterableList.SelectedValueChanged += _filterableList_SelectedValueChanged;
                }

                return _filterableList;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UIBrowserController{TInput, TOutput, TFilter, TValue}"/>.
        /// Establece como <see cref="UILinker{TUIElement}"/> aquel establecido por defecto a través de 
        /// <see cref="UILinkersManager"/>.
        /// </summary>
		public UIBrowserController()
			: base()
		{
		}

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UIBrowserController{TInput, TOutput, TFilter, TValue}"/>, 
        /// estableciendo el <see cref="UILinker{TUIElement}"/> especificado como valor de la propiedad 
        /// <see cref="UIElementController{TInput, TOutput, TUIElement}.Linker"/> donde <c>TUIElement</c>
        /// implementa <see cref="ShellComponent"/>.
        /// </summary>
        public UIBrowserController(UILinker<ShellComponent> linker)
			: base(linker)
		{
		}

		#endregion

        #region Abstract Methods

        /// <summary>
        /// Devuelve la lista que presentará el buscador aplicando los filtros actuales a la lista original.
        /// </summary>
        /// <returns>Lista de <see cref="IListable{TValue}"/>.</returns>
        protected abstract IList<IListable<TValue>> GetList();

        /// <summary>
        /// Devuelve el valor del item que debe aparecer seleccionado inicialmente.
        /// </summary>
        /// <returns></returns>
        protected abstract TValue GetInitialSelectedValue();

        #endregion

        #region Protected Methods

        /// <summary>
        /// Devuelve una referencia del <see cref="DataListComponent{TValue}"/> de la controladora.
        /// </summary>
        protected DataListComponent<TValue> GetUIDataListComponent()
        {
            return (FilterableList.GetUIComponent() as DataListComponent<TValue>);
        }

        /// <summary>
        /// Selecciona el item con el valor indicado.
        /// </summary>
        /// <remarks>
        /// Para invocar este método la controladora ha de estar iniciada, 
        /// en otro caso, devolverá una excepcion.
        /// </remarks>
        /// <exception cref="NotValidStateException">La controladora no está iniciada.</exception>
        /// <param name="value">Valor del item a seleccionar.</param>
        protected void SelectListableItem(TValue value)
        {
            CheckState(CLStates.Started);
            FilterableList.SelectListableItem(value);
        }

        #endregion

        #region Start Methods

        /// <summary>
        /// Invoca al método sobrescirto <see cref="UIFiltersGroupController{TInput, TOutput, TFilter}.OnBeforeStartController()"/>.
        /// </summary>
        protected override void OnBeforeStartController()
        {
            base.OnBeforeStartController();
        }

		/// <summary>
        /// Invoca al método sobrescirto <see cref="Controller{TInput, TOutput}.OnAfterStartController()"/>.
		/// </summary>
        protected override void OnAfterStartController()
        {
            base.OnAfterStartController();

            FilterableList.Start(new UIDataListController<TValue>.Input(GetList(), GetInitialSelectedValue()));
        }

        /// <summary>
        /// Invoca al método sobrescirto <see cref="Controller{TInput, TOutput}.OnBeforeResetController()"/>.
        /// </summary>
        protected override void OnBeforeResetController()
        {
            base.OnBeforeResetController();
        }

        /// <summary>
        /// Invoca al método sobrescirto <see cref="Controller{TInput, TOutput}.OnAfterResetController()"/>.
        /// </summary>
        protected override void OnAfterResetController()
        {
            base.OnAfterResetController();

            FilterableList.Reset(new UIDataListController<TValue>.Input(GetList(), GetInitialSelectedValue()));
        }

        #endregion

        #region Inclusions events handlers

        private void _filterableList_SelectedValueChanged(object sender, Core.SFValueEventArgs<TValue> e)
        {
            OnSelectedValueChanged(e);
        }

        #endregion
    }
}