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
	 * Argumento y manejador para los eventos GuestChanging.
	 */

	/// <summary>
	/// Proporciona datos para un evento <see cref="UIActorController{TInput, TOutpu, TUISettings, TComponent, TGuest}.GuestChanging"/>.
	/// </summary>
	public class CLComponentChangingEventArgs : SFCancelEventArgs
	{
		/// <summary>
		/// Obtiene la clave del componete a mostrar.
		/// </summary>
		public readonly int Key;

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="CLComponentChangingEventArgs"/>, estableciendo la clave del componente
		/// al que se va a cambiar.
		/// </summary>
        public CLComponentChangingEventArgs(int key)
            : base()
        {
			Key = key;
        }
	}

	/// <summary>
	/// Representa el método que controla un evento <see cref="UIActorController{TInput, TOutpu, TUISettings, TComponent, TGuest}.GuestChanging"/>.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="CLComponentChangingEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void CLComponentChangingEventHandler(object sender, CLComponentChangingEventArgs e);
}