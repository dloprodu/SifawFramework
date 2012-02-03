///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// IViewController.cs
/// 
/// Diseñador:     David López Rguez
/// Programadores: David López Rguez
///	
/// </summary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 30/12/2011 -- Creación de la clase.
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


namespace Sifaw.Controllers
{
	/// <summary>
	/// Define una serie de métodos, propiedade y eventos con el fin de
	/// crear un patrón generalizado que han de cumplir las controladoras
	/// de vistas del framework.
	/// </summary>
	public interface IUIViewController : IUIElementController
	{
		#region Métodos

		/// <summary>
		/// Muestra la vista.
		/// 
		/// Para invocar este método la controladora ha de estar iniciada, 
		/// en otro caso, devolverá una excepcion.
		/// </summary>
		/// <exception cref="NotValidCtrlStateException">La controladora no está iniciada.</exception>
		void Show();

		#endregion
	}
}