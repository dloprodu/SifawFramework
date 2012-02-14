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
	 * Argumento y manejador para los eventos que solicitan la finalización de una controladora desde
	 * la vista asociada a la controladora.
	 */
	
	/// <summary>
	/// Proporciona datos para un evento que solicitan la finalización de una controladora desde
	/// la vista asociada a la controladora.
	/// </summary>
	public class UIFinishRequestEventArgs : Sifaw.Core.SFCancelEventArgs
	{
		/// <summary>
		/// Valor que indica si la vista se cerrará por si sola.
		/// </summary>
		public readonly bool IsClosing;

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIFinishRequestEventArgs"/>, estableciendo un valor en la propiedad <see cref="IsClosing"/>.
		/// </summary>
		public UIFinishRequestEventArgs(bool isClosing)
			: base()
		{
			IsClosing = isClosing;
		}
	}

	/// <summary>
	/// Representa el método que controla un evento que solicita la finalización de la controladora desde
	/// la vista asociada a la controladora.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="UIFinishRequestEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void UIFinishRequestEventHandler(object sender, UIFinishRequestEventArgs e);
}