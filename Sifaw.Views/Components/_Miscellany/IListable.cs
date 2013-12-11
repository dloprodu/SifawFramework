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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sifaw.Views.Components
{
	/// <summary>
    /// Define una interfáz genérica para poder presentar un conjundo de datos a modo de lista con el componente <see cref="DataListComponent{TValue}"/>.
	/// </summary>
    public interface IListable<TValue> : IComparer, IComparer<IListable<TValue>>, IComparable, IComparable<IListable<TValue>>, IEquatable<IListable<TValue>>
	{
		/// <summary>
        /// Obtiene la denominación del item <see cref="IListable{TValue}"/>.
		/// </summary>
		string DisplayItem { get; }

        /// <summary>
        /// Obtiene el valor del item  <see cref="IListable{TValue}"/>.
        /// </summary>
        TValue ValueItem { get; }

        /// <summary>
        /// Devuelve la clave del grupo al que pertence el item <see cref="IListable{TValue}"/>.
        /// </summary>
        string GroupKey { get; }
	}
}