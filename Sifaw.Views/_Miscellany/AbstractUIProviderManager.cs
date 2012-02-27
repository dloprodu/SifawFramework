/*
 * Sifaw.Views
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 08/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Text;


namespace Sifaw.Views
{
	/// <summary>
	/// Gestor encargado de almacenamiento y suministro del ViewLinker para las operaciones de 
	/// enlazado controlador - vista.
	/// </summary>
	public static class AbstractUIProviderManager<TLinker> 
		where TLinker : AbstractUIProvider
	{
		#region Fields

		private static TLinker _linker = default(TLinker);

		#endregion

		#region Properties

		/// <summary>
		/// Devuelve el enlazador de vistas establecido por defecto para
		/// la aplicación.
		/// </summary>
		public static TLinker Linker
		{
			get { return _linker; }
		}

		#endregion

		#region Methods

		/// <summary>
		/// Establece el enlazador de elementos de interfaz de usuario.
		/// </summary>
		/// <param name="linker">Linker</param>
		public static void SetUIElementLinker(TLinker linker)
		{
			_linker = linker;
		}

		#endregion
	}
}