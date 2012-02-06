///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// Controladora que permite realizar filtros sobre un enumerado.
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
	/// Controladora que permite realizar filtros sobre un enumerado mediante una interfaz
	/// de usuario.
	/// </summary>
	public class UIEnumFilterController : UIFilterController
		< Enum
		, UIEnumFilterController.UISettingsContainer
		, ComponentFilter<Enum>>
	{
		#region Settings

		[Serializable]
		public class UISettingsContainer : UIFilterController
			< Enum
			, UISettingsContainer
			, ComponentFilter<Enum>>.UISettingsContainer<ComponentFilter<Enum>>
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

		public UIEnumFilterController()
			: base()
		{
		}

		public UIEnumFilterController(AbstractUILinker<ComponentFilter<Enum>> linker)
			: base(linker)
		{
		}

		#endregion

		#region Default input / output

		public override Input GetDefaultInput()
		{
			return new Input(null);
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
