///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary> 
/// FiltersComponent.cs
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
	/// Representa un componente para realizar filtros de tipo <see cref="TFiler"/>.
	/// </summary>
	/// <typeparam name="TFiler">Tipo del filtro del componente.</typeparam>
	public interface FilterComponent<TFilter> : UIComponent
	{
		#region Propiedades

		/// <summary>
		/// Obtiene o establece el filtro del componente.
		/// </summary>
		TFilter Filter { get; set; }

		#endregion

		#region Eventos

		/// <summary>
		/// Se produce cuando cambia el valor de la propiedad <see cref="Filter"/>.
		/// </summary>
		event UIFilterChangedEventHandler<TFilter> FilterChanged;

		#endregion
	}
}