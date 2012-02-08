///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary> 
/// ComponentFilterBase.cs
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
	public interface ComponentFilterBase<TFilter> : UIComponent
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

		/// <summary>
		/// Obtiene el valor real del item <see cref="IFilterable"/>.
		/// </summary>
		object ValueFilter { get; }
	}
}