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

using Sifaw.Core;


namespace Sifaw.Views.Components
{
	/*
	 * Argumento y manejador para los eventos FilterChanged.
	 */

	/// <summary>
	/// Proporciona datos para un evento FilterChanged.
	/// </summary>
	public class UIFilterChangedEventArgs : SFCancelEventArgs
	{
		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIFilterChangedEventArgs"/>.
		/// </summary>
		public UIFilterChangedEventArgs()
			: base()
		{
		}
	}

	/// <summary>
	/// Representa el método que controla un evento FilterChanged.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="UIFilterChangedEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void UIFilterChangedEventHandler(object sender, UIFilterChangedEventArgs e);
}
