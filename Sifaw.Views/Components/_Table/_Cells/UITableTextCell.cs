/*
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


namespace Sifaw.Views.Components
{
	/// <summary>
	/// Representa una celda de texto de un objeto <see cref="UITableRow"/>.
	/// </summary>
	[Serializable]
	public class UITableTextCell : UITableCell
	{
		#region Fields

		private string _text;

		#endregion

		#region Properties

		/// <summary>
		/// Obtiene el texto de la celda.
		/// </summary>
		public string Text
		{
			get { return _text; }
			set
			{
				if (_text != value)
				{
					_text = value;
					// Notificar: Table:{name}; Section:{name}; Row:{name}; Cell:{name}.
					// OnTextChange
				}
			}
		}

		#endregion

		#region Constructor

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UITableTextCell"/>.
		/// </summary>
		/// <param name="name">Nombre de la celda.</param>
		/// <param name="text">Texto de la celda.</param>
		public UITableTextCell(string name, string text)
			: base(name)
		{
			this._text = text;
		}

		#endregion
	}
}
