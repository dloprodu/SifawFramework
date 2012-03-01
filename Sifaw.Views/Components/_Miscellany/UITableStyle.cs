/*
 * Sifaw.Views.Components
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 01/03/2012: Creación de la clase.
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
	public class UITableStyle : INotifyPropertyChanged
	{
		#region Fields

		private UIColor _background = UIColors.Whites.White;
		private UIColor _foreground = UIColors.Grays.Black;
		private UIFrame _border = new UIFrame(1);
		private UIFrameColor _borderColor = new UIFrameColor(UIColors.Grays.LightGrey);

		#endregion

		#region INotifyPropertyChanged Members

		public event PropertyChangedEventHandler PropertyChanged;

		#endregion
	}
}