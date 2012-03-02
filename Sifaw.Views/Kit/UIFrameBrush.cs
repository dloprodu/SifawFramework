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


namespace Sifaw.Views.Kit
{
	/// <summary>
	/// Describe los pinceles para dibujar un marco situado alrededor de un rectángulo. 
    /// Cuatro valores <see cref="UIBrush"/> describen los pinceles de los lados Left, Top, Right y Bottom del rectángulo, respectivamente.
	/// </summary>
	public struct UIFrameBrush
	{
		/// <summary>
		/// Obtiene o establece el pincel del lado izquierdo del rectángulo delimitador.
		/// </summary>
        public UIBrush Left;

		/// <summary>
		/// Obtiene o establece el pincel del lado superior del rectángulo delimitador.
		/// </summary>
        public UIBrush Top;

		/// <summary>
		/// Obtiene o establece el pincel del lado derecho del rectángulo delimitador.
		/// </summary>
        public UIBrush Right;

		/// <summary>
		/// Obtiene o establece el pincel del lado menor del rectángulo delimitador.
		/// </summary>
        public UIBrush Bottom;

		#region Constructors

		/// <summary>
		/// Inicializa una nueva instancia de la estructura <see cref="UIFrameBrush"/> que tiene los pinceles 
		/// específicos (se proporcionan como valor de tipo <c>UIColor</c>) aplicadas a cada lado del rectángulo.
		/// </summary>
        public UIFrameBrush(UIBrush left, UIBrush top, UIBrush right, UIBrush bottom)
		{
			Left = left;
			Top = top;
			Right = right;
			Bottom = bottom;
		}

		/// <summary>
		/// Inicializa una nueva instancia de la estructura <see cref="UIFrameBrush"/> que tiene el pincel 
		/// uniforme especificado en cada lado.
		/// </summary>
        public UIFrameBrush(UIBrush all)
			: this(all, all, all, all)
		{
		}

		#endregion
	}
}
