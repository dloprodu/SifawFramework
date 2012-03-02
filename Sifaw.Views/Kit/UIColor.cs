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
using System.Text.RegularExpressions;


namespace Sifaw.Views.Kit
{
    /// <summary>
    /// Describe un color en función de los canales alpha, rojo, verde y azul.
    /// </summary>
    [Serializable]
    public struct UIColor : IEquatable<UIColor>
    {
        #region Fields

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

        #endregion

        #region Constructor

        static UIColor()
        {

        }

        private UIColor(byte a, byte r, byte g, byte b)
        {
            A = a;
            R = r;
            G = g;
            B = b;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Devuelve una cadena que describe el color en hexadecimal.
        /// </summary>
        /// <returns></returns>
        public string ToHtml()
        {
            return String.Format("#{0:X2}{1:X2}{2:X2}", R, G, B);
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Busca en la cadena de entrada especificada la primera apareción de un número 
        /// hexadecimal en formato html y la devuelve.
        /// </summary>
        private static string GetHexDigits(string input)
        {
            // Remove any characters that are not digits (like #)            
            Regex regex = new Regex(@"([a-fA-F0-9]{6}|[a-fA-F0-9]{3})", RegexOptions.Compiled);
            Match match = regex.Match(input);
            return match.Value;
        }

        #endregion

        #region Override Methods

        /// <summary>
        /// Devuelve la representación de cadena de un objeto <see cref="UIColor"/>.
        /// </summary>
        public override string ToString()
        {
            return ToHtml();
        }

        /// <summary>
        /// Determina si un objeto <see cref="UIColor"/> proporcionado es equivalente al objeto <see cref="UIColor"/> actual.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is UIColor))
                return false;

            return A.Equals(((UIColor)obj).A)
                && R.Equals(((UIColor)obj).R)
                && G.Equals(((UIColor)obj).G)
                && B.Equals(((UIColor)obj).B);
        }

        /// <summary>
        /// Obtiene un código hash de este objeto <see cref="UIColor"/>.
        /// </summary>
        public override int GetHashCode()
        {
            return A.GetHashCode() ^ R.GetHashCode() ^ G.GetHashCode() ^ B.GetHashCode();
        }

        /// <summary>
        /// Determina si un objeto <see cref="UIColor"/> proporcionado es equivalente al objeto <see cref="UIColor"/> actual.
        /// </summary>
        public bool Equals(UIColor other)
        {
            return A.Equals(other.A)
                && R.Equals(other.R)
                && G.Equals(other.G)
                && B.Equals(other.B);
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Crea una estructura <see cref="UIColor"/> a partir de una cadena de texto con una representación
        /// hexadecimal de un color en formato Html.
        /// </summary>
        /// <remarks>
        /// <example>
        /// <code>
        /// UIColor color1 = UIColor.FromHtml("#FFAACC");
        /// UIColor color2 = UIColor.FromHtml("#FAC");
        /// </code>
        /// </example>
        /// </remarks>
        /// <param name="value">Cadena que contiene una representación html hexadecimal de un color.</param>
        /// <exception cref="ArgumentException">El valor de entrada no tiene un formato html hexadecimal válido.</exception>        
        public static UIColor FromHtml(string value)
        {
            string hc = GetHexDigits(value);
            string r, g, b;

            if (hc.Length == 3)
            {
                r = hc.Substring(0, 1);
                g = hc.Substring(1, 1);
                b = hc.Substring(2, 1);
            }
            else if (hc.Length == 6)
            {
                r = hc.Substring(0, 2);
                g = hc.Substring(2, 2);
                b = hc.Substring(4, 2);
            }
            else
                throw new ArgumentException("El valor de entrada no tiene un formato html hexadecimal válido.", "value");

            UIColor color;

            try
            {
                byte ri = Byte.Parse(r, System.Globalization.NumberStyles.HexNumber);
                byte gi = Byte.Parse(g, System.Globalization.NumberStyles.HexNumber);
                byte bi = Byte.Parse(b, System.Globalization.NumberStyles.HexNumber);
                color = UIColor.FromRgb(ri, gi, bi);
            }
            catch (Exception e)
            {
                throw new ArgumentException("No se pudo realizar la conversión.");
            }

            return color;
        }

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

        #endregion        

        #region Operator Overloading

        /// <summary>
        /// Resta una estructura <see cref="UIColor"/> de una estructura <see cref="UIColor"/>
        /// </summary>
        /// <param name="color1">Estructura <see cref="UIColor"/> que va a ser restada.</param>
        /// <param name="color2">Estructura <see cref="UIColor"/> que se va a restar de color1.</param>
        /// <returns>
        /// Nueva estructura <see cref="UIColor"/> cuyos valores de color son los
        /// resultados de la operación de resta.
        /// </returns>
        public static UIColor operator -(UIColor color1, UIColor color2)
        {
            return UIColor.FromArgb(
                  Convert.ToByte(Math.Min(Byte.MaxValue, Math.Max(Byte.MinValue, color1.A - color2.A)))
                , Convert.ToByte(Math.Min(Byte.MaxValue, Math.Max(Byte.MinValue, color1.R - color2.R)))
                , Convert.ToByte(Math.Min(Byte.MaxValue, Math.Max(Byte.MinValue, color1.G - color2.G)))
                , Convert.ToByte(Math.Min(Byte.MaxValue, Math.Max(Byte.MinValue, color1.B - color2.B))));
        }
        
        /// <summary>
        /// Comprueba si dos estructuras <see cref="UIColor"/> no son idénticas.
        /// </summary>
        /// <param name="color1"> Primera estructura <see cref="UIColor"/> que se va a comparar.</param>
        /// <param name="color2"> Segunda estructura <see cref="UIColor"/> que se va a comparar.</param>
        /// <returns> Es true si color1 y color2 no son iguales; en caso contrario, es false.</returns>
        public static bool operator !=(UIColor color1, UIColor color2)
        {
            return color1.A != color2.A
                || color1.R != color2.R
                || color1.G != color2.G
                || color1.B != color2.B;
        }
              
        /// <summary>
        /// Multiplica los canales alfa, rojo, azul y verde de la estructura <see cref="UIColor"/>
        /// especificada por el valor especificado.
        /// </summary>
        /// <param name="color"><see cref="UIColor"/> que se va a multiplicar.</param>
        /// <param name="coefficient">Valor por el que se va a multiplicar.</param>
        /// <returns>
        /// Nueva estructura <see cref="UIColor"/> cuyos valores de color son los
        /// resultados de la operación de multiplicación.
        /// </returns>
        public static UIColor operator *(UIColor color, float coefficient)
        {
            return UIColor.FromArgb(
                  Convert.ToByte(color.A * coefficient)
                , Convert.ToByte(color.R * coefficient)
                , Convert.ToByte(color.G * coefficient)
                , Convert.ToByte(color.B * coefficient));
        }
       
        /// <summary>
        /// Suma dos estructuras <see cref="UIColor"/>.
        /// </summary>
        /// <param name="color1">Primera estructura <see cref="UIColor"/> a sumar.</param>
        /// <param name="color2">Segunda estructura <see cref="UIColor"/> que se va a sumar.</param>
        /// <returns>
        /// Nueva estructura <see cref="UIColor"/> cuyos valores de color son los
        /// resultados de la operación de suma.
        /// </returns>
        public static UIColor operator +(UIColor color1, UIColor color2)
        {
            return UIColor.FromArgb(
                  Convert.ToByte(Math.Min(Byte.MaxValue, Math.Max(Byte.MinValue,color1.A + color2.A)))
                , Convert.ToByte(Math.Min(Byte.MaxValue, Math.Max(Byte.MinValue,color1.R + color2.R)))
                , Convert.ToByte(Math.Min(Byte.MaxValue, Math.Max(Byte.MinValue,color1.G + color2.G)))
                , Convert.ToByte(Math.Min(Byte.MaxValue, Math.Max(Byte.MinValue,color1.B + color2.B))));
        }
   
        /// <summary>
        ///  Comprueba si dos estructuras <see cref="UIColor"/> son idénticas.
        /// </summary>
        /// <param name="color1"> Primera estructura <see cref="UIColor"/> que se va a comparar.</param>
        /// <param name="color2"> Segunda estructura <see cref="UIColor"/> que se va a comparar.</param>
        /// <returns>
        /// Es true si color1 y color2 son totalmente idénticos; en caso contrario, es
        /// false.
        /// </returns>
        public static bool operator ==(UIColor color1, UIColor color2)
        {
            return color1.A == color2.A
                && color1.R == color2.R
                && color1.G == color2.G
                && color1.B == color2.B;
        }

        #endregion
    }
}