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


namespace Sifaw.Controllers.Components.Filters
{
	/// <summary>
	/// Controladora que permite realizar filtros booleanos mediante una interfaz
	/// de usuario.
	/// </summary>
	public class UIBoolFilterController : UIFilterController
		< bool
		, UIBoolFilterController.UISettingsContainer
		, ComponentFilter<bool>>
	{
		#region Settings

		[Serializable]
		public class UISettingsContainer : UIFilterController
			< bool
			, UISettingsContainer
			, ComponentFilter<bool>>.UISettingsContainer<ComponentFilter<bool>>
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

		public UIBoolFilterController()
			: base()
		{
		}

		public UIBoolFilterController(AbstractUILinker<ComponentFilter<bool>> linker)
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