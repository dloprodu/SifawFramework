/*
 * Sifaw.Views.Components.Filters
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


namespace Sifaw.Views.Components.Filters
{
	/// <summary>
	/// Representa un componente para realizar filtros sobre una lista
	/// de <see cref="IFilterable"/> devolviendo una sublista de elementos
	/// seleccionados.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Este componente ha de exponer la lista de filtro de forma que permita
	/// elegir uno o varios elementos de la lista.
	/// </para>
	/// </remarks>
	public interface ListFilterComponent : ListFilterBaseComponent<IList<IFilterable>, IList<IFilterable>>
	{
		/* Empty */
	}
}