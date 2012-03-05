﻿/*
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
    public class TextFilterControlSettings : ControlSettings, TextFilterSettings
    {
		#region Fields

		private string _placeholder = string.Empty;

		#endregion

		#region Properties

		/// <summary>
		/// Obtiene o establece el placeholder, o texto de entrada, para el componente.
		/// </summary>
		public string Placeholder
		{
			get { return _placeholder; }
			set
			{
				if (_placeholder != value)
				{
					_placeholder = value;
					OnPropertyChanged(() => Placeholder);
				}
			}
		}

		#endregion

        #region Constructor

        public TextFilterControlSettings(TextFilterControl control)
			: base(control)
        {
            
        }

        #endregion
    }
}