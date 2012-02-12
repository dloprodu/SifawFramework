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
	/// donde interviene un componente tipo shell que actúa como contenedor de otros componentes.
	/// </summary>
	/// <typeparam name="TInput">Tipo para establecer los parámetros de inicio de la controladora.</typeparam>
	/// <typeparam name="TOutput">Tipo para establcer los parametros de retorno cuando finaliza la controladora.</typeparam>
	/// <typeparam name="TUISettings">Tipo para establecer el proxy encargado de establecer los ajustes al elemento de interfaz de usuario.</typeparam>
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
			#region Constructors

			protected Input()
				: base()
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
			#region Constructors

			protected Output()
				: base()
			{
			}

			#endregion
		}

		#endregion

		#region Settings

		[Serializable]
		public new class UISettingsContainer : UIComponentController
			< TInput
			, TOutput
			, TUISettings
			, ShellComponent>.UISettingsContainer
		{
			#region Constructors

			public UISettingsContainer()
				: base()
			{
			}

			#endregion
		}

		#endregion

		#region Fields

		[CLReseteable(null)]
		protected ReadOnlyCollection<TGuest> GuestComponentes = null;

		#endregion

		#region Constructors

		protected UIShellComponentController()
			: base()
		{
		}

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
		/// <param name="heighthMode">Mode de ajuste de la fila.</param>
		protected abstract void GetRowSettings(uint row, out double height, out UILengthModes mode);

		/// <summary>
		/// Devuelve la configuracion de una celda de la shell.
		/// </summary>
		/// <param name="row">Fila de columna.</param>
		/// <param name="cell">Celda.</param>
		/// <param name="width">Ancho de la celda.</param>
		/// <param name="widthMode">Modo de ajuste de la celda.</param>
		/// <param name="component">Contenido de la celda.</param>
		protected abstract void GetRowCellSettings(uint row, uint cell, out double width, out UILengthModes mode, out TGuest guest);

		#endregion

        #region UIElement Methods

        protected override void OnApplyUISettings()
        {
            base.OnApplyUISettings();
        }

        #endregion

        #region Start Methods

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