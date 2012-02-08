///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// Controladora que permite realizar un filtro booleano.
/// 
/// Diseñador: David López Rguez
/// Programador: David López Rguez
/// </sumary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 06/02/2012: Creación de controladora.
/// 
/// ===============================================================================================
/// Observaciones:
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



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
		, BoolComponentFilter>
	{
		#region Settings

		[Serializable]
		public class UISettingsContainer : UIFilterBaseController
			< bool
			, UISettingsContainer
			, BoolComponentFilter>.UISettingsContainer<BoolComponentFilter>
		{
			#region Variables

			private string _text;

			#endregion

			#region Propiedades

			public string Text
			{
				get { return _text; }
				set { _text = value; }
			}

			#endregion

			#region Constructor

			public UISettingsContainer()
				: base()
			{
			}

			#endregion

			#region Métodos públicos

			public override void Apply()
			{
				base.Apply();

				UIElement.Text = Text;
			}

			#endregion
		}

		#endregion

		#region Constructor

		public UIBoolFilterController()
			: base()
		{
		}

		public UIBoolFilterController(AbstractUILinker<BoolComponentFilter> linker)
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

		#region StartController

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