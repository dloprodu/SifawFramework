/*
 * Sifaw.WPF
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 03/03/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

using Sifaw.Views;
using Sifaw.Views.Components;


namespace Sifaw.WPF
{
	[Serializable]
    public class BackgroundWorkerControlSettings : ControlSettings, BackgroundWorkerSettings
    {
		#region Fields

		private bool _withControl = true;
		private bool _allowCancel = false;
		private string _summary = string.Empty;
		private string _processDescription = string.Empty;
		private string _progress = string.Empty;
		private int _maxProgressPercentage = 100;

		#endregion

		#region Properties

		/// <summary>
		/// Obtiene o establece un valor que indica si el proceso
		/// se ejecuta con o sin control de seguimiento.
		/// </summary>
		public bool WithControl
		{
			get { return _withControl; }
			set
			{
				if (_withControl != value)
				{
					_withControl = value;
					OnPropertyChanged(() => WithControl);
				}
			}
		}

		/// <summary>
		/// Obtiene o establece un valor que indica si se permite
		/// cancelar el proceso.
		/// </summary>
		public bool AllowCancel
		{
			get { return _allowCancel; }
			set
			{
				if (_allowCancel != value)
				{
					_allowCancel = value;
					OnPropertyChanged(() => AllowCancel);
				}
			}
		}

		/// <summary>
		/// Obtiene o establece una descripción breve del proceso.
		/// </summary>
		public string Summary
		{
			get { return _summary; }
			set
			{
				if (_summary != value)
				{
					_summary = value;
					OnPropertyChanged(() => Summary);
				}
			}
		}

		/// <summary>
		/// Obtiene o establece una descripción del proceso.
		/// </summary>
		public string ProcessDescription
		{
			get { return _processDescription; }
			set
			{
				if (_processDescription != value)
				{
					_processDescription = value;
					OnPropertyChanged(() => ProcessDescription);
				}
			}
		}

		/// <summary>
		/// Obtiene o establece el texto a mostrar durante el progreso del
		/// proceso.
		/// </summary>
		public string Progress
		{
			get { return _progress; }
			set
			{
				if (_progress != value)
				{
					_progress = value;
					OnPropertyChanged(() => Progress);
				}
			}
		}

		/// <summary>
		/// Obtiene o establece un valor que indica el máximo progreso 
		/// del proceso.
		/// </summary>
		public int MaxProgressPercentage
		{
			get { return _maxProgressPercentage; }
			set
			{
				if (_maxProgressPercentage != value)
				{
					_maxProgressPercentage = value;
					OnPropertyChanged(() => MaxProgressPercentage);
				}
			}
		}

		#endregion

        #region Constructor

        public BackgroundWorkerControlSettings(BackgroundWorkerControl control)
			: base(control)
        {
            
        }

        #endregion
    }
}