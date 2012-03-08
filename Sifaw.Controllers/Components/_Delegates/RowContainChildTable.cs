/*
 * Sifaw.Controllers.Components
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

using Sifaw.Views.Components;


namespace Sifaw.Controllers.Components
{
	/// <summary>
	/// Representa el callbak que es invocado cuando se solicita, desde un componente
	/// que gestiona un objeto <see cref="Sifaw.Views.Components.UITable"/>, que indica si la fila de la 
	/// sección especificada tiene una tabla secundaria asociada. 
	/// </summary>
	/// <param name="path">Ruta de la fila.</param>
	/// <returns>
	/// <c>true</c> si la fila tiene una tabla secundaria asociada; 
	/// <c>false</c> en otro caso.
	/// </returns>
	internal delegate bool RowContainChildTable(UIIndexRowPath path);
}