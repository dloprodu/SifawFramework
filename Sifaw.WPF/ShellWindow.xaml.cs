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
using System.Windows.Shapes;

using Sifaw.Views;


namespace Sifaw.WPF
{
	/// <summary>
	/// Interaction logic for Shell.xaml
	/// </summary>
	public partial class ShellWindow : Window, ShellView
    {
        #region Constructors

        public ShellWindow()
		{
			InitializeComponent();			
		}

		#endregion

		#region Events Handlers
                
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

		#endregion

        #region Methods sobreescritos

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            OnAfterClose(EventArgs.Empty);
        }

        #endregion

		#region UIShell Members

		public void SetLayout(UIShellRow[] rows)
		{
			shell.SetLayout(rows);
		}

		#endregion

		#region UIView Members

		#region Methods

		public void Show(bool isModal)
		{
			OnBeforeShow(EventArgs.Empty);

            if (!isModal)
                Show();
            else
                ShowDialog();
		}

		public new void Close()
		{
			// Solicitud de la controladora de cerrar la vista por lo que 
			// desenganchamos el evento Clousing para que la vista se
			// cierre correctamente.
			this.Closing -= new System.ComponentModel.CancelEventHandler(Window_Closing);
			base.Close();
		}

        public void BeginWaitState()
        {
            Mouse.OverrideCursor = Cursors.Wait;
        }

        public void FinalizeWaitState()
        {
            Mouse.OverrideCursor = null;
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

		public bool ConfirmMessage(string title, string message)
		{
			return MessageBox.Show(this, message, title, MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes;
		}

		#endregion

		#region Events

		public event EventHandler BeforeShow;
		private void OnBeforeShow(EventArgs e)
		{
			if (BeforeShow != null)
				BeforeShow(this as ShellView, e);
		}

		public event EventHandler AfterShow;
		private void OnAfterShow(EventArgs e)
		{
			if (AfterShow != null)
				AfterShow(this as ShellView, e);
		}

		public event UIFinishRequestEventHandler BeforeClose;
		private void OnBeforeClose(UIFinishRequestEventArgs e)
		{
			if (BeforeClose != null)
				BeforeClose(this as ShellView, e);
		}

		public event EventHandler AfterClose;
		private void OnAfterClose(EventArgs e)
		{
			if (AfterClose != null)
				AfterClose(this as ShellView, e);
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
			shell.Reset();
		}

		public void SetLikeActive()
		{
			shell.Focus();
		}

		#endregion

		#region UISettings

		private ViewSettings _uiSettings = null;
		public ViewSettings UISettings
		{
			get
			{
				if (_uiSettings == null)
					_uiSettings = new WindowSettings(this);

				return _uiSettings;
			}
		}

		UISettings Views.UIElement.UISettings
		{
			get { return UISettings; }
		}

		#endregion
    }
}