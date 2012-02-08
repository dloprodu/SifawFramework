///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// IController.cs
/// 
/// Dise�ador:     David L�pez Rguez
/// Programadores: David L�pez Rguez
///	
/// </summary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 21/12/2011 -- Creaci�n de la clase.
/// ===============================================================================================
/// Observaciones:
/// 
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



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
		#region Popiedades

		/// <summary>
		/// Devuelve el estado en el que se encuentra  una controladora.
		/// </summary>
		CtrlStates State { get; }

		/// <summary>
		/// Devuelve la informaci�n que describe a una controladora.
		/// </summary>
		CtrlInformation Information { get; }

		#endregion

		#region M�todos

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

		#region Eventos

		/// <summary>
		/// Evento para cominicar un cambio de estado.
		/// </summary>
		event CtrlStatesEventHandler StateChanged;

		/// <summary>
		/// Evento para indicar que se est� iniciando una controladora. 
		/// Se puede indicar que se cancele el proceso de inicio.
		/// </summary>
		event CancelEventHandler Starting;

		/// <summary>
		/// Evento para indicar que se est� finalizando una controladora. 
		/// Se puede indicar que se cancele el proceso de finalizaci�n.
		/// </summary>
		event CancelEventHandler Finishing;

		/// <summary>
		/// Evento para comunicar el progreso de un proceso
		/// de la controladora.
		/// </summary>
		event IntEventHandler ProgressChanged;

		/// <summary>
		/// Evento para comunicar el mensaje de progreso del proceso.
		/// </summary>
		event StringEventHandler ProgressMessageChanged;

		/// <summary>
		/// Evento para comunicar que se debe iniciar una controladora.
		/// </summary>
		event CtrlEventHandler ThrowCtrl;

		#endregion
	}

	/// <summary>
	/// Define una serie de m�todos, propiedade y eventos, en base a unos
	/// par�metros de entrada y salida, con el fin de crear un patr�n 
	/// generalizado que han de cumplir las controladoras del framework.
	/// </summary>
	public interface IController<TInput, TOutput> : IController
	{
		#region M�todos

		/// <summary>
		/// Inicia la controladora.
		/// </summary>
		bool Start(TInput input);

		/// <summary>
		/// Reinicia la controladora.
		/// </summary>
		bool Reset(TInput input);

		#endregion

		#region Eventos

		/// <summary>
		/// Evento para comunicar que la controladora ha finalizado.
		/// </summary>
		event CtrlFinishedEventHandler<TOutput> Finished;

		#endregion
	}

	#region Miscelanea

	/// <summary>
	/// Estados de una controladora.
	/// </summary>
	[Flags()]
	public enum CtrlStates : byte
	{
		/// <summary>
		/// Estado que indica que la controladora no est� iniciada.
		/// </summary>
		NotStarted,

		/// <summary>
		/// Estado que indica que la controladora est� iniciada.
		/// </summary>
		Started,
	}

	/// <summary>
	/// Almacena la descripci�n de una controladora.
	/// </summary>
	[Serializable]
	public class CtrlInformation
	{
		#region Variables

		public readonly static CtrlInformation Empty;

		/// <summary>
		/// Devuelve el nombre de la controladora.
		/// </summary>
		public readonly string Name;

		/// <summary>
		/// Devuelve la descripci�n de la controladora.
		/// </summary>
		public readonly string Description;

		#endregion

		#region Constructor

		static CtrlInformation()
		{
			Empty = new CtrlInformation(string.Empty, string.Empty);
		}

		public CtrlInformation(string name, string description)
		{
			Name = name;
			Description = description;
		}

		#endregion
	}

	#endregion
}
