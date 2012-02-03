///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// Controladora base que provee de un patrón e infraestructura común a aquellos casos de uso
/// con vistas.
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
using System.Text;
using System.Diagnostics.Contracts;
using System.Reflection;
using System.Threading;

using Sifaw.Views;
using Sifaw.Core;


namespace Sifaw.Controllers
{
	/*
	 * Temas a considerar:
	 *  1. Gestionar pila de vistas activas. <=> ¿Controladora ppal?
	 *  
	 *  2. Mecanismo para asegurar que las vistas (UI Controls) se abren y cierran en el hilo
	 *     principal. Por si un subropceso lanza una UIViewController.
	 *      • Implementar un ViewDispatcher que proporciones servicios para administrar mensajes 
	 *        de las vistas en el proceso principal.
	 *        
	 *	3. ¿Como gestionar lo vistas modales, empotradas? 
	 *	   ¿Seguir el esquema de 3 niveles (1º ppal, 2º sub, 3º edición)?
	 *	    • En eKade ...
	 *	      If TopLevel 
	 *	         if Modal -> Cuadro de dialogo que no permite la interacción con otra vista
	 *	            Show(vistaActiva)
	 *	         else -> Si no es modal lo obligamos
	 *	            ShowDialog(vistaActiva)
	 *	      else -> No es un form de nivel superior
	 *	         Show(vistaActiva)
	 *	    • En Sifaw ...
	 */


