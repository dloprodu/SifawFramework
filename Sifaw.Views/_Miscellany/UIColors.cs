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
	public static class UIColors
	{
		public static class Whites
		{
			public static readonly UIColor White;			
			public static readonly UIColor WhiteSmoke;

			static Whites()
			{
				White = UIColor.FromRgb(255, 255, 255);
				WhiteSmoke = UIColor.FromRgb(245, 245, 245);
			}
		}

		public static class Grays
		{
			public static readonly UIColor Gainsboro;
			public static readonly UIColor LightGrey;
			public static readonly UIColor Silver;
			public static readonly UIColor DarkGray;
			public static readonly UIColor Gray;
			public static readonly UIColor DimGray;
			public static readonly UIColor Black;

			static Grays()
			{
				Gainsboro = UIColor.FromRgb(220, 220, 220);
				LightGrey = UIColor.FromRgb(211, 211, 211);
				Silver = UIColor.FromRgb(192, 192, 192);
				DarkGray = UIColor.FromRgb(169, 169, 169);
				Gray = UIColor.FromRgb(105, 105, 105);
				DimGray = UIColor.FromRgb(105, 105, 105);
				Black = UIColor.FromRgb(0, 0, 0);
			}
		}

		public static class Blues
		{
			public static readonly UIColor GhostWhite;

			static Blues()
			{
				GhostWhite = UIColor.FromRgb(248, 248, 255);
			}
		}

		public static class Reds
		{
			public static readonly UIColor Snow;

			static Reds()
			{
				Snow = UIColor.FromRgb(255, 250, 250);				
			}
		}
	}
}
