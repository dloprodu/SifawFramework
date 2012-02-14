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
	/// Representa un componente base para realizar filtros en base a una lista de objetos <see cref="IFilterable"/>.
	/// </summary>
	/// <typeparam name="TFilter">Tipo del filtro del componente.</typeparam>
	/// <typeparam name="TSource">Tipo para las lista sobre las que se realizarán los filtros. 
	/// Ha de implementar <see cref="IList{T}"/> donde <c>T</c> implementa <see cref="IFilterable"/>.
	/// </typeparam>
	public interface ListFilterBaseComponent<TFilter, TSource> : FilterBaseComponent<TFilter>
		where TSource : IList<IFilterable>
	{
		#region Methods

		/// <summary>
		/// Establece la lista sobre la que se realizarán los filtros.
		/// </summary>
		/// <param name="source">
		/// Lista de filtrado que ha de implementar <see cref="IList{T}"/> donde <c>T</c> implementa
		/// <see cref="IFilterable"/>.
		/// </param>
		void Add(TSource source);

		#endregion
	}
}