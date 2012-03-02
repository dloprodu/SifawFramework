/*
 * Sifaw.Core.Drawing
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


namespace Sifaw.Core.Drawing
{
	/// <summary>
    /// Extensión del struct <see cref="Color"/>.
	/// </summary>
	public static class ColorExtensions
	{
		private const float SLIGHTDARK_FACTOR = 0.15F;

		/// <summary>
		/// Devuelve una representación levemente oscurecida del color especificado.
		/// </summary>
		public static Color SlightDark(this Color color)
		{
			return color.SlightDark(SLIGHTDARK_FACTOR);
		}

		/// <summary>
		/// Devuelve una representación oscurecida del color especificado en base a un factor.
		/// </summary>
		public static Color SlightDark(this Color color, float factor)
		{
			return Color.FromArgb((int)(color.R * (1 - factor)), (int)(color.G * (1 - factor)), (int)(color.B * (1 - factor)));
		}

		/// <summary>
		/// Transforma un color en formato RGB a su correspondiente en escala de grises según la función
		/// Y = 0.299*R + 0.587*G + 0.114*B.
		/// </summary>
		public static Color ToBN(this Color color)
		{
			int y = Convert.ToInt32(0.299f * color.R + 0.587f * color.G + 0.114f * color.B);
			return Color.FromArgb(color.A , y, y, y);
		}

		/// <summary>
		/// Devuelve una representación <see cref="HSLColor"/> de color.
		/// </summary>
		/// <param name="color">Color que se va representar en formato HSL.</param>
		/// <returns>Representación HSL.</returns>
		public static HSLColor ToHSL(this Color color)
		{
			return new HSLColor(color.GetHue(), color.GetSaturation(), color.GetBrightness());
		}
	}
}