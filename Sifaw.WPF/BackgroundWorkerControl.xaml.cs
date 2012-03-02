﻿/*
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


namespace Sifaw.WPF
{
	/// <summary>
	/// Interaction logic for BackgroundWorkerManagerControl.xaml
	/// </summary>
	public partial class BackgroundWorkerControl : UserControl, BackgroundWorkerComponent
	{
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

		#region Properties

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