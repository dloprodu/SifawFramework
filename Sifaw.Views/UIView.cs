/*
 * Sifaw.Views
 * 
 * Dise�ador:   David L�pez Rguez
 * Programador: David L�pez Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 09/02/2012: Creaci�n de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;

using Sifaw.Core;
using Sifaw.Views.Kit;


namespace Sifaw.Views
{
	/// <summary>
	/// <para>
	/// Representa un componente gr�fico capaz de mostrarse por si solo.
	/// Puele alojar elementos <see cref="UIComponent"/>.
	/// </para>
	/// </summary>
	public interface UIView : UIElement
	{
		#region Properties
		
        /// <summary>
		/// Obtiene el <see cref="ViewSettings"/> del <see cref="UIView"/>.
		/// </summary>
        new ViewSettings UISettings { get; }

		#endregion

		#region Methods

		/// <summary>
		/// Muestra la vista.
		/// </summary>
		void Show();

		/// <summary>
		/// Cierra la vista.
		/// </summary>
		void Close();

		/// <summary>
		/// Muestra un message al usuario.
		/// </summary>
		/// <param name="message">Mensaje a mostrar.</param>
		void ShowMessage(string message);

		/// <summary>
		/// Muestra un message al usuario.
		/// </summary>
		/// <param name="title">T�tulo a mostrar antes del message.</param>
		/// <param name="message">Mensaje a mostrar.</param>
		void ShowMessage(string title, string message);

		/// <summary>
		/// Muestra un message de advertencia al usuario.
		/// </summary>
		/// <param name="warning">Mensaje a mostrar.</param>
		void ShowWarning(string warning);

		/// <summary>
		/// Muestra un message de advertencia al usuario.
		/// </summary>
		/// <param name="title">T�tulo a mostrar antes del message.</param>
		/// <param name="warning">Mensaje a mostrar.</param>
		void ShowWarning(string title, string warning);

		/// <summary>
		/// Muestra un message de error al usuario.
		/// </summary>
		/// <param name="error">Mensaje a mostrar.</param>
		void ShowError(string error);

		/// <summary>
		/// Muestra un message de error al usuario.
		/// </summary>
		/// <param name="title">T�tulo a mostrar antes del message.</param>
		/// <param name="error">Mensaje a mostrar.</param>
		void ShowError(string title, string error);

		/// <summary>
		/// Muestra un mensaje al usuario pidiendo confirmaci�n para el mismo.
		/// </summary>
		/// <param name="message">Mensaje a mostrar.</param>
		bool ConfirmMessage(string message);

		/// <summary>
		/// Muestra un mensaje al usuario pidiendo confirmaci�n para el mismo.
		/// </summary>
		/// <param name="title">T�tulo a mostrar antes del message.</param>
		/// <param name="message">Mensaje a mostrar.</param>
		bool ConfirmMessage(string title, string message);

		#endregion

		#region Events

		/// <summary>
		/// Se produce antes de que la vista sea mostrada.
		/// </summary>
		event EventHandler BeforeShow;

		/// <summary>
		/// Se produce una vez que la vista se ha mostrado.
		/// </summary>
		event EventHandler AfterShow;

		/// <summary>
		/// Se produce cuando se solicita desde la vista la finalizaci�n.
		/// </summary>
		/// <remarks>
		/// <para>
		/// Es la controladora quien gestiona la finalizaci�n y cierre de la vista. Cualquier intento de finalizaci�n
		/// de la vista ha de ser comunicado la controladora.
		/// </para>
		/// <para>
		/// Si la vista tiene la capacidad de cerrarse autom�ticamente tras la generaci�n de este evento se ha de 
		/// establecer la propiedad IsClosing del <see cref="SFCancelEventArgs"/> en true para evitar que la controladora
		/// la cierre de forma explicita. En caso contrario, se podr�a producir alguna excepci�n.
		/// </para>
		/// <para>
		/// Si se cancela este evento, la controladora permanece iniciada. Para cancelar la finalizaci�n, establezca 
		/// la propiedad Cancel del <see cref="SFCancelEventArgs"/> que se pasa al controlador de eventos en true.
		/// </para>
		/// </remarks>		
		event UIFinishRequestEventHandler BeforeClose;

		/// <summary>
		/// Se produce cuando la vista se ha cerrado.
		/// </summary>
		event EventHandler AfterClose;

		#endregion
	}
}