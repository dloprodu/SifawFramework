/*
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

using Sifaw.Views.Kit;


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
		/// Obtiene el <see cref="UISettings"/> del <see cref="UIElement"/>.
		/// </summary>
		UISettings UISettings { get; }			
		
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

        #region Eventos

        /// <summary>
        /// Se produce cuando el elemento está inicializado correctamente.
        /// </summary>
        event EventHandler Loaded;

        #endregion
    }
}