///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary> 
/// Libreria de clases misceláneas de Sifaw.Views.Components.
/// 
/// Diseñador:   David López Rodríguez
/// Programador: David López Rodríguez
/// </summary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 27/01/2012: Creación de la interfaz.
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


namespace Sifaw.Views.Components
{
	/// <summary>
	/// Define un método generalizado, que implementa una clase o tipo de valor con
	/// el fin de crear un método para realizar filtros sobre listas.
	/// </summary>
	public interface IFilterable : IComparable, IComparable<IFilterable>
	{
		/// <summary>
		/// Obtiene la denominación del item <see cref="IFilterable"/>.
		/// </summary>
		string DisplayFilter { get; }
	}
}