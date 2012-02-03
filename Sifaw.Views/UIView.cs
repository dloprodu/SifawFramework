///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Interfaz base con los m�todos generales que deben tener todas las vistas.
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
using Sifaw.Core;


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
		#region Propiedades

		/// <summary>
		/// Establece o devuelve la cabecera de la vista.
		/// </summary>
		string Header { get; set; }

		/// <summary>
		/// Establece o devuelve el ancho de la vista.
		/// </summary>
		double Width { get; set; }

		/// <summary>
		/// Establece o devuelve el alto de la vista.
		/// </summary>
		double Height { get; set; }

		/// <summary>
		/// Establece o devuelve un valor que indica si la vista se ajusta a su contenido.
		/// </summary>
		bool SizeToContent { get; set; }

		#endregion

		#region M�todos

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
		/// <param name="message">Mensaje a mostrar.</param>
		void ShowWarning(string warning);

		/// <summary>
		/// Muestra un message de advertencia al usuario.
		/// </summary>
		/// <param name="titulo">T�tulo a mostrar antes del message.</param>
		/// <param name="message">Mensaje a mostrar.</param>
		void ShowWarning(string title, string warning);

		/// <summary>
		/// Muestra un message de error al usuario.
		/// </summary>
		/// <remarks>
		/// Este m�todo se borrar� en cuanto haya dejado de usarse por los programadores
		/// de Pincel eKade. Se debe usar el MostrarError que recibe un objeto Exception.
		/// </remarks>
		/// <param name="message">Mensaje a mostrar.<</param>
		void ShowError(string error);

		/// <summary>
		/// Muestra un message de error al usuario.
		/// </summary>
		/// <remarks>
		/// Este m�todo se borrar� en cuanto haya dejado de usarse por los programadores
		/// de Pincel eKade. Se debe usar el MostrarError que recibe un objeto Exception.
		/// </remarks>
		/// <param name="titulo">T�tulo a mostrar antes del message.</param>
		/// <param name="message">Mensaje a mostrar.<</param>
		void ShowError(string title, string error);

		/// <summary>
		/// Muestra un mensaje al usuario pidiendo confirmaci�n para el mismo.
		/// </summary>
		/// <param name="message">Mensaje a mostrar.</param>
		bool ConfirmMessage(string message);

		/// <summary>
		/// Muestra un mensaje al usuario pidiendo confirmaci�n para el mismo.
		/// </summary>
		/// <param name="titulo">T�tulo a mostrar antes del message.</param>
		/// <param name="message">Mensaje a mostrar.</param>
		bool ConfirmMessage(string titulo, string message);

		#endregion

		#region Eventos

		/// <summary>
		/// Tiene lugar antes de que la vista sea mostrada.
		/// </summary>
		event EventHandler BeforeShow;

		/// <summary>
		/// Tiene lugar una vez que la vista se ha mostrado.
		/// </summary>
		event EventHandler AfterShow;

		/// <summary>
		/// Tiene lugar cuando se solicita desde la vista la finalizaci�n.
		/// </summary>
		/// <remarks>
		/// <para>
		/// Es la controladora quien gestiona la finalizaci�n y cierre de la vista. Cualquier intento de finalizaci�n
		/// de la vista ha de ser comunicado la controladora.
		/// </para>
		/// <para>
		/// Si la vista tiene la capacidad de cerrarse autom�ticamente tras la generaci�n de este evento se ha de 
		/// establecer la propiedad IsClosing del <see cref="CancelEventArgs"/> en true para evitar que la controladora
		/// la cierre de forma explicita. En caso contrario, se podr�a producir alguna excepci�n.
		/// </para>
		/// <para>
		/// Si se cancela este evento, la controladora permanece iniciada. Para cancelar la finalizaci�n, establezca 
		/// la propiedad Cancel del <see cref="CancelEventArgs"/> que se pasa al controlador de eventos en true.
		/// </para>
		/// </remarks>		
		event UIFinishRequestEventHandler BeforeClose;

		/// <summary>
		/// Tiene lugar cuando la vista se ha cerrado.
		/// </summary>
		event EventHandler AfterClose;

		#endregion
	}
}