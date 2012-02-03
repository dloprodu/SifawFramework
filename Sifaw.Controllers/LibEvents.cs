///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Contiene la librería de eventos
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
using System.Text;


namespace Sifaw.Controllers
{
	/*
	 * Argumento y manejador para los eventos que comunican el estado de una controladora.
	 */

	/// <summary>
	/// Proporciona datos para un evento que comunica el estado de una controladora.
	/// </summary>
	public class CtrlSatesEventArgs : EventArgs
	{
		public readonly CtrlStates State;

		public CtrlSatesEventArgs(CtrlStates state)
			: base()
		{
			this.State = state;
		}
	}

	/// <summary>
	/// Representa el método que controla un evento que comunica el estado de una controladora.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="CtrlSatesEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void CtrlStatesEventHandler(object sender, CtrlSatesEventArgs e);
	
	/*
	 * Argumento y manejador para los eventos que comunican la finalización de una controladora.
	 */

	/// <summary>
	/// Proporciona datos para un evento de finalización de controladora.
	/// </summary>
	public class CtrlFinishedEventArgs<T> : EventArgs
	{
		public readonly T Output;

		public CtrlFinishedEventArgs(T output)
			: base()
		{
			this.Output = output;
		}
	}

	/// <summary>
	/// Representa el método que controla un evento de finalización de controladora.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="CtrlFinishedEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void CtrlFinishedEventHandler<T>(object sender, CtrlFinishedEventArgs<T> e);

	/*
	 * Argumento y manejador para los eventos que solicitan el inicio de una controladora.
	 */
	
	/// <summary>
	/// Proporciona datos para un evento que solicita el inicio de una controladora.
	/// </summary>
	public class CtrlEventArgs : EventArgs
	{
		public readonly Type CtrlType = null;
		public readonly object[] Parameters = null;

		public CtrlEventArgs(Type ctrlType, params object[] parameters)
		{
			CtrlType = ctrlType;
			Parameters = parameters;
		}
	}

	/// <summary>
	/// Representa el método que controla un evento que solicita el inicio de una controladora.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="CtrlEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void CtrlEventHandler(object sender, CtrlEventArgs e);

	/*
	 * Argumento y manejador para los eventos FilterChanged.
	 */

	/// <summary>
	/// Proporciona datos para un evento FilterChanged.
	/// </summary>
	public class CtrlFilterChangedEventArgs<TFilter> : EventArgs
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