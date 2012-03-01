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


namespace Sifaw.Views
{
	/// <summary>
	/// Describe los colores de un marco situado alrededor de un rectángulo. 
	/// Cuatro valores <c>string</c> describen los colores de los lados Left, Top, Right y Bottom del rectángulo, respectivamente.
	/// </summary>
	public struct UIFrameColor
	{
		/// <summary>
		/// Obtiene o establece el color del lado izquierdo del rectángulo delimitador.
		/// </summary>
		public UIColor Left;

		/// <summary>
		/// Obtiene o establece el color del lado superior del rectángulo delimitador.
		/// </summary>
		public UIColor Top;

		/// <summary>
		/// Obtiene o establece el color del lado derecho del rectángulo delimitador.
		/// </summary>
		public UIColor Right;

		/// <summary>
		/// Obtiene o establece el color del lado menor del rectángulo delimitador.
		/// </summary>
		public UIColor Bottom;

		#region Constructors

		/// <summary>
		/// Inicializa una nueva instancia de la estructura <see cref="UIFrameColor"/> que tiene los colores 
		/// específicos (se proporcionan como valor de tipo <c>UIColor</c>) aplicadas a cada lado del rectángulo.
		/// </summary>
		public UIFrameColor(UIColor left, UIColor top, UIColor right, UIColor bottom)
		{
			Left = left;
			Top = top;
			Right = right;
			Bottom = bottom;
		}

		/// <summary>
		/// Inicializa una nueva instancia de la estructura <see cref="UIFrameColor"/> que tiene el color 
		/// uniforme especificado en cada lado.
		/// </summary>
		public UIFrameColor(UIColor all)
			: this(all, all, all, all)
		{
		}

		#endregion
	}
}
