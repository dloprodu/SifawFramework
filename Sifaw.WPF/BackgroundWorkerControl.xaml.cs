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
using Sifaw.Views.Components;
using Sifaw.Views.Kit;

using Sifaw.WPF.CCL;


namespace Sifaw.WPF
{
	/// <summary>
	/// Interaction logic for BackgroundWorkerManagerControl.xaml
	/// </summary>
	public partial class BackgroundWorkerControl : UserControl, BackgroundWorkerComponent
	{
		#region Dependency Properties

		public static readonly DependencyProperty WithControlProperty = DependencyProperty.Register(
			"WithControl",
			typeof(bool),
			typeof(BackgroundWorkerControl),
			new FrameworkPropertyMetadata(
				false,
				new PropertyChangedCallback(BackgroundWorkerControl.OnWithControlChanged)));

		public static readonly DependencyProperty AllowCancelProperty = DependencyProperty.Register(
			"AllowCancel",
			typeof(bool),
			typeof(BackgroundWorkerControl),
			new FrameworkPropertyMetadata(
				false,
				new PropertyChangedCallback(BackgroundWorkerControl.OnAllowCancelChanged)));

		public static readonly DependencyProperty MaxProgressPercentageProperty = DependencyProperty.Register(
			"MaxProgressPercentage",
			typeof(int),
			typeof(BackgroundWorkerControl),
			new FrameworkPropertyMetadata(
				100,
				new PropertyChangedCallback(BackgroundWorkerControl.OnMaxProgressPercentageChanged)));

		public static readonly DependencyProperty SummaryProperty = DependencyProperty.Register(
			"Summary",
			typeof(string),
			typeof(BackgroundWorkerControl),
			new FrameworkPropertyMetadata(
				"Operación pesada...",
				new PropertyChangedCallback(BackgroundWorkerControl.OnSummaryChanged)));

		public static readonly DependencyProperty ProcessDescriptionProperty = DependencyProperty.Register(
			"ProcessDescription",
			typeof(string),
			typeof(BackgroundWorkerControl),
			new FrameworkPropertyMetadata(
				"Se está ejecutando un proceso pesado. Esta operación puede tardar varios minutos. Espere por favor...",
				new PropertyChangedCallback(BackgroundWorkerControl.OnProcessDescriptionChanged)));

		public static readonly DependencyProperty ProgressProperty = DependencyProperty.Register(
			"Progress",
			typeof(string),
			typeof(BackgroundWorkerControl),
			new FrameworkPropertyMetadata(
				"Ejecutando proceso...",
				new PropertyChangedCallback(BackgroundWorkerControl.OnProgressChanged)));

		#endregion

		#region Properties

		[Category("Behavior")]
		public bool WithControl
        {
            get { return (bool)GetValue(WithControlProperty); }
            set { SetValue(WithControlProperty, value); }
        }

		[Category("Behavior")]
        public bool AllowCancel
        {
			get { return (bool)GetValue(AllowCancelProperty); }
			set { SetValue(AllowCancelProperty, value); }
		}

		[Category("Behavior")]
        public int MaxProgressPercentage
        {
			get { return (int)GetValue(MaxProgressPercentageProperty); }
			set { SetValue(MaxProgressPercentageProperty, value); }
		}

		[Category("Behavior")]
        public string Summary
        {
			get { return (string)GetValue(SummaryProperty); }
			set { SetValue(SummaryProperty, value); }
        }

		[Category("Behavior")]
        public string ProcessDescription
        {
			get { return (string)GetValue(ProcessDescriptionProperty); }
			set { SetValue(ProcessDescriptionProperty, value); }
		}

		[Category("Behavior")]
        public string Progress
        {
			get { return (string)GetValue(ProgressProperty); }
			set { SetValue(ProgressProperty, value); }
		}

        #endregion

		#region Constructors

		public BackgroundWorkerControl()
		{
			InitializeComponent();

            // Sincronizamos el valores ...
            buttonCancelar.Visibility = AllowCancel ? Visibility.Visible : Visibility.Collapsed;            
            progressBar.IsIndeterminate = !WithControl;
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

		#region Changed Handlers

		private static void OnWithControlChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			(d as BackgroundWorkerControl).OnWithControlChanged((bool)e.OldValue, (bool)e.NewValue);
		}

