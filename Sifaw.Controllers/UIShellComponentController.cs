/*
 * Sifaw.Controllers
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 14/12/2011: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Views;


namespace Sifaw.Controllers
{
	/// <summary>
	/// Controladora base que provee de un patrón e infraestructura común a aquellas controladoras
    /// donde interviene un componente que actúa como shell, es decir, a modo de contenedor de componentes
    /// <see cref="UIComponentController{TInput, TOutput, TUISettings, TComponent}"/>.
	/// </summary>
    /// <typeparam name="TInput">
    /// Tipo para establecer los parámetros de inicio de la controladora. Ha de ser serializable y 
    /// derivar de <see cref="UIShellComponentController{TInput, TOutput, TUISettings, TGuest}.Input"/>.
    /// </typeparam>
    /// <typeparam name="TOutput">
    /// Tipo para establcer los parametros de retorno cuando finaliza la controladora. Ha de ser serializable y 
    /// derivar de <see cref="UIShellComponentController{TInput, TOutput, TUISettings, TGuest}.Output"/>.
    /// </typeparam>
    /// <typeparam name="TUISettings">
    /// Tipo para establecer el contenedor de ajustes encargado de establecer las configuración del elemento de interfaz de usuario. Ha de
    /// ser serializable, proveer de consturctor público y derivar de <see cref="UIShellComponentController{TInput, TOutput, TUISettings, TGuest}.UISettingsContainer"/>.
    /// </typeparam>
    /// <typeparam name="TGuest">
    /// Tipo de los componentes que puede alojar la shell. Ha de implementar <see cref="UIComponent"/>.
    /// </typeparam>
    public abstract class UIShellComponentController<TInput, TOutput, TUISettings, TGuest>
		: UIComponentController
		< TInput
		, TOutput
		, TUISettings
		, ShellComponent>
		where TInput      : UIShellComponentController<TInput, TOutput, TUISettings, TGuest>.Input
		where TOutput     : UIShellComponentController<TInput, TOutput, TUISettings, TGuest>.Output
		where TUISettings : UIShellComponentController<TInput, TOutput, TUISettings, TGuest>.UISettingsContainer
						  , new()
		where TGuest      : UIComponent
	{
		#region Input / Output

		/// <summary>
		/// Parámetros de entrada de las controladora.
		/// </summary>
		[Serializable]
		public abstract new class Input : UIComponentController<TInput, TOutput, TUISettings, ShellComponent>.Input
		{
            #region Constructor

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIShellComponentController{TInput, TOutput, TUISettings, TGuest}.Input"/>.
            /// </summary>
            protected Input()
            {
            }

            #endregion
		}

		/// <summary>
		/// Parámetros de retorno de la controladora.
		/// </summary>
		[Serializable]
		public abstract new class Output : UIComponentController<TInput, TOutput, TUISettings, ShellComponent>.Output
		{
            #region Constructor

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIShellComponentController{TInput, TOutput, TUISettings, TGuest}.Output"/>.
            /// </summary>
            protected Output()
            {
            }

            #endregion
		}

		#endregion

		#region Settings

        /// <summary>
        /// Contenedor de ajustes de <see cref="UIShellComponentController{TInput, TOutput, TUISettings, TGuest}"/>.
        /// </summary>
		[Serializable]
		public new class UISettingsContainer : UIComponentController
			< TInput
			, TOutput
			, TUISettings
			, ShellComponent>.UISettingsContainer
		{
			#region Constructors

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIShellComponentController{TInput, TOutput, TUISettings, TGuest}.UISettingsContainer"/>.
            /// </summary>
			public UISettingsContainer()
				: base()
			{
			}

			#endregion
		}

		#endregion

		#region Fields

        /// <summary>
        /// Lista de componetnes <see cref="Sifaw.Views.UIComponent"/> embebidos en la shell.
        /// </summary>
		[CLReseteable(null)]
		protected ReadOnlyCollection<TGuest> GuestComponentes = null;

		#endregion

		#region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UIShellComponentController{TInput, TOutput, TUISettings, TGuest}"/>.
        /// Establece como <see cref="AbstractUILinker{TUIElement}"/> aquel establecido por defecto a través de 
        /// <see cref="AbstractUIProviderManager{TLinker}"/>.
        /// </summary>
		protected UIShellComponentController()
			: base()
		{
		}

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UIShellComponentController{TInput, TOutput, TUISettings, TGuest}"/>, 
		/// estableciendo el <see cref="AbstractUILinker{TUIElement}"/> especificado como valor de la propiedad 
		/// <see cref="UIElementController{TInput, TOutput, TUISettings, TUIElement}.Linker"/> donde <c>TUIElement</c> 
		/// implementa <see cref="ShellComponent"/>.
        /// </summary>
        protected UIShellComponentController(AbstractUILinker<ShellComponent> linker)
			: base(linker)
		{
		}

		#endregion

		#region Abstract Methods

		/// <summary>
		/// Deuvelve el número de filas de la shell.
		/// </summary>		
		protected abstract uint GetNumberOfRows();

		/// <summary>
		/// Devuelve el número de celdas por fila de la shell.
		/// </summary>
		/// <param name="row">Fila.</param>
		/// <returns>Número de columnas.</returns>
		protected abstract uint GetNumberOfCellsAt(uint row);

		/// <summary>
		/// Devuelve la configuración de una fila de la shell.
		/// </summary>
		/// <param name="row">Fila</param>
		/// <param name="height">Aultura de la fila.</param>
        /// <param name="mode">Mode de ajuste de la fila.</param>
		protected abstract void GetRowSettings(uint row, out double height, out UILengthModes mode);

		/// <summary>
		/// Devuelve la configuracion de una celda de la shell.
		/// </summary>
		/// <param name="row">Fila de columna.</param>
		/// <param name="cell">Celda.</param>
		/// <param name="width">Ancho de la celda.</param>
        /// <param name="mode">Modo de ajuste de la celda.</param>
        /// <param name="guest">Contenido de la celda.</param>
		protected abstract void GetRowCellSettings(uint row, uint cell, out double width, out UILengthModes mode, out TGuest guest);

		#endregion

        #region UIElement Methods

        /// <summary>
		/// Invoca al método sobrescirto <see cref="UIElementController{TInput, TOutput, TUISettings, TUIElement}.OnApplyUISettings()"/> y
		/// posteriormente aplica la configuración al elemento <see cref="UIElementController{TInput, TOutput, TUISettings, TView}.UIElement"/> 
		/// del tipo <see cref="ShellComponent"/>
        /// </summary>
        protected override void OnApplyUISettings()
        {
            base.OnApplyUISettings();
        }

        #endregion

        #region Start Methods

        /// <summary>
		/// Invoca al método sobrescirto <see cref="Controller{TInput, TOutput}.OnBeforeStartController()"/> y
        /// posteriormente aplica la configuración de la shell, configuración como el número de filas, celdas por fila y componentes embebidos.
        /// </summary>
        protected override void OnBeforeStartController()
		{
			base.OnBeforeStartController();

			UIShellRow[] rows = ShellOperationsManager.GetSettings<TGuest>(
				  GetNumberOfRows
				, GetNumberOfCellsAt
				, GetRowSettings
				, GetRowCellSettings);

			List<TGuest> guests = new List<TGuest>();

			foreach (UIShellRow row in rows)
			{
				foreach (UIShellRowCell cell in row.Cells)
				{
					if (cell.Content != null)
						guests.Add((TGuest)cell.Content);
				}
			}

			GuestComponentes = guests.AsReadOnly();
			
			UIElement.SetSettings(rows);
		}

		#endregion
	}
}