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
using System.Linq;
using System.Text;

using Sifaw.Views.Kit;


namespace Sifaw.Views
{
	/// <summary>
	/// Representa un componente que implementa una interfaz que administra un
	/// conjunto relacionado de componente.
	/// </summary>
	public interface UIActorComponent<TStyle> : UIComponent<TStyle>
		where TStyle : ComponentStyle
	{
		#region Properties

		/// <summary>
		/// Establece un array que informa del número de componentes a hospedar conteniendo
		/// para cada uno de ellos una cadena de texto susceptible de ser usada como identificador
		/// en la interfaz de usuario.
		/// </summary>
		string[] Descriptors { set; }

		#endregion

		#region Methods

		/// <summary>
		/// Establece el componente de interfaz de usuario a mostrar.
		/// </summary>
		/// <param name="content">Componente a mostrar.</param>
		/// <param name="key">Valor que indica la posición actual en la secuencia de componentes.</param>
		void Update(UIComponent content, int key);

		#endregion

		#region Eventos

		/// <summary>
		/// Se produce cuando se solicita cambiar el componente a hospedar.
		/// </summary>
		event UIGuestSelectingEventHandler GuestSelecting;

		#endregion
	}
}