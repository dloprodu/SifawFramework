/*
 * Sifaw.Views.Kit
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 02/03/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Views.Kit;


namespace Sifaw.Views
{
	/// <summary>
	/// Provee un conjunto de propiedades que permiten modificar la apariencia
	/// de un componente de interfaz de usuario.
	/// </summary>
	[Serializable]
	public class ComponentStyle : ElementStyle
	{
		#region Fields

		private UIFrame _border = new UIFrame(1);
		private UIFrameBrush _borderBrush = new UIFrameBrush(new UISolidBrush(UIColors.GrayColors.LightGray));
		private UIHorizontalAlignment _horizontalAlignment = UIHorizontalAlignment.Inherit;
		private UIVerticalAlignment _verticalAlignment = UIVerticalAlignment.Inherit;

		#endregion

		#region Properties

		/// <summary>
		/// Obtiene o establece el grosor del borde del componente.
		/// </summary>
		public UIFrame Border
		{
			get { return _border; }
			set { _border = value; }
		}

		/// <summary>
		/// Obtiene o establece un pincel que describe el fondo del borde del componente.
		/// </summary>
		public UIFrameBrush BorderBrush
		{
			get { return _borderBrush; }
			set { _borderBrush = value; }
		}

		/// <summary>
		/// Obtiene o establece la alineación horizontal que se aplican a este elemento
		/// cuando se aloja dentro de un elemento primario.
		/// </summary>
		public UIHorizontalAlignment HorizontalAlignment
		{
			get { return _horizontalAlignment; }
			set { _horizontalAlignment = value; }
		}

		/// <summary>
		/// Obtiene o establece la alineación vertical que se aplican a este elemento
		/// cuando se aloja dentro de un elemento primario.
		/// </summary>
		public UIVerticalAlignment VerticalAlignment
		{
			get { return _verticalAlignment; }
			set { _verticalAlignment = value; }
		}

		#endregion

		#region Constructor

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="ComponentStyle"/>.
		/// </summary>
		public ComponentStyle()
			: base()
		{
		}

		#endregion
	}
}