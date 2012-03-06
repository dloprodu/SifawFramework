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


namespace Sifaw.Views
{
	/// <summary>
	/// Provee un conjunto de propiedades que permiten modificar la apariencia
	/// de un componente de interfaz de usuario.
	/// </summary>
	public interface ComponentSettings : UISettings
	{
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
	}
}