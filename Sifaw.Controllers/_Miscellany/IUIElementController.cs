///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// IUIElementController.cs
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
using Sifaw.Core;


namespace Sifaw.Controllers
{
	/// <summary>
	/// Define una serie de métodos, propiedade y eventos con el fin de
	/// crear un patrón generalizado que han de cumplir las controladoras
	/// donde intervienen elementos de interfaz de usuario (UI)..
	/// </summary>
	public interface IUIElementController : IController
	{
		#region Métodos

		/// <summary>
		/// Activa la vista de la controladora proporcionandole
		/// el foco.
		/// 
		/// Para invocar este método la controladora ha de estar iniciada, 
		/// en otro caso, devolverá una excepcion.
		/// </remarks>
		/// <exception cref="NotValidCtrlStateException">La controladora no está iniciada.</exception>
		void SetLikeActive();

		#endregion
	}
}