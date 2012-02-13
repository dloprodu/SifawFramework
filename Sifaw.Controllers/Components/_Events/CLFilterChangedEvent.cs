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

using Sifaw.Core;


namespace Sifaw.Controllers.Components
{
	/*
	 * Argumento y manejador para los eventos FilterChanged.
	 */

	/// <summary>
	/// Proporciona datos para un evento <see cref="UIFilterBaseController{TFilter, TUISettings, TComponent}.FilterChanged"/>.
	/// </summary>
	public class CLFilterChangedEventArgs<TFilter> : SFCancelEventArgs
	{
		/// <summary>
		/// Devuelve el valor del filtro.
		/// </summary>
		public readonly TFilter Filter;

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="CLFilterChangedEventArgs{TFilter}"/>.
		/// </summary>
		/// <param name="filter">Filtro aplicado.</param>
		public CLFilterChangedEventArgs(TFilter filter)
			: base()
		{
			Filter = filter;
		}
	}

	/// <summary>
	/// Representa el método que controla un evento <see cref="UIFilterBaseController{TFilter, TUISettings, TComponent}.FilterChanged"/>.
	/// </summary>
	/// <param name="sender">Origen del evento.</param>
	/// <param name="e"><see cref="CLFilterChangedEventArgs{TFiler}"/> que contiene los datos de eventos.</param>
	public delegate void CLFilterChangedEventHandler<TFiler>(object sender, CLFilterChangedEventArgs<TFiler> e);
}