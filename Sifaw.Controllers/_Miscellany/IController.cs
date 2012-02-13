/*
 * Sifaw.Controllers
 * 
 * Dise�ador:   David L�pez Rguez
 * Programador: David L�pez Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 08/02/2012: Creaci�n de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Text;

using Sifaw.Core;


namespace Sifaw.Controllers
{
	/// <summary>
	/// Define una serie de m�todos, propiedade y eventos con el fin de
	/// crear un patr�n generalizado que han de cumplir las controladoras
	/// del framework.
	/// </summary>
	public interface IController 
	{
		#region Properties

		/// <summary>
		/// Devuelve el estado en el que se encuentra  una controladora.
		/// </summary>
		CLStates State { get; }

		/// <summary>
		/// Devuelve la informaci�n que describe a una controladora.
		/// </summary>
		CLInformation Information { get; }

		#endregion

		#region Methods

		/// <summary>
		/// Inicia la controladora.
		/// </summary>
		bool Start();

		/// <summary>
		/// Reinicia la controladora.
		/// </summary>
		bool Reset();

		/// <summary>
		/// Finaliza la controladora.
		/// </summary>
		bool Finish();

		#endregion

		#region Events

		/// <summary>
		/// Evento para cominicar un cambio de estado.
		/// </summary>
		event CLStateChangedEventHandler StateChanged;

		/// <summary>
		/// Evento para indicar que se est� iniciando una controladora. 
		/// Se puede indicar que se cancele el proceso de inicio.
		/// </summary>
		event SFCancelEventHandler Starting;

		/// <summary>
		/// Evento para indicar que se est� finalizando una controladora. 
		/// Se puede indicar que se cancele el proceso de finalizaci�n.
		/// </summary>
		event SFCancelEventHandler Finishing;

		/// <summary>
		/// Evento para comunicar el progreso de un proceso
		/// de la controladora.
		/// </summary>
        event CLProgressChangedEventHandler ProgressChanged;

		/// <summary>
		/// Evento para comunicar que se debe iniciar una controladora.
		/// </summary>
		event CLThrowEventHandler ThrowCtrl;

		#endregion
	}

	/// <summary>
	/// Define una serie de m�todos, propiedade y eventos, en base a unos
	/// par�metros de entrada y salida, con el fin de crear un patr�n 
	/// generalizado que han de cumplir las controladoras del framework.
	/// </summary>
	public interface IController<TInput, TOutput> : IController
	{
		#region Methods

		/// <summary>
		/// Inicia la controladora.
		/// </summary>
		bool Start(TInput input);

		/// <summary>
		/// Reinicia la controladora.
		/// </summary>
		bool Reset(TInput input);

		#endregion

		#region Events

		/// <summary>
		/// Evento para comunicar que la controladora ha finalizado.
		/// </summary>
		event CLFinishedEventHandler<TOutput> Finished;

		#endregion
	}
}