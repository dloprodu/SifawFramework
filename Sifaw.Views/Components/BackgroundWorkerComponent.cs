/*
 * Sifaw.Views.Components
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 09/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.ComponentModel;

using Sifaw.Views.Kit;


namespace Sifaw.Views.Components
{
	/// <summary>
	/// Interfaz para la vistas que gestionan procesos pesados.
	/// </summary>
	public interface BackgroundWorkerComponent : UIComponent
	{
		#region Properties

        /// <summary>
        /// Obtiene el <see cref="BackgroundWorkerSettings"/> del <see cref="BackgroundWorkerComponent"/>.
        /// </summary>
        new BackgroundWorkerSettings UISettings { get; }

		#endregion

		#region Methods

		/// <summary>
		/// Actualiza el mensaje del progreso.
		/// </summary>
		/// <param name="message">Mensaje asociado al progreso.</param>
		void UpdateProgress(string message);
		
		/// <summary>
		/// Actualiza  el mensaje del progreso e indica si el progreso ha sido cancelado.
		/// </summary>
		/// <param name="message">Mensaje asociado al progreso.</param>
		/// <param name="isCancelled">Valor que indica si el proceso ha sido cancelado.</param>
		void UpdateProgress(string message, bool isCancelled);
		
		/// <summary>
		/// Actualiza el progreso del proceso peado.
		/// </summary>
		/// <param name="value">Progreso del proceso.</param>
		void UpdateProgress(int value);

		#endregion

		#region Events

		/// <summary>
		/// Se produce cuando se solicita cancelar el proceso.
		/// </summary>
		event EventHandler Cancel;

		#endregion
	}
}