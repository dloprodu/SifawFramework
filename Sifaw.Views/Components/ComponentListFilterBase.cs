///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary> 
/// ComponentListFilterBase.cs
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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sifaw.Views.Components
{
	/// <summary>
	/// Representa un componente base para realizar filtros sobre listas de objetos <see cref="TFiler"/>.
	/// </summary>
	/// <typeparam name="TFiler">Tipo del filtro del componente.</typeparam>
	public interface ComponentListFilterBase<TFilter, TSource> : ComponentFilterBase<TFilter>
		where TSource : IList<IFilterable>
	{
		#region Métodos

		void Add(TSource source);

		#endregion
	}
}