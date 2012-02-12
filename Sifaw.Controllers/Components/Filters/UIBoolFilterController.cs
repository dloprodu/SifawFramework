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
	/// Controladora que permite realizar filtros sobre un campo booleanos, devolviendo como
	/// filtro <see cref="true"/> o <see cref="false"/>.
	/// </summary>
	public class UIBoolFilterController : UIFilterBaseController
		< bool
		, UIBoolFilterController.UISettingsContainer
		, BoolFilterComponent>
	{
		#region Settings

		[Serializable]
		public new class UISettingsContainer : UIFilterBaseController
			< bool
			, UISettingsContainer
			, BoolFilterComponent>.UISettingsContainer
		{
			#region Fields

			private string _text;

			#endregion

			#region Properties

			public string Text
			{
				get { return _text; }
				set { _text = value; }
			}

			#endregion

			#region Constructors

			public UISettingsContainer()
				: base()
			{
			}

			#endregion
		}

		#endregion

		#region Constructors

		public UIBoolFilterController()
			: base()
		{
		}

		public UIBoolFilterController(AbstractUILinker<BoolFilterComponent> linker)
			: base(linker)
		{
		}

		#endregion

		#region Default input / output

		public override Input GetDefaultInput()
		{
			return new Input(false);
		}

		#endregion

        #region UIElement Methods

        protected override void OnApplyUISettings()
        {
            base.OnApplyUISettings();

            UIElement.Text = UISettings.Text;
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