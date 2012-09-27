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
using Sifaw.Views.Kit;


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
			OnGuestSelecting(new UIGuestSelectingEventArgs(assistantProgressBar.Value - 2));
		}

		private void buttonSiguiente_Click(object sender, RoutedEventArgs e)
		{
			OnGuestSelecting(new UIGuestSelectingEventArgs(assistantProgressBar.Value));
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

		#region Events

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
		
		#region UIActorComponent Members

		#region Propiedades

		private string[] _descriptors = null;
		public string[] Descriptors
		{
			get { return _descriptors; }
			set 
			{
				_descriptors = value;
				assistantProgressBar.Maximum = (byte)value.Length; 
			}
		}

		#endregion

		#region Métodos

		public void Update(UIComponent content, int key)
		{
			// Precondiciones.
			if (!(content is FrameworkElement))
				throw new ArgumentException("Se esperaba un componente WPF.", "content");
			
			if (key < 0 || key > assistantProgressBar.Maximum - 1)
				throw new ArgumentOutOfRangeException("key");
			
			// Actualizamos el contenido.
            (content as FrameworkElement).Height = double.NaN;
            (content as FrameworkElement).Width = double.NaN;

            dockPanel.Children.Add(content as FrameworkElement);

			// Eliminamos la vista anterior.
			// • Se hace después de mostrar la vista actual para evitar parpadeos.
            if (dockPanel.Children.Count > 1)
                dockPanel.Children.Remove(dockPanel.Children[0]);

			// Actualizamos el estado de la barra de progreso del asistente.
			assistantProgressBar.Value = (byte)(key + 1);
			labelStep.Content = (key + 1);
			textBlockTitle.Text = Descriptors[key];
			textBlockDescription.Text = content.UISettings.Description;
		}

		#endregion

		#region Eventos

		public event UIGuestSelectingEventHandler GuestSelecting;
		private void OnGuestSelecting(UIGuestSelectingEventArgs e)
		{
			if (GuestSelecting != null)
				GuestSelecting(this as AssistantComponent, e);
		}

		#endregion

		#endregion

		#region UIElement Members

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

        #region UISettings

        private ComponentSettings _uiSettings = null;
        public ComponentSettings UISettings
        {
            get
            {
                if (_uiSettings == null)
                    _uiSettings = new ControlSettings(this);

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