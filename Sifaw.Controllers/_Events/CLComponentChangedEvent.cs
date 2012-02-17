/*
 * Sifaw.Controllers
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 17/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Core;


namespace Sifaw.Controllers
{
	/*
	 * Argumento y manejador para los eventos ProgressChanged.
	 */

	/// <summary>
	/// Proporciona datos para un evento <see cref="UIActorController{TInput, TOutpu, TUISettings, TComponent, TGuest}.ComponentChanged"/>.
	/// </summary>
	public class CLComponentChangedEventArgs : EventArgs
	{
		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="CLComponentChangedEventArgs"/>.
		/// </summary>
        public CLComponentChangedEventArgs()
            : base()
        {
        }
	}

	/// <summary>
	/// Representa el método que controla un evento <see cref="UIActorController{TInput, TOutpu, TUISettings, TComponent, TGuest}.ComponentChanged"/>.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="CLComponentChangedEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void CLComponentChangedEventHandler(object sender, CLComponentChangedEventArgs e);
}