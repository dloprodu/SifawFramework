/*
 * Sifaw.Views.Kit
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 01/03/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Core;

using Sifaw.Views.Kit;


namespace Sifaw.Views
{
	/// <summary>
	/// Provee un conjunto de propiedades que permiten modificar la apariencia
	/// de un elemento de interfaz de usuario.
	/// </summary>
	public interface UISettings
	{
        /// <summary>
        /// Obtiene o establece una denominación al elemento.
        /// </summary>
        string Denomination { get; set; }

        /// <summary>
        /// Obtiene o establece una descripción al elemento.
        /// </summary>
		string Description { get; set; }

		/// <summary>
		/// Obtiene o establece el pincel que describe el fondo del elemento.
		/// </summary>
		UIBrush Background { get; set; }

		/// <summary>
		/// Obtiene o establece el pincel que describe el color de primer plano del elemento.
		/// </summary>
		UIBrush Foreground { get; set; }

		/// <summary>
		/// Obtiene o establece el margen exterior del elemento.
		/// </summary>
		UIFrame Margin { get; set; }

		/// <summary>
		/// Obtiene o establece el relleno interior del elemento.
		/// </summary>
		UIFrame Padding { get; set; }
                
		/// <summary>
		/// Obtiene o establece el tamaño mínimo del elemento.
		/// </summary>
		UISize MinSize { get; set; }

		/// <summary>
		/// Obtiene o establece el tamaño máximo del elemento.
		/// </summary>
		UISize MaxSize { get; set; }

		/// <summary>
		/// Obtiene o establece el ancho del elemento. El valor por defecto es -1, lo que sifnifica
		/// que se mantiene el ancho por defecto de la representación concreta del elemento.
		/// </summary>
		double Width { get; set; }

		/// <summary>
		/// Obtiene o establece el alto del elemento. El valor por defecto es -1, lo que sifnifica
		/// que se mantiene el alto por defecto de la representación concreta del elemento.
		/// </summary>
		double Height { get; set; }

        /// <summary>
        /// Obtiene o establece un valor que indica si se debe ajustar el tamaño del elemento a su contenido.
        /// </summary>
        bool SizeToContent { get; set; }
	}
}