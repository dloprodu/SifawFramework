/*
 * Sifaw.Controllers
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


namespace Sifaw.Controllers
{
	/// <summary>
	/// Almacena la descripción de una controladora.
	/// </summary>
	[Serializable]
	public struct CLInformation
	{
		/// <summary>
		/// Representa un <see cref="CLInformation"/> vacío.
		/// </summary>
		public readonly static CLInformation Empty;

		/// <summary>
		/// Devuelve el nombre de la controladora.
		/// </summary>
		public readonly string Name;

		/// <summary>
		/// Devuelve la descripción de la controladora.
		/// </summary>
		public readonly string Description;

		#region Constructors

		static CLInformation()
		{
			Empty = new CLInformation(string.Empty, string.Empty);
		}

		/// <summary>
		/// Inicializa una instancia de la estructura <see cref="CLInformation"/>.
		/// </summary>
		/// <param name="name">Nombre de la controladora.</param>
		/// <param name="description">Descripción de la controladora.</param>
		public CLInformation(string name, string description)
		{
			Name = name;
			Description = description;
		}

		#endregion
	}
}
