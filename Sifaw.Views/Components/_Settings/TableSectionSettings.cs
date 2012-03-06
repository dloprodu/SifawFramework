/*
 * Sifaw.Views.Kit
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 02/03/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sifaw.Views.Kit;


namespace Sifaw.Views.Components
{
	/// <summary>
	/// Provee un conjunto de propiedades que permiten modificar la apariencia
	/// de un componente de interfaz de usuario.
	/// </summary>
	public interface TableSectionSettings
	{
		/// <summary>
		/// Obtiene o establece el pincel que describe el fondo del elemento.
		/// </summary>
		UIBrush Background { get; set; }

		/// <summary>
		/// Obtiene o establece el margen exterior del elemento.
		/// </summary>
		UIFrame Margin { get; set; }

		/// <summary>
		/// Obtiene o establece el relleno interior del elemento.
		/// </summary>
		UIFrame Padding { get; set; }

		/// <summary>
		/// Obtiene o establece el grosor del borde del componente.
		/// </summary>
		UIFrame Border { get; set; }

		/// <summary>
		/// Obtiene o establece un pincel que describe el fondo del borde del componente.
		/// </summary>
		UIFrameBrush BorderBrush { get; set; }

		/// <summary>
		/// Obtiene o establece el alto de las filas de la sección.
		/// </summary>
		double RowHeight { get; set; }
	}
}