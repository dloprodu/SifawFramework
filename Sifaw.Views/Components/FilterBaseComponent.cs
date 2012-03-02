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

using Sifaw.Views;
using Sifaw.Views.Kit;


namespace Sifaw.Views.Components
{
	/// <summary>
	/// Representa un componente base para realizar filtros de tipo especificado.
	/// </summary>
	/// <typeparam name="TFilter">Tipo del filtro del componente.</typeparam>
	public interface FilterBaseComponent<TFilter> : UIComponent
	{
		#region Properties

		/// <summary>
		/// Obtiene o establece el filtro del componente.
		/// </summary>
		TFilter Filter { get; set; }

		#endregion

		#region Events

		/// <summary>
		/// Se produce cuando cambia el valor de la propiedad <see cref="Filter"/>.
		/// </summary>
		event UIFilterChangedEventHandler FilterChanged;

		#endregion
	}
}