/*
 * Sifaw.WPF
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 09/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using Sifaw.Views;


namespace Sifaw.WPF
{
	/// <summary>
	/// Representa un control que permite definir una shell personalizada.
	/// </summary>
	public partial class ShellControl : UserControl, ShellComponent
	{
		#region Constructors

		public ShellControl()
		{
			InitializeComponent();
		}

		#endregion

		#region Helpers

		private GridLength GetGridLength(double length, UILengthModes mode)
		{
			GridLength gLength;

			switch (mode)
			{
				case UILengthModes.Auto:
					gLength = GridLength.Auto;
					break;

				case UILengthModes.Pixel:
					gLength = new GridLength(length, GridUnitType.Pixel);
					break;

				case UILengthModes.WeightedProportion:
					gLength = new GridLength(length, GridUnitType.Star);
					break;

				default:
					gLength = GridLength.Auto;
					break;
			}

			return gLength;
		}

		#endregion

		#region UIShell Members

		public void SetSettings(UIShellRow[] rows)
		{
			Reset();

			// Para que se ajuste a su contenido (Auto).
			grid.Width = double.NaN;
			grid.Height = double.NaN;

			for (int row = 0; row < rows.Length; row++)
			{
				RowDefinition rDefinition = new RowDefinition();
				rDefinition.Height = GetGridLength(rows[row].Height, rows[row].Mode);
				grid.RowDefinitions.Add(rDefinition);

				Grid gCells = new Grid();
				gCells.HorizontalAlignment = HorizontalAlignment.Stretch;
				gCells.VerticalAlignment = VerticalAlignment.Stretch;

				// Para que se ajuste a su contenido (Auto).
				gCells.Width = double.NaN;
				gCells.Height = double.NaN;

				for (int cell = 0; cell < rows[row].Cells.Length; cell++)
				{
					ColumnDefinition cDefinition = new ColumnDefinition();
					cDefinition.Width = GetGridLength(rows[row].Cells[cell].Width, rows[row].Cells[cell].Mode);
					gCells.ColumnDefinitions.Add(cDefinition);

					if (rows[row].Cells[cell].Content != null)
					{
						FrameworkElement content = (rows[row].Cells[cell].Content as FrameworkElement);
						content.HorizontalAlignment = HorizontalAlignment.Stretch;
						content.VerticalAlignment = VerticalAlignment.Stretch;

						Grid.SetColumn(content, cell);
						gCells.Children.Add(content);
					}
				}

				Grid.SetRow(gCells, row);
				grid.Children.Add(gCells);
			}
		}

		#endregion

		#region UIComponent Members

		public new UIFrame Margin
		{
			get { return new UIFrame(base.Margin.Left, base.Margin.Top, base.Margin.Right, base.Margin.Bottom); }
			set { base.Margin = new Thickness(value.Left, value.Top, value.Right, value.Bottom); }
		}

		#endregion

		#region UIElement Members

		#region Properties

		private string _denomination = string.Empty;
		public string Denomination
		{
			get { return _denomination; }
			set { _denomination = value; }
		}

		private string _description = string.Empty;
		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}

		#endregion

		#region Methods

		public void Refresh()
		{
			/* Empty */
		}

		public void Reset()
		{
			grid.Children.Clear();
			grid.RowDefinitions.Clear();
			grid.ColumnDefinitions.Clear();
		}

		public void SetLikeActive()
		{
			grid.Focus();
		}

		#endregion

		#endregion
	}
}