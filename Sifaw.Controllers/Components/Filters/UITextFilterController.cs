///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// Controladora que permite realizar filtros de texto.
/// 
/// Diseñador: David López Rguez
/// Programador: David López Rguez
/// </sumary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 27/01/2012: Creación de controladora.
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
		public class UISettingsContainer : UIFilterBaseController
			< string
			, UISettingsContainer
			, TextFilterComponent>.UISettingsContainer<TextFilterComponent>
		{
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
			}

			#endregion
		}

		#endregion

		#region Constructor

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