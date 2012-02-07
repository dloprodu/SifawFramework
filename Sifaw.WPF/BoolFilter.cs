///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// BoolFilter.cs
/// 
/// Diseñador: David López Rguez
/// Programador: David López Rguez
/// </sumary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 06/02/2012: Creación de controladora.
/// 
/// ===============================================================================================
/// Observaciones:
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

using Sifaw.Views.Components;
using Sifaw.Views;
using Sifaw.Views.Components.Filters;


namespace Sifaw.WPF
{
	/// <summary>
	/// Representa un control que puede ser usado para filtrar un valor de tipo booleano.
	/// </summary>
	public class BoolFilter : CheckBox, BoolComponentFilter
	{
		#region Constructor

		static BoolFilter()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(BoolFilter), new FrameworkPropertyMetadata(typeof(BoolFilter)));
		}

		#endregion

		#region Métodos sobreescritos

		protected override void OnChecked(RoutedEventArgs e)
		{
			base.OnChecked(e);

			OnFilterChanged(new UIFilterChangedEventArgs<bool>(false, true));
		}

		protected override void OnUnchecked(RoutedEventArgs e)
		{
			base.OnUnchecked(e);

			OnFilterChanged(new UIFilterChangedEventArgs<bool>(true, false));
		}

		#endregion

		#region ComponentFilter<bool> Members

		public bool Filter
		{
			get { return IsChecked.HasValue ? IsChecked.Value : false; }
			set { IsChecked = value; }
		}

		public event UIFilterChangedEventHandler<bool> FilterChanged;
		private void OnFilterChanged(UIFilterChangedEventArgs<bool> e)
		{
			if (FilterChanged != null)
				FilterChanged(this as ComponentFilterBase<bool>, e);
		}

		#endregion

		#region UIElement Members

		#region Propiedades

		public string Denomination
		{
			get { return Content != null ? Content.ToString() : string.Empty; }
			set { Content = value; }
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
			/* Emtpy */
		}

		public void Reset()
		{
			/* Emtpy */
		}

		public void SetLikeActive()
		{
			Focus();
		}

		#endregion

		#endregion
	}
}