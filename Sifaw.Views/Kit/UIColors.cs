/*
 * Sifaw.Views.Kit
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


namespace Sifaw.Views.Kit
{
    /// <summary>
    /// Provee del conjunto de colores X11 predefinidos.
    /// </summary>
    /// <remarks>
    /// Para mas información consultar http://en.wikipedia.org/wiki/Web_colors.
    /// </remarks>
    public static class UIColors
    {
        /// <summary>
        /// Paleta de blancos.
        /// </summary>
        public static class WhiteColors
        {
            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FFFFFF.
            /// </summary>
            public static readonly UIColor White;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FFFAFA.
            /// </summary>
            public static readonly UIColor Snow;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #F0FFF0.
            /// </summary>
            public static readonly UIColor Honeydew;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #F5FFFA.
            /// </summary>
            public static readonly UIColor MintCream;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #F0FFFF.
            /// </summary>
            public static readonly UIColor Azure;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #F0F8FF.
            /// </summary>
            public static readonly UIColor AliceBlue;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #F8F8FF.
            /// </summary>
            public static readonly UIColor GhostWhite;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #F5F5F5.
            /// </summary>
            public static readonly UIColor WhiteSmoke;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FFF5EE.
            /// </summary>
            public static readonly UIColor Seashell;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #F5F5DC.
            /// </summary>
            public static readonly UIColor Beige;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FDF5E6.
            /// </summary>
            public static readonly UIColor OldLace;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FFFAF0.
            /// </summary>
            public static readonly UIColor FloralWhite;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FFFFF0.
            /// </summary>
            public static readonly UIColor Ivory;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FAEBD7.
            /// </summary>
            public static readonly UIColor AntiqueWhite;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FAF0E6.
            /// </summary>          
            public static readonly UIColor Linen;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FFF0F5.
            /// </summary>
            public static readonly UIColor LavenderBlush;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FFE4E1.
            /// </summary>
            public static readonly UIColor MistyRose;

            static WhiteColors()
            {
                White = UIColor.FromRgb(255, 255, 255);
                Snow = UIColor.FromRgb(255, 250, 250);
                Honeydew = UIColor.FromRgb(240, 255, 240);
                MintCream = UIColor.FromRgb(245, 255, 250);
                Azure = UIColor.FromRgb(240, 255, 255);
                AliceBlue = UIColor.FromRgb(240, 248, 255);
                GhostWhite = UIColor.FromRgb(248, 248, 255);
                WhiteSmoke = UIColor.FromRgb(245, 245, 245);
                Seashell = UIColor.FromRgb(255, 245, 238);
                Beige = UIColor.FromRgb(245, 245, 220);
                OldLace = UIColor.FromRgb(253, 245, 230);
                FloralWhite = UIColor.FromRgb(255, 250, 240);
                Ivory = UIColor.FromRgb(255, 255, 240);
                AntiqueWhite = UIColor.FromRgb(250, 235, 215);
                Linen = UIColor.FromRgb(250, 240, 230);
                LavenderBlush = UIColor.FromRgb(255, 240, 245);
                MistyRose = UIColor.FromRgb(255, 228, 225);
            }
        }

        /// <summary>
        /// Paleta de grises.
        /// </summary>
        public static class GrayColors
        {
            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #DCDCDC.
            /// </summary>			
            public static readonly UIColor Gainsboro;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #D3D3D3.
            /// </summary>
            public static readonly UIColor LightGrey;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #C0C0C0.
            /// </summary>
            public static readonly UIColor Silver;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #A9A9A9.
            /// </summary>
            public static readonly UIColor DarkGray;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #808080.
            /// </summary>
            public static readonly UIColor Gray;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #696969.
            /// </summary>
            public static readonly UIColor DimGray;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #778899.
            /// </summary>
            public static readonly UIColor LightSlateGray;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #708090.
            /// </summary>
            public static readonly UIColor SlateGray;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #2F4F4F.
            /// </summary>
            public static readonly UIColor DarkSlateGray;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #000000.
            /// </summary>
            public static readonly UIColor Black;

            static GrayColors()
            {
                Gainsboro = UIColor.FromRgb(220, 220, 220);
                LightGrey = UIColor.FromRgb(211, 211, 211);
                Silver = UIColor.FromRgb(192, 192, 192);
                DarkGray = UIColor.FromRgb(169, 169, 169);
                Gray = UIColor.FromRgb(105, 105, 105);
                DimGray = UIColor.FromRgb(105, 105, 105);
                LightSlateGray = UIColor.FromRgb(119, 136, 153);
                SlateGray = UIColor.FromRgb(112, 128, 144);
                DarkSlateGray = UIColor.FromRgb(47, 79, 79);
                Black = UIColor.FromRgb(0, 0, 0);
            }
        }

        /// <summary>
        /// Paleta de marrones.
        /// </summary>
        public static class BrownColors
        {
            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FFF8DC.
            /// </summary>
            public static readonly UIColor Cornsilk;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FFEBCD.
            /// </summary>
            public static readonly UIColor BlanchedAlmond;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FFE4C4.
            /// </summary>
            public static readonly UIColor Bisque;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FFDEAD.
            /// </summary>
            public static readonly UIColor NavajoWhite;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #F5DEB3.
            /// </summary>
            public static readonly UIColor Wheat;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #DEB887.
            /// </summary>
            public static readonly UIColor BurlyWood;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #D2B48C.
            /// </summary>
            public static readonly UIColor Tan;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #BC8F8F.
            /// </summary>
            public static readonly UIColor RosyBrown;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #F4A460.
            /// </summary>
            public static readonly UIColor SandyBrown;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #DAA520.
            /// </summary>
            public static readonly UIColor Goldenrod;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #B8860B.
            /// </summary>
            public static readonly UIColor DarkGoldenrod;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #CD853F.
            /// </summary>
            public static readonly UIColor Peru;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #D2691E.
            /// </summary>
            public static readonly UIColor Chocolate;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #8B4513.
            /// </summary>
            public static readonly UIColor SaddleBrown;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #A0522D.
            /// </summary>
            public static readonly UIColor Sienna;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #A52A2A.
            /// </summary>
            public static readonly UIColor Brown;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #800000.
            /// </summary>
            public static readonly UIColor Maroon;

            static BrownColors()
            {
                Cornsilk = UIColor.FromRgb(255, 248, 220);
                BlanchedAlmond = UIColor.FromRgb(255, 235, 205);
                Bisque = UIColor.FromRgb(255, 228, 196);
                NavajoWhite = UIColor.FromRgb(255, 222, 173);
                Wheat = UIColor.FromRgb(245, 222, 179);
                BurlyWood = UIColor.FromRgb(222, 184, 135);
                Tan = UIColor.FromRgb(210, 180, 140);
                RosyBrown = UIColor.FromRgb(188, 143, 143);
                SandyBrown = UIColor.FromRgb(244, 164, 96);
                Goldenrod = UIColor.FromRgb(218, 165, 32);
                DarkGoldenrod = UIColor.FromRgb(184, 134, 11);
                Peru = UIColor.FromRgb(205, 133, 63);
                Chocolate = UIColor.FromRgb(210, 105, 30);
                SaddleBrown = UIColor.FromRgb(139, 69, 19);
                Sienna = UIColor.FromRgb(160, 82, 45);
                Brown = UIColor.FromRgb(165, 42, 42);
                Maroon = UIColor.FromRgb(128, 0, 0);
            }
        }

        /// <summary>
        /// Paleta de rojos.
        /// </summary>
        public static class RedColors
        {
            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #CD5C5C.
            /// </summary>
            public static readonly UIColor IndianRed;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #F08080.
            /// </summary>
            public static readonly UIColor LightCoral;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FA8072.
            /// </summary>
            public static readonly UIColor Salmon;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #E9967A.
            /// </summary>
            public static readonly UIColor DarkSalmon;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FFA07A.
            /// </summary>
            public static readonly UIColor LightSalmon;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FF0000.
            /// </summary>
            public static readonly UIColor Red;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #DC143C.
            /// </summary>
            public static readonly UIColor Crimson;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #B22222.
            /// </summary>
            public static readonly UIColor FireBrick;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #8B0000.
            /// </summary>
            public static readonly UIColor DarkRed;

            static RedColors()
            {
                IndianRed = UIColor.FromRgb(205, 92, 92);
                LightCoral = UIColor.FromRgb(240, 128, 128);
                Salmon = UIColor.FromRgb(250, 128, 114);
                DarkSalmon = UIColor.FromRgb(233, 150, 122);
                LightSalmon = UIColor.FromRgb(255, 160, 122);
                Red = UIColor.FromRgb(255, 0, 0);
                Crimson = UIColor.FromRgb(220, 20, 60);
                FireBrick = UIColor.FromRgb(178, 34, 34);
                DarkRed = UIColor.FromRgb(139, 0, 0);
            }
        }

        /// <summary>
        /// Paleta de rosas.
        /// </summary>
        public static class PinkColors
        {
            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FFC0CB.
            /// </summary>
            public static readonly UIColor Pink;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FFB6C1.
            /// </summary>
            public static readonly UIColor LightPink;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FF69B4.
            /// </summary>
            public static readonly UIColor HotPink;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FF1493.
            /// </summary>
            public static readonly UIColor DeepPink;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #C71585.
            /// </summary>
            public static readonly UIColor MediumVioletRed;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #DB7093.
            /// </summary>
            public static readonly UIColor PaleVioletRed;

            static PinkColors()
            {
                Pink = UIColor.FromRgb(255, 192, 203);
                LightPink = UIColor.FromRgb(255, 182, 193);
                HotPink = UIColor.FromRgb(255, 105, 180);
                DeepPink = UIColor.FromRgb(255, 20, 147);
                MediumVioletRed = UIColor.FromRgb(199, 21, 133);
                PaleVioletRed = UIColor.FromRgb(219, 112, 14);
            }
        }

        /// <summary>
        /// Paleta de naranjas.
        /// </summary>
        public static class OrangeColors
        {
            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FFA07A.
            /// </summary>
            public static readonly UIColor LightSalmon;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FF7F50.
            /// </summary>
            public static readonly UIColor Coral;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FF6347.
            /// </summary>
            public static readonly UIColor Tomato;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FF4500.
            /// </summary>
            public static readonly UIColor OrangeRed;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FF8C00.
            /// </summary>
            public static readonly UIColor DarkOrange;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FFA500.
            /// </summary>
            public static readonly UIColor Orange;

            static OrangeColors()
            {
                LightSalmon = UIColor.FromRgb(255, 160, 122);
                Coral = UIColor.FromRgb(255, 127, 80);
                Tomato = UIColor.FromRgb(255, 99, 71);
                OrangeRed = UIColor.FromRgb(255, 69, 0);
                DarkOrange = UIColor.FromRgb(255, 140, 0);
                Orange = UIColor.FromRgb(255, 165, 0);
            }
        }

        /// <summary>
        /// Paleta de amarillos.
        /// </summary>
        public static class YellowColors
        {
            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FFD700.
            /// </summary>
            public static readonly UIColor Gold;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FFFF00.
            /// </summary>
            public static readonly UIColor Yellow;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FFFFE0.
            /// </summary>
            public static readonly UIColor LightYellow;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FFFACD.
            /// </summary>
            public static readonly UIColor LemonChiffon;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FAFAD2.
            /// </summary>
            public static readonly UIColor LightGoldenrodYellow;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FFEFD5.
            /// </summary>
            public static readonly UIColor PapayaWhip;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FFE4B5.
            /// </summary>
            public static readonly UIColor Moccasin;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FFDAB9.
            /// </summary>
            public static readonly UIColor PeachPuff;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #EEE8AA.
            /// </summary>
            public static readonly UIColor PaleGoldenrod;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #F0E68C.
            /// </summary>
            public static readonly UIColor Khaki;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #BDB76B.
            /// </summary>
            public static readonly UIColor DarkKhaki;

            static YellowColors()
            {
                Gold = UIColor.FromRgb(255, 215, 0);
                Yellow = UIColor.FromRgb(255, 255, 0);
                LightYellow = UIColor.FromRgb(255, 255, 224);
                LemonChiffon = UIColor.FromRgb(255, 250, 205);
                LightGoldenrodYellow = UIColor.FromRgb(250, 250, 210);
                PapayaWhip = UIColor.FromRgb(255, 239, 213);
                Moccasin = UIColor.FromRgb(255, 228, 181);
                PeachPuff = UIColor.FromRgb(255, 218, 185);
                PaleGoldenrod = UIColor.FromRgb(238, 232, 170);
                Khaki = UIColor.FromRgb(240, 230, 140);
                DarkKhaki = UIColor.FromRgb(189, 183, 107);
            }
        }

        /// <summary>
        /// Paleta de púrpuras.
        /// </summary>
        public static class PurpleColors
        {
            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #E6E6FA.
            /// </summary>
            public static readonly UIColor Lavender;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #D8BFD8.
            /// </summary>
            public static readonly UIColor Thistle;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #DDA0DD.
            /// </summary>
            public static readonly UIColor Plum;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #EE82EE.
            /// </summary>
            public static readonly UIColor Violet;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #DA70D6.
            /// </summary>
            public static readonly UIColor Orchid;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FF00FF.
            /// </summary>
            public static readonly UIColor Fuchsia;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #FF00FF.
            /// </summary>
            public static readonly UIColor Magenta;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #BA55D3.
            /// </summary>
            public static readonly UIColor MediumOrchid;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #9370DB.
            /// </summary>
            public static readonly UIColor MediumPurple;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #8A2BE2.
            /// </summary>
            public static readonly UIColor BlueViolet;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #9400D3.
            /// </summary>
            public static readonly UIColor DarkViolet;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #9932CC.
            /// </summary>
            public static readonly UIColor DarkOrchid;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #8B008B.
            /// </summary>
            public static readonly UIColor DarkMagenta;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #800080.
            /// </summary>
            public static readonly UIColor Purple;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #4B0082.
            /// </summary>
            public static readonly UIColor Indigo;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #483D8B.
            /// </summary>
            public static readonly UIColor DarkSlateBlue;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #6A5ACD.
            /// </summary>
            public static readonly UIColor SlateBlue;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #7B68EE.
            /// </summary>
            public static readonly UIColor MediumSlateBlue;

            static PurpleColors()
            {
                Lavender = UIColor.FromRgb(230, 230, 250);
                Thistle = UIColor.FromRgb(216, 191, 216);
                Plum = UIColor.FromRgb(221, 160, 221);
                Violet = UIColor.FromRgb(238, 130, 238);
                Orchid = UIColor.FromRgb(218, 112, 214);
                Fuchsia = UIColor.FromRgb(255, 0, 255);
                Magenta = UIColor.FromRgb(255, 0, 255);
                MediumOrchid = UIColor.FromRgb(186, 85, 211);
                MediumPurple = UIColor.FromRgb(147, 112, 219);
                BlueViolet = UIColor.FromRgb(138, 43, 226);
                DarkViolet = UIColor.FromRgb(148, 0, 211);
                DarkOrchid = UIColor.FromRgb(153, 50, 204);
                DarkMagenta = UIColor.FromRgb(139, 0, 139);
                Purple = UIColor.FromRgb(128, 0, 128);
                Indigo = UIColor.FromRgb(75, 0, 130);
                DarkSlateBlue = UIColor.FromRgb(72, 61, 139);
                SlateBlue = UIColor.FromRgb(106, 90, 205);
                MediumSlateBlue = UIColor.FromRgb(123, 104, 238);
            }
        }

        /// <summary>
        /// Paleta de verdes.
        /// </summary>
        public static class GreenColors
        {
            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #ADFF2F.
            /// </summary>
            public static readonly UIColor GreenYellow;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #7FFF00.
            /// </summary>
            public static readonly UIColor Chartreuse;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #7CFC00.
            /// </summary>
            public static readonly UIColor LawnGreen;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #00FF00.
            /// </summary>
            public static readonly UIColor Lime;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #32CD32.
            /// </summary>
            public static readonly UIColor LimeGreen;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #98FB98.
            /// </summary>
            public static readonly UIColor PaleGreen;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #90EE90.
            /// </summary>
            public static readonly UIColor LightGreen;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #00FA9A.
            /// </summary>
            public static readonly UIColor MediumSpringGreen;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #00FF7F.
            /// </summary>
            public static readonly UIColor SpringGreen;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #3CB371.
            /// </summary>
            public static readonly UIColor MediumSeaGreen;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #2E8B57.
            /// </summary>
            public static readonly UIColor SeaGreen;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #228B22.
            /// </summary>
            public static readonly UIColor ForestGreen;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #008000.
            /// </summary>
            public static readonly UIColor Green;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #006400.
            /// </summary>
            public static readonly UIColor DarkGreen;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #9ACD32.
            /// </summary>
            public static readonly UIColor YellowGreen;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #6B8E23.
            /// </summary>
            public static readonly UIColor OliveDrab;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #808000.
            /// </summary>
            public static readonly UIColor Olive;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #556B2F.
            /// </summary>
            public static readonly UIColor DarkOliveGreen;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #66CDAA.
            /// </summary>
            public static readonly UIColor MediumAquamarine;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #8FBC8F.
            /// </summary>
            public static readonly UIColor DarkSeaGreen;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #20B2AA.
            /// </summary>
            public static readonly UIColor LightSeaGreen;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #008B8B.
            /// </summary>
            public static readonly UIColor DarkCyan;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #008080.
            /// </summary>
            public static readonly UIColor Teal;

            static GreenColors()
            {
                GreenYellow = UIColor.FromRgb(173, 255, 47);
                Chartreuse = UIColor.FromRgb(127, 255, 0);
                LawnGreen = UIColor.FromRgb(124, 252, 0);
                Lime = UIColor.FromRgb(0, 255, 0);
                LimeGreen = UIColor.FromRgb(50, 205, 50);
                PaleGreen = UIColor.FromRgb(152, 251, 152);
                LightGreen = UIColor.FromRgb(144, 238, 144);
                MediumSpringGreen = UIColor.FromRgb(0, 250, 154);
                SpringGreen = UIColor.FromRgb(0, 255, 127);
                MediumSeaGreen = UIColor.FromRgb(60, 179, 113);
                SeaGreen = UIColor.FromRgb(46, 139, 87);
                ForestGreen = UIColor.FromRgb(34, 139, 34);
                Green = UIColor.FromRgb(0, 128, 0);
                DarkGreen = UIColor.FromRgb(0, 100, 0);
                YellowGreen = UIColor.FromRgb(154, 205, 50);
                OliveDrab = UIColor.FromRgb(107, 142, 35);
                Olive = UIColor.FromRgb(128, 128, 0);
                DarkOliveGreen = UIColor.FromRgb(85, 107, 47);
                MediumAquamarine = UIColor.FromRgb(102, 205, 170);
                DarkSeaGreen = UIColor.FromRgb(143, 188, 143);
                LightSeaGreen = UIColor.FromRgb(32, 178, 170);
                DarkCyan = UIColor.FromRgb(0, 139, 139);
                Teal = UIColor.FromRgb(0, 128, 128);
            }
        }

        /// <summary>
        /// Paleta de azules.
        /// </summary>
        public static class BlueColors
        {
            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #00FFFF.
            /// </summary>
            public static readonly UIColor Aqua;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #00FFFF.
            /// </summary>
            public static readonly UIColor Cyan;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #E0FFFF.
            /// </summary>
            public static readonly UIColor LightCyan;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #AFEEEE.
            /// </summary>
            public static readonly UIColor PaleTurquoise;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #7FFFD4.
            /// </summary>
            public static readonly UIColor Aquamarine;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #40E0D0.
            /// </summary>
            public static readonly UIColor Turquoise;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #48D1CC.
            /// </summary>
            public static readonly UIColor MediumTurquoise;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #00CED1.
            /// </summary>
            public static readonly UIColor DarkTurquoise;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #5F9EA0.
            /// </summary>
            public static readonly UIColor CadetBlue;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #4682B4.
            /// </summary>
            public static readonly UIColor SteelBlue;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #B0C4DE.
            /// </summary>
            public static readonly UIColor LightSteelBlue;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #B0E0E6.
            /// </summary>
            public static readonly UIColor PowderBlue;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #ADD8E6.
            /// </summary>
            public static readonly UIColor LightBlue;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #87CEEB.
            /// </summary>
            public static readonly UIColor SkyBlue;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #87CEFA.
            /// </summary>
            public static readonly UIColor LightSkyBlue;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #00BFFF.
            /// </summary>
            public static readonly UIColor DeepSkyBlue;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #1E90FF.
            /// </summary>
            public static readonly UIColor DodgerBlue;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #6495ED.
            /// </summary>
            public static readonly UIColor CornflowerBlue;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #4169E1.
            /// </summary>
            public static readonly UIColor RoyalBlue;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #0000FF.
            /// </summary>
            public static readonly UIColor Blue;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #0000CD.
            /// </summary>
            public static readonly UIColor MediumBlue;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #00008B.
            /// </summary>
            public static readonly UIColor DarkBlue;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #000080.
            /// </summary>
            public static readonly UIColor Navy;

            /// <summary>
            /// Obtiene el color que tiene un valor de RGB de #191970.
            /// </summary>
            public static readonly UIColor MidnightBlue;

            static BlueColors()
            {
                Aqua = UIColor.FromRgb(0, 255, 255);
                Cyan = UIColor.FromRgb(0, 255, 255);
                LightCyan = UIColor.FromRgb(224, 255, 255);
                PaleTurquoise = UIColor.FromRgb(175, 238, 238);
                Aquamarine = UIColor.FromRgb(127, 255, 212);
                Turquoise = UIColor.FromRgb(64, 224, 208);
                MediumTurquoise = UIColor.FromRgb(72, 209, 204);
                DarkTurquoise = UIColor.FromRgb(0, 206, 209);
                CadetBlue = UIColor.FromRgb(95, 158, 160);
                SteelBlue = UIColor.FromRgb(70, 130, 180);
                LightSteelBlue = UIColor.FromRgb(176, 196, 222);
                PowderBlue = UIColor.FromRgb(176, 224, 230);
                LightBlue = UIColor.FromRgb(173, 216, 230);
                SkyBlue = UIColor.FromRgb(135, 206, 235);
                LightSkyBlue = UIColor.FromRgb(135, 206, 250);
                DeepSkyBlue = UIColor.FromRgb(0, 191, 255);
                DodgerBlue = UIColor.FromRgb(30, 144, 255);
                CornflowerBlue = UIColor.FromRgb(100, 149, 237);
                RoyalBlue = UIColor.FromRgb(65, 105, 225);
                Blue = UIColor.FromRgb(0, 0, 255);
                MediumBlue = UIColor.FromRgb(0, 0, 205);
                DarkBlue = UIColor.FromRgb(0, 0, 139);
                Navy = UIColor.FromRgb(0, 0, 128);
                MidnightBlue = UIColor.FromRgb(25, 25, 112);
            }
        }
    }
}