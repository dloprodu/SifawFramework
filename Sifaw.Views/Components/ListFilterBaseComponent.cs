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
	/// Representa un componente base para realizar filtros sobre listas de objetos <see cref="TFiler"/>.
	/// </summary>
	/// <typeparam name="TFiler">Tipo del filtro del componente.</typeparam>
	public interface ListFilterBaseComponent<TFilter, TSource> : FilterBaseComponent<TFilter>
		where TSource : IList<IFilterable>
	{
		#region Methods

		void Add(TSource source);

		#endregion
	}
}