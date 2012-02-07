///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary> 
/// EnumComponentFilter.cs
/// 
/// Diseñador:   David López Rodríguez
/// Programador: David López Rodríguez
/// </summary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 07/02/2012: Creación de la interfaz.
/// 
/// ===============================================================================================
/// Observaciones:
/// 
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



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
	/// El componente ha de mostrar en todo momento todos los elementos de la lista.
	/// Si la lista de filtro tiene demasiados items es mejor usar un componente mas
	/// adecuado como <see cref="DropDownListComponentFilter"/>.
	/// </para>
	/// </remarks>
	public interface EnumComponentFilter : ComponentListFilterBase<IFilterable, IList<IFilterable>>
	{
		/* Empty */
	}
}