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

using Sifaw.Views;


namespace Sifaw.Controllers
{
	/// <summary>
	/// Define una serie de métodos, propiedade y eventos con el fin de
	/// crear un patrón generalizado que han de cumplir las controladoras
	/// de vistas del framework.
	/// </summary>
	public interface IUIViewController : IUIElementController
	{
		#region Methods

		/// <summary>
		/// Muestra la vista.
		/// 
		/// Para invocar este método la controladora ha de estar iniciada, 
		/// en otro caso, devolverá una excepcion.
		/// </summary>
		/// <exception cref="NotValidStateException">La controladora no está iniciada.</exception>
		void Show();

		#endregion
	}
}