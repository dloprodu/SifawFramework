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
 */



using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sifaw.Views.Kit
{
    /// <summary>
    /// Representa una colección de objetos <see cref="UIGradientStop"/> a los
    /// que el índice puede tener acceso individualmente.
    /// </summary>
    [Serializable]
    public class UIGradientStopCollection : CollectionBase
    {
        #region Properties

        /// <summary>
        /// Obtiene el objeto <see cref="UIGradientStop"/> en el índice especificado de la colección.
        /// </summary>
        /// <param name="index">Índice del objeto <see cref="UIGradientStop"/> que se va a recuperar de la colección.</param>
        /// <returns>
        /// <see cref="UIGradientStop"/> ubicado en el índice especificado de la colección
        /// </returns>
        public UIGradientStop this[int index]
        {
            get { return ((UIGradientStop)List[index]); }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UIGradientStopCollection"/>.
        /// </summary>
        public UIGradientStopCollection()
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Agrega un objeto <see cref="UIGradientStop"/> existente a la colección.
        /// </summary>
        /// <param name="value"> Objeto <see cref="UIGradientStop"/> que se va a agregar a la colección.</param>
        /// <returns>Índice basado en cero en la colección donde se almacena el elemento.</returns>
        public int Add(UIGradientStop value)
        {
            return (List.Add(value));
        }

        /// <summary>
        /// Devuelve el índice del objeto <see cref="UIGradientStop"/> especificado incluido en la colección.
        /// </summary>
        /// <param name="value">
        /// <see cref="UIGradientStop"/> que se va a buscar en la colección.
        /// </param>
        /// <returns>
        /// Índice de base cero de la ubicación del objeto <see cref="UIGradientStop"/> en la colección.
        /// Si el objeto <see cref="UIGradientStop"/> no se encuentra en la colección, el valor devuelto
        /// es -1.
        /// </returns>
        public int IndexOf(UIGradientStop value)
        {
            return (List.IndexOf(value));
        }
        
        /// <summary>
        /// Inserta una sección existente en la colección, en el índice
        /// especificado.
        /// </summary>
        /// <param name="index">Posición de índice de base cero donde se inserta el objeto <see cref="UIGradientStop"/>.</param>
        /// <param name="value">Objeto <see cref="UIGradientStop"/> que se va a insertar en la colección.</param>
        public void Insert(int index, UIGradientStop value)
        {
            List.Insert(index, value);
        }

        /// <summary>
        /// Quita el objeto <see cref="UIGradientStop"/> especificado de la colección.
        /// </summary>
        /// <param name="value">
        /// <see cref="UIGradientStop"/> que se va a quitar de la colección.
        /// </param>
        public void Remove(UIGradientStop value)
        {
            List.Remove(value);
        }

        /// <summary>
        /// Determina si el objeto <see cref="UIGradientStop"/> especificado se encuentra en la colección.
        /// </summary>
        /// <param name="value">
        /// <see cref="UIGradientStop"/> que se va a buscar en la colección.
        /// </param>
        /// <returns>
        /// true si la colección contiene el objeto <see cref="UIGradientStop"/>; en caso contrario, false.
        /// </returns>
        public bool Contains(UIGradientStop value)
        {
            return (List.Contains(value));
        }

        #endregion
    }
}