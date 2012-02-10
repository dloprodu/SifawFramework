///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary> 
/// Librería de componentes de Sifaw.Views.Components.
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

using Sifaw.Views;


namespace Sifaw.Views.Components
{
	/// <summary>
	/// Representa un componente base para realizar filtros de tipo <see cref="TFiler"/>.
	/// </summary>
	/// <typeparam name="TFiler">Tipo del filtro del componente.</typeparam>
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