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
    /// Define un formato concreto para el texto, incluidos el nombre de fuente, el tamaño y los atributos de estilo
    /// </summary>
    [Serializable]
    public class UIFont : IEquatable<UIFont>, ICloneable
    {
        #region Fields

        private string _name = "Verdana";
        private double _size = 7.25;
        private UIFontStyles _style = UIFontStyles.Regular;

        #endregion

        #region Properties

        /// <summary>
        /// Obtiene el nombre de fuente de este objeto <see cref="UIFont"/>.
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Obtiene el tamaño de este objeto <see cref="UIFont"/> expresado en pixels
        /// </summary>
        public double Size
        {
            get { return _size; }
        }

        /// <summary>
        /// Obtiene la información de estilo de esta <see cref="UIFont"/>.
        /// </summary>
        public UIFontStyles Style
        {
            get { return _style; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UIImage"/>.
        /// </summary>
        /// <param name="name">Tipo de letra.</param>
        /// <param name="size">Tamñao de la letra.</param>
        public UIFont(string name, double size)
            : this(name, size, UIFontStyles.Regular)
        {
        }

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UIImage"/>.
        /// </summary>
        /// <param name="name">Tipo de letra.</param>
        /// <param name="size">Tamñao de la letra.</param>
        /// <param name="style">Estilo a aplicar a la letra.</param>
        public UIFont(string name, double size, UIFontStyles style)
        {
            this._name = name;
            this._size = size;
            this._style = style;
        }

        #endregion

        #region Override Methods

        /// <summary>
        /// Devuelve la representación de cadena de un objeto <see cref="UIFont"/>.
        /// </summary>
        public override string ToString()
        {
            return string.Format("{0} : {1} : {2}", Name, Size, Style.ToString());
        }

        /// <summary>
        /// Determina si un objeto <see cref="UIFont"/> proporcionado es equivalente al objeto <see cref="UIFont"/> actual.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (!(obj is UIFont))
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            return string.Equals(Name, ((UIFont)obj).Name)
                && Size.Equals(((UIFont)obj).Size)
                && Style.Equals(((UIFont)obj).Style);
        }

        /// <summary>
        /// Obtiene un código hash de este objeto <see cref="UIFont"/>.
        /// </summary>
        public override int GetHashCode()
        {
            return Name.GetHashCode() 
                ^ Size.GetHashCode() 
                ^ Style.GetHashCode();
        }

        #endregion

        #region IEquatable<UIFont> Members

        /// <summary>
        /// Determina si un objeto <see cref="UIFont"/> proporcionado es equivalente al objeto <see cref="UIFont"/> actual.
        /// </summary>
        public bool Equals(UIFont other)
        {
            if (other == null)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            return string.Equals(Name, other.Name)
                && Size.Equals(other.Size)
                && Style.Equals(other.Style);
        }

        #endregion

        #region IClonable Memberes

        /// <summary>
        /// Crea un nuevo objeto copiado de la instancia actual.
        /// </summary>
        public object Clone()
        {
            return new UIFont(_name, _size, _style);
        }

        #endregion
    }
}