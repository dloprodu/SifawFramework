///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary> 
/// BoolComponentFilter.cs
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
	/// Representa un componente para realizar filtros sobre un campo
	/// booleano.
	/// </summary>
	public interface BoolFilterComponent : FilterBaseComponent<bool>
	{
		/// <summary>
		/// Establece el texto que mostrará el componente.
		/// </summary>
		string Text { set; }
	}
}