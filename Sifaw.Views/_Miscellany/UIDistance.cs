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
	/// Describe el grosor de un marco situado alrededor de un rectángulo. 
	/// Cuatro valores <c>Double</c> describen los lados Left, Top, Right y Bottom del rectángulo, respectivamente.
	/// </summary>
	public struct UIDistance
	{
		/// <summary>
		/// Representa una estructura <see cref="UIDistance"/> con longitudes definidas a 0.
		/// </summary>
		public static readonly UIDistance Empty;

		/// <summary>
		/// Obtiene o establece el ancho, en píxeles, del lado izquierdo del rectángulo delimitador.
		/// </summary>
		public double Left;

		/// <summary>
		/// Obtiene o establece el ancho, en píxeles, del lado superior del rectángulo delimitador.
		/// </summary>
		public double Top;

		/// <summary>
		/// Obtiene o establece el ancho, en píxeles, del lado menor del rectángulo delimitador.
		/// </summary>
		public double Right;

		/// <summary>
		/// Obtiene o establece el ancho, en píxeles, del lado menor del rectángulo delimitador.
		/// </summary>
		public double Bottom;

		#region Constructors

		static UIDistance()
		{
			Empty = new UIDistance(0.0f, 0.0f, 0.0f, 0.0f);
		}

		/// <summary>
		/// Inicializa una nueva instancia de la estructura <see cref="UIDistance"/> que tiene las longitudes 
		/// específicas (se proporcionan como valor de tipo <c>Double</c>) aplicadas a cada lado del rectángulo.
		/// </summary>
		public UIDistance(double left, double top, double right, double bottom)
		{
			Left = left;
			Top = top;
			Right = right;
			Bottom = bottom;
		}

		/// <summary>
		/// Inicializa una nueva instancia de la estructura <see cref="UIDistance"/> que tiene la longitud 
		/// uniforme especificada en cada lado.
		/// </summary>
		public UIDistance(double all)
			: this(all, all, all, all)
		{
		}

		/// <summary>
		/// Inicializa una nueva instancia de la estructura <see cref="UIDistance"/> que tiene las longitudes 
		/// específicas (se proporcionan como valor de tipo <c>Double</c>) aplicadas a cada lado del rectángulo.
		/// </summary>
		public UIDistance(int left, int top, int right, int bottom)
			: this(Convert.ToSingle(left), Convert.ToSingle(top), Convert.ToSingle(right), Convert.ToSingle(bottom))
		{
		}

		/// <summary>
		/// Inicializa una nueva instancia de la estructura <see cref="UIDistance"/> que tiene la longitud 
		/// uniforme especificada en cada lado.
		/// </summary>
		public UIDistance(int all)
			: this(Convert.ToSingle(all))
		{
		}

		#endregion
	}
}
