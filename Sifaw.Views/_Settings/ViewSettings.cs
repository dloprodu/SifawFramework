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


namespace Sifaw.Views
{
	/// <summary>
	/// Provee un conjunto de propiedades que permiten modificar la apariencia
	/// de una vista de interfaz de usuario.
	/// </summary>
	[Serializable]
	public class ViewSettings : UISettings
	{
		#region Fields

		private string _header = "SifaWake Application";

		#endregion

		#region Properties

		/// <summary>
		/// Obtiene o establece la cabecera de la vista.
		/// </summary>
		public string Header
		{
			get { return _header; }
			set
            {
                if (_header != value)
                {
                    _header = value;
                    OnPropertyChanged(() => Header);
                }
            }
		}
		
		#endregion

		#region Constructor

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="ViewSettings"/>.
		/// </summary>
		public ViewSettings()
			: base()
		{
		}

		#endregion
	}
}