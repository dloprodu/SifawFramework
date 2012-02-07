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
	/// Representa un componente para realizar filtros sobre una lista desplegable
	/// de <see cref="IFilterable"/> devolviendo el item seleccionado.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Este componente ha de exponer la lista de filtro de forma que permita
	/// elegir un solo elemento.
	/// </para>
	/// <para>
	/// El componente solo muestra el item seleccionado.
	/// </para>
	/// </remarks>
	public interface DropDownListComponentFilter : ComponentListFilterBase<IFilterable, IList<IFilterable>>
	{
		/* Empty */
	}
}