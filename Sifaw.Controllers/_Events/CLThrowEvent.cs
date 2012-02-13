/*
 * Sifaw.Controllers
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 08/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sifaw.Controllers
{
	/*
	 * Argumento y manejador para los eventos que solicitan el inicio de una controladora.
	 */

	/// <summary>
	/// Proporciona datos para un evento que solicita el inicio de una controladora.
	/// </summary>
	public class CLThrowEventArgs : EventArgs
	{
		/// <summary>
		/// Devuelve el tipo de la controladora que se va a iniciar.
		/// </summary>
		public readonly Type CLType = null;

		/// <summary>
		/// Devuelve los parámetros de inicio de la controladora que se va a iniciar.
		/// </summary>
		public readonly object[] Parameters = null;

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="CLThrowEventArgs"/>.
		/// </summary>
		public CLThrowEventArgs(Type clType, params object[] parameters)
		{
			CLType = clType;
			Parameters = parameters;
		}
	}

	/// <summary>
	/// Representa el método que controla un evento que solicita el inicio de una controladora.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="CLThrowEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void CLThrowEventHandler(object sender, CLThrowEventArgs e);
}
