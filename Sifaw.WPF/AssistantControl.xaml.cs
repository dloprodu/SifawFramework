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

using Sifaw.Views.Components;
using Sifaw.Views;


namespace Sifaw.WPF
{
	/// <summary>
	/// Interaction logic for AssistantManagerControl.xaml
	/// </summary>
	public partial class AssistantControl : UserControl, AssistantComponent
	{
		#region Constructors

		public AssistantControl()
		{
			InitializeComponent();
		}

		#endregion

		#region Events Handlers

		private void buttonAnterior_Click(object sender, RoutedEventArgs e)
		{
			OnPrevious(EventArgs.Empty);
		}

		private void buttonSiguiente_Click(object sender, RoutedEventArgs e)
		{
			OnNext(EventArgs.Empty);
		}

		private void buttonAceptar_Click(object sender, RoutedEventArgs e)
		{
			OnAccept(EventArgs.Empty);
		}

		private void buttonCancelar_Click(object sender, RoutedEventArgs e)
		{
			OnCancel(EventArgs.Empty);
		}

		#endregion

		#region AssistantManagerComponent Members

		#region Properties

		public byte NumComponents
		{
			get { return assistantProgressBar.Maximum; }
			set { assistantProgressBar.Maximum = value; }
		}

		public bool PreviousEnabled
		{
			get { return buttonAnterior.IsEnabled; }
			set { buttonAnterior.IsEnabled = value; }
		}

		public bool NextEnabled
		{
			get { return buttonSiguiente.IsEnabled; }
			set { buttonSiguiente.IsEnabled = value; }
		}

		public bool AcceptEnabled
		{
			get { return buttonAceptar.IsEnabled; }
			set { buttonAceptar.IsEnabled = value; }
		}

		public bool CancelEnabled
		{
			get { return buttonCancelar.IsEnabled; }
			set { buttonCancelar.IsEnabled = value; }
		}

		#endregion

		#region Methods

		public void SetCurrentUIComponent(UIComponent component, byte step)
		{
            if (gridContent.Children.Contains(component as System.Windows.UIElement))
                return;

			(component as FrameworkElement).VerticalAlignment = VerticalAlignment.Stretch;
			(component as FrameworkElement).HorizontalAlignment = HorizontalAlignment.Stretch;
			(component as FrameworkElement).Margin = new Thickness(0);
			
			gridContent.Children.Add(component as System.Windows.UIElement);

			// Eliminamos la vista anterior
			// • Se hace después de mostrar la vista actual para evitar parpadeos.
			if (gridContent.Children.Count > 1)
				gridContent.Children.Remove(gridContent.Children[0]);

			// Actualizamos el estado de la barra de progreso del asistente.
			assistantProgressBar.Value = step;
			labelStep.Content = step;
			textBlockTitle.Text = component.Denomination;
			textBlockDescription.Text = component.Description;
		}

		#endregion

		#region Events

		public event EventHandler Next;
		private void OnNext(EventArgs e)
		{
			if (Next != null)
				Next(this as AssistantComponent, e);
		}

		public event EventHandler Previous;
		private void OnPrevious(EventArgs e)
		{
			if (Previous != null)
				Previous(this as AssistantComponent, e);
		}

		public event EventHandler Cancel;
		private void OnCancel(EventArgs e)
		{
			if (Cancel != null)
				Cancel(this as AssistantComponent, e);
		}

		public event EventHandler Accept;
		private void OnAccept(EventArgs e)
		{
			if (Accept != null)
				Accept(this as AssistantComponent, e);
		}

		#endregion

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
			/* Empty */
		}

		public void SetLikeActive()
		{
			Focus();
		}

		#endregion

		#endregion
	}
}