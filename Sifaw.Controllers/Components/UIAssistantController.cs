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
	/// Controladora base encargada de administrar un conjunto relacionado de 
	/// componentes de interfaz <see cref="Sifaw.Views.UIComponent"/> que comparten entre ellos
	/// el mismo espacio en pantalla pudiendo el usuario visualizarlos de forma secuencial a 
	/// modo de asistente.
	/// </summary>
    /// <typeparam name="TInput">
    /// Tipo para establecer los parámetros de inicio de la controladora. Ha de ser serializable y 
    /// derivar de <see cref="UIAssistantController{TInput, TOutput, TGuest}.Input"/>.
    /// </typeparam>
    /// <typeparam name="TOutput">
    /// Tipo para establcer los parametros de retorno cuando finaliza la controladora. Ha de ser serializable y 
    /// derivar de <see cref="UIAssistantController{TInput, TOutput, TGuest}.Output"/>.
    /// </typeparam>
	/// <typeparam name="TGuest">
	/// Tipo de los componentes que puede alojar el asistente. Ha de implementar <see cref="UIComponent"/>.
	/// </typeparam>
	public abstract class UIAssistantController<TInput, TOutput, TGuest> : UIActorController
		< TInput
		, TOutput
		, AssistantComponent
		, TGuest>
		where TInput  : UIAssistantController<TInput, TOutput, TGuest>.Input
		where TOutput : UIAssistantController<TInput, TOutput, TGuest>.Output
		where TGuest  : UIComponent
	{
		#region Input / Output

        /// <summary>
        /// Parámetros de entrada de las controladora.
        /// </summary>
		[Serializable]
		public new abstract class Input : UIActorController
			< TInput
			, TOutput
			, AssistantComponent
			, TGuest>.Input
		{
			#region Constructors

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIAssistantController{TInput, TOutput, TGuest}.Input"/>.
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
		public new abstract class Output : UIActorController
			< TInput
			, TOutput
			, AssistantComponent
			, TGuest>.Output
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
            /// Inicializa una nueva instancia de la clase <see cref="UIAssistantController{TInput, TOutput, TGuest}.Output"/>.
            /// </summary>
			public Output()
				: base()
			{
			}

			#endregion
		}

		#endregion

		#region Events

		/*
		 * Desencadenadores privados.
		 *  • Solo son lanzados por la controladora padre.
		 */

		/* Empty */

		/*
		 * Desencadenadores protegidos.
		 *  • Pueden ser lanzados por controladoras hijas.
		 */

		/* Empty */

		/*
		 * Desencadenadores protegidos virtuales sin manejadores asociados.
		 *  • Pueden ser sobreescritos por controladoras hijas para
		 *    completar funcionalidad.
		 */

		/// <summary>
		/// <para>
		/// Se llama al método <see cref="OnBeforeUpdateAssistant"/> antes de actualizar el assistente 
		/// para mostrar el componente que corresponde. El método permite que las clases derivadas 
		/// controlen el evento sin asociar un delegado.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Este método no dispone de su equivalente <c>OnAfterUpdateAssistant</c>, en su lugar, usar
		/// <see cref="UIActorController{TInput, TOutput, TComponent, TGuest}.OnAfterUpdateGuest"/>.
		/// </para>
		/// </remarks>		
		/// <param name="allowCancel">Valor que indica si la etapa actual permite la cancelación.</param>
		/// <param name="allowPrevious">Valor que indica si la etapa actual permite el retroceso a la anterior.</param>
		protected abstract void OnBeforeUpdateAssistant(out bool allowCancel, out bool allowPrevious);

		/// <summary>
		/// <para>
		/// Se llama al métodos <see cref="OnBeforeCancel"/> antes de cancelar la operación realizada
		/// por el asistente. El método permite que las clases derivadas realicen las operaciones necesarias
		/// cuando se produce el evento.
		/// </para>
		/// </summary>
		/// <remarks>
		/// <para>
		/// Este método no dispone de su equivalente <c>OnAfterCancel</c>, puesto que la controladora
		/// es finalizada al cancelar la operación realizada por el assistente.
		/// </para>
		/// </remarks>		
		/// <param name="finish">
		/// Si es true se finaliza la controladora completando la operación de cancelar, 
		/// en otro caso, no se finaliza la controladora.
		/// </param>
		/// <param name="output">Parámetros de salida.</param>
		protected abstract void OnBeforeCancel(out bool finish, out TOutput output);

		/// <summary>
		/// <para>
		/// Se llama al métodos <see cref="OnBeforeAccept"/> antes de aceptar la operación realizada
		/// por el asistente. El método permite que las clases derivadas realicen las operaciones necesarias
		/// cuando se produce el evento.
		/// </para>		
		/// </summary>
		/// <remarks>
		/// <para>
		/// Este método no dispone de su equivalente <c>OnAfterAccept</c>, puesto que la controladora
		/// es finalizada al aceptar la operación realizada por el asistente.
		/// </para>
		/// </remarks>	
		/// <param name="finish">
		/// Si es true se finaliza la controladora completando la operación de aceptar, 
		/// en otro caso, no se finaliza la controladora.
		/// </param>
		/// <param name="output">Parámetros de salida.</param>
		protected abstract void OnBeforeAccept(out bool finish, out TOutput output);

		#endregion

		#region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UIAssistantController{TInput, TOutput, TGuest}"/>.
        /// Establece como <see cref="UILinker{TUIElement}"/> aquel establecido por defecto a través de 
        /// <see cref="UILinkersManager{TLinker}"/>.
        /// </summary>
		protected UIAssistantController()
			: base()
		{
		}

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UIAssistantController{TInput, TOutput, TGuest}"/>, 
		/// estableciendo el <see cref="UILinker{TUIElement}"/> establecido como valor de la propiedad 
		/// <see cref="UIElementController{TInput, TOutput, TUIElement}.Linker"/> donde <c>TUIElement</c>
		/// implementa <see cref="AssistantComponent"/>.
        /// </summary>
		protected UIAssistantController(UILinker<AssistantComponent> linker)
			: base(linker)
		{
		}

		#endregion

		#region Helpers

		private void UpdateAssistant()
		{
			bool allowCancel = true;
			bool allowPrevious = true;

			OnBeforeUpdateAssistant(out allowCancel, out allowPrevious);

			UIElement.NextEnabled = Key < Descriptors.Length - 1;
			UIElement.PreviousEnabled = allowPrevious && Key > 0;
			UIElement.AcceptEnabled = Key == Descriptors.Length - 1;
			UIElement.CancelEnabled = allowCancel;
		}

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

		#region UIElement Methods

		/// <summary>
		/// Invoca al método sobrescirto <see cref="UIComponentController{TInput, TOutput, TComponent}.OnAfterUIElementLoad()"/>  y
		/// posteriormente se subscribe a eventos de <see cref="AssistantComponent"/>.
		/// </summary>
		protected override void OnAfterUIElementLoad()
		{
			base.OnAfterUIElementLoad();

			/* Subscripción a eventos del componente... */
			UIElement.Cancel += new EventHandler(UIElement_Cancel);
			UIElement.Accept += new EventHandler(UIElement_Accept);
		}

		#endregion

		#region UIActor Methods

		/// <summary>
		/// Invoca al método sobrescirto <see cref="UIActorController{TInput, TOutput, TComponent, TGuest}.OnAfterUpdateGuest()"/>  y
		/// posteriormente actualiza el asistente.
		/// </summary>
		protected override void OnAfterUpdateGuest()
		{
			base.OnAfterUpdateGuest();

			UpdateAssistant();
		}

		#endregion

		#region Start Methods

		/// <summary>
        /// Invoca al método sobrescirto <see cref="Controller{TInput, TOutput}.OnAfterStartController()"/> y
        /// posteriormente establece la configuración inicial del asistente.
        /// </summary>
		protected override void OnAfterStartController()
		{
            base.OnAfterStartController();

			UpdateAssistant();
		}

        /// <summary>
        /// Devuelve un valor que indica que, por defecto, no se permite reiniciar un asistente.
        /// </summary>
		protected override bool AllowReset()
		{
			return false;
		}

        /// <summary>
        /// No realiza ninguna operación puesto que, por defecto, la controladora no permite el reinicio.
        /// </summary>
		protected override void ResetController()
		{
			/* Nada */
		}

		#endregion

		#region UIElement Events Handlers

		private void UIElement_Accept(object sender, EventArgs e)
		{
			bool finish = true;

			TOutput output = null;

			OnBeforeAccept(out finish, out output);

			output.Cancelled = false;

			if (finish)
				FinishController(output);
		}

		private void UIElement_Cancel(object sender, EventArgs e)
		{
			bool finish = true;

			TOutput output = null;

			OnBeforeCancel(out finish, out output);

			output.Cancelled = finish;

			if (finish)
				FinishController(output);
		}

		#endregion
	}
}