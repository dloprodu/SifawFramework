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


namespace Sifaw.Controllers.Components
{
	/// <summary>
	/// Representa el callbak que es invocado cuando se solicita desde, desde un componente
	/// que gestiona un objeto <see cref="UITable"/>, el número de filas que componen la 
	/// cabecera de la tabla especificada.
	/// </summary>
	/// <param name="tableName">Nombre de la tabla.</param>
	/// <returns>Número de filas de la cabecera.</returns>
	internal delegate int GetNumberOfHeaderRows(string tableName);
}