/*
 * Sifaw.Core.Utilities
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Globalization;

using Sifaw.Core.Drawing;


namespace Sifaw.Core.Utilities
{
	/// <summary>
	/// Proporciona métodos estáticos para operaciones de gestión de colores.
	/// </summary>
	public static class UtilColor
	{
		/// <summary>
		/// Crea una estructura <see cref="System.Drawing.Color"/> a partir de los cuatro valores de los componentes ARGB de 8 bits (alfa, rojo, verde y azul).
		/// </summary>
		public static Color FromARGB(string argb)
		{
			try
			{
				int iargb = Int32.Parse(argb, NumberStyles.HexNumber);
				return (Color.FromArgb(iargb));
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// Crea una estructura <see cref="System.Drawing.Color"/> a partir de los cuatro valores de los componentes ARGB de 8 bits (alfa, rojo, verde y azul).
		/// </summary>
		public static Color FromARGB(string a, string r, string g, string b)
		{
			string argb = a + r + g + b;
			return FromARGB(argb);
		}	
	}
}
