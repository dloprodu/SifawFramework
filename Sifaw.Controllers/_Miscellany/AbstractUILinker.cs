/*
 * Sifaw.Controllers
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 08/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Views;


namespace Sifaw.Controllers
{
	/// <summary>
	/// Define el método para enlazar el componente de interfaz de usuario con su correspondiente instancia
	/// en la capa de presentación.
	/// </summary>
	/// <remarks>
	/// Sigue el patrón de diseño 'Abstract Factory (Fábrica abstractra)' para crear
	/// interfaces gráficas.
	/// </remarks>
	public interface AbstractUILinker<TUIElement>
		where TUIElement : UIElement
	{
		void Get(out TUIElement ui);
	}
}