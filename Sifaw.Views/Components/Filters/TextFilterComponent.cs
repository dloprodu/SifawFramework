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
	/// Representa un componente para realizar filtros sobre un campo 
	/// de texto.
	/// </summary>
	public interface TextFilterComponent : FilterBaseComponent<string>
	{
		/// <summary>
		/// Texto a mostrar como punto de entrada del componente.
		/// </summary>
		string Placeholder { get; set; }
	}
}