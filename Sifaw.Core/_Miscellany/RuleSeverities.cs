/*
 * Sifaw.Core
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 14/12/2011: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sifaw.Core
{
	/// <summary>
	/// Define los niveles de severidad de las reglas rotas.
	/// </summary>
	public enum RuleSeverities
	{
		/// <summary>
		/// Represents a serious
		/// business rule violation that
		/// should cause an object to
		/// be considered invalid.
		/// </summary>
		Error,

		/// <summary>
		/// Represents a business rule
		/// violation that should be
		/// displayed to the user, but which
		/// should not make an object be
		/// invalid.
		/// </summary>
		Warning,

		/// <summary>
		/// Represents a business rule
		/// result that should be displayed
		/// to the user, but which is less
		/// severe than a warning.
		/// </summary>
		Information
	}
}
