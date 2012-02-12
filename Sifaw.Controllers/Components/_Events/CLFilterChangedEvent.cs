/*
 * Sifaw.Controllers.Components
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

using Sifaw.Core;


namespace Sifaw.Controllers.Components
{
	/*
	 * Argumento y manejador para los eventos FilterChanged.
	 */

	/// <summary>
	/// Proporciona datos para un evento FilterChanged.
	/// </summary>
	public class CLFilterChangedEventArgs<TFilter> : SFCancelEventArgs
	{
		/// <summary>
		/// Valor actual del filtro.
		/// </summary>
		public readonly TFilter Filter;

		public CLFilterChangedEventArgs(TFilter filter)
			: base()
		{
			Filter = filter;
		}
	}

	/// <summary>
	/// Representa el método que controla un evento FilterChanged.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="CtrlFilterChangedEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void CLFilterChangedEventHandler<TFiler>(object sender, CLFilterChangedEventArgs<TFiler> e);
}