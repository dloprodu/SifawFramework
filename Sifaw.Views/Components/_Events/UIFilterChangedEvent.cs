///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Librería de eventos de Sifaw.Views.
/// 
/// Diseñador:     David López Rguez
/// Programadores: David López Rguez
///	
/// </summary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 26/01/2012 -- Creación de la clase.
/// ===============================================================================================
/// Observaciones:
/// 
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



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
