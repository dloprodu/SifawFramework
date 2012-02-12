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