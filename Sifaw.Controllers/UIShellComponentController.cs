﻿/*
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
using Sifaw.Views.Kit;


namespace Sifaw.Controllers
{
	/// <summary>
	/// Controladora base que provee de un patrón e infraestructura común a aquellas controladoras
    /// donde interviene un componente que actúa como shell, es decir, a modo de contenedor de componentes
    /// <see cref="UIComponentController{TInput, TOutput, TComponent}"/>.
	/// </summary>
    /// <typeparam name="TInput">
    /// Tipo para establecer los parámetros de inicio de la controladora. Ha de ser serializable y 
    /// derivar de <see cref="UIShellComponentController{TInput, TOutput, TGuest}.Input"/>.
    /// </typeparam>
    /// <typeparam name="TOutput">
    /// Tipo para establcer los parametros de retorno cuando finaliza la controladora. Ha de ser serializable y 
    /// derivar de <see cref="UIShellComponentController{TInput, TOutput, TGuest}.Output"/>.
    /// </typeparam>
    /// <typeparam name="TGuest">
    /// Tipo de los componentes que puede alojar la shell. Ha de implementar <see cref="UIComponent"/>.
    /// </typeparam>
    public abstract class UIShellComponentController<TInput, TOutput, TGuest> : UIComponentController
		< TInput
		, TOutput
		, ShellComponent>
		where TInput  : UIShellComponentController<TInput, TOutput, TGuest>.Input
		where TOutput : UIShellComponentController<TInput, TOutput, TGuest>.Output
		where TGuest  : UIComponent
	{
		#region Input / Output

		/// <summary>
		/// Parámetros de entrada de las controladora.
		/// </summary>
		[Serializable]
		public abstract new class Input : UIComponentController<TInput, TOutput, ShellComponent>.Input
		{
            #region Constructor

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIShellComponentController{TInput, TOutput, TGuest}.Input"/>.
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
		public abstract new class Output : UIComponentController<TInput, TOutput, ShellComponent>.Output
		{
            #region Constructor

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIShellComponentController{TInput, TOutput, TGuest}.Output"/>.
            /// </summary>
            protected Output()
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
		protected ReadOnlyCollection<TGuest> Guests = null;

		#endregion

		#region Constructors

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UIShellComponentController{TInput, TOutput, TGuest}"/>.
        /// Establece como <see cref="UILinker{TUIElement}"/> aquel establecido por defecto a través de 
        /// <see cref="UILinkersManager"/>.
        /// </summary>
		protected UIShellComponentController()
			: base()
		{
		}

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UIShellComponentController{TInput, TOutput, TGuest}"/>, 
		/// estableciendo el <see cref="UILinker{TUIElement}"/> especificado como valor de la propiedad 
		/// <see cref="UIElementController{TInput, TOutput, TUIElement}.Linker"/> donde <c>TUIElement</c> 
		/// implementa <see cref="ShellComponent"/>.
        /// </summary>
        protected UIShellComponentController(UILinker<ShellComponent> linker)
			: base(linker)
		{
		}

		#endregion

        #region UIElement Methods

        /// <summary>
        /// Invoca al método sobrescirto <see cref="UIComponentController{TInput, TOutput, TComponent}.OnAfterUIElementCreate()"/> y
        /// posteriormente se subscribe a eventos de <see cref="UIView"/>.
        /// </summary>
        protected override void OnAfterUIElementCreate()
        {
            base.OnAfterUIElementCreate();

            /* Subscripción a eventos de la vista... */
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
		protected abstract void GetRowSettings(uint row, out double height, out UIShellLengthModes mode);

		/// <summary>
		/// Devuelve la configuracion de una celda de la shell.
		/// </summary>
		/// <param name="row">Fila de columna.</param>
		/// <param name="cell">Celda.</param>
		/// <param name="width">Ancho de la celda.</param>
        /// <param name="mode">Modo de ajuste de la celda.</param>
        /// <param name="guest">Contenido de la celda.</param>
		protected abstract void GetRowCellSettings(uint row, uint cell, out double width, out UIShellLengthModes mode, out TGuest guest);

		#endregion

        #region Start Methods

        /// <summary>
		/// Invoca al método sobrescirto <see cref="Controller{TInput, TOutput}.OnBeforeStartController()"/> y
        /// posteriormente aplica la configuración de la shell, configuración como el número de filas, celdas por fila y componentes embebidos.
        /// </summary>
        protected override void OnBeforeStartController()
		{
			base.OnBeforeStartController();

			UIShellRow[] rows = ShellOperationsManager.BuildLayout<TGuest>(
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
                    {
                        guests.Add((TGuest)cell.Content);

                        /* Default Settings... */
                        cell.Content.UISettings.HorizontalAlignment = UIHorizontalAlignment.Fill;
                        cell.Content.UISettings.VerticalAlignment = UIVerticalAlignment.Fill;
                        cell.Content.UISettings.Margin = UIFrame.Empty;
                    }
				}
			}

			Guests = guests.AsReadOnly();
			
			UIElement.SetLayout(rows);
		}

		#endregion
	}
}