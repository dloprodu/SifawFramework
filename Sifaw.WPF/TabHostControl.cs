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
			Items.Clear();
		}

		public void SetLikeActive()
		{
			Focus();
		}

		#endregion

		#endregion
	}
}