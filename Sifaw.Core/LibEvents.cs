///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Contiene la librer�a de eventos de Sifaw.Core.
/// 
/// Dise�ador:     David L�pez Rguez
/// Programadores: David L�pez Rguez
///	
/// </summary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 14/12/2011 -- Creaci�n de la clase.
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
	/// Representa el m�todo que maneja el evento que comunica un valor entero.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="IntEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void IntEventHandler(object sender, IntEventArgs e);

	/*
	 * Argumento y manejador para los eventos que comunican el una excepci�n.
	 */

	/// <summary>
	/// Proporciona datos para eventos que informan de una excepci�n.
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
	/// Representa el m�todo que maneja el evento que informan de una excepci�n.
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
	/// Representa el m�todo que maneja el evento que comunica un valor string.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="StringEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void StringEventHandler(object sender, StringEventArgs e);

	/*
	 * Argumento y manejador para los eventos que solicitan una confirmaci�n sobre
	 * alguna acci�n.
	 */

	/// <summary>
	/// Proporciona datos para eventos que solicitan una confirmaci�n sobre
	/// alguna acci�n.
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
	/// Representa el m�todo que maneja el evento que solicita una confirmaci�n sobre
	/// alguna acci�n.
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
	/// Representa el m�todo que controla un evento cancelable.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="CancelEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void CancelEventHandler(object sender, CancelEventArgs e);
}
