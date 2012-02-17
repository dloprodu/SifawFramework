/*
 * Sifaw.Views.Components
 * 
 * Dise�ador:   David L�pez Rguez
 * Programador: David L�pez Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 09/02/2012: Creaci�n de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Text;


namespace Sifaw.Views.Components
{
	/// <summary>
	/// Representa un componente que implementa una interfaz que permite la presentaci�n 
	/// secuencial, a modo de asistente, de componentes <see cref="UIComponent"/>.
	/// </summary>
	public interface AssistantComponent : UIActorComponent
	{
		#region Properties

		/// <summary>
		/// Obtiene o estableceun valor que indica si se permite la navegaci�n al componente anterior.
		/// </summary>
		bool PreviousEnabled { get; set; }

		/// <summary>
		/// Obtiene o estableceun valor que indica si se permite la navegaci�n al componente siguiente.
		/// </summary>
		bool NextEnabled { get; set; }

		/// <summary>
		/// Obtiene o estableceun valor que indica si se permite aceptar el proceso.
		/// </summary>
		bool AcceptEnabled { get; set; }

		/// <summary>
		/// Obtiene o estableceun valor que indica si se permite cancelar el proceso.
		/// </summary>
		bool CancelEnabled { get; set; }

		#endregion

		#region Events

		/// <summary>
		/// Se produce cuando se solicita cancelar el proceso.
		/// </summary>
		event EventHandler Cancel;

		/// <summary>
		/// Se produce cuando se solicita aceptar el proceso.
		/// </summary>
		event EventHandler Accept;

		#endregion
	}
}