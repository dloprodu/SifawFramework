/*
 * Sifaw.Views
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 18/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;


namespace Sifaw.Views.Kit
{
    /// <summary>
    /// Clase que almacena una imagen.
    /// </summary>
    [Serializable]
    public class UIImage : IEquatable<UIImage>, ICloneable
    {
        #region Fields

        private readonly byte[] _buffer = null;

        #endregion

        #region Properties

        /// <summary>
        /// Devuelve el array de bytes que almacena la imagen.
        /// </summary>
        public byte[] Buffer
        {
            get { return _buffer; }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la estructura <see cref="UIImage"/>.
        /// </summary>
        /// <param name="path">Fichero que almacena la imagen.</param>
        public UIImage(string path)
        {
            using (FileStream fStream = new FileStream(path, FileMode.Open))
            {
                fStream.Seek(0, SeekOrigin.Begin);

                using (MemoryStream mStream = new MemoryStream())
                {
                    fStream.CopyTo(mStream);
                    _buffer = mStream.ToArray();
                }
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la estructura <see cref="UIImage"/>.
        /// </summary>
        /// <param name="bytes">Array de bytes que almacena la imagen.</param>
        public UIImage(byte[] bytes)
        {
            if ((bytes != null) && (bytes.Length > 0))
            {
                _buffer = new byte[bytes.Length];

                Array.Copy(bytes, 0, _buffer, 0, _buffer.Length);
            }
        }

        /// <summary>
        /// Inicializa una nueva instancia de la estructura <see cref="UIImage"/>.
        /// </summary>
        /// <param name="stream">Stream que almacena la imagen.</param>
        public UIImage(Stream stream)
        {
            if ((stream != null) && (stream.Length > 0))
            {
                long iPosition = stream.Position;

                stream.Seek(0, SeekOrigin.Begin);

                using (MemoryStream mStream = new MemoryStream())
                {
                    stream.CopyTo(mStream);
                    _buffer = mStream.ToArray();
                }

                stream.Seek(iPosition, SeekOrigin.Begin);
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Devuelve una cadena resultante de convertir la imagen almacenada a Base64.
        /// </summary>        
        public string ToBase64()
        {
            string base64 = string.Empty;

            if (_buffer != null)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    base64 = Convert.ToBase64String(_buffer);
                }
            }

            return base64;
        }

        #endregion

        #region Factory Methods

        /// <summary>
        /// Devuelve una nueva instancia de la clase <see cref="UIImage"/> que almacena la imagen
        /// representada por la cadena en base64 indicada por parámetro.
        /// </summary>
        /// <param name="base64">Imagen en Base64.</param>
        /// <returns><see cref="UIImage"/></returns>
        public static UIImage CraeteFromBase64(string base64)
        {
            return new UIImage(Convert.FromBase64String(base64));
        }

        #endregion

        #region Override Methods

        /// <summary>
        /// Devuelve la representación de cadena de un objeto <see cref="UIImage"/>.
        /// </summary>
        public override string ToString()
        {
            return string.Format(GetType().Name);
        }

        /// <summary>
        /// Determina si un objeto <see cref="UIImage"/> proporcionado es equivalente al objeto <see cref="UIImage"/> actual.
        /// </summary>
        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            return ReferenceEquals(this, obj);
        }

        /// <summary>
        /// Obtiene un código hash de este objeto <see cref="UIImage"/>.
        /// </summary>
        public override int GetHashCode()
        {
            return ((_buffer != null) ? (_buffer.GetHashCode()) : (-1));
        }

        #endregion

        #region IEquatable<UIImage> Members

        /// <summary>
        /// Determina si un objeto <see cref="UIImage"/> proporcionado es equivalente al objeto <see cref="UIImage"/> actual.
        /// </summary>
        public bool Equals(UIImage other)
        {
            return ReferenceEquals(this, other);
        }

        #endregion

        #region ICloneable Members

        public object Clone()
        {
            return new UIImage(_buffer);
        }

        #endregion
    }
}