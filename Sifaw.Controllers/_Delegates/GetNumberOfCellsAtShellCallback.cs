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
	/// <returns>Número de celdas de la fila <see cref="row"/>.</returns>
	public delegate uint GetNumberOfCellsAtShellCallback(uint row);
}
