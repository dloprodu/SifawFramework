﻿/*
 * Sifaw.Views
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


namespace Sifaw.Views
{
	/// <summary>
	/// Define el método para enlazar el componente de interfaz de usuario con su correspondiente instancia
	/// en la capa de presentación.
	/// </summary>
	/// <remarks>
	/// Sigue el patrón de diseño 'Abstract Factory (Fábrica abstractra)' para crear
	/// interfaces gráficas.
	/// </remarks>
	/// <typeparam name="TUIElement">
	/// Tipo abstracto del elemento de interfaz de usuario, derivado de <see cref="UIElement"/>.
	/// </typeparam>
	public interface UILinker<TUIElement>
		where TUIElement : UIElement
	{
		/// <summary>
		/// Devuelve una representación concreta para el componente abstracto <c>TUIElement</c>.
		/// </summary>
		/// <param name="ui">Elemento de interfaz de usuario.</param>
		void Create(out TUIElement ui);
	}
}