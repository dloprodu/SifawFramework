///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// TextFilter.cs
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

using Sifaw.WPF.CCL;
using Sifaw.Views.Components;
using Sifaw.Views;
using Sifaw.Views.Components.Filters;


namespace Sifaw.WPF
{
	/// <summary>
	/// Representa un control que puede ser usado para mostrar o editar texto sin formato
	/// con el que ejecutar filtros o búsquedas.
	/// </summary>
	public class TextFilter : SearchTextField, TextComponentFilter
	{
		#region Variables

		private string LastFilter = string.Empty;

		#endregion

		#region Constructor

		static TextFilter()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(TextFilter), new FrameworkPropertyMetadata(typeof(TextFilter)));
		}

		#endregion

		#region Métodos sobreescritos

		protected override void OnSearch(RoutedEventArgs e)
		{
			base.OnSearch(e);
		
			OnFilterChanged(new UIFilterChangedEventArgs<string>(LastFilter, LastFilter = Filter));
		}

		#endregion

		#region FilterComponent<string> Members

		public string Filter
		{
			get { return Text; }
			set { Text = value; }
		}

		public event UIFilterChangedEventHandler<string> FilterChanged;
		private void OnFilterChanged(UIFilterChangedEventArgs<string> e)
		{
			if (FilterChanged != null)
				FilterChanged(this as ComponentFilterBase<string>, e);
		}

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
			/* Emtpy */
		}

		public void Reset()
		{
			Text = string.Empty;
		}

		public void SetLikeActive()
		{
			Focus();
		}

		#endregion

		#endregion
	}
}