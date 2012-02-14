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
	/// Interfaz para el componente que gestionan la presentaci�n secuencial, a modo de asistente,
	/// de componentes que implementen la interfaz <see cref="UIComponent"/>.
	/// </summary>
	public interface AssistantComponent : UIComponent
	{
		#region Properties

		/// <summary>
		/// Devuelve o establece el n�mero de componentes que mostrar� el asistente.
		/// </summary>
		byte NumComponents { get; set; }

		/// <summary>
		/// Devuelve o establece un valor que indica si se permite la navegaci�n al componente anterior.
		/// </summary>
		bool PreviousEnabled { get; set; }

		/// <summary>
		/// Devuelve o establece un valor que indica si se permite la navegaci�n al componente siguiente.
		/// </summary>
		bool NextEnabled { get; set; }

		/// <summary>
		/// Devuelve o establece un valor que indica si se permite aceptar el proceso.
		/// </summary>
		bool AcceptEnabled { get; set; }

		/// <summary>
		/// Devuelve o establece un valor que indica si se permite cancelar el proceso.
		/// </summary>
		bool CancelEnabled { get; set; }

		#endregion

		#region Methods

		/// <summary>
		/// Establece el componente de interfaz de usuario a mostrar.
		/// </summary>
		/// <param name="component">Componente a mostrar.</param>
		/// <param name="step">Valor que indica la posici�n actual en la secuencia de componentes.</param>
		void SetCurrentUIComponent(UIComponent component, byte step);

		#endregion

		#region Events

		/// <summary>
		/// Se produce cuando se solicita mostrar el siguiente componente.
		/// </summary>
		event EventHandler Next;

		/// <summary>
		/// Se produce cuando se solicita mostrar el anterior componente.
		/// </summary>
		event EventHandler Previous;

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