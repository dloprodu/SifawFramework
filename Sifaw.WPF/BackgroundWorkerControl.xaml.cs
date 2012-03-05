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

using Sifaw.Views.Components;
using Sifaw.Views;
using Sifaw.Views.Kit;
using Sifaw.WPF.CCL;


namespace Sifaw.WPF
{
	/// <summary>
	/// Interaction logic for BackgroundWorkerManagerControl.xaml
	/// </summary>
	public partial class BackgroundWorkerControl : UserControl, BackgroundWorkerComponent
	{
        #region Properties

        public bool WithControl
        {
            get { return !progressBar.IsIndeterminate; }
            set { progressBar.IsIndeterminate = !value; }
        }

        public bool AllowCancel
        {
            get { return buttonCancelar.IsVisible; }
            set { buttonCancelar.Visibility = value ? Visibility.Visible : Visibility.Collapsed; }
        }

        public int MaxProgressPercentage
        {
            get { return (int)progressBar.Maximum; }
            set { progressBar.Maximum = value; }
        }

        public string Summary
        {
            get { return labelSummary.Content.ToString(); }
            set { labelSummary.Content = value; }
        }

        public string ProcessDescription
        {
            get { return textBlockDescription.Text; }
            set { textBlockDescription.Text = value; }
        }

        public string Progress
        {
            get { return labelProgress.Content.ToString(); }
            set { labelProgress.Content = value; }
        }

        #endregion

		#region Constructors

		public BackgroundWorkerControl()
		{
			InitializeComponent();
		}

		#endregion

		#region Methods auxiliares

		private double Rango(int value, ProgressBar barra)
		{
			if (value < barra.Minimum) 
				return barra.Minimum;

			if (value > barra.Maximum) 
				return barra.Maximum;

			return value;
		}

		#endregion

		#region Events Handlers

		private void buttonCancelar_Click(object sender, RoutedEventArgs e)
		{
			OnCancel(EventArgs.Empty);
		}

		#endregion

		#region BackgroundWorkerManagerComponent Members

		#region Methods

		public void UpdateProgress(string message)
		{
			labelProgress.Content = message;
			textBlockDetail.Text += Environment.NewLine + message;
		}

		public void UpdateProgress(string message, bool isCancelled)
		{
			buttonCancelar.IsEnabled = !isCancelled;
			labelProgress.Foreground = Brushes.Red;
			UpdateProgress(message);
		}

		public void UpdateProgress(int progressPercentage)
		{
			progressBar.Value = Rango(progressPercentage, progressBar);
		}

		#endregion

		#region Events

		public event EventHandler Cancel;
		private void OnCancel(EventArgs e)
		{
			if (Cancel != null)
				Cancel(this as BackgroundWorkerComponent, e);
		}

		#endregion

		#endregion

		#region UIElement Members

		public void Refresh()
		{
			/* Empty */
		}

		public void Reset()
		{
			progressBar.Minimum = 0;
			progressBar.Maximum = 100;
			progressBar.Value = 0;
			textBlockDetail.Text = string.Empty;
		}

		public void SetLikeActive()
		{
			expanderDetail.Focus();
		}

		#endregion		

        #region UISettings

        private BackgroundWorkerSettings _uiSettings; 
        public BackgroundWorkerSettings UISettings
        {
            get 
            {
                if (_uiSettings == null)
                    _uiSettings = new BackgroundWorkerControlSettings(this);

                return _uiSettings;
            }
        }

        ComponentSettings UIComponent.UISettings
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
        public class BackgroundWorkerControlSettings : ControlSettings, BackgroundWorkerSettings
        {
            #region Fields

            private bool _withControl = true;
            private bool _allowCancel = false;
            private string _summary = string.Empty;
            private string _processDescription = string.Empty;
            private string _progress = string.Empty;
            private int _maxProgressPercentage = 100;

            #endregion

            #region Properties

            /// <summary>
            /// Obtiene o establece un valor que indica si el proceso
            /// se ejecuta con o sin control de seguimiento.
            /// </summary>
            public bool WithControl
            {
                get { return _withControl; }
                set
                {
                    if (_withControl != value)
                    {
                        _withControl = value;
                        OnPropertyChanged(() => WithControl);
                    }
                }
            }

            /// <summary>
            /// Obtiene o establece un valor que indica si se permite
            /// cancelar el proceso.
            /// </summary>
            public bool AllowCancel
            {
                get { return _allowCancel; }
                set
                {
                    if (_allowCancel != value)
                    {
                        _allowCancel = value;
                        OnPropertyChanged(() => AllowCancel);
                    }
                }
            }

            /// <summary>
            /// Obtiene o establece una descripción breve del proceso.
            /// </summary>
            public string Summary
            {
                get { return _summary; }
                set
                {
                    if (_summary != value)
                    {
                        _summary = value;
                        OnPropertyChanged(() => Summary);
                    }
                }
            }

            /// <summary>
            /// Obtiene o establece una descripción del proceso.
            /// </summary>
            public string ProcessDescription
            {
                get { return _processDescription; }
                set
                {
                    if (_processDescription != value)
                    {
                        _processDescription = value;
                        OnPropertyChanged(() => ProcessDescription);
                    }
                }
            }

            /// <summary>
            /// Obtiene o establece el texto a mostrar durante el progreso del
            /// proceso.
            /// </summary>
            public string Progress
            {
                get { return _progress; }
                set
                {
                    if (_progress != value)
                    {
                        _progress = value;
                        OnPropertyChanged(() => Progress);
                    }
                }
            }

            /// <summary>
            /// Obtiene o establece un valor que indica el máximo progreso 
            /// del proceso.
            /// </summary>
            public int MaxProgressPercentage
            {
                get { return _maxProgressPercentage; }
                set
                {
                    if (_maxProgressPercentage != value)
                    {
                        _maxProgressPercentage = value;
                        OnPropertyChanged(() => MaxProgressPercentage);
                    }
                }
            }

            #endregion

            #region Constructor

            public BackgroundWorkerControlSettings(BackgroundWorkerControl control)
                : base(control)
            {
                //UtilWPF.BindField(this, "WithControl",           control, BackgroundWorkerControl.WithControlProperty, BindingMode.TwoWay);
                //UtilWPF.BindField(this, "AllowCancel",           control, BackgroundWorkerControl.AllowCancelProperty, BindingMode.TwoWay);
                //UtilWPF.BindField(this, "Summary",               control, BackgroundWorkerControl.SummaryProperty, BindingMode.TwoWay);
                //UtilWPF.BindField(this, "MaxProgressPercentage", control, BackgroundWorkerControl.MaxProgressPercentageProperty, BindingMode.TwoWay);
                //UtilWPF.BindField(this, "ProcessDescription",    control, BackgroundWorkerControl.ProcessDescriptionProperty, BindingMode.TwoWay);
                //UtilWPF.BindField(this, "Progress",              control, BackgroundWorkerControl.ProgressProperty, BindingMode.TwoWay);
            }

            #endregion
        }

        #endregion
    }
}