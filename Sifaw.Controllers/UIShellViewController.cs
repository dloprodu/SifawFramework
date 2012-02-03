///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// Controladora base que provee de un patrón e infraestructura común a aquellos casos de uso
/// con vistas tipo shell.
/// 
/// Diseñador:     David López Rguez
/// Programadores: David López Rguez
/// </sumary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 09/01/2012: Creación de controladora.
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


namespace Sifaw.Controllers
{
	/// <summary>
	/// Controladora base que provee de un patrón e infraestructura común a aquellos casos de uso
	/// donde intervienen vistas tipo shell que actuan como contenedores de componentes.
	/// </summary>
	/// <typeparam name="TInput">Tipo para establecer los parámetros de inicio de la controladora.</typeparam>
	/// <typeparam name="TOutput">Tipo para establcer los parametros de retorno cuando finaliza la controladora.</typeparam>
	/// <typeparam name="TUISettings">Tipo para establecer el proxy encargado de establecer los ajustes al elemento de interfaz de usuario.</typeparam>
	public abstract class UIShellViewController<TInput, TOutput, TUISettings>
		: UIViewController
		< TInput
		, TOutput
		, TUISettings
		, UIShellView>
		where TInput      : UIShellViewController<TInput, TOutput, TUISettings>.Input
		where TOutput     : UIShellViewController<TInput, TOutput, TUISettings>.Output
		where TUISettings : UIShellViewController<TInput, TOutput, TUISettings>.UISettingsContainer<UIShellView>, new()
	{
		#region Entrada / Salida

		/// <summary>
		/// Parámetros de entrada de las controladora.
		/// </summary>
		[Serializable]
		public abstract new class Input : UIViewController<TInput, TOutput, TUISettings, UIShellView>.Input
		{
			#region Constructor

			protected Input()
				: this(true)
			{
			}

			protected Input(bool showView)
				: base(showView:showView)
			{
			}

			#endregion
		}

		/// <summary>
		/// Parámetros de retorno de la controladora.
		/// </summary>
		[Serializable]
		public abstract new class Output : UIViewController<TInput, TOutput, TUISettings, UIShellView>.Output
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
		public class UISettingsContainer : UIViewController<TInput, TOutput, TUISettings, UIShellView>.UISettingsContainer<UIShellView>
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

		#region Constructor

		protected UIShellViewController()
			: base()
		{
		}

		protected UIShellViewController(AbstractUILinker<UIShellView> linker)
			: base(linker)
		{
		}

		#endregion

		#region Mëtodos abstractos

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
		protected abstract void GetRowSettings(uint row, out double height, out UIShellGridLengthModes mode);

		/// <summary>
		/// Devuelve la configuracion de una celda de la shell.
		/// </summary>
		/// <param name="row">Fila de columna.</param>
		/// <param name="cell">Celda.</param>
		/// <param name="width">Ancho de la celda.</param>
		/// <param name="widthMode">Modo de ajuste de la celda.</param>
		/// <param name="component">Contenido de la celda.</param>
		protected abstract void GetCellSettings(uint row, uint cell, out double width, out UIShellGridLengthModes mode, out UIComponent component);

		#endregion

		#region Métodos sobreescritos

		protected override void OnBeforeStartController()
		{
			base.OnBeforeStartController();

			UIShellRow[] rows = new UIShellRow[Math.Max(1, GetNumberOfRows())];

			for (uint row = 0; row < rows.Length; row++)
			{
				double height = 0.0f;
				UIShellGridLengthModes heightMode = UIShellGridLengthModes.Auto;
				GetRowSettings(row, out height, out heightMode);

				UIShellRowCell[] columns = new UIShellRowCell[Math.Max(1, GetNumberOfCellsAt(row))];

				for (uint column = 0; column < columns.Length; column++)
				{
					double width = 0.0f;
					UIShellGridLengthModes widthMode = UIShellGridLengthModes.Auto;
					UIComponent component = null;

					GetCellSettings(row, column, out width, out widthMode, out component);

					columns[column] = new UIShellRowCell(width, widthMode, component);
				}

				rows[row] = new UIShellRow(height, heightMode, columns);
			}

			UIElement.SetSettings(rows);
		}

		#endregion
	}
}