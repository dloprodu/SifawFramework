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
    /// Clase abstracta que almacena una imagen.
    /// </summary>
    public class UIImage : IDisposable, IEquatable<UIImage>
    {
        #region Fields

        private byte[] _bytes = null;

        #endregion

        #region Properties

        /// <summary>
        /// Devuelve el array de bytes que almacena la imagen.
        /// </summary>
        public byte[] Bytes
        {
            get { return _bytes; }
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
                using (BinaryReader bReader = new BinaryReader(fStream))
                {
                    _bytes = bReader.ReadBytes((Int32)fStream.Length);
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
                _bytes = new byte[bytes.Length];

                Array.Copy(bytes, 0, _bytes, 0, _bytes.Length);
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
                using (BinaryReader bReader = new BinaryReader(stream))
                {
                     _bytes = bReader.ReadBytes((Int32)stream.Length);
                }
            }
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
            return ((_bytes != null) ? (_bytes.GetHashCode()) : (-1));
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

        #region IDisposable Members

        /// <summary>
        /// Libera los recursos del objeto <see cref="UIImage"/>.
        /// </summary>
        public void Dispose()
        {
            _bytes = null;
        }

        #endregion
    }
}