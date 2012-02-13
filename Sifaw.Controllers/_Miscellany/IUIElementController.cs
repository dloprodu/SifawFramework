/*
 * Sifaw.Controllers
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
using System.Linq;
using System.Text;


namespace Sifaw.Controllers
{
	/// <summary>
	/// Define una serie de métodos, propiedade y eventos con el fin de
	/// crear un patrón generalizado que han de cumplir las controladoras
	/// donde intervienen elementos de interfaz de usuario (UI)..
	/// </summary>
	public interface IUIElementController : IController
	{
		#region Methods

		/// <summary>
		/// Activa la vista de la controladora proporcionandole
		/// el foco.
		/// </summary>
		/// <remarks>
		/// Para invocar este método la controladora ha de estar iniciada, 
		/// en otro caso, devolverá una excepcion.
		/// </remarks>
		/// <exception cref="NotValidStateException">La controladora no está iniciada.</exception>
		void SetLikeActive();

		#endregion
	}
}