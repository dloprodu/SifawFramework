/*
 * Sifaw.Controllers.Components
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
using System.Text;
using System.Collections;
using System.IO;

using Sifaw.Views;
using Sifaw.Views.Components;


namespace Sifaw.Controllers.Components
{
	/// <summary>
	/// Controladora encargada de presentar una serie de componentes <see cref="Sifaw.Views.UIComponent"/> de forma secuencial 
    /// a modo de asistente.
	/// </summary>
    /// <typeparam name="TInput">
    /// Tipo para establecer los parámetros de inicio de la controladora. Ha de ser serializable y 
    /// derivar de <see cref="UIAssistantController{TInput, TOutput}.Input"/>.
    /// </typeparam>
    /// <typeparam name="TOutput">
    /// Tipo para establcer los parametros de retorno cuando finaliza la controladora. Ha de ser serializable y 
    /// derivar de <see cref="UIAssistantController{TInput, TOutput}.Output"/>.
    /// </typeparam>
    public abstract class UIAssistantController<TInput, TOutput> : UIComponentController
		< TInput
		, TOutput
		, UIAssistantController<TInput, TOutput>.UISettingsContainer
		, AssistantComponent>
		where TInput  : UIAssistantController<TInput, TOutput>.Input
		where TOutput : UIAssistantController<TInput, TOutput>.Output
	{
		#region Input / Output

        /// <summary>
        /// Parámetros de entrada de las controladora.
        /// </summary>
		[Serializable]
		public new abstract class Input : UIComponentController
			< TInput
			, TOutput
			, UISettingsContainer
			, AssistantComponent>.Input
		{
			#region Constructors

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIAssistantController{TInput, TOutput}.Input"/>.
            /// </summary>
			public Input()
				: base()
			{
			}

			#endregion
		}

        /// <summary>
        /// Parámetros de retorno de las controladora.
        /// </summary>
		[Serializable]
		public new abstract class Output : UIComponentController
			< TInput
			, TOutput
			, UISettingsContainer
			, AssistantComponent>.Output
		{
			#region Fields

			private bool _cancelled;

			#endregion

			#region Properties

			/// <summary>
			/// Obtiene un valor que indica si el proceso fue cancelado.
			/// </summary>
			public bool Cancelled
			{
				get { return _cancelled; }
				internal set { _cancelled = value; }
			}

			#endregion

			#region Constructors

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIAssistantController{TInput, TOutput}.Output"/>.
            /// </summary>
			public Output()
				: base()
			{
			}

			#endregion
		}

		#endregion

		#region Settings

        /// <summary>
        /// Contenedor de ajustes de <see cref="UIAssistantController{TInput, TOutput}"/>.
        /// </summary>
		[Serializable]
		public new class UISettingsContainer : UIComponentController
			< TInput
			, TOutput
			, UISettingsContainer
			, AssistantComponent>.UISettingsContainer
		{
			#region Constructors

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIAssistantController{TInput, TOutput}.UISettingsContainer"/>.
            /// </summary>
			public UISettingsContainer()
				: base()
			{
			}

			#endregion
		}	
		
		#endregion

		#region Fields

		[CLReseteable(null)]
		private Stack<UIComponent> _stack = null;

		#endregion

		#region Events

		/*
		 * Desencadenadores protegidos virtuales sin manejadores asociados.
		 *  • Pueden ser sobreescritos por controladoras hijas para
		 *    completar funcionalidad.
		 */

		/// <summary>
		/// <para>
		/// Se llama al método <see cref="OnBeforeUpdateUIAssistant"/> antes de actualizar el assistente 
		/// para mostrar el componente que corresponde. El método permite que las clases derivadas 
		/// controlen el evento sin asociar un delegado.
		/// </para>
		/// <para>
		/// El comportamiento por defecto permite cancelar la operación o dirigirse a una etapa anterior.
		/// </para>
		/// </summary>
		/// <remarks>
		/// Al reemplazar <see cref="OnBeforeUpdateUIAssistant"/> en una clase derivada, asegúrese de llamar al
		/// método <see cref="OnBeforeUpdateUIAssistant"/> de la clase base para que los delegados registrados 
		/// reciban el evento si desea mantener el comportamiento por defecto.
		/// </remarks>
		/// <param name="current">Componente que se va a mostrar en la etapa actual.</param>
        /// <param name="allowCancel">Valor que indica si la etapa actual permite la cancelación.</param>
		/// <param name="allowPrevious">Valor que indica si la etapa actual permite el retroceso a la anterior.</param>
		protected virtual void OnBeforeUpdateUIAssistant(UIComponent current, out bool allowCancel, out bool allowPrevious)
		{
			allowCancel = true;
			allowPrevious = true;
		}

		/// <summary>
		/// <para>
		/// Se llama al método <see cref="OnAfterUpdateUIAssistant"/> después de actualizar el assistente 
		/// para mostrar el componente que corresponde. El método permite que las clases derivadas 
		/// controlen el evento sin asociar un delegado.
		/// </para>
		/// </summary>
		/// <remarks>
		/// Al reemplazar <see cref="OnAfterUpdateUIAssistant"/> en una clase derivada, asegúrese de llamar al
		/// método <see cref="OnAfterUpdateUIAssistant"/> de la clase base para que los delegados registrados 
		/// reciban el evento si desea mantener el comportamiento por defecto.
		/// </remarks>
		protected virtual void OnAfterUpdateUIAssistant()
		{
			/* Empty */
		}

		#endregion

		#region Properties

		private Stack<UIComponent> StackComponents
		{
			get
			{
				if (_stack == null)
					_stack = new Stack<UIComponent>();

				return _stack;
			}
		}

		#endregion

		#region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UIAssistantController{TInput, TOutput}"/>.
        /// Establece como <see cref="AbstractUILinker{TUIElement}"/> aquel establecido por defecto a través de 
        /// <see cref="AbstractUIProviderManager{TLinker}"/>.
        /// </summary>
		protected UIAssistantController()
			: base()
		{
		}

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UIAssistantController{TInput, TOutput}"/>, 
        /// estableciendo un valor en la propiedad <see cref="Sifaw.Controllers.UIElementController{TInput, TOutput, TUISettings, TUIElement}.Linker"/>.
        /// </summary>
		protected UIAssistantController(AbstractUILinker<AssistantComponent> linker)
			: base(linker)
		{
		}

		#endregion

		#region UIElement Methods

        /// <summary>
        /// Invoca al método sobrescirto <see cref="UIComponentController{TInput, TOutput, TUISettings, TComponent}.OnAfterUIElementLoad()"/>  y
        /// posteriormente se subscribe a eventos de <see cref="AssistantComponent"/>.
        /// </summary>
		protected override void OnAfterUIElementLoad()
		{
			base.OnAfterUIElementLoad();

			/* Subscripción a eventos del componente... */			
			UIElement.Cancel += new EventHandler(UIElement_Cancel);
			UIElement.Accept += new EventHandler(UIElement_Accept);
			UIElement.Previous += new EventHandler(UIElement_Previous);
			UIElement.Next += new EventHandler(UIElement_Next);
		}

        /// <summary>
        /// Invoca al método sobrescirto <see cref="UIComponentController{TInput, TOutput, TUISettings, TComponent}.OnApplyUISettings()"/>.
        /// </summary>
        protected override void OnApplyUISettings()
        {
            base.OnApplyUISettings();
        }

		#endregion

		#region Helpers

		private void UpdateAssistant()
		{
			bool allowCancel = true;
			bool allowPrevious = true;

			OnBeforeUpdateUIAssistant(StackComponents.Peek(), out allowCancel, out allowPrevious);
			
			UIElement.SetCurrentUIComponent(StackComponents.Peek(), (byte)StackComponents.Count);
			UIElement.NextEnabled = StackComponents.Count < GetNumberOfComponents();
			UIElement.PreviousEnabled = allowPrevious && StackComponents.Count > 1;
			UIElement.AcceptEnabled = StackComponents.Count == GetNumberOfComponents();
			UIElement.CancelEnabled = allowCancel;

			OnAfterUpdateUIAssistant();
		}

		#endregion

		#region Abstract Methods

		/// <summary>		
		/// Devuelve el número total de componentes que presentará el asistente al usuario.
		/// </summary>
		protected abstract byte GetNumberOfComponents();

		/// <summary>
		/// Devuelve el componente inicial de la que parte el asistente.
		/// </summary>
		protected abstract UIComponent GetStartComponent();

		/// <summary>
		/// Devuelve el siguiente componente a mostrar en el asistente.
		/// </summary>
        /// <param name="current">Vista que actualmente esta mostrando el asistente.</param>
		protected abstract UIComponent GetNextComponent(UIComponent current);

		/// <summary>
		/// Se encarga de ejecutar las operaciones necesarias al aceptar al finalizar el asistente.
		/// </summary>
		/// <param name="current">Componente que actualmente está mostrando el asistente.</param>
		/// <param name="finish">
		/// Si es true se finaliza la controladora completando la operación de cancelar, 
		/// en otro caso, no se finaliza la controladora.
		/// </param>
		/// <param name="output">Parámetros de salida.</param>
		protected abstract void OnBeforeCancel(UIComponent current, out bool finish, out TOutput output);

		/// <summary>
		/// Se encarga de ejecutar las operaciones necesarias al cancelar el asistente.
		/// </summary>
		/// <param name="current">Componente que actualmente está mostrando el asistente.</param>
		/// <param name="finish">
		/// Si es true se finaliza la controladora completando la operación de aceptar, 
		/// en otro caso, no se finaliza la controladora.
		/// </param>
		/// <param name="output">Parámetros de salida.</param>
		protected abstract void OnBeforeAccept(UIComponent current, out bool finish, out TOutput output);

		#endregion

		#region Check Preconditions

		/// <summary>
		/// Para chequear las precondiciones de la controladora del caso de uso
		/// </summary>
		/// <param name="preconditionName">Precondición a chequear. Cadena vacia si se quieren chequear todas la precondiciones.</param>
		protected override void OnCheckPreconditions(string preconditionName)
		{
			base.OnCheckPreconditions(preconditionName);
		}

		#endregion

		#region Start Methods

        /// <summary>
        /// Invoca al método sobrescirto <see cref="UIElementController{TInput, TOutput, TUISettings, TUIElement}.OnAfterStartController()"/> y
        /// posteriormente establece la configuración inicial del asistente.
        /// </summary>
		protected override void OnAfterStartController()
		{
            base.OnAfterStartController();

			UIElement.NumComponents = GetNumberOfComponents();
			StackComponents.Push(GetStartComponent());
			UpdateAssistant();
		}

        /// <summary>
        /// Devuelve un valor que indica que no se permite reiniciar un asistente.
        /// </summary>
		protected sealed override bool AllowReset()
		{
			return false;
		}

        /// <summary>
        /// No realiza ninguna operación puesto que la controladora no permite el reinicio.
        /// </summary>
		protected sealed override void ResetController()
		{
			/* Nada */
		}

		#endregion

		#region UIElement Events Handlers

		private void UIElement_Accept(object sender, EventArgs e)
		{
			bool finish = true;

			TOutput output = null;

			OnBeforeAccept(StackComponents.Peek(), out finish, out output);

			output.Cancelled = false;

			if (finish)
				FinishController(output);
		}

		private void UIElement_Cancel(object sender, EventArgs e)
		{
			bool finish = true;

			TOutput output = null;

			OnBeforeCancel(StackComponents.Peek(), out finish, out output);

			output.Cancelled = finish;

			if (finish)
				FinishController(output);
		}

		private void UIElement_Next(object sender, EventArgs e)
		{
			UIComponent next = GetNextComponent(StackComponents.Peek());

			if (next != null)
			{
				StackComponents.Push(next);
				UpdateAssistant();
			}

			// Si no se devuelve una vista (null) y tampoco un mensaje el asistente permanece en la vista actual.
		}

		private void UIElement_Previous(object sender, EventArgs e)
		{
			if (StackComponents.Count > 1)
			{
				StackComponents.Pop();
				UpdateAssistant();
			}
		}

		#endregion
	}
}