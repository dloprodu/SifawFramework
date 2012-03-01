/*
 * Sifaw.Views
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 09/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sifaw.Views
{
	/// <summary>
	/// Describe un color en función de los canales alpha, rojo, verde y azul.
	/// </summary>
	public sealed struct UIColor
	{
		/// <summary>
		/// Obtiene el valor del componente alfa de esta estructura <see cref="UIColor"/>.
		/// </summary>
		public readonly byte A;

		/// <summary>
		/// Obtiene el valor del componente Rojo de esta estructura <see cref="UIColor"/>.
		/// </summary>
		public readonly byte R;

		/// <summary>
		/// Obtiene el valor del componente Verde de esta estructura <see cref="UIColor"/>.
		/// </summary>
		public readonly byte G;

		/// <summary>
		/// Obtiene el valor del componente Azul de esta estructura <see cref="UIColor"/>.
		/// </summary>
		public readonly byte B;

		private UIColor(byte a, byte r, byte g, byte b)
		{
			A = a;
			R = r;
			G = g;
			B = b;
		}

		// TODO: UIColor From/To Html
		//public static UIColor FromHtml(string value)
		//{
		//}

		/// <summary>
		/// Crea una estructura <see cref="UIColor"/> a partir de los cuatro valores de los componentes ARGB de 8 bits (alfa, rojo, verde y azul).
		/// </summary>
		public static UIColor FromArgb(byte a, byte r, byte g, byte b)
		{
			return (new UIColor(a, r, g, b));
		}

		/// <summary>
		/// Crea una estructura <see cref="UIColor"/> a partir de los cuatro valores de los componentes ARGB de 8 bits (alfa, rojo, verde y azul).
		/// </summary>
		public static UIColor FromArgb(byte a, UIColor color)
		{
			return (new UIColor(a, color.R, color.G, color.B));
		}

		/// <summary>
		/// Crea una estructura <see cref="UIColor"/> a partir de los tres valores de los componentes RGB de 8 bits (rojo, verde y azul).
		/// </summary>
		public static UIColor FromRgb(byte r, byte g, byte b)
		{
			return (new UIColor(255, r, g, b));
		}
	}
}