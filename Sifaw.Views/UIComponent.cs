///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Interfaz base con los métodos generales que deben tener todos los componentes UI.
/// 
/// Diseñador:     David López Rguez
/// Programadores: David López Rguez
///	
/// </summary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 03/01/2012 -- Creación de la clase.
/// ===============================================================================================
/// Observaciones:
/// 
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



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
		/* Empty */
	}
}