﻿/*
 * Sifaw.Views
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 09/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sifaw.Views
{
	/// <summary>
	/// Define métodos, propiedades y eventos que ha de tener cualquier elemento
	/// de interfaz de usuario.
	/// </summary>
	public interface UIElement
	{
		#region Properties

		/// <summary>
		/// Obtiene o establece la denominación del <see cref="UIElement"/>.
		/// </summary>
		string Denomination { get; set; }

		/// <summary>
		/// Obtiene o establece la descripción del <see cref="UIElement"/>.
		/// </summary>
		string Description { get; set; }

		/// <summary>
		/// Obtiene o establece el ancho mínimo del <see cref="UIElement"/>.
		/// </summary>
		double MinWidth { get; set; }

		/// <summary>
		/// Obtiene o establece el ancho máximo del <see cref="UIElement"/>.
		/// </summary>
		double MaxWidth { get; set; }

		/// <summary>
		/// Obtiene o establece el alto mínimo del <see cref="UIElement"/>.
		/// </summary>
		double MinHeight { get; set; }

		/// <summary>
		/// Obtiene o establece el alto máximo del <see cref="UIElement"/>.
		/// </summary>
		double MaxHeight { get; set; }
		
		#endregion

		#region Methods

		/// <summary>
		/// Refresca el elemento UI.
		/// </summary>
		void Refresh();

		/// <summary>
		/// Resetea y libera recursos del elemento UI.
		/// </summary>
		void Reset();

		/// <summary>
		/// Método encargado de activar el y proporcionarle el foco.
		/// </summary>
		void SetLikeActive();

		#endregion
	}
}