/*
 * Sifaw.Controllers.Components.Filters
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 08/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Views.Components;
using Sifaw.Views.Components.Filters;


namespace Sifaw.Controllers.Components.Filters
{
	/// <summary>
	/// Controladora que permite realizar filtros de texto, devolviendo como
	/// filtro el texto introducido por el usuario.
	/// </summary>
	public class UITextFilterController : UIFilterBaseController
		< string
		, UITextFilterController.UISettingsContainer
		, TextFilterComponent>
	{
		#region Settings

		[Serializable]
		public new class UISettingsContainer : UIFilterBaseController
			< string
			, UISettingsContainer
			, TextFilterComponent>.UISettingsContainer
		{
			#region Fields

			private string _placeholder = string.Empty;

			#endregion

			#region Properties

			public string Placeholder
			{
				get { return _placeholder; }
				set { _placeholder = value; }
			}

			#endregion

			#region Constructors

			public UISettingsContainer()
				: base()
			{
				this._placeholder = "Buscar...";
			}

			#endregion
		}

		#endregion

		#region Constructors

		public UITextFilterController()
			: base()
		{
		}

		public UITextFilterController(AbstractUILinker<TextFilterComponent> linker)
			: base(linker)
		{
		}

		#endregion

		#region Default input / output

		public override Input GetDefaultInput()
		{
			return new Input(string.Empty);
		}

		#endregion

        #region UIElement Methods

        protected override void OnApplyUISettings()
        {
            base.OnApplyUISettings();

            UIElement.Placeholder = UISettings.Placeholder;
        }

        #endregion

		#region Start Methods

		protected override void StartController()
		{
			/* Empty */
		}

		protected override bool AllowReset()
		{
			return true;
		}

		protected override void ResetController()
		{
			/* Empty */
		}

		#endregion
	}
}