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
		public readonly static CLInformation Empty;

		/// <summary>
		/// Devuelve el nombre de la controladora.
		/// </summary>
		public readonly string Name;

		/// <summary>
		/// Devuelve la descripción de la controladora.
		/// </summary>
		public readonly string Description;

		#region Constructor

		static CLInformation()
		{
			Empty = new CLInformation(string.Empty, string.Empty);
		}

		public CLInformation(string name, string description)
		{
			Name = name;
			Description = description;
		}

		#endregion
	}
}
