/*
 * Sifaw.Views.Components
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 09/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Views;
using Sifaw.Core;


namespace Sifaw.Views.Components
{
	/// <summary>
	/// Representa un componente que implemnenta una interfaz que permite la presentaión de listad de objectos
    /// <see cref="IListable{TValue}"/>.
	/// </summary>
    public interface DataListComponent<TValue> : UIComponent
    {
        #region Properties

        /// <summary>
        /// Determina se si permite seleccionar un solo elemento o múltiples.
        /// </summary>
        bool MultiSelection
        {
            get;
            set;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Carga la lista de datos.
        /// </summary>
        /// <param name="list"></param>
        void SetDataList(IList<IListable<TValue>> list);

        /// <summary>
        /// Selecciona el item con valor indicado.
        /// </summary>
        /// <param name="value">Valor del item a seleccionar.</param>
        void SelectListableItem(TValue value);

        /// <summary>
        /// Devuelve la lista de elementos seleccionados.
        /// </summary>
        /// <returns>Elementos seleccionados.</returns>
        IList<TValue> GetSelection();

        /// <summary>
        /// Limpia la selección.
        /// </summary>
        void ClearSelection();

        #endregion

        #region Events

        /// <summary>
        /// Se produce cuando cambia el valor seleccionado.
        /// </summary>
        event SFIntEventHandler SelectedIndexChanged;

        /// <summary>
        /// Se produce cuando cambia el valor seleccionado.
        /// </summary>
        event SFValueEventHandler<TValue> SelectedValueChanged;

        #endregion
    }
}