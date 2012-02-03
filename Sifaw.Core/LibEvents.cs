///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Contiene la librería de eventos de Sifaw.Core.
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


namespace Sifaw.Core
{
	/*
	 * Argumento y manejador para los eventos que comunican el un valor entero.
	 */
	
	/// <summary>
	/// Proporciona datos para eventos que comunican un valor entero.
	/// </summary>
	public class IntEventArgs : EventArgs
	{
		public readonly int Value;

		public IntEventArgs(int value)
			: base()
		{
			this.Value = value;
		}
	}

	/// <summary>
	/// Representa el método que maneja el evento que comunica un valor entero.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="IntEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void IntEventHandler(object sender, IntEventArgs e);

	/*
	 * Argumento y manejador para los eventos que comunican el una excepción.
	 */

	/// <summary>
	/// Proporciona datos para eventos que informan de una excepción.
	/// </summary>
	public class ExceptionEventArgs : EventArgs
	{
		public readonly Exception Exception;

		public ExceptionEventArgs(Exception ex)
			: base()
		{
			this.Exception = ex;
		}
	}

	/// <summary>
	/// Representa el método que maneja el evento que informan de una excepción.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="ExceptionEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void ExceptionEventHandler(object sender, ExceptionEventArgs e);

	/*
	 * Argumento y manejador para los eventos que comunican un valor string.
	 */

	/// <summary>
	/// Proporciona datos para eventos que comunican un valor string.
	/// </summary>
	public class StringEventArgs : EventArgs
	{
		public readonly string Value = string.Empty;

		public StringEventArgs(string value)
			: base()
		{
			Value = value;
		}
	}

	/// <summary>
	/// Representa el método que maneja el evento que comunica un valor string.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="StringEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void StringEventHandler(object sender, StringEventArgs e);

	/*
	 * Argumento y manejador para los eventos que solicitan una confirmación sobre
	 * alguna acción.
	 */

	/// <summary>
	/// Proporciona datos para eventos que solicitan una confirmación sobre
	/// alguna acción.
	/// </summary>
	public class ConfirmMessageEventArgs : StringEventArgs
	{
		public bool Confirmed = false;

		public ConfirmMessageEventArgs(string message)
			: base(message)
		{
			Confirmed = false;
		}
	}

	/// <summary>
	/// Representa el método que maneja el evento que solicita una confirmación sobre
	/// alguna acción.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="ConfirmMessageEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void ConfirmMessageEventHandler(object sender, ConfirmMessageEventArgs e);

	/*
	 * Argumento y manejador para los eventos cancelables.
	 */

	/// <summary>
	/// Proporciona datos para un evento cancelable.
	/// </summary>
	public class CancelEventArgs : EventArgs
	{
		/// <summary>
		/// Obtiene o establece un valor que indica si se debe cancelar el evento.
		/// </summary>
		public bool Cancel = false;

		public CancelEventArgs()
		{
			Cancel = false;
		}
	}

	/// <summary>
	/// Representa el método que controla un evento cancelable.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="CancelEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void CancelEventHandler(object sender, CancelEventArgs e);
}
