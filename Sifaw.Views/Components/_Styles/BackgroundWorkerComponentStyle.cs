/*
 * Sifaw.Views.Kit
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 02/03/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sifaw.Views.Components
{
	/// <summary>
	/// Provee un conjunto de propiedades que permiten modificar la apariencia
	/// de un componente de interfaz de usuario.
	/// </summary>
	[Serializable]
	public class BackgroundWorkerComponentStyle : ComponentStyle
	{
		#region Fields

		private bool _withControl = true;
		private bool _allowCancel = false;
		private string _summary = string.Empty;
		private string _processDescription = string.Empty;
		private string _progress = string.Empty;

		#endregion

		#region Properties

		/// <summary>
		/// Obtiene o establece un valor que indica si el proceso
		/// se ejecuta con o sin control de seguimiento.
		/// </summary>
		public bool WithControl
		{
			get { return _withControl; }
			set { _withControl = value; }
		}

		/// <summary>
		/// Obtiene o establece un valor que indica si se permite
		/// cancelar el proceso.
		/// </summary>
		public bool AllowCancel
		{
			get { return _allowCancel; }
			set { _allowCancel = value; }
		}

		/// <summary>
		/// Obtiene o establece una descripción breve del proceso.
		/// </summary>
		public string Summary
		{
			get { return _summary; }
			set { _summary = value; }
		}

		/// <summary>
		/// Obtiene o establece una descripción del proceso.
		/// </summary>
		public string ProcessDescription
		{
			get { return _processDescription; }
			set { _processDescription = value; }
		}

		/// <summary>
		/// Obtiene o establece el texto a mostrar durante el progreso del
		/// proceso.
		/// </summary>
		public string Progress
		{
			get { return _progress; }
			set { _progress = value; }
		}

		#endregion

		#region Constructor

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="BackgroundWorkerComponentStyle"/>.
		/// </summary>
		public BackgroundWorkerComponentStyle()
			: base()
		{
			this.Summary = "Operación pesada";
			this.ProcessDescription = "Se está ejecutando un proceso pesado. Esta operación puede tardar varios minutos. Espere por favor...";
			this.Progress = "Ejecutando proceso...";
			this.WithControl = true;
			this.AllowCancel = false;
		}

		#endregion
	}
}