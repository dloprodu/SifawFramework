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


namespace Sifaw.WPF
{
	/// <summary>
	/// Representa un control que contiene varios elementos que comparten el mismo espacio en la pantalla.
	/// </summary>
	public class TabHostControl : TabControl, TabHostComponent
	{
		#region Constructor

		static TabHostControl()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(TabHostControl), new FrameworkPropertyMetadata(typeof(TabHostControl)));
		}

		#endregion

		#region UIActorComponent Members

		public string[] Descriptors
		{
			set
			{
				Reset();

				if (value != null)
				{
					for (int i = 0; i < value.Length; i++)
						Items.Add(value[i]);
				}
			}
		}

		public void UpdateContent(UIComponent content, int key)
		{
			// TODO
		}

		public event UIComponentChangedEventHandler UIComponentChanged;
		private void OnUIComponentChanged(UIComponentChangedEventArgs e)
		{
			if (UIComponentChanged != null)
				UIComponentChanged(this as TabHostComponent, e);
		}

		#endregion

		#region UIComponent Members

		public new UIDistance Margin
		{
			get { return new UIDistance(base.Margin.Left, base.Margin.Top, base.Margin.Right, base.Margin.Bottom); }
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