/*
 * Sifaw.Views.Components
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
using System.ComponentModel;


namespace Sifaw.Views.Components
{
	/// <summary>
	/// Interfaz para la vistas que gestionan procesos pesados.
	/// </summary>
	public interface BackgroundWorkerComponent : UIComponent
	{
		#region Properties
		
		/// <summary>
		/// Establece o devuelve un valor que indica si el proceso
		/// se ejecuta con o sin control de seguimiento.
		/// </summary>
		bool WithControl { get;  set; }

		/// <summary>
		/// Establece o devuelve un valor que indica si se permite
		/// cancelar el proceso.
		/// </summary>
		bool AllowCancel { get;  set; }

		/// <summary>
		/// Obtiene o establece el valor m�ximo del progreso del proceso.
		/// </summary>
		int MaxProgressPercentage { get; set; }

		/// <summary>
		/// Establece o devuelve una descripci�n breve del proceso.
		/// </summary>
		string Summary { get; set; }

		/// <summary>
		/// Establece o devuelve una descripci�n del proceso.
		/// </summary>
		string ProcessDescription { get; set; }

		/// <summary>
		/// Establece o devuelve el texto a mostrar durante el progreso del
		/// proceso.
		/// </summary>
		string Progress { get;  set; }

		#endregion

		#region Methods

		void UpdateProgress(string message);
		void UpdateProgress(string message, bool isCancelled);
		void UpdateProgress(int value);

		#endregion

		#region Events

		event EventHandler Cancel;

		#endregion
	}
}