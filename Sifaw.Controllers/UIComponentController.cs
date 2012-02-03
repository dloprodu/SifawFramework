///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// Controladora base que provee de un patrón e infraestructura común a aquellos casos de uso
/// que trabajan con componentes de interfaz de usuario.
/// 
/// Diseñador:     David López Rguez
/// Programadores: David López Rguez
/// </sumary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 20/12/2011: Creación de controladora.
/// 
/// ===============================================================================================
/// Observaciones:
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Views;
using Sifaw.Views.Components;
using Sifaw.Core;


namespace Sifaw.Controllers
{
	/// <summary>
	/// Controladora base que provee de un patrón e infraestructura común a aquellos casos de uso
	/// donde intervienen componentes de interfaz de usuario.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Un <see cref="UIComponentController<TInput, TOutput, TComponent>"/> implementa un caso de uso
	/// donde interviene un componente de UI. El componente de UI no puede mostrarse por si solo, en su lugar,
	/// ha de ser usado en un <see cref="UIViewController"/>.
	/// </para>
	/// </remarks>
	/// <typeparam name="TInput">Tipo para establecer los parámetros de inicio de la controladora.</typeparam>
	/// <typeparam name="TOutput">Tipo para establcer los parametros de retorno cuando finaliza la controladora.</typeparam>
	/// <typeparam name="TUISettings">Tipo para establecer el proxy encargado de establecer los ajustes al elemento de interfaz de usuario.</typeparam>
	/// <typeparam name="TComponent">Tipo del componente de UI del controlador.</typeparam>
	public abstract class UIComponentController<TInput, TOutput, TUISettings, TComponent>
		: UIElementController<TInput, TOutput, TUISettings, TComponent>
		, IUIComponentController
		where TInput      : UIComponentController<TInput, TOutput, TUISettings, TComponent>.Input
		where TOutput     : UIComponentController<TInput, TOutput, TUISettings, TComponent>.Output
		where TUISettings : UIComponentController<TInput, TOutput, TUISettings, TComponent>.UISettingsContainer<TComponent>
						  , new()
		where TComponent  : UIComponent
	{
		#region Entrada / Salida

		/// <summary>
		/// Parámetros de entrada de las controladoras
		/// </summary>
		[Serializable]
		public new abstract class Input : UIElementController<TInput, TOutput, TUISettings, TComponent>.Input
		{
			#region Constructor

			protected Input()
				: base()
			{
			}

			#endregion
		}

		/// <summary>
		/// Parámetros de retorno de las controladoras
		/// </summary>
		[Serializable]
		public new abstract class Output : UIElementController<TInput, TOutput, TUISettings, TComponent>.Output
		{
			#region Constructor

			protected Output()
				: base()
			{
			}

			#endregion
		}

		#endregion

		#region Settings

		[Serializable]
		public new class UISettingsContainer<TUI> : UIElementController<TInput, TOutput, TUISettings, TComponent>.UISettingsContainer<TUI>
			where TUI : TComponent
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

		#region Eventos

		/*
		 * Desencadenadores privados.
		 *  • Solo son lanzados por la controladora padre.
		 */

		/* Empty */

		/*
		 * Desencadenadores protegidos.
		 *  • Pueden ser lanzados por controladoras hijas.
		 */

		/// <summary>
		/// Evento para comunicar un error producido por excepción.
		/// </summary>
		public event ExceptionEventHandler ShowError;
		protected void OnShowError(ExceptionEventArgs e)
		{
			if (ShowError != null)
				ShowError(this, e);
		}

		/// <summary>
		/// Evento para comunicar que se debe mostrar una advertencia.
		/// </summary>
		public event StringEventHandler ShowWarning;
		protected void OnShowWarning(StringEventArgs e)
		{
			if (ShowWarning != null)
				ShowWarning(this, e);
		}

		/// <summary>
		/// Evento para comunicar que se debe mostrar un mensaje.
		/// </summary>
		public event StringEventHandler ShowMessage;
		protected void OnShowMessage(StringEventArgs e)
		{
			if (ShowMessage != null)
				ShowMessage(this, e);
		}

		/// <summary>
		/// Evento para solicitar una confirmación para un mensaje dado.
		/// </summary>
		public event ConfirmMessageEventHandler ConfirmMessage;
		protected void OnConfirmMessage(ConfirmMessageEventArgs e)
		{
			if (ConfirmMessage != null)
				ConfirmMessage(this, e);
		}

		/*
		 * Desencadenadores protegidos virtuales sin manejadores asociados.
		 *  • Pueden ser sobreescritos por controladoras hijas para
		 *    completar funcionalidad.
		 */

		/* Empty */

		#endregion

		#region Constructor

		protected UIComponentController()
			: base()
		{
		}

		protected UIComponentController(AbstractUILinker<TComponent> linker)
			: base(linker)
		{
		}

		#endregion

		#region Métodos públicos

		public UIComponent GetUIComponent()
		{
			return UIElement as UIComponent;
		}

		#endregion

		#region Métodos sobreescritos

		protected override void OnAfterUIElementLoad()
		{
			base.OnAfterUIElementLoad();
			
			/* Subscripción a eventos del componente... */			
		}

		protected override void OnBeforeStartController()
		{
			base.OnBeforeStartController();

			// Nos enganchamos a eventos de la controladoras hijas para propagarlos.
			// • Los eventos ShowMessage, ShowWarning, ShowError y ConfirmMessage han de ser propagados hasta que sean
			//   capturados por una controladora UIViewController que los gestione.
			foreach (IController controller in GetControllers())
			{
				if (controller is IUIComponentController)
				{
					(controller as IUIComponentController).ShowMessage += new StringEventHandler(UIComponentController_ShowMessage);
					(controller as IUIComponentController).ShowWarning += new StringEventHandler(UIComponentController_ShowWarning);
					(controller as IUIComponentController).ShowError += new ExceptionEventHandler(UIComponentController_ShowError);
					(controller as IUIComponentController).ConfirmMessage += new ConfirmMessageEventHandler(UIComponentController_ConfirmMessage);
				}
			}
		}

		#endregion

		#region Gestión de eventos de componentes embebidos

		private void UIComponentController_ConfirmMessage(object sender, ConfirmMessageEventArgs e)
		{
			OnConfirmMessage(e);
		}

		private void UIComponentController_ShowMessage(object sender, StringEventArgs e)
		{
			OnShowMessage(e);
		}

		private void UIComponentController_ShowWarning(object sender, StringEventArgs e)
		{
			OnShowWarning(e);
		}

		private void UIComponentController_ShowError(object sender, ExceptionEventArgs e)
		{
			OnShowError(e);
		}

		#endregion
	}
}