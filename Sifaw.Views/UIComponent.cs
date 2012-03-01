/*
 * Sifaw.Views
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 09/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sifaw.Views
{
	/// <summary>
	/// <para>
	/// Representa un componente que implementa la lógica concreta de la interfaz 
	/// con la que ha de interactuar el usuario de una controladora. 
	/// </para>
	/// <para>
	/// Se trata de un elemento que no se puede mostrar por si solo,
	/// sino que se ha de agregar en un contenedor que lo muestre, 
	/// por ejemplo una vista.
	/// </para>
	/// </summary>
	public interface UIComponent : UIElement
	{
		/// <summary>
		/// Obtiene o establece el margen del componente.
		/// </summary>
		UIFrame Margin { get; set; }
	}
}