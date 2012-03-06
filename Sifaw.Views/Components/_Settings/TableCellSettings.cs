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
	public interface TableCellSettings
	{
		/// <summary>
		/// Obtiene o establece el pincel que describe el fondo del elemento.
		/// </summary>
		UIBrush Background { get; set; }

		/// <summary>
		/// Obtiene o establece el pincel que describe el color de primer plano del elemento.
		/// </summary>
		UIBrush Foreground { get; set; }

		/// <summary>
		/// Obtiene o establece el grosor del borde del componente.
		/// </summary>
		UIFrame Border { get; set; }

		/// <summary>
		/// Obtiene o establece un pincel que describe el fondo del borde del componente.
		/// </summary>
		UIFrameBrush BorderBrush { get; set; }

		/// <summary>
		/// Obtiene o establece la alineación horizontal que se aplican a este elemento
		/// cuando se aloja dentro de un elemento primario.
		/// </summary>
		UIHorizontalAlignment HorizontalAlignment { get; set; }

		/// <summary>
		/// Obtiene o establece la alineación vertical que se aplican a este elemento
		/// cuando se aloja dentro de un elemento primario.
		/// </summary>
		UIVerticalAlignment VerticalAlignment { get; set; }

		/// <summary>
		/// Obtiene o establece el ancho de la celda.
		/// </summary>
		double Width { get; set; }

		/// <summary>
		/// Obtiene o establece el modo en el que se ajusta la celda.
		/// </summary>
		UITableCellLengthModes WidthMode { get; set; }
	}
}