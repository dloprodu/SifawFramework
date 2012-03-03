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
	public abstract class ComponentSettings : UISettings
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
			set 
            {
                if (_border != value)
                {
                    _border = value;
                    OnPropertyChanged(() => Border);
                }
            }
		}

		/// <summary>
		/// Obtiene o establece un pincel que describe el fondo del borde del componente.
		/// </summary>
		public UIFrameBrush BorderBrush
		{
			get { return _borderBrush; }
			set
            {
                if (_borderBrush != value)
                {
                    _borderBrush = value;
                    OnPropertyChanged(() => BorderBrush);
                }
            }
		}

		/// <summary>
		/// Obtiene o establece la alineación horizontal que se aplican a este elemento
		/// cuando se aloja dentro de un elemento primario.
		/// </summary>
		public UIHorizontalAlignment HorizontalAlignment
		{
			get { return _horizontalAlignment; }
			set
            {
                if (_horizontalAlignment != value)
                {
                    _horizontalAlignment = value;
                    OnPropertyChanged(() => HorizontalAlignment);
                }
            }
		}

		/// <summary>
		/// Obtiene o establece la alineación vertical que se aplican a este elemento
		/// cuando se aloja dentro de un elemento primario.
		/// </summary>
		public UIVerticalAlignment VerticalAlignment
		{
			get { return _verticalAlignment; }
			set 
            {
                if (_verticalAlignment != value)
                {
                    _verticalAlignment = value;
                    OnPropertyChanged(() => VerticalAlignment);
                }
            }
		}

		#endregion

		#region Constructor

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="ComponentSettings"/>.
		/// </summary>
		protected ComponentSettings()
			: base()
		{
		}

		#endregion
	}
}