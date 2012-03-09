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
	/// que gestiona un objeto <see cref="UITable"/>, la configuración
	/// de la sección especificada.
	/// </summary>
	/// <param name="table">Nombre de la tabla.</param>
	/// <param name="section">Índice de la sección.</param>
	/// <param name="caption">Título de sección.</param>
	/// <param name="detail">Detalle de sección.</param>
	/// <param name="setting">Estilo visual de la sección.</param>
	internal delegate void GetSectionAt(string table, int section, out string caption, out string detail, out UITableSection.UISettings setting);
}