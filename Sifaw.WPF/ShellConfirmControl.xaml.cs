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
using System.ComponentModel;

using Sifaw.Views;
using Sifaw.Views.Kit;
using Sifaw.WPF.CCL;


namespace Sifaw.WPF
{
	/// <summary>
	/// Representa un control que permite definir una shell personalizada.
	/// </summary>
	public partial class ShellConfirmControl : UserControl, ShellConfirmComponent
    {
        #region Dependecy Properties

        public static DependencyProperty IsCancelableProperty =
            DependencyProperty.Register(
                "IsCancelable",
                typeof(bool),
                typeof(ShellConfirmControl),
                new FrameworkPropertyMetadata(
                    false,
                    new PropertyChangedCallback(OnIsCancelableChanged)));

        #endregion

        #region Properties

        /// <summary>
        /// Obtiene o establecela duración de tiempo en el desencadenamiento de eventos
        /// <see cref="Search"/> en el modo de búsqueda Instant.
        /// </summary>
        [Category("Common")]
        public bool IsCancelable
        {
            get { return (bool)GetValue(IsCancelableProperty); }
            set { SetValue(IsCancelableProperty, value); }
        }

        #endregion

        #region Constructors

        public ShellConfirmControl()
		{
			InitializeComponent();
		}

        #endregion

		#region Helpers

		private GridLength GetGridLength(double length, UIShellLengthModes mode)
		{
			GridLength gLength;

			switch (mode)
			{
				case UIShellLengthModes.Auto:
					gLength = GridLength.Auto;
					break;

				case UIShellLengthModes.Pixel:
					gLength = new GridLength(length, GridUnitType.Pixel);
					break;

				case UIShellLengthModes.WeightedProportion:
					gLength = new GridLength(length, GridUnitType.Star);
					break;

				default:
					gLength = GridLength.Auto;
					break;
			}

			return gLength;
		}

        private void ClearGrid(Grid grid)
        {
            foreach (FrameworkElement child in grid.Children)
            {
                if (child is Grid)
                {
                    ClearGrid(child as Grid);
                }
            }

            grid.Children.Clear();
            grid.RowDefinitions.Clear();
            grid.ColumnDefinitions.Clear();
        }

		#endregion

        #region Methods de factoria

        private static void OnIsCancelableChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            ShellConfirmControl confirm = o as ShellConfirmControl;

            if (confirm != null)
            {
                confirm.buttonCancel.Visibility = ((bool)e.NewValue)
                    ? System.Windows.Visibility.Visible
                    : System.Windows.Visibility.Collapsed;
            }
        }

        #endregion

        #region Gestión de eventos

        private void buttonConfirm_Click(object sender, RoutedEventArgs e)
        {
            OnConfirm(e);
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            OnCancel(e);
        }

        #endregion

		#region UIShell Members

		public void SetLayout(UIShellRow[] rows)
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
                gCells.Margin = new Thickness(0);
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
                        content.Width = double.NaN;
                        content.Height = double.NaN;
                        content.Margin = new Thickness(0);

						Grid.SetColumn(content, cell);
						gCells.Children.Add(content);
					}
				}

				Grid.SetRow(gCells, row);
				grid.Children.Add(gCells);
			}
		}

        public event EventHandler Confirm;
        private void OnConfirm(EventArgs e)
        {
            if (Confirm != null)
                Confirm(this as ShellConfirmComponent, e);
        }

        public event EventHandler Cancel;
        private void OnCancel(EventArgs e)
        {
            if (Cancel != null)
                Cancel(this as ShellConfirmComponent, e);
        }

		#endregion

		#region UIElement Members

		public void Refresh()
		{
			/* Empty */
		}

		public void Reset()
		{
            ClearGrid(grid);
		}

		public void SetLikeActive()
		{
			grid.Focus();
		}

		#endregion

        #region UISettings

        private ShellConfirmSettings _uiSettings = null;
        public ShellConfirmSettings UISettings
        {
            get
            {
                if (_uiSettings == null)
                    _uiSettings = new ShellControlSettings(this);

                return _uiSettings;
            }
        }

        ComponentSettings Views.UIComponent.UISettings
        {
            get { return UISettings; }
        }

        UISettings Views.UIElement.UISettings
        {
            get { return UISettings; }
        }

        #endregion

        #region Miscellany

        [Serializable]
        public class ShellControlSettings : ControlSettings, ShellConfirmSettings
        {
            #region Fields

            private bool _isCancelable = true;

            #endregion

            #region Properties

            /// <summary>
            /// Flag que indica si el control es cancelable.
            /// </summary>
            public bool IsCancelable
            {
                get { return _isCancelable; }
                set
                {
                    if (_isCancelable != value)
                    {
                        _isCancelable = value;
                        OnPropertyChanged(() => IsCancelable);
                    }
                }
            }

            #endregion

            #region Constructor

            public ShellControlSettings(ShellConfirmControl control)
                : base(control)
            {
                UtilWPF.BindField(this, "IsCancelable", control, ShellConfirmControl.IsCancelableProperty, BindingMode.TwoWay);
            }

            #endregion
        }

        #endregion
    }
}