		private void OnWithControlChanged(bool oldValue, bool newValue)
		{
			progressBar.IsIndeterminate = !newValue;
		}

		private static void OnAllowCancelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			(d as BackgroundWorkerControl).OnAllowCancelChanged((bool)e.OldValue, (bool)e.NewValue);
		}

		private void OnAllowCancelChanged(bool oldValue, bool newValue)
		{
			buttonCancelar.Visibility = newValue ? Visibility.Visible : Visibility.Collapsed; 
		}

		private static void OnMaxProgressPercentageChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			(d as BackgroundWorkerControl).OnMaxProgressPercentageChanged((int)e.OldValue, (int)e.NewValue);
		}

		private void OnMaxProgressPercentageChanged(int oldValue, int newValue)
		{
			progressBar.Maximum = newValue; 
		}

		private static void OnSummaryChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			(d as BackgroundWorkerControl).OnSummaryChanged((string)e.OldValue, (string)e.NewValue);
		}

		private void OnSummaryChanged(string oldValue, string newValue)
		{
			labelSummary.Content = newValue; 
		}

		private static void OnProcessDescriptionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			(d as BackgroundWorkerControl).OnProcessDescriptionChanged((string)e.OldValue, (string)e.NewValue);
		}

		private void OnProcessDescriptionChanged(string oldValue, string newValue)
		{
			textBlockDescription.Text = newValue; 
		}

		private static void OnProgressChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			(d as BackgroundWorkerControl).OnProgressChanged((string)e.OldValue, (string)e.NewValue);
		}

		private void OnProgressChanged(string oldValue, string newValue)
		{
			labelProgress.Content = newValue;
		}

		#endregion

		#region Events Handlers
        
        private void BackgroundWorkerControl_Loaded(object sender, RoutedEventArgs e)
        {
            OnUILoaded(EventArgs.Empty);
        }

		private void buttonCancelar_Click(object sender, RoutedEventArgs e)
		{
			OnCancel(EventArgs.Empty);
		}

		#endregion

		#region BackgroundWorkerManagerComponent Members

		#region Methods

		public void UpdateProgress(string message)
		{
            if (((string)labelProgress.Content) != message)
            {
                labelProgress.Content = message;

                try
                {
                    textBoxDetail.AppendText(Environment.NewLine + message);
                }
                catch
                {
                    textBoxDetail.Text = string.Empty;
                    textBoxDetail.AppendText(message);
                }
                finally
                {
                    scrollViewer.ScrollToEnd();
                }
            }
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
            textBoxDetail.Text = string.Empty;
		}

		public void SetLikeActive()
		{
			expanderDetail.Focus();
		}

        public event EventHandler UILoaded;
        private void OnUILoaded(EventArgs e)
        {
            if (UILoaded != null)
                UILoaded(this as BackgroundWorkerComponent, e);
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

            private bool _withControl = false;
            private bool _allowCancel = false;
            private string _summary = "Operación pesada";
            private string _processDescription = "Se está ejecutando un proceso pesado. Esta operación puede tardar varios minutos. Espere por favor...";
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
				UtilWPF.BindField(this, "WithControl",           control, BackgroundWorkerControl.WithControlProperty,           BindingMode.TwoWay);
				UtilWPF.BindField(this, "AllowCancel",           control, BackgroundWorkerControl.AllowCancelProperty,           BindingMode.TwoWay);
                UtilWPF.BindField(this, "Summary",               control, BackgroundWorkerControl.SummaryProperty,               BindingMode.TwoWay);
                UtilWPF.BindField(this, "MaxProgressPercentage", control, BackgroundWorkerControl.MaxProgressPercentageProperty, BindingMode.TwoWay);
                UtilWPF.BindField(this, "ProcessDescription",    control, BackgroundWorkerControl.ProcessDescriptionProperty,    BindingMode.TwoWay);
                UtilWPF.BindField(this, "Progress",              control, BackgroundWorkerControl.ProgressProperty,              BindingMode.TwoWay);
            }

            #endregion
        }

        #endregion
    }
}