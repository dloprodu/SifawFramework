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
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Views;
using Sifaw.Views.Components;
using Sifaw.Views.Components.Filters;


namespace Sifaw.Controllers.Components.Filters
{
	/// <summary>
	/// Controladora que por medio del componente de interfaz de usuario <see cref="BoolFilterComponent"/>
	/// permite realizar filtros sobre un campo booleanos, devolviendo como filtro <c>true</c> o <c>false</c>.
	/// </summary>
	public class UIBoolFilterController : UIFilterBaseController
		< bool
		, UIBoolFilterController.UISettingsContainer
		, BoolFilterComponent>
	{
		#region Settings

		/// <summary>
		/// Contenedor de ajustes de <see cref="UIBoolFilterController"/>.
		/// </summary>
		[Serializable]
		public new class UISettingsContainer : UIFilterBaseController
			< bool
			, UISettingsContainer
			, BoolFilterComponent>.UISettingsContainer
		{
			#region Fields

			private string _text;

			#endregion

			#region Properties

			/// <summary>
			/// Obtiene o establece el texto que se muestra como descripción del filtro booleano.
			/// </summary>
			public string Text
			{
				get { return _text; }
				set { _text = value; }
			}

			#endregion

			#region Constructors

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UIBoolFilterController.UISettingsContainer"/>,
			/// estableciendo la propiedad <see cref="Text"/> a <c>string.Empty</c>.
			/// </summary>
			public UISettingsContainer()
				: this(string.Empty)
			{
			}

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UIBoolFilterController.UISettingsContainer"/>,
			/// estableciendo un valor a la propiedad <see cref="Text"/>.
			/// </summary>
			public UISettingsContainer(string text)
				: base()
			{
				this._text = text;
			}

			#endregion
		}

		#endregion

		#region Constructors

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIBoolFilterController"/>.
		/// Establece como <see cref="AbstractUILinker{TUIElement}"/> aquel establecido por defecto a través de 
		/// <see cref="AbstractUIProviderManager{TLinker}"/>.
		/// </summary>
		public UIBoolFilterController()
			: base()
		{
		}

		/// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="UIBoolFilterController"/>, 
		/// estableciendo el <see cref="AbstractUILinker{TUIElement}"/> como valor de la propiedad 
		/// <see cref="UIElementController{TInput, TOutput, TUIStyle, TUIElement}.Linker"/> donde <c>TUIElement</c>
		/// implementa <see cref="BoolFilterComponent"/>.
		/// </summary>
		public UIBoolFilterController(AbstractUILinker<BoolFilterComponent> linker)
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
			return new Input(false);
		}

		#endregion

        #region UIElement Methods

		/// <summary>
		/// Invoca al método sobrescirto <see cref="UIElementController{TInput, TOutput, TUIStyle, TComponent}.OnApplyUISettings()"/> y
		/// posteriormente aplica la configuración al elemento <see cref="UIElementController{TInput, TOutput, TUIStyle, TView}.UIElement"/> 
		/// del tipo <see cref="BoolFilterComponent"/>.
		/// </summary>
        protected override void OnApplyUISettings()
        {
            base.OnApplyUISettings();

            UIElement.Text = UISettings.Text;
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