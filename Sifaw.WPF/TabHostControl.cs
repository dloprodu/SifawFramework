/*
 * Sifaw.WPF
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 27/02/2012: Creación de la clase.
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
using Sifaw.Views.Components;
using Sifaw.Views.Kit;


namespace Sifaw.WPF
{
	/// <summary>
	/// Representa un control que contiene varios elementos que comparten el mismo espacio en la pantalla.
	/// </summary>
	public class TabHostControl : TabControl, TabHostComponent
	{
		#region Fields

		/// <summary>
		/// Flag que indica si se está procesando una solicitud de selección.
		/// </summary>
		private bool selecting = false;

		#endregion

		#region Constructor

		static TabHostControl()
		{			
			DefaultStyleKeyProperty.OverrideMetadata(typeof(TabHostControl), new FrameworkPropertyMetadata(typeof(TabHostControl)));
		}
		
		#endregion

        #region Methods sobreescritos

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            OnUILoaded(EventArgs.Empty);
        }

        #endregion

		#region Override Methods

		protected override void OnSelectionChanged(SelectionChangedEventArgs e)
		{
			if (selecting)
				return;

			selecting = true;

			UIGuestSelectingEventArgs args = new UIGuestSelectingEventArgs(SelectedIndex);

			OnGuestSelecting(args);
				
			if (args.Cancel && e.RemovedItems.Count != 0)
				SelectedItem = e.RemovedItems[0];

			if (!args.Cancel)
				base.OnSelectionChanged(e);

			selecting = false;
		}

		#endregion

		#region UIActorComponent Members

		#region Propiedades

		private string[] _descriptors = null;
		public string[] Descriptors
		{
			get { return _descriptors; }
			set
			{
				Reset();				
				_descriptors = value;
				
				if (value != null)
				{
					for (int i = 0; i < value.Length; i++)
					{
						TabItem item = new TabItem();
						item.Header = value[i];
						Items.Add(item);
					}
				}
			}
		}

		#endregion

		#region Métodos

		public void Update(UIComponent content, int key)
		{
			// Precondiciones.
			if (!(content is FrameworkElement))
				throw new ArgumentException("Se esperaba un componente WPF.", "content");

			if (key < 0 || key > Items.Count - 1)
				throw new ArgumentOutOfRangeException("key");

            // Actualizamos el contenido.
            (content as FrameworkElement).Height = double.NaN;
            (content as FrameworkElement).Width = double.NaN;

			// Actualizamos el contenido.
			(Items[key] as TabItem).Content = null;
			(Items[key] as TabItem).Content = content;
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

		public void Refresh()
		{
			/* Empty */
		}

		public void Reset()
		{
			Items.Clear();
		}

		public void SetLikeActive()
		{
			Focus();
		}

        public event EventHandler UILoaded;
        private void OnUILoaded(EventArgs e)
        {
            if (UILoaded != null)
                UILoaded(this as ShellView, e);
        }

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