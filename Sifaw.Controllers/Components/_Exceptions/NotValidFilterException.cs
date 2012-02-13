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
	/// Excepción producida por incoherencia al tratar un <see cref="Sifaw.Views.UIComponent"/> 
	/// como un <see cref="Sifaw.Views.Components.FilterBaseComponent{TFilter}"/>.
	/// </summary>
	public class NotValidFilterException : Exception
	{
		/// <summary>
		///  Inicializa una nueva instancia de la clase <see cref="NotValidFilterException"/>.
		/// </summary>
		public NotValidFilterException()
			: base("El componente no es un filtro válido.")
		{
		}
	}
}
