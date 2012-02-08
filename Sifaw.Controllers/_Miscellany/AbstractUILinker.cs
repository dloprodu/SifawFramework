/////////////////////////////////////////////////////////////
/// <summary>
/// AbstractUILinker.cs
/// 
/// Diseñador:     David López Rguez
/// Programadores: David López Rguez
/// </summary>
/// <remarks>
/// ========================================================
/// Historial de versiones:
///   - 14/12/2011 -- Creación de la clase.
/// 
/// ========================================================
/// Observaciones:
/// 
/// </remarks>
////////////////////////////////////////////////////////////



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