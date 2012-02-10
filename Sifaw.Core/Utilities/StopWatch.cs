///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// StopWatch.cs
/// 
/// Dise�ador:   David L�pez Rguez
/// Programador: David L�pez Rguez
/// </sumary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 14/12/2011: Creaci�n de la clase.
/// 
/// ===============================================================================================
/// Observaciones:
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



using System;


namespace Sifaw.Core.Utilities
{
	/// <summary>
	/// Permite la medici�n de tiempos con alta precisi�n.
	/// </summary>
	public class StopWatch
	{
		#region Fields

		long startCount = 0;

		#endregion

		#region Factory Methods

		[System.Runtime.InteropServices.DllImport("Kernel32.dll")]
		public static extern bool QueryPerformanceCounter(out long perfcount);

		[System.Runtime.InteropServices.DllImport("Kernel32.dll")]
		public static extern bool QueryPerformanceFrequency(out long freq);

		public static long QueryPerformanceCounter()
		{
			long perfcount;
			QueryPerformanceCounter(out perfcount);
			return perfcount;
		}

		public static long QueryPerformanceFrequency()
		{
			long freq;
			QueryPerformanceFrequency(out freq);
			return freq;
		}

		#endregion

		#region Public Methods

		public void StartCounter()
		{
			startCount = QueryPerformanceCounter();
		}

		public double GetElapsedSeconds()
		{
			long stopCount = QueryPerformanceCounter();
			long elapsedCount = (stopCount > startCount) ? (stopCount - startCount) : (startCount - stopCount);
			return (double)elapsedCount / QueryPerformanceFrequency();
		}

		#endregion
	}
}