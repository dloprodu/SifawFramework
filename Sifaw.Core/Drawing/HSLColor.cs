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

using Sifaw.Core.Utilities;


namespace Sifaw.Core.Drawing
{
	/// <summary>
	/// Representa un color en el espacio de colores HSL.
	/// </summary>
	public struct HSLColor
	{
		public static readonly HSLColor Empty;

		#region Fields

		private float h;
		private float s;
		private float l;

		#endregion

		#region Properties

		public float Hue
		{
			get	{ return h; }
			set
			{
				h = (float)(Math.Abs(value) % 360);
			}
		}

		public float Saturation
		{
			get { return s; }
			set
			{
				s = (float)Math.Max(Math.Min(1.0, value), 0.0);
			}
		}

		public float Luminance
		{
			get	{ return l; }
			set
			{
				l = (float)Math.Max(Math.Min(1.0, value), 0.0);
			}
		}

		public Color RGB
		{
			get { return ToRGB(Hue, Saturation, Luminance); }
		}

		#endregion

		#region Constructors

		static HSLColor()
		{
			Empty = new HSLColor(0.0f, 0.0f, 0.0f);
		}

		public HSLColor(float hue, float saturation, float luminance)
		{
			h = hue;
			s = saturation;
			l = luminance;
		}

		#endregion

		#region Methods de factoria

		public static Color ToRGB(HSLColor color)
		{
			return ToRGB(color.Hue, color.Saturation, color.Luminance);
		}

		public static Color ToRGB(float hue, float saturacion, float luminosidad)
		{
			double r = 0, g = 0, b = 0;

			double temp1, temp2;

			double normalisedH = hue / 360.0;

			if (luminosidad == 0)
			{
				r = g = b = 0;
			}
			else
			{
				if (saturacion == 0)
				{
					r = g = b = luminosidad;
				}
				else
				{
					temp2 = ((luminosidad <= 0.5) ? luminosidad * (1.0 + saturacion) : luminosidad + saturacion - (luminosidad * saturacion));

					temp1 = 2.0 * luminosidad - temp2;

					double[] t3 = new double[] { normalisedH + 1.0 / 3.0, normalisedH, normalisedH - 1.0 / 3.0 };

					double[] clr = new double[] { 0, 0, 0 };

					for (int i = 0; i < 3; ++i)
					{
						if (t3[i] < 0)
							t3[i] += 1.0;

						if (t3[i] > 1)
							t3[i] -= 1.0;

						if (6.0 * t3[i] < 1.0)
							clr[i] = temp1 + (temp2 - temp1) * t3[i] * 6.0;
						else if (2.0 * t3[i] < 1.0)
							clr[i] = temp2;
						else if (3.0 * t3[i] < 2.0)
							clr[i] = (temp1 + (temp2 - temp1) * ((2.0 / 3.0) - t3[i]) * 6.0);
						else
							clr[i] = temp1;

					}

					r = clr[0];
					g = clr[1];
					b = clr[2];
				}
			}

			return Color.FromArgb((int)(255 * r), (int)(255 * g), (int)(255 * b));
		}

		public static HSLColor FromRGB(byte red, byte green, byte blue)
		{
			return FromRGB(Color.FromArgb(red, green, blue));
		}

		public static HSLColor FromRGB(Color color)
		{
			return new HSLColor(color.GetHue(), color.GetSaturation(), color.GetBrightness());
		}

		#endregion
	}
}