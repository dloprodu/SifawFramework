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
	 * Argumento y manejador para los eventos que comunican la finalización de una controladora.
	 */

	/// <summary>
	/// Proporciona datos para un evento de finalización de controladora.
	/// </summary>
	public class CLFinishedEventArgs<T> : EventArgs
	{
		/// <summary>
		/// Devuelve el valor de retorno de la controladora.
		/// </summary>
		public readonly T Output;

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="CLFinishedEventArgs{T}"/>, estableciendo un valor en la propiedad <see cref="Output"/>.
		/// </summary>
		/// <param name="output">Valor de retorno de la controladora.</param>
		public CLFinishedEventArgs(T output)
			: base()
		{
			this.Output = output;
		}
	}

	/// <summary>
	/// Representa el método que controla un evento de finalización de controladora.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="CLFinishedEventArgs{T}"/> que contiene los datos de eventos.</param>
	public delegate void CLFinishedEventHandler<T>(object sender, CLFinishedEventArgs<T> e);
}
