///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary> 
/// 
/// Diseñador: David López Rguez
/// Programador: David López Rguez
/// </summary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 15/12/2011: Creación de la interfaz.
/// 
/// ===============================================================================================
/// Observaciones:
/// 
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



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
		/// Devuelve o establece el valor máximo del progreso del proceso.
		/// </summary>
		int MaxProgressPercentage { get; set; }

		/// <summary>
		/// Establece o devuelve una descripción breve del proceso.
		/// </summary>
		string Summary { get; set; }

		/// <summary>
		/// Establece o devuelve una descripción del proceso.
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