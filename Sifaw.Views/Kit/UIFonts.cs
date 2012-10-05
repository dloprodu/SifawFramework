/*
 * Sifaw.Views
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 04/10/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sifaw.Views.Kit
{
    /// <summary>
    /// Provee del conjunto de fuentes comunes.
    /// </summary>
    public static class UIFonts
    {
        static UIFonts()
        {
        }

        /// <summary>
        /// Los signos de las fuentes con serif, tal como el término es usado en CSS, tienen rasgos con remates, 
        /// con terminaciones acampanadas o biseladas, o auténticas terminaciones con serif (incluyendo los serif cuadrados o slab serif). 
        /// Las fuentes con serif son típicamente de espaciado proporcional. A menudo tienen mayor variación entre los rasgos finos y 
        /// gruesos que las fuentes de las familias 'sans-serif'. CSS utiliza el término 'serif' para aplicar a una fuente en cualquier 
        /// tipo de escritura, aunque otros nombres resulten más familiares para algunas escrituras en particular, como Mincho (Japonés), 
        /// Sung o Song (Chino), Pathang (Coreano). Cualquier fuente descripta de este modo puede usarse para representar la familia genérica 'serif'.
        /// </summary>
        public static class Serif
        {
            /// <summary>
            /// Times New Roman.
            /// </summary>
            public static readonly UIFont TimesNewRoman;

            /// <summary>
            /// Bodoni.
            /// </summary>
            public static readonly UIFont Bodoni;

            /// <summary>
            /// Garamond.
            /// </summary>
            public static readonly UIFont Garamond;

            /// <summary>
            /// Georgia.
            /// </summary>
            public static readonly UIFont Georgia;

            static Serif()
            {
                TimesNewRoman = new UIFont("Times New Roman", 7.25);
                Bodoni = new UIFont("Bodoni", 7.25);
                Garamond = new UIFont("Garamond", 7.25);
                Georgia = new UIFont("Georgia", 7.25);
            }
        }

        /// <summary>
        /// Los signos de las fuentes sans-serif, tal como el término es usado en CSS, no tienen remates -sin formas acampanadas, trazos finales u otros ornamentos-. 
        /// Las fuentes sans-serif son típicamente de espaciado proporcional. A menudo tienen menor variación entre los rasgos finos y gruesos, 
        /// comparadas con las fuentes con serif. CSS utiliza el término 'sans-serif' para aplicar a una fuente en cualquier tipo de escritura, 
        /// aunque otros nombres resulten más familiares para algunas escrituras en particular, como Gothic (Japonés), Kai (Chino), Totum o Kodig (Coreano). 
        /// Cualquier fuente descripta de este modo puede usarse para representar la familia genérica 'sans-serif'.
        /// </summary>
        public static class Sans_Serif
        {
            /// <summary>
            /// Trebuchet.
            /// </summary>
            public static readonly UIFont Trebuchet;

            /// <summary>
            /// Arial.
            /// </summary>
            public static readonly UIFont Arial;

            /// <summary>
            /// Verdana.
            /// </summary>
            public static readonly UIFont Verdana;

            /// <summary>
            /// Gill Sans.
            /// </summary>
            public static readonly UIFont GillSans;

            /// <summary>
            /// Helvetica.
            /// </summary>
            public static readonly UIFont Helvetica;

            static Sans_Serif()
            {
                Trebuchet = new UIFont("Trebuchet", 7.25);
                Arial = new UIFont("Arial", 7.25);
                Verdana = new UIFont("Verdana", 7.25);
                GillSans = new UIFont("Gill Sans", 7.25);
                Helvetica = new UIFont("Helvetica", 7.25);
            }
        }

        /// <summary>
        /// Los signos de las fuentes cursive, tal como el término es usado en CSS, generalmente tienen rasgos unidos u otra característica cursiva
        /// más marcada que los tipos itálicos. Los signos están parcial o completamente conectados y el resultado se asemeja más a la escritura
        /// manual o de pincel que a un tipo impreso. En algunos sistemas de escritura, como el arábigo, las fuentes son casi siempre cursivas. 
        /// CSS usa el término 'cursive' para ser aplicado a una fuente en cualquier tipo de escritura, aunque otros nombres como Chancery, Brush, 
        /// Swing y Script son también usados en los nombres de las fuentes.
        /// </summary>
        public static class Cursive
        {
            /* Empty */

            static Cursive()
            {
            }
        }

        /// <summary>
        /// Las fuentes de fantasía, tal como el término es usado en CSS, son principalmente decorativas pero siguen representando caracteres 
        /// (en oposición a las fuentes de símbolos, que no representan caracteres). Los ejemplos incluyen:
        /// </summary>
        public static class Fantasy
        {
            /* Empty */
            
            static Fantasy()
            {
            }
        }

        /// <summary>
        /// El único criterio para reconocer una fuente monospace es que todas los signos ocupan un mismo espacio horizontal constante. (Esto puede hacer
        /// que algunos sistemas de escritra, como el arábigo, tengan un estilo más peculiar.) El efecto es similar al de las máquinas de escribir manuales
        /// y es a menudo utilizada para ilustrar los ejemplos de códigos de computadora.
        /// </summary>
        public static class Monospace
        {
            /// <summary>
            /// Andele Mono.
            /// </summary>
            public static readonly UIFont AndeleMono;

            /// <summary>
            /// Courier.
            /// </summary>
            public static readonly UIFont Courier;

            /// <summary>
            /// Courier New.
            /// </summary>
            public static readonly UIFont CourierNew;

            /// <summary>
            /// Prestige
            /// </summary>
            public static readonly UIFont Prestige;

            static Monospace()
            {
                AndeleMono = new UIFont("Andele Mono", 7.25);
                Courier = new UIFont("Courier", 7.25);
                CourierNew = new UIFont("Courier New", 7.25);
                Prestige = new UIFont("Prestige", 7.25);
            }
        }
    }
}