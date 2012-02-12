/*
 * Sifaw.Views.Components
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 09/02/2012: Creación de la clase.
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
	/// Interfaz para el componente que gestionan la presentación secuencial, a modo de asistente,
	/// de componentes que implementen la interfaz <see cref="UIComponent"/>.
	/// </summary>
	public interface AssistantComponent : UIComponent
	{
		#region Properties

		byte NumComponents { get; set; }
		bool PreviousEnabled { get; set; }
		bool AcceptEnabled { get; set; }
		bool CancelEnabled { get; set; }
		bool NextEnabled { get; set; }

		#endregion

		#region Methods

		/// <summary>
		/// Establece el componente de interfaz de usuario a mostrar.
		/// </summary>
		/// <param name="component"></param>
		void SetCurrentUIComponent(UIComponent component, byte step);

		#endregion

		#region Events

		event EventHandler Next;
		event EventHandler Previous;
		event EventHandler Cancel;
		event EventHandler Accept;

		#endregion
	}
}