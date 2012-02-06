///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// Controladora que permite realizar filtros sobre una lista.
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
	/// Controladora que permite realizar filtros sobre una lista de objetos mediante una interfaz
	/// de usuario.
	/// </summary>
	public class UIListFilterController : UIFilterController
		< IList<IFilterable>
		, UIListFilterController.UISettingsContainer
		, ComponentFilter<IList<IFilterable>>>
	{
		#region Settings

		[Serializable]
		public class UISettingsContainer : UIFilterController
			< IList<IFilterable>
			, UISettingsContainer
			, ComponentFilter<IList<IFilterable>>>.UISettingsContainer<ComponentFilter<IList<IFilterable>>>
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

		public UIListFilterController()
			: base()
		{
		}

		public UIListFilterController(AbstractUILinker<ComponentFilter<IList<IFilterable>>> linker)
			: base(linker)
		{
		}

		#endregion

		#region Default input / output

		public override Input GetDefaultInput()
		{
			return new Input(new List<IFilterable>());
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