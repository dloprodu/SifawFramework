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
        #region Methods

        /// <summary>
        /// Carga la lista de datos.
        /// </summary>
        /// <param name="list"></param>
        void SetDataList(IList<IListable<TValue>> list);

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