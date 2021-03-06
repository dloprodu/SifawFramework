﻿/*
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
		#region Methods

		/// <summary>
		/// Devuelve una referencia al componente UI de la controladora.
		/// </summary>
		/// <returns>Componente de interfaz de usuario.</returns>
		UIComponent GetUIComponent();

		#endregion

		#region Events

        /// <summary>
        /// Evento para comunicar la solicitud mostrar un estado de espera.
        /// </summary>
        event EventHandler BeginWaitState;

        /// <summary>
        /// Evento para comunicar la solicitud finalizar el estado de espera.
        /// </summary>
        event EventHandler FinalizeWaitState;

		/// <summary>
		/// Evento para comunicar que se debe mostrar un mensaje.
		/// </summary>
		event CLShowInfoEventHandler ShowMessage;

		/// <summary>
		/// Evento para comunicar que se debe mostrar una advertencia.
		/// </summary>
		event CLShowWarningEventHandler ShowWarning;

		/// <summary>
		/// Evento para comunicar un error producido por excepción.
		/// </summary>
		event CLShowErrorEventHandler ShowError;

		/// <summary>
		/// Evento para solicitar una confirmación para un mensaje dado.
		/// </summary>
		event CLConfirmMessageEventHandler ConfirmMessage;

		#endregion
	}
}