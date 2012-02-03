///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// BackgroundWorkerManagerControl.xaml.cs
/// 
/// Diseñador:     David López Rguez
/// Programadores: David López Rguez
///	
/// </summary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 04/01/2012 -- Creación de la clase.
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;

using Sifaw.Views.Components;
using Sifaw.Views;


namespace Sifaw.WPF
{
	/// <summary>
	/// Interaction logic for BackgroundWorkerManagerControl.xaml
	/// </summary>
	public partial class BackgroundWorkerControl : UserControl, BackgroundWorkerComponent
	{
		#region Constructor

		public BackgroundWorkerControl()
		{
			InitializeComponent();
		}

		#endregion

		#region Métodos auxiliares

		private double Rango(int value, ProgressBar barra)
		{
			if (value < barra.Minimum) 
				return barra.Minimum;

			if (value > barra.Maximum) 
				return barra.Maximum;

			return value;
		}

		#endregion

		#region Gestión de eventos

		private void buttonCancelar_Click(object sender, RoutedEventArgs e)
		{
			OnCancel(EventArgs.Empty);
		}

		#endregion

		#region BackgroundWorkerManagerComponent Members

		#region Propiedades

		public bool WithControl
		{
			get	{ return !progressBar.IsIndeterminate; }
			set { progressBar.IsIndeterminate = !value; }
		}

		public bool AllowCancel
		{
			get { return buttonCancelar.IsVisible;	}
			set	{ buttonCancelar.Visibility = value ? Visibility.Visible : Visibility.Collapsed; }
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

		#region Métodos

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

		#region Eventos

		public event EventHandler Cancel;
		private void OnCancel(EventArgs e)
		{
			if (Cancel != null)
				Cancel(this as BackgroundWorkerComponent, e);
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

		#endregion		
	}
}