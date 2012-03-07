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
	/// Representa el callbak que es invocado cuando se solicita, desde un componente
	/// que gestiona un objeto <see cref="UITable"/>, el número de filas que componen 
	/// la sección especificada.
	/// </summary>
	/// <param name="tableName">Nombre de la tabla.</param>
	/// <param name="section">Índice de la sección.</param>
	/// <returns>Número de filas.</returns>
	internal delegate int GetNumberOfRowsAt(string tableName, int section);
}