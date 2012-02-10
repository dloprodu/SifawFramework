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
	/// Controladora que permite realizar filtros sobre una lista de objetos <see cref="IFilterable"/>, 
	/// devolviendo como filtro una sublista de objetos seleccioandos.
	/// </summary>
	/// <remarks>
	/// <para>
	/// El componente muestra toda la lista de elementos <see cref="IFilterable"/> al usuario. 
	/// elegir uno o varios elementos de la lista.
	/// </para>
	/// </remarks>
	public class UIListFilterController : UIListFilterBaseController
		< IList<IFilterable>
		, IList<IFilterable>
		, UIListFilterController.UISettingsContainer
		, ListFilterComponent>
	{
		#region Settings

		[Serializable]
		public class UISettingsContainer : UIListFilterBaseController
			< IList<IFilterable>
			, IList<IFilterable>
			, UISettingsContainer
			, ListFilterComponent>.UISettingsContainer<ListFilterComponent>
		{
			#region Constructors

			public UISettingsContainer()
				: base()
			{
			}

			#endregion

			#region Public Methods

			public override void Apply()
			{
				base.Apply();
			}

			#endregion
		}

		#endregion

		#region Constructors

		public UIListFilterController()
			: base()
		{
		}

		public UIListFilterController(AbstractUILinker<ListFilterComponent> linker)
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