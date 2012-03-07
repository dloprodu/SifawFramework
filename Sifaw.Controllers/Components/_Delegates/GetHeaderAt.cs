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
	/// que gestiona un objeto <see cref="UITable"/>, la configuración de celdas que componen la fila especificada de la cabecera.
	/// </summary>
	/// <param name="tableName">Nombre de la tabla.</param>
	/// <param name="row">Índice de la fila.</param>
	/// <returns>Array de celdas.</returns>
	internal delegate UITableCell[] GetHeaderAt(string tableName, int row);
}