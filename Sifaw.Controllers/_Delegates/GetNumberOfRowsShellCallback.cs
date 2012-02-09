using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sifaw.Controllers
{
	/// <summary>
	/// Representa el callbak que es invocado cuando se solicita desde una 
	/// shell el número de filas.
	/// </summary>
	/// <returns>Número de filas de la shell.</returns>
	public delegate uint GetNumberOfRowsShellCallback();
}
