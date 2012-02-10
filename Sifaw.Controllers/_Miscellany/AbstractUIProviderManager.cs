///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// AbstractUIProviderManager.cs
/// 
/// Dise�ador:     David L�pez Rguez
/// Programadores: David L�pez Rguez
///	
/// </summary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 20/12/2011 -- Creaci�n de la clase.
/// ===============================================================================================
/// Observaciones:
/// 
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;
using System.Text;


namespace Sifaw.Controllers
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
		/// la aplicaci�n.
		/// </summary>
		internal static TLinker Linker
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