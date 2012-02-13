/*
 * Sifaw.Core
 * 
 * Dise�ador:   David L�pez Rguez
 * Programador: David L�pez Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 14/12/2011: Creaci�n de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;


namespace Sifaw.Core
{
	/// <summary>
	/// Permite la medici�n de tiempos con alta precisi�n.
	/// </summary>
	public class StopWatch
	{
		#region Fields

		private long startCount = 0;

		#endregion

		#region Factory Methods

		/// <summary>
		/// Recupera el valor actual del contador de rendimiento de alta resoluci�n.
		/// </summary>
		[System.Runtime.InteropServices.DllImport("Kernel32.dll")]
		public static extern bool QueryPerformanceCounter(out long perfcount);

		/// <summary>
		/// Recupera la frecuencia del contador de rendimiento de alta resoluci�n, si existe. La frecuencia no puede cambiar mientras el sistema est� funcionando.
		/// </summary>
		[System.Runtime.InteropServices.DllImport("Kernel32.dll")]
		public static extern bool QueryPerformanceFrequency(out long freq);

		/// <summary>
		/// Recupera el valor actual del contador de rendimiento de alta resoluci�n.
		/// </summary>
		public static long QueryPerformanceCounter()
		{
			long perfcount;
			QueryPerformanceCounter(out perfcount);
			return perfcount;
		}

		/// <summary>
		/// Recupera la frecuencia del contador de rendimiento de alta resoluci�n, si existe.
		/// La frecuencia no puede cambiar mientras el sistema est� funcionando.
		/// </summary>
		public static long QueryPerformanceFrequency()
		{
			long freq;
			QueryPerformanceFrequency(out freq);
			return freq;
		}

		#endregion

		#region Public Methods

		/// <summary>
		/// Inicializa una nueva medici�n.
		/// </summary>
		public void StartCounter()
		{
			startCount = QueryPerformanceCounter();
		}

		/// <summary>
		/// Obtiene los segundos pasados desde el inicio de la medici�n.
		/// </summary>
		public double GetElapsedSeconds()
		{
			long stopCount = QueryPerformanceCounter();
			long elapsedCount = (stopCount > startCount) ? (stopCount - startCount) : (startCount - stopCount);
			return (double)elapsedCount / QueryPerformanceFrequency();
		}

		#endregion
	}
}