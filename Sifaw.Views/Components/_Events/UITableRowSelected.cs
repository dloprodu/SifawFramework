/*
 * Sifaw.Views.Components
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 08/03/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Core;


namespace Sifaw.Views.Components
{
	/*
	 * Argumento y manejador para los eventos TableSectionRowSelected.
	 */

	/// <summary>
	/// Proporciona datos para un evento <see cref="TableComponent.RowSelected"/>.
	/// </summary>
	public class UITableSectionRowSelectedEventArgs : EventArgs
	{
		/// <summary>
		/// Obtiene la ruta de la fila.
		/// </summary>
		public readonly UIIndexRowPath Path;

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UITableSectionRowSelectedEventArgs"/>.
		/// </summary>
		public UITableSectionRowSelectedEventArgs(UIIndexRowPath path)
			: base()
		{
			Path = path;
		}
	}

	/// <summary>
	/// Representa el método que controla un evento <see cref="TableComponent.RowSelected"/>.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="UIFilterChangedEventArgs"/> que contiene los datos de eventos.</param>
	public delegate void UITableSectionRowSelectedEventHandler(object sender, UITableSectionRowSelectedEventArgs e);
}
