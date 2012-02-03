///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Interfaz base con los métodos generales que deben tener todos los componentes UI.
/// 
/// Diseñador:     David López Rguez
/// Programadores: David López Rguez
///	
/// </summary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 03/01/2012 -- Creación de la clase.
/// ===============================================================================================
/// Observaciones:
/// 
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sifaw.Views
{
	#region Miscelanea

	/// <summary>
	/// Almacena un par de valores que indican el nombre de una propiedad
	/// de la vista y su valor.
	/// </summary>
	public struct UISetting
	{
		public static readonly UISetting Empty;

		public string Key;
		public object Value;

		static UISetting()
		{
			Empty = new UISetting(string.Empty, null);
		}

		public UISetting(string key, object value)
		{
			Key = key;
			Value = value;
		}
	}

	#endregion

	/// <summary>
	/// Define métodos, propiedades y eventos que ha de tener cualquier elemento
	/// de interfaz de usuario.
	/// </summary>
	public interface UIElement
	{
		#region Propiedades

		/// <summary>
		/// Establece o devuelve la denominación del <see cref="UIElement"/>.
		/// </summary>
		string Denomination { get; set; }

		/// <summary>
		/// Establece o devuevle la descripción del <see cref="UIElement"/>.
		/// </summary>
		string Description { get; set; }

		/// <summary>
		/// Establece o devuelve el ancho mínimo del <see cref="UIElement"/>.
		/// </summary>
		double MinWidth { get; set; }

		/// <summary>
		/// Establece o devuelve el ancho máximo del <see cref="UIElement"/>.
		/// </summary>
		double MaxWidth { get; set; }

		/// <summary>
		/// Establece o devuelve el alto mínimo del <see cref="UIElement"/>.
		/// </summary>
		double MinHeight { get; set; }

		/// <summary>
		/// Establece o devuelve el alto máximo del <see cref="UIElement"/>.
		/// </summary>
		double MaxHeight { get; set; }

		#endregion

		#region Métodos

		/// <summary>
		/// Refresca el elemento UI.
		/// </summary>
		void Refresh();

		/// <summary>
		/// Resetea y libera recursos del elemento UI.
		/// </summary>
		void Reset();

		/// <summary>
		/// Método encargado de activar el y proporcionarle el foco.
		/// </summary>
		void SetLikeActive();

		#endregion
	}
}