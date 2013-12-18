/*
 * Sifaw.Controllers.Components
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 11/12/2013: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sifaw.Core;

using Sifaw.Views;
using Sifaw.Views.Components;
using Sifaw.Views.Kit;


namespace Sifaw.Controllers.Components
{
    /// <summary>
    /// Controladora encargada de administrar la visualización de una lista de datos.
    /// </summary>
    /// <typeparam name="TValue">
    /// Tipo que usa el objeto a listar para el campo que identifica de forma única como <see cref="System.Guid"/>, <see cref="System.Int32"/> o <see cref="System.String"/>.
    /// </typeparam>
    public class UIDataListController<TValue> : UIComponentController
        < UIDataListController<TValue>.Input
        , UIDataListController<TValue>.Output
		, DataListComponent<TValue>>
    {
        #region Input / Output

		/// <summary>
		/// Parámetros de entrada de las controladora.
		/// </summary>
		[Serializable]
		public new class Input : UIComponentController
			< Input
			, Output
            , DataListComponent<TValue>>.Input
		{
            #region Fields

            private TValue _selectedValue = default(TValue);
            private IList<IListable<TValue>> _list;

            #endregion

            #region Properties

            /// <summary>
            /// Devuelve el valor del elemento a seleccionar.
            /// </summary>
            public TValue SelectedValue
            {
                get { return _selectedValue; }
            }

            /// <summary>
            /// Devuelve la lista a aplicar al iniciar la controladora.
            /// </summary>
            public IList<IListable<TValue>> List
            {
                get { return _list; }
            }

            #endregion

			#region Constructor

			/// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIDataListController{TValue}.Input"/>.
			/// </summary>
            /// <param name="list">Listado de <see cref="IListable{TValue}"/></param>
            public Input(IList<IListable<TValue>> list)
			{
                this._list = list;
			}

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIDataListController{TValue}.Input"/>.
            /// </summary>
            /// <param name="list">Listado de <see cref="IListable{TValue}"/>.</param>
            /// <param name="selected">Valor del item a seleccionar.</param>
            public Input(IList<IListable<TValue>> list, TValue selected)
                : this(list)
            {
                this._selectedValue = selected;
            }

			#endregion
		}

		/// <summary>
		/// Parámetros de retorno de la controladora.
		/// </summary>
		[Serializable]
		public new class Output : UIComponentController
			< Input
			, Output
            , DataListComponent<TValue>>.Output
		{
            #region Fields

            private TValue _value;

            #endregion

            #region Properties

            /// <summary>
            /// Devuelve el valor seleccionado.
            /// </summary>
            public TValue Value
            {
                get { return _value; }
            }

            #endregion

			#region Constructor

			/// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIDataListController{TValue}.Output"/>.
			/// </summary>
            /// <param name="value">Valor del elemento seleccionado.</param>
			public Output(TValue value)
			{
                _value = value;
			}

			#endregion
		}

		#endregion

		#region Fileds

		[CLReseteable(null)]
        private IList<IListable<TValue>> _dataList = null;

        private TValue _selectedValue = default(TValue);

        [CLReseteable(-1)]
        private int _selectedIndex = -1;

		#endregion

		#region Events

		/*
		 * Desencadenadores privados.
		 *  • Solo son lanzados por la controladora padre.
		 */

        /// <summary>
        /// Se produce cuando cambia el valor seleccionado.
        /// </summary>
        public event SFIntEventHandler SelectedIndexChanged;

		/// <summary>
        /// Provoca el evento <see cref="SelectedIndexChanged"/>. 
		/// </summary>
        /// <param name="e"><see cref="Sifaw.Core.SFIntEventHandler"/> que contiene los datos del evento.</param>
        private void OnSelectedIndexChanged(SFIntEventArgs e)
		{
            if (SelectedIndexChanged != null)
                SelectedIndexChanged(this, e);
		}

        /// <summary>
        /// Se produce cuando cambia el valor seleccionado.
        /// </summary>
        public event SFValueEventHandler<TValue> SelectedValueChanged;

		/// <summary>
        /// Provoca el evento <see cref="SelectedValueChanged"/>. 
		/// </summary>
        /// <param name="e"><see cref="Sifaw.Core.SFValueEventHandler{TValue}"/> que contiene los datos del evento.</param>
        private void OnSelectedValueChanged(SFValueEventArgs<TValue> e)
		{
            if (SelectedValueChanged != null)
                SelectedValueChanged(this, e);
		}

		/*
		 * Desencadenadores protegidos.
		 *  • Pueden ser lanzados por controladoras hijas.
		 */

		/* Empty */

		#endregion

		#region Properties

		/// <summary>
		/// Devuelve la lista de datos.
		/// </summary>
        /// <remarks>
        /// Para acceder a la propiedad la controladora ha de estar iniciada, 
        /// en otro caso, devolverá una excepcion.
        /// </remarks>
        /// <exception cref="NotValidStateException">La controladora no está iniciada.</exception>
        public IList<IListable<TValue>> DataList
		{
			get
            {
                CheckState(CLStates.Started);
                return _dataList; 
            }
		}

        /// <summary>
        /// Devuelve el valor del elemento seleccionado.
        /// </summary>
        /// <remarks>
        /// Para acceder a la propiedad la controladora ha de estar iniciada, 
        /// en otro caso, devolverá una excepcion.
        /// </remarks>
        /// <exception cref="NotValidStateException">La controladora no está iniciada.</exception>
        public TValue SelectedValue
        {
            get 
            {
                CheckState(CLStates.Started);
                return _selectedValue; 
            }
        }

        /// <summary>
        /// Devuelve el índice del elemento seleccionado.
        /// </summary>
        /// <remarks>
        /// Para acceder a la propiedad la controladora ha de estar iniciada, 
        /// en otro caso, devolverá una excepcion.
        /// </remarks>
        /// <exception cref="NotValidStateException">La controladora no está iniciada.</exception>
        public int SelectedIndex
        {
            get 
            {
                CheckState(CLStates.Started);
                return _selectedIndex; 
            }
        }

		#endregion

		#region Constructors

		/// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UIDataListController{TValue}"/>.
        /// Establece como <see cref="UILinker{TUIElement}"/> aquel establecido por defecto a través de 
        /// <see cref="UILinkersManager"/>.
        /// </summary>
		public UIDataListController()
			: base()
		{
		}

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UIDataListController{TValue}"/>, 
		/// estableciendo el <see cref="UILinker{TUIElement}"/> especificado como valor de la propiedad 
		/// <see cref="UIElementController{TInput, TOutput, TUIElement}.Linker"/> donde <c>TUIElement</c> 
        /// implementa <see cref="DataListComponent{TValue}"/>.
        /// </summary>
        public UIDataListController(UILinker<DataListComponent<TValue>> linker)
			: base(linker)
		{
		}

		#endregion

        #region Public Methods

        /// <summary>
        /// Establece la lista de objectos listables <see cref="IListable{TValue}"/>.
        /// </summary>
        /// <remarks>
        /// Para invocar este método la controladora ha de estar iniciada, 
        /// en otro caso, devolverá una excepcion.
        /// </remarks>
        /// <exception cref="NotValidStateException">La controladora no está iniciada.</exception>
        /// <param name="list">Lista de <see cref="IListable{TValue}"/></param>
        public void SetDataList(IList<IListable<TValue>> list)
        {
            CheckState(CLStates.Started);

            this._dataList = list;

            UIElement.SetDataList(DataList);
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
        public void SelectListableItem(TValue value)
        {
            CheckState(CLStates.Started);
            UIElement.SelectListableItem(value);
        }
        
        #endregion

        #region UIElement Methods

        /// <summary>
        /// Invoca al método sobrescirto <see cref="UIComponentController{TInput, TOutput, TComponent}.OnAfterUIElementCreate()"/>.
		/// </summary>
		protected override void OnAfterUIElementCreate()
		{
			base.OnAfterUIElementCreate();

			/* Subscripción a eventos del componente... */
            UIElement.SelectedIndexChanged += UIElement_SelectedIndexChanged;
            UIElement.SelectedValueChanged += UIElement_SelectedValueChanged;
		}

		#endregion

        #region Default input / output

        /// <summary>
        /// Devuelve los parámetros de inicio por defecto.
        /// </summary>
        public override Input GetDefaultInput()
        {
            return new Input(null);
        }

        /// <summary>
        /// Devuelve los parámetros de reinicio por defecto.
        /// </summary>
        public override Input GetResetInput()
        {
            return new Input(null);
        }

        /// <summary>
        /// Devuelve los parámetros de retorno por defecto.
        /// </summary>
        protected override Output GetDefaultOutput()
        {
            return new Output(SelectedValue);
        }

        #endregion

        #region Start Methods

        /// <summary>
        /// Ejecuta los comandos de inicio de la controladora.
        /// </summary>
        protected override void StartController()
        {
            SetDataList(Parameters.List);
            UIElement.SelectListableItem(Parameters.SelectedValue);
        }

        /// <summary>
        /// Ejecuta los comandos de reinicio de la controladora.
        /// </summary>
        protected override void ResetController()
        {
            SetDataList(Parameters.List);
            UIElement.SelectListableItem(Parameters.SelectedValue);
        }

        /// <summary>
        /// Resetea los campos de la controladora cuando esta es finalizada.
        /// </summary>
        protected override void OnAfterResetFields(List<System.Reflection.FieldInfo> fields)
        {
            base.OnAfterResetFields(fields);

            this._selectedValue = default(TValue);
        }

        #endregion

        #region UIElement Event Handlers

        private void UIElement_SelectedValueChanged(object sender, SFValueEventArgs<TValue> e)
        {
            this._selectedValue = e.Value;

            OnSelectedValueChanged(e);
        }

        protected override bool AllowReset()
        {
            return true;
        }

        private void UIElement_SelectedIndexChanged(object sender, SFIntEventArgs e)
        {
            this._selectedIndex = e.Value;

            OnSelectedIndexChanged(e);
        }

		#endregion
    }
}
