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

using Sifaw.Views.Kit;


namespace Sifaw.Views.Components
{
    [Serializable]
	public class UITableStyle
	{
		#region Fields

        private UIBrush _background = new UISolidBrush(UIColors.WhiteColors.White);
        private UIBrush _foreground = new UISolidBrush(UIColors.GrayColors.Black);
		private UIFrame _border = new UIFrame(1);
		private UIFrameBrush _borderColor = new UIFrameBrush(new UISolidBrush(UIColors.GrayColors.LightGrey));

		#endregion
	}
}