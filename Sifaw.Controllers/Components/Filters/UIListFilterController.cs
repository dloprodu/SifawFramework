///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// Controladora que permite realizar filtros sobre una lista devolviendo sublistas de la lista
/// original.
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
	/// Controladora que permite realizar filtros sobre una lista de objetos, devolviendo como
	/// filtro una sublista.
	/// </summary>
	public class UIListFilterController : UIListFilterBaseController
		< IList<IFilterable>
		, IList<IFilterable>
		, UIListFilterController.UISettingsContainer
		, ListComponentFilter>
	{
		#region Settings

		[Serializable]
		public class UISettingsContainer : UIListFilterBaseController
			< IList<IFilterable>
			, IList<IFilterable>
			, UISettingsContainer
			, ListComponentFilter>.UISettingsContainer<ListComponentFilter>
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

		public UIListFilterController(AbstractUILinker<ListComponentFilter> linker)
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