	/// <summary>
	/// Controladora base que provee de un patrón e infraestructura común a aquellos casos de uso
	/// donde intervienen vistas.
	/// </summary>
	/// <remarks>
	/// <para>
	/// Un <see cref="UIViewController"/> implementa un caso de uso donde interviene
	/// una vista. La vistas solo deben de actuar a modo de contenedor de componentes <see cref="UIComponentController"/>
	/// </para>
	/// <para>
	/// Esto implica que un <see cref="UIViewController"/> actúa a modo de shell
	/// sobre uno o varios componentes <see cref="UIComponentController"/> que se comunican entre si para
	/// componer un caso de uso mas complejo.
	/// </para>
	/// </remarks>
	/// <typeparam name="TInput">Tipo para establecer los parámetros de inicio de la controladora.</typeparam>
	/// <typeparam name="TOutput">Tipo para establcer los parametros de retorno cuando finaliza la controladora.</typeparam>
	/// <typeparam name="TUISettings">Tipo para establecer el proxy encargado de establecer los ajustes al elemento de interfaz de usuario.</typeparam>
	/// <typeparam name="TView">Tipo de la vista del controlador.</typeparam>
	public abstract class UIViewController<TInput, TOutput, TUISettings, TView>
		: UIElementController<TInput, TOutput, TUISettings, TView>
		, IUIViewController
		where TInput      : UIViewController<TInput, TOutput, TUISettings, TView>.Input
		where TOutput     : UIViewController<TInput, TOutput, TUISettings, TView>.Output
		where TUISettings : UIViewController<TInput, TOutput, TUISettings, TView>.UISettingsContainer<TView>
						  , new()
		where TView       : UIView
	{
		#region Entrada / Salida

		/// <summary>
		/// Parámetros de entrada de la controladora.
		/// </summary>
		[Serializable]
		public new abstract class Input : UIElementController<TInput, TOutput, TUISettings, TView>.Input
		{
			#region Variables

			private bool _showView = true;

			#endregion

			#region Propiedades

			/// <summary>
			/// Devuelve un valor que indica si se ha de mostrar la vista
			/// al iniciar la controladora.
			/// </summary>
			public bool ShowView
			{
				get { return _showView; }
			}

			#endregion

			#region Constructor

			protected Input()
				: this(true)
			{
			}

			protected Input(bool showView)
				: base()
			{
				this._showView = showView;
			}

			#endregion
		}

		/// <summary>
		/// Parámetros de retorno de la controladora.
		/// </summary>
		[Serializable]
		public new abstract class Output : UIElementController<TInput, TOutput, TUISettings, TView>.Output
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
		public new class UISettingsContainer<TUI> : UIElementController<TInput, TOutput, TUISettings, TView>.UISettingsContainer<TUI>
			where TUI : TView
		{
			#region Variables

			private string _header;
			private double _width;
			private double _height;
			private bool _sizeToContent;

			#endregion

			#region Propiedades

			public string Header
			{
				get { return _header; }
				set { _header = value; }
			}

			public double Width
			{
				get { return _width; }
				set { _width = value; }
			}

			public double Height
			{
				get { return _height; }
				set { _height = value; }
			}

			public bool SizeToContent
			{
				get { return _sizeToContent; }
				set { _sizeToContent = value; }
			}

			#endregion

			#region Constructor

			public UISettingsContainer()
				: base()
			{
				this._header = "SifaWake Application";
				this._sizeToContent = false;
				this._width = -1.0f;
				this._height = -1.0f;
			}

			#endregion

			#region Métodos públicos

			public override void Apply()
			{
				base.Apply();

				this.UIElement.Header = Header;

				if (Width >= 0)
					this.UIElement.Width = Width;

				if (Height >= 0)
					this.UIElement.Height = Height;

				this.UIElement.SizeToContent = SizeToContent;
			}

			#endregion
		}

		#endregion

		#region Fields

		[CtrlReseteable(false)]
		private bool autoClosing = false;

		#endregion

		#region Eventos

		/*
		 * Desencadenadores protegidos virtuales sin manejadores asociados.
		 *  • Pueden ser sobreescritos por controladoras hijas para
		 *    completar funcionalidad.
		 */

		/// <summary>
		/// <para>
		/// Se llama al método <see cref="OnBeforeUIShow"/> justo antes de que la vista sea mostrada. 
		/// El método permite que las clases derivadas controlen el evento sin asociar un delegado.
		/// </para>
		/// </summary>
		/// <remarks>
		/// Al reemplazar <see cref="OnBeforeUIShow"/> en una clase derivada, asegúrese de llamar al
		/// método <see cref="OnBeforeUIShow"/> de la clase base para que los delegados registrados 
		/// reciban el evento si desea mantener el comportamiento por defecto.
		/// </remarks>
		protected virtual void OnBeforeUIShow()
		{
			/* Empty */
		}

		/// <summary>
		/// <para>
		/// Se llama al método <see cref="OnAfterUIShow"/> justo después de que la vista sea mostrada. 
		/// El método permite que las clases derivadas controlen el evento sin asociar un delegado.
		/// </para>
		/// </summary>
		/// <remarks>
		/// Al reemplazar <see cref="OnAfterUIShow"/> en una clase derivada, asegúrese de llamar al
		/// método <see cref="OnAfterUIShow"/> de la clase base para que los delegados registrados 
		/// reciban el evento si desea mantener el comportamiento por defecto.
		/// </remarks>
		protected virtual void OnAfterUIShow()
		{
			/* Empty */
		}

		/// <summary>
		/// <para>
		/// Se llama al método <see cref="OnBeforeUIClose"/> cuando el usuario solicita desde la
		/// interfaz de usuario finalizar la controladora. El método permite que las clases derivadas 
		/// controlen el evento sin asociar un delegado.
		/// </para>
		/// <para>
		/// El comportamiento por defecto no cancela la finalización de la controladora.
		/// </para>
		/// </summary>
		/// <remarks>
		/// Al reemplazar <see cref="OnBeforeUIClose"/> en una clase derivada, asegúrese de llamar al
		/// método <see cref="OnBeforeUIClose"/> de la clase base para que los delegados registrados 
		/// reciban el evento si desea mantener el comportamiento por defecto.
		/// </remarks>
		/// <param name="cancel">Valor que indica si la solicitud de finalización es cancelada.</param>
		protected virtual void OnBeforeUIClose(out bool cancel)
		{
			cancel = false;
		}

		/// <summary>
		/// <para>
		/// Se llama al método <see cref="OnAfterUIClose"/> justo después de que la vista sea cerrada. 
		/// El método permite que las clases derivadas controlen el evento sin asociar un delegado.
		/// </para>
		/// </summary>
		/// <remarks>
		/// Al reemplazar <see cref="OnAfterUIClose"/> en una clase derivada, asegúrese de llamar al
		/// método <see cref="OnAfterUIClose"/> de la clase base para que los delegados registrados 
		/// reciban el evento si desea mantener el comportamiento por defecto.
		/// </remarks>
		private void OnAfterUIClose()
		{
			/* Empty */
		}

		#endregion

		#region Constructor

		protected UIViewController()
			: base()
		{
		}

		protected UIViewController(AbstractUILinker<TView> linker)
			: base(linker)
		{
		}

		#endregion

		#region Métodos públicos

		/// <summary>
		/// Muestra la vista.
		/// 
		/// Para invocar este método la controladora ha de estar iniciada, 
		/// en otro caso, devolverá una excepcion.
		/// </summary>
		/// <exception cref="NotValidCtrlStateException">La controladora no está iniciada.</exception>
		public void Show()
		{
			CheckState(CtrlStates.Started);
			UISettings.Apply();
			UIElement.Show();
		}

		#endregion

		#region Métodos sobreescritos

		protected override void OnAfterUIElementLoad()
		{
			base.OnAfterUIElementLoad();

			/* Subscripción a eventos de la vista... */	
			UIElement.BeforeShow += new EventHandler(UIElement_BeforeShow);
			UIElement.AfterShow += new EventHandler(UIElement_AfterShow);
			UIElement.BeforeClose += new UIFinishRequestEventHandler(UIElement_BeforeClose);
			UIElement.AfterClose += new EventHandler(UIElement_AfterClose);
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

		protected override void OnAfterStartController()
		{
			base.OnAfterStartController();

			if (Parameters.ShowView)
			{
				UISettings.Apply();
				UIElement.Show();
			}
		}

		#endregion

		#region Gestión de finalización

		protected override void OnBeforeFinishControllers(List<IController> children)
		{
			base.OnBeforeFinishControllers(children);
			
			if (!autoClosing)
				UIElement.Close();
		}

		#endregion

		#region Gestión de eventos de la vista

		private void UIElement_BeforeShow(object sender, EventArgs e)
		{
			OnBeforeUIShow();
		}

		private void UIElement_AfterShow(object sender, EventArgs e)
		{
			OnAfterUIShow();
		}

		private void UIElement_BeforeClose(object sender, UIFinishRequestEventArgs e)
		{
			OnBeforeUIClose(out e.Cancel);

			if (!e.Cancel)
			{
				autoClosing = e.IsClosing;
				Finish();
			}
		}

		private void UIElement_AfterClose(object sender, EventArgs e)
		{
			OnAfterUIClose();
		}

		#endregion
		
		#region Gestión de eventos de componentes embebidos

		private void UIComponentController_ConfirmMessage(object sender, ConfirmMessageEventArgs e)
		{
			e.Confirmed = UIElement.ConfirmMessage(e.Value);			
		}

		private void UIComponentController_ShowMessage(object sender, StringEventArgs e)
		{
			UIElement.ShowMessage(e.Value);
		}

		private void UIComponentController_ShowWarning(object sender, StringEventArgs e)
		{
			UIElement.ShowWarning(e.Value);
		}

		private void UIComponentController_ShowError(object sender, ExceptionEventArgs e)
		{
			UIElement.ShowError(e.Exception.Message);
		}

		#endregion
	}
}