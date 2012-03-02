﻿/*
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

using Sifaw.Views;
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

		/// <summary>
		/// Contenedor de ajustes de <see cref="UIDropDownListFilterController"/>.
		/// </summary>
		[Serializable]
		public new class UISettingsContainer : UIListFilterBaseController
			< IFilterable
			, IList<IFilterable>
			, UISettingsContainer
			, DropDownListFilterComponent>.UISettingsContainer
		{
			#region Constructors

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UIDropDownListFilterController.UISettingsContainer"/>.
			/// </summary>
			public UISettingsContainer()
				: base()
			{
			}

			#endregion
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIDropDownListFilterController"/>.
		/// Establece como <see cref="AbstractUILinker{TUIElement}"/> aquel establecido por defecto a través de 
		/// <see cref="AbstractUIProviderManager{TLinker}"/>.
		/// </summary>
		public UIDropDownListFilterController()
			: base()
		{
		}

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIDropDownListFilterController"/>, 
		/// estableciendo el <see cref="AbstractUILinker{TUIElement}"/> como valor de la propiedad 
		/// <see cref="UIElementController{TInput, TOutput, TUIStyle, TUIElement}.Linker"/> donde <c>TUIElement</c>
		/// implementa <see cref="DropDownListFilterComponent"/>.
		/// </summary>
		public UIDropDownListFilterController(AbstractUILinker<DropDownListFilterComponent> linker)
			: base(linker)
		{
		}

		#endregion

		#region Default input / output

		/// <summary>
		/// Devuelve los parámetros de inicio por defecto.
		/// </summary>
		public override Input GetDefaultInput()
		{
			return new Input(null);
		}

		#endregion

        #region UIElement Methods

		/// <summary>
		/// Invoca al método sobrescirto <see cref="UIElementController{TInput, TOutput, TUIStyle, TComponent}.OnApplyUISettings()"/> y
		/// posteriormente aplica la configuración al elemento <see cref="UIElementController{TInput, TOutput, TUIStyle, TView}.UIElement"/> 
		/// del tipo <see cref="DropDownListFilterComponent"/>.
		/// </summary>
        protected override void OnApplyUISettings()
        {
            base.OnApplyUISettings();
        }

        #endregion

        #region Start Methods

		/// <summary>
		/// Ejecuta los comandos de inicio de la controladora.
		/// </summary>
		protected override void StartController()
		{
			/* Empty */
		}

		/// <summary>
		/// Ejecuta los comandos de reinicio de la controladora.
		/// </summary>
		protected override void ResetController()
		{
			/* Empty */
		}

		#endregion
	}
}