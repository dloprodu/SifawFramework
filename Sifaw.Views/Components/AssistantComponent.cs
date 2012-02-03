///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary> 
/// AssistantManagerComponent.cs
/// 
/// Dise�ador:   David L�pez Rodr�guez
/// Programador: David L�pez Rodr�guez
/// </summary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 15/12/2011: Creaci�n de la interfaz.
/// 
/// ===============================================================================================
/// Observaciones:
/// 
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;
using System.Text;


namespace Sifaw.Views.Components
{
	/// <summary>
	/// Interfaz para el componente que gestionan la presentaci�n secuencial, a modo de asistente,
	/// de componentes que implementen la interfaz <see cref="UIComponent"/>.
	/// </summary>
	public interface AssistantComponent : UIComponent
	{
		#region Propiedades

		byte NumComponents { get; set; }
		bool PreviousEnabled { get; set; }
		bool AcceptEnabled { get; set; }
		bool CancelEnabled { get; set; }
		bool NextEnabled { get; set; }

		#endregion

		#region M�todos

		/// <summary>
		/// Establece el componente de interfaz de usuario a mostrar.
		/// </summary>
		/// <param name="component"></param>
		void SetCurrentUIComponent(UIComponent component, byte step);

		#endregion

		#region Eventos

		event EventHandler Next;
		event EventHandler Previous;
		event EventHandler Cancel;
		event EventHandler Accept;

		#endregion
	}
}