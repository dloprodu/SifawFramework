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


namespace Sifaw.Controllers
{
	/// <summary>
	/// Representa el callbak que es invocado cuando se solicita desde una 
	/// shell el número de celdas de una fila.
	/// </summary>
	/// <param name="row">Fila.</param>
	/// <returns>Número de celdas de la fila.</returns>
	public delegate uint GetNumberOfCellsAtShellCallback(uint row);
}
