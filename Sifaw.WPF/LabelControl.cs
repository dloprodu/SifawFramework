/*
 * Sifaw.WPF
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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Sifaw.Views.Components;
using Sifaw.Views;
using Sifaw.Views.Components.Filters;
using Sifaw.Views.Kit;
using Sifaw.WPF.CCL;


namespace Sifaw.WPF
{
	/// <summary>
    /// Representa un control que implementa el componente <see cref="LabelComponent"/>.
	/// </summary>
	public class LabelControl : Label, LabelComponent
	{
		#region Constructors

		static LabelControl()
		{
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LabelControl), new FrameworkPropertyMetadata(typeof(LabelControl)));
		}

        #endregion

		#region UIElement Members

		public void Refresh()
		{
			/* Emtpy */
		}

		public void Reset()
        {
            /* Emtpy */
		}

		public void SetLikeActive()
		{
			Focus();
		}

		#endregion

        #region UISettings

        private LabelSettings _uiSettings = null;
        public LabelSettings UISettings
        {
            get
            {
                if (_uiSettings == null)
                    _uiSettings = new LabelControlSettings(this);

                return _uiSettings;
            }
        }

        ComponentSettings UIComponent.UISettings
        {
            get { return UISettings; }
        }

        UISettings Views.UIElement.UISettings
        {
            get { return UISettings; }
        }

        #endregion

        #region Miscellany

        [Serializable]
        public class LabelControlSettings : ControlSettings, LabelSettings
        {
            #region Fields

            private string _label = string.Empty;

            #endregion

            #region Properties

            /// <summary>
            /// Obtiene o establece la etiqueta, o texto de entrada, para el componente.
            /// </summary>
            public string Label
            {
                get { return _label; }
                set
                {
                    if (_label != value)
                    {
                        _label = value;
                        OnPropertyChanged(() => Label);
                    }
                }
            }

            #endregion

            #region Constructor

            public LabelControlSettings(LabelControl control)
                : base(control)
            {
                /* Initial values */
                this.Label = (string)SettingsOperationsManager.StringToObject.ConvertBack(control.Content, null, null, null);

                UtilWPF.BindField(this, "Label", control, LabelControl.ContentProperty, BindingMode.TwoWay, SettingsOperationsManager.StringToObject);
            }

            #endregion
        }

        #endregion
    }
}