/*
 * Sifaw.Controllers.Components
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 29/02/2012: Creación de la clase.
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


namespace Sifaw.Controllers.Components
{
	/// <summary>
	/// Controladora que gestiona la representacion de datos en forma de tabla.
	/// </summary>
	/// <remarks>
	/// </remarks>
	/// <typeparam name="TInput">
	/// Tipo para establecer los parámetros de inicio de la controladora. Ha de ser serializable y 
	/// derivar de <see cref="UITableController{TInput, TOutput}.Input"/>.
	/// </typeparam>
	/// <typeparam name="TOutput">
	/// Tipo para establcer los parametros de retorno cuando finaliza la controladora. Ha de ser serializable y 
	/// derivar de <see cref="UITableController{TInput, TOutput}.Output"/>.
	/// </typeparam>
	public abstract class UITableController<TInput, TOutput> : UIComponentController
		< TInput
		, TOutput
		, TableComponent>
		where TInput  : UITableController<TInput, TOutput>.Input
		where TOutput : UITableController<TInput, TOutput>.Output
	{
		#region Input / Output

		/// <summary>
		/// Parámetros de entrada de las controladora.
		/// </summary>
		[Serializable]
		public abstract new class Input : UIComponentController
			< TInput
			, TOutput
			, TableComponent>.Input
		{
			#region Constructor

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UITableController{TInput, TOutput}.Input"/>.
			/// </summary>
			protected Input()
			{
			}

			#endregion
		}

		/// <summary>
		/// Parámetros de retorno de la controladora.
		/// </summary>
		[Serializable]
		public abstract new class Output : UIComponentController
			< TInput
			, TOutput
			, TableComponent>.Output
		{
			#region Constructor

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UITableController{TInput, TOutput}.Output"/>.
			/// </summary>
			protected Output()
			{
			}

			#endregion
		}

		#endregion

		#region Fields

		[CLReseteable(null)]
		private UITable _root = null;
		
		#endregion

		#region Properties

		/// <summary>
		/// Devuelve el contenedor de ajustes del elemento de interfaz a través
		/// del cual se puede modificar la configuración predeterminada.
		/// </summary>
		public new TableSettings UISettings
		{
			get { return UIElement.UISettings; }
		}

		#endregion

		#region Fileds


		#endregion

		#region Events

		/*
		 * Desencadenadores privados.
		 *  • Solo son lanzados por la controladora padre.
		 */

		/* Empty */

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

		/// <summary>
		/// <para>
		/// Se llama al método <see cref="OnRowSelected"/> cuando una fila es
		/// seleccionada. El método permite que las clases derivadas 
		/// controlen el evento sin asociar un delegado.
		/// </para>
		/// <para>
		/// Este métodos permite que las clases derivadas realicen operaciones de 
		/// configuración tales como suscribirse a eventos de la vista.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Al reemplazar <see cref="OnRowSelected"/> en una clase derivada, asegúrese de llamar al
		/// método <see cref="OnRowSelected"/> de la clase base para que los delegados registrados 
		/// reciban el evento.
		/// </para>
		/// </remarks>
		protected virtual void OnRowSelected(UIIndexRowPath path)
		{
			/* Empty */
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UITableController{TInput, TOutput}"/>.
        /// Establece como <see cref="AbstractUILinker{TUIElement}"/> aquel establecido por defecto a través de 
        /// <see cref="AbstractUIProviderManager{TLinker}"/>.
        /// </summary>
		protected UITableController()
			: base()
		{
		}

        /// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UITableController{TInput, TOutput}"/>, 
		/// estableciendo el <see cref="AbstractUILinker{TUIElement}"/> especificado como valor de la propiedad 
		/// <see cref="UIElementController{TInput, TOutput, TUIElement}.Linker"/> donde <c>TUIElement</c> 
		/// implementa <see cref="TableComponent"/>.
        /// </summary>
		protected UITableController(AbstractUILinker<TableComponent> linker)
			: base(linker)
		{
		}

		#endregion

		#region UIElement Methods

		/// <summary>
		/// Invoca al método sobrescirto <see cref="UIElementController{TInput, TOutput, TComponent}.OnAfterUIElementLoad()"/>.
		/// </summary>
		protected override void OnAfterUIElementLoad()
		{
			base.OnAfterUIElementLoad();

			/* Subscripción a eventos del componente... */
			UIElement.RowSelected += new UITableSectionRowSelectedEventHandler(UIElement_RowSelected);
		}

		#endregion

		#region UITableController Members

		/// <summary>
		/// Devuelve el número de filas que componen la cabecera de la tabla especificada.
		/// </summary>
		/// <param name="table">Nombre de la tabla.</param>
		/// <returns>Número de filas de la cabecera.</returns>
		protected abstract int GetNumberOfHeaderRows(string table);

		/// <summary>
		/// Devuelve el número de filas que componen el pie de la tabla especificada.
		/// </summary>
		/// <param name="table">Nombre de la tabla.</param>
		/// <returns>Número de filas del pie de tabla.</returns>
		protected abstract int GetNumberOfFooterRows(string table);

		/// <summary>
		/// Devuelve el número de secciones que componen el cuerpo de la tabla especificada.
		/// </summary>
		/// <param name="table">Nombre de la tabla.</param>
		/// <param name="settings">Ajustes de la sección.</param>
		/// <returns>Número de secciones de la tabla.</returns>
		protected abstract int GetNumberOfSectionsAt(string table, out UITableSection.UISettings settings);

		/// <summary>
		/// Devuelve el número de filas que componen la sección especificada.
		/// </summary>
		/// <param name="table">Nombre de la tabla.</param>
		/// <param name="section">Índice de la sección.</param>
		/// <returns>Número de filas.</returns>
		protected abstract int GetNumberOfRowsAt(string table, int section);

		/// <summary>
		/// Devuelve la configuración de celdas que componen la fila especificada de la cabecera.
		/// </summary>
		/// <param name="table">Nombre de la tabla.</param>
		/// <param name="row">Índice de la fila.</param>
		/// <returns>Array de celdas.</returns>
		protected abstract UITableCell[] GetHeaderAt(string table, int row);

		/// <summary>
		/// Devuelve la configuración de celdas que componen la fila especificada.
		/// </summary>
		/// <param name="path">Ruta de la fila.</param>
		/// <returns>Array de celdas.</returns>
		protected abstract UITableCell[] GetCellsAt(UIIndexRowPath path);

		/// <summary>
		/// Devuelve un valor que indica si la fila especificada tiene una tabla secundaria asociada. 
		/// </summary>
		/// <param name="path">Ruta de la fila.</param>
		/// <returns>
		/// <c>true</c> si la fila tiene una tabla secundaria asociada; 
		/// <c>false</c> en otro caso.
		/// </returns>
		protected abstract bool RowContainChildTable(UIIndexRowPath path);

		/// <summary>
		/// Devuelve el nombre de la tabla hija vinculada a la fila especificada.
		/// </summary>
		/// <param name="path">Ruta de la fila.</param>
		/// <returns>Nombre del a tabla hija.</returns>
		protected abstract string GetChildTableNameAt(UIIndexRowPath path);

		/// <summary>
		/// Devuelve la configuración de celdas que componen la fila especificada del pie de tabla.
		/// </summary>
		/// <param name="table">Nombre de la tabla.</param>
		/// <param name="row">Índice de la fila.</param>
		/// <returns>Array de celdas.</returns>
		protected abstract UITableCell[] GetFooterAt(string table, int row);

		#endregion

		#region Start Controler

		/// <summary>
		/// Devuelve un valor que indica que se puede reiniciar una controladora <see cref="UITableController{TInput, TOutput}"/>.
		/// </summary>
		/// <returns>true</returns>
		protected override bool AllowReset()
		{
			return true;
		}

		/// <summary>
		/// Invoca al método sobrescirto <see cref="Controller{TInput, TOutput}.OnAfterStartController()"/> y
		/// posteriormente establece la configuración inicial de <see cref="TableComponent"/>.
		/// </summary>
		protected override void OnAfterStartController()
		{
			base.OnAfterStartController();

			_root = TableOperationsManager.BuildTable(
				  GetNumberOfHeaderRows
				, GetHeaderAt
				, GetNumberOfFooterRows
				, GetFooterAt
				, GetNumberOfSectionsAt
				, GetNumberOfRowsAt
				, GetCellsAt
				, RowContainChildTable
				, GetChildTableNameAt
				, "Root");

			UIElement.SetTable(_root);
		}

		/// <summary>
		/// Invoca al método sobrescirto <see cref="Controller{TInput, TOutput}.OnAfterResetController()"/> y
		/// posteriormente establece la configuración de reinicio de <see cref="TableComponent"/>.
		/// </summary>
		protected override void OnAfterResetController()
		{
			base.OnAfterResetController();

			_root = TableOperationsManager.BuildTable(
				  GetNumberOfHeaderRows
				, GetHeaderAt
				, GetNumberOfFooterRows
				, GetFooterAt
				, GetNumberOfSectionsAt
				, GetNumberOfRowsAt
				, GetCellsAt
				, RowContainChildTable
				, GetChildTableNameAt
				, "Root");

			UIElement.SetTable(_root);
		}

		#endregion

		#region UIElement Event Handlers

		private void UIElement_RowSelected(object sender, UITableSectionRowSelectedEventArgs e)
		{
			OnRowSelected(e.Path);
		}

		#endregion
	}
}