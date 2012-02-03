///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// Fichero contenedor de tipos de datos miscelaneos y funciones de utilidad.
/// 
/// Diseñador: David López Rguez
/// Programador: David López Rguez
/// </sumary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 27/12/2011 Creación del fichero
/// 
/// ===============================================================================================
/// Observaciones:
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

using Sifaw.Core.Drawing;


namespace Sifaw.Core.Utilities
{
	/// <summary>
	/// Proporciona métodos estáticos para operaciones de gestión de colores.
	/// </summary>
	public static class UtilColor
	{
		public static Color SlightDark(Color color)
		{
			return color.SlightDark();
		}

		public static Color SlightDark(Color color, float factor)
		{
			return color.SlightDark(factor);
		}

		public static Color FromARGB(string argb)
		{
			try
			{
				int iargb = Int32.Parse(argb, System.Globalization.NumberStyles.HexNumber);
				return (Color.FromArgb(iargb));
			}
			catch
			{
				throw;
			}
		}

		public static Color FromARGB(string a, string r, string g, string b)
		{
			string argb = a + r + g + b;
			return FromARGB(argb);
		}

		/// <summary>
		/// Transforma un color en formato RGB a su correspondiente en escala de grises según la función
		/// Y = 0.299*R + 0.587*G + 0.114*B.
		/// </summary>
		public static Color ToBN(Color color)
		{
			return color.ToBN();
		}		
	}
}
