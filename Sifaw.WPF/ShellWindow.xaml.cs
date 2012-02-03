///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Shell.xaml.cs.
/// 
/// Diseñador:     David López Rguez
/// Programadores: David López Rguez
///	
/// </summary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 09/01/2012 -- Creación de la clase.
/// ===============================================================================================
/// Observaciones:
/// 
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



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
using System.Windows.Shapes;

using Sifaw.Views;


namespace Sifaw.WPF
{
	/// <summary>
	/// Interaction logic for Shell.xaml
	/// </summary>
	public partial class ShellWindow : Window, UIShellView
	{
		#region Constructor

		public ShellWindow()
		{
			InitializeComponent();
		}

		#endregion

		#region Métodos auxiliares

		private GridLength GetGridLength(double length, UIShellGridLengthModes mode)
		{
			GridLength gLength;

			switch (mode)
			{
				case UIShellGridLengthModes.Auto:
					gLength = GridLength.Auto;
					break;

				case UIShellGridLengthModes.Pixel:
					gLength = new GridLength(length, GridUnitType.Pixel);
					break;

				case UIShellGridLengthModes.WeightedProportion:
					gLength = new GridLength(length, GridUnitType.Star);
					break;

				default:
					gLength = GridLength.Auto;
					break;
			}

			return gLength;
		}

		#endregion

		#region Gestión de eventos
		
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
			// Cuando una ventana se abre por primera vez, se producen los eventos Loaded y ContentRendered una vez que se produce el evento Activated. 
			// Con esta perspectiva, una ventana puede considerarse abierta cuando se produce ContentRendered.
			OnAfterShow(EventArgs.Empty);
		}

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			// Es la controladora quién controla el Close.
			UIFinishRequestEventArgs args = new UIFinishRequestEventArgs(true);
			OnBeforeClose(args);
			e.Cancel = args.Cancel;			
		}
		
		private void Window_Closed(object sender, EventArgs e)
		{
			OnAfterClose(EventArgs.Empty);
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

		#region UIView Members

		#region Propiedades

		public string Header
		{
			get { return base.Title; }
			set { base.Title = value; }
		}

		public new bool SizeToContent
		{
			get { return base.SizeToContent == System.Windows.SizeToContent.WidthAndHeight; }
			set
			{
				base.SizeToContent = value ? System.Windows.SizeToContent.WidthAndHeight : System.Windows.SizeToContent.Manual;
				base.ResizeMode = value ? System.Windows.ResizeMode.NoResize : System.Windows.ResizeMode.CanResize;
			}
		}

		#endregion

		#region Métodos

		public new void Show()
		{
			OnBeforeShow(EventArgs.Empty);
			base.Show();
		}

		public new void Close()
		{
			// Solicitud de la controladora de cerrar la vista por lo que 
			// desenganchamos el evento Clousing para que la vista se
			// cierre correctamente.
			this.Closing -= new System.ComponentModel.CancelEventHandler(Window_Closing);			
			base.Close();
		}

		public void ShowMessage(string message)
		{
			MessageBox.Show(this, message, "Mensaje", MessageBoxButton.OK, MessageBoxImage.Information);
		}

		public void ShowMessage(string title, string message)
		{
			MessageBox.Show(this, message, title, MessageBoxButton.OK, MessageBoxImage.Information);
		}

		public void ShowWarning(string warning)
		{
			MessageBox.Show(this, warning, "Advertencia", MessageBoxButton.OK, MessageBoxImage.Warning);
		}

		public void ShowWarning(string title, string warning)
		{
			MessageBox.Show(this, warning, title, MessageBoxButton.OK, MessageBoxImage.Warning);
		}

		public void ShowError(string error)
		{
			MessageBox.Show(this, error, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
		}

		public void ShowError(string title, string error)
		{
			MessageBox.Show(this, error, title, MessageBoxButton.OK, MessageBoxImage.Error);
		}

		public bool ConfirmMessage(string message)
		{
			return MessageBox.Show(this, message, "Mensaje", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
		}

		public bool ConfirmMessage(string titulo, string message)
		{
			return MessageBox.Show(this, message, titulo, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
		}

		#endregion

		#region Eventos

		public event EventHandler BeforeShow;
		private void OnBeforeShow(EventArgs e)
		{
			if (BeforeShow != null)
				BeforeShow(this as UIShellView, e);
		}

		public event EventHandler AfterShow;
		private void OnAfterShow(EventArgs e)
		{
			if (AfterShow != null)
				AfterShow(this as UIShellView, e);
		}

		public event UIFinishRequestEventHandler BeforeClose;
		private void OnBeforeClose(UIFinishRequestEventArgs e)
		{
			if (BeforeClose != null)
				BeforeClose(this as UIShellView, e);
		}

		public event EventHandler AfterClose;
		private void OnAfterClose(EventArgs e)
		{
			if (AfterClose != null)
				AfterClose(this as UIShellView, e);
		}

		#endregion

		#endregion

		#region UIElement Members

		#region Propiedades

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

		#region Métodos

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