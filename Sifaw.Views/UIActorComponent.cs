/*
 * Sifaw.Views.Components
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
	/// Representa un componente que implementa una interfaz que permite seleccionar y mostrar
	/// un componente <see cref="UIComponent"/> de entre un grupo de componentes.
	/// </summary>
	public interface UIActorComponent : UIComponent
	{
		#region Properties

		/// <summary>
		/// Obtiene o establece el número de componentes que gestionará el componente.
		/// </summary>
		byte NumComponents { get; set; }

		#endregion

		#region Methods

		/// <summary>
		/// Establece el componente de interfaz de usuario a mostrar.
		/// </summary>
		/// <param name="content">Componente a mostrar.</param>
		/// <param name="key">Valor que indica la posición actual en la secuencia de componentes.</param>
		void UpdateContent(UIComponent content, byte key);

		#endregion

		#region Eventos

		/// <summary>
		/// Se produce cuando se solicita cambiar el componente a mostrar.
		/// </summary>
		event UIComponentChangedEventHandler UIComponentChanged;

		#endregion
	}
}