///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Librería de eventos de Sifaw.Controllers.
/// 
/// Diseñador:     David López Rguez
/// Programadores: David López Rguez
///	
/// </summary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 14/12/2011 -- Creación de la clase.
/// ===============================================================================================
/// Observaciones:
/// 
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sifaw.Controllers
{
	/*
	 * Argumento y manejador para los eventos FilterChanged.
	 */

	/// <summary>
	/// Proporciona datos para un evento FilterChanged.
	/// </summary>
	public class CtrlFilterChangedEventArgs<TFilter> : Sifaw.Core.CancelEventArgs
	{
		/// <summary>
		/// Valor anterior del filtro.
		/// </summary>
		public readonly TFilter OlderValue;

		/// <summary>
		/// Valor actual del filtro.
		/// </summary>
		public readonly TFilter NewValue;

		public CtrlFilterChangedEventArgs(TFilter olderValue, TFilter newValue)
			: base()
		{
			OlderValue = olderValue;
			NewValue = newValue;
		}
	}

	/// <summary>
	/// Representa el método que controla un evento FilterChanged.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="CtrlFilterChangedEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void CtrlFilterChangedEventHandler<TFiler>(object sender, CtrlFilterChangedEventArgs<TFiler> e);
}
