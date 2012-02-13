/*
 * Sifaw.Core
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 14/12/2011: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;


namespace Sifaw.Core
{
	/// <summary>
	/// Permite la medición de tiempos con alta precisión.
	/// </summary>
	public class StopWatch
	{
		#region Fields

		private long startCount = 0;

		#endregion

		#region Factory Methods

		/// <summary>
		/// Recupera el valor actual del contador de rendimiento de alta resolución.
		/// </summary>
		[System.Runtime.InteropServices.DllImport("Kernel32.dll")]
		public static extern bool QueryPerformanceCounter(out long perfcount);

		/// <summary>
		/// Recupera la frecuencia del contador de rendimiento de alta resolución, si existe. La frecuencia no puede cambiar mientras el sistema está funcionando.
		/// </summary>
		[System.Runtime.InteropServices.DllImport("Kernel32.dll")]
		public static extern bool QueryPerformanceFrequency(out long freq);

		/// <summary>
		/// Recupera el valor actual del contador de rendimiento de alta resolución.
		/// </summary>
		public static long QueryPerformanceCounter()
		{
			long perfcount;
			QueryPerformanceCounter(out perfcount);
			return perfcount;
		}

		/// <summary>
		/// Recupera la frecuencia del contador de rendimiento de alta resolución, si existe.
		/// La frecuencia no puede cambiar mientras el sistema está funcionando.
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
		/// Inicializa una nueva medición.
		/// </summary>
		public void StartCounter()
		{
			startCount = QueryPerformanceCounter();
		}

		/// <summary>
		/// Obtiene los segundos pasados desde el inicio de la medición.
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