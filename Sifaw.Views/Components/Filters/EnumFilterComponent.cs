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
	/// de <see cref="IFilterable"/> devolviendo el item seleccionado.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Este componente ha de exponer la lista de filtro de forma que permita
	/// elegir un solo elemento.
	/// </para>
	/// <para>
	/// El componente ha de mostrar todos los elementos de la lista.
	/// Si la lista de filtro tiene demasiados items es mejor usar un componente mas
	/// adecuado como <see cref="DropDownListFilterComponent"/> que solo muestra
	/// el elemento seleccionado.
	/// </para>
	/// </remarks>
	public interface EnumFilterComponent : ListFilterBaseComponent<IFilterable, IList<IFilterable>>
	{
		/* Empty */
	}
}