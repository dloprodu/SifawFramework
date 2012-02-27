/*
 * Sifaw.Views
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


namespace Sifaw.Views
{
	/*
	 * Argumento y manejador para los eventos que solicitan el cambio de componente en un UIActorComponent.
	 */
	
	/// <summary>
	/// Proporciona datos para un evento que solicita el cambio del componente <see cref="UIComponent"/> a mostrar
	/// en un <see cref="UIActorComponent"/>.
	/// </summary>
	public class UIComponentChangedEventArgs : EventArgs
	{
		/// <summary>
		/// Obtiene la clave del componete a mostrar.
		/// </summary>
		public readonly int Key;

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIComponentChangedEventArgs"/>.
		/// </summary>
		public UIComponentChangedEventArgs(int key)
			: base()
		{
			Key = key;
		}
	}

	/// <summary>
	/// Representa el método que controla un evento que solicita el cambio del componente <see cref="UIComponent"/> 
	/// a mostrar en un <see cref="UIActorComponent"/>.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="UIComponentChangedEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void UIComponentChangedEventHandler(object sender, UIComponentChangedEventArgs e);
}