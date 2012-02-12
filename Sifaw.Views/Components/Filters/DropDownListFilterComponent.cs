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
	/// Representa un componente para realizar filtros sobre una lista desplegable
	/// de <see cref="IFilterable"/> devolviendo el item seleccionado.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Este componente ha de exponer la lista de filtro de forma que permita
	/// elegir un solo elemento.
	/// </para>
	/// <para>
	/// El componente muestra el elemento <see cref="IFilterable"/> seleccionado pudiendo 
	/// desplegar la lista y cambiar la selección.
	/// </para>
	/// </remarks>
	public interface DropDownListFilterComponent : ListFilterBaseComponent<IFilterable, IList<IFilterable>>
	{
		/* Empty */
	}
}