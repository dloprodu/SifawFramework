using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Sifaw.Controllers
{
	/// <summary>
	/// Define los esstados de una controladora.
	/// </summary>
	[Flags()]
	public enum CLStates : byte
	{
		/// <summary>
		/// Estado que indica que la controladora no está iniciada.
		/// </summary>
		NotStarted,

		/// <summary>
		/// Estado que indica que la controladora está iniciada.
		/// </summary>
		Started,
	}
}
