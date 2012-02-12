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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Views.Components;
using Sifaw.Views.Components.Filters;


namespace Sifaw.Controllers.Components.Filters
{
	/// <summary>
	/// Controladora que permite realizar filtros sobre una lista de objetos <see cref="IFilterable"/>, 
	/// devolviendo como filtro el item seleccionado.
	/// </summary>
	/// <remarks>
	/// <para>
	/// El componente muestra el elemento <see cref="IFilterable"/> seleccionado pudiendo 
	/// desplegar la lista y cambiar la selección.
	/// </para>
	/// </remarks>
	public class UIDropDownListFilterController : UIListFilterBaseController
		< IFilterable
		, IList<IFilterable>
		, UIDropDownListFilterController.UISettingsContainer
		, DropDownListFilterComponent>
	{
		#region Settings

		[Serializable]
		public new class UISettingsContainer : UIListFilterBaseController
			< IFilterable
			, IList<IFilterable>
			, UISettingsContainer
			, DropDownListFilterComponent>.UISettingsContainer
		{
			#region Constructors

			public UISettingsContainer()
				: base()
			{
			}

			#endregion
		}

		#endregion

		#region Constructors

		public UIDropDownListFilterController()
			: base()
		{
		}

		public UIDropDownListFilterController(AbstractUILinker<DropDownListFilterComponent> linker)
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

        #region UIElement Methods

        protected override void OnApplyUISettings()
        {
            base.OnApplyUISettings();
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