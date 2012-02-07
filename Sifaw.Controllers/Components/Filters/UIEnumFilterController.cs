///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// Controladora que permite realizar filtros sobre una lista devolviendo solo uno item de la lista
/// original.
/// 
/// Diseñador: David López Rguez
/// Programador: David López Rguez
/// </sumary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 07/02/2012: Creación de controladora.
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
	/// filtro el item <see cref="IFilterable"/> seleccionado.
	/// </summary>
	/// <remarks>
	/// La controladora usa un componente que muestra toda la lista de filtro al usuario. 
	/// Si la lista de filtro tiene demasiados items es mejor usar un componente mas
	/// adecuado como <see cref="UIDropDownListFilterController"/>.
	/// </remarks>
	public class UIEnumFilterController : UIListFilterBaseController
		< IFilterable
		, IList<IFilterable>
		, UIEnumFilterController.UISettingsContainer
		, EnumComponentFilter>
	{
		#region Settings

		[Serializable]
		public class UISettingsContainer : UIListFilterBaseController
			< IFilterable
			, IList<IFilterable>
			, UISettingsContainer
			, EnumComponentFilter>.UISettingsContainer<EnumComponentFilter>
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

		public UIEnumFilterController(AbstractUILinker<EnumComponentFilter> linker)
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