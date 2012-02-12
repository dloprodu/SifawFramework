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
	/// Representa el callbak que es invocado cuando se solicita desde una 
	/// shell la configuración de una celda de la shell.
	/// </summary>
	/// <typeparam name="TGuest">Tipo de los componentes que puede alojar la shell.</typeparam>
	/// <param name="row">Fila.</param>
	/// <param name="height">Alto de la fila.</param>
	/// <param name="mode">Modo de ajuste de la fila.</param>
	public delegate void GetRowCellSettingsShellCallback<TGuest>(uint row, uint cell, out double width, out UILengthModes mode, out TGuest guest)
		where TGuest : UIComponent;
}
