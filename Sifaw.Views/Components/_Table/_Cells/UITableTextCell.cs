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
			: this(name, text, UISettings.Default)
		{
			this._text = text;
		}

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UITableTextCell"/>.
		/// </summary>
		/// <param name="name">Nombre de la celda.</param>
		/// <param name="text">Texto de la celda.</param>
		/// <param name="settings">Estilo visual de la celda.</param>
		/// <param name="rowSpan">Número de filas que ocupa la celda.</param>
		/// <param name="colSpan">Número de columnas que ocupa la celda.</param>
		public UITableTextCell(string name, string text, UISettings settings, int rowSpan = 1, int colSpan = 1)
			: base(name, settings, rowSpan, colSpan)
		{
			this._text = text;
		}

		#endregion
	}
}
