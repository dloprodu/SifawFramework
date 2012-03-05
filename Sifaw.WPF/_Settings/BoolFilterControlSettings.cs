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

using Sifaw.WPF.Filters;


namespace Sifaw.WPF
{
	[Serializable]
    public class BoolFilterControlSettings : ControlSettings, BoolFilterSettings
    {
		#region Fields

		private string _textDisplay = string.Empty;

		#endregion

		#region Properties

		/// <summary>
		/// Obtiene o establece el texto a mostrar.
		/// </summary>
		public string TextDisplay
		{
			get { return _textDisplay; }
			set
			{
				if (_textDisplay != value)
				{
					_textDisplay = value;
					OnPropertyChanged(() => TextDisplay);
				}
			}
		}		

		#endregion

        #region Constructor

		public BoolFilterControlSettings(BoolFilterControl control)
			: base(control)
        {
            
        }

        #endregion
	}
}