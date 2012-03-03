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


namespace Sifaw.Views.Components
{
	/// <summary>
	/// Provee un conjunto de propiedades que permiten modificar la apariencia
	/// de un componente de interfaz de usuario.
	/// </summary>
	[Serializable]
	public abstract class TextFilterSettings : ComponentSettings
	{
        #region Fields

        private string _placeholder = string.Empty;

        #endregion

        #region Properties

        /// <summary>
        /// Obtiene o establece el placeholder, o texto de entrada, para el componente.
        /// </summary>
        public string Placeholder
        {
            get { return _placeholder; }
            set 
            {
                if (_placeholder != value)
                {
                    _placeholder = value;
                    OnPropertyChanged(() => Placeholder);
                }
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="TextFilterSettings"/>.
		/// </summary>
        protected TextFilterSettings()
			: base()
		{
            this._placeholder = "Buscar...";
		}

		#endregion
	}
}