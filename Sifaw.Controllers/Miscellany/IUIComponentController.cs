using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Views;
using Sifaw.Core;


namespace Sifaw.Controllers
{
	/// <summary>
	/// Define una serie de métodos, propiedade y eventos con el fin de
	/// crear un patrón generalizado que han de cumplir las controladoras
	/// de componentes del framework.
	/// </summary>
	public interface IUIComponentController : IUIElementController
	{
		#region Métodos

		/// <summary>
		/// Devuelve una referencia al componente UI de la controladora.
		/// </summary>
		/// <returns>Componente de interfaz de usuario.</returns>
		UIComponent GetUIComponent();

		#endregion

		#region Eventos

		/// <summary>
		/// Evento para comunicar que se debe mostrar un mensaje.
		/// </summary>
		event StringEventHandler ShowMessage;

		/// <summary>
		/// Evento para comunicar que se debe mostrar una advertencia.
		/// </summary>
		event StringEventHandler ShowWarning;

		/// <summary>
		/// Evento para comunicar un error producido por excepción.
		/// </summary>
		event ExceptionEventHandler ShowError;

		/// <summary>
		/// Evento para solicitar una confirmación para un mensaje dado.
		/// </summary>
		event ConfirmMessageEventHandler ConfirmMessage;

		#endregion
	}
}