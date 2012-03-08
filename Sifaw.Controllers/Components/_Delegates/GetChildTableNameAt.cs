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
	/// que gestiona un objeto <see cref="UITable"/>, el nombre de una tabla hija asociada
	/// a una fila.
	/// </summary>
	/// <param name="path">Ruta de fila.</param>
	/// <returns>Nombre de la tabla hija.</returns>
	internal delegate string GetChildTableNameAt(UIIndexRowPath path);
}