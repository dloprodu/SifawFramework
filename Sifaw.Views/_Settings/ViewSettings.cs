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


namespace Sifaw.Views
{
	/// <summary>
	/// Provee un conjunto de propiedades que permiten modificar la apariencia
	/// de una vista de interfaz de usuario.
	/// </summary>
	public interface ViewSettings : UISettings
	{
		/// <summary>
		/// Obtiene o establece la cabecera de la vista.
		/// </summary>
		string Header
		{
			get;
			set;
		}
	}
}