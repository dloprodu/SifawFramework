﻿/*
 * Sifaw.Views.Components
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 29/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Views;
using Sifaw.Views.Kit;


namespace Sifaw.Views.Components
{
	/// <summary>
	/// Representa un componente que muestra datos en una tabla.
	/// </summary>
	public interface TableComponent : UIComponent<ComponentStyle>
	{
		/// <summary>
		/// Establece la tabla a mostrar.
		/// </summary>		
		void SetTable(UITable table);
	}
}