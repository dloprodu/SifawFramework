﻿///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// ListFilter.cs
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

using Sifaw.Views;
using Sifaw.Views.Components;
using Sifaw.Views.Components.Filters;


namespace Sifaw.WPF
{
	/// <summary>
	/// Representa un control que implementa el componente <see cref="ListComponentFilter"/>.
	/// </summary>
	public class ListFilter : ListBox, ListComponentFilter
	{
		#region Constructores

		static ListFilter()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(ListFilter), new FrameworkPropertyMetadata(typeof(ListFilter)));
		}

		#endregion

		#region Helpers

		/// <summary>
		/// Flag que indica si se está aplicando un filtro.
		/// </summary>
		private bool filtering = false;

		private void BeginFilter()
		{
			filtering = true;
		}

		private void EndFilter()
		{
			filtering = false;
		}

		#endregion
		
		#region Override Methods

		/// <summary>
		/// Último filtro válido aplicado.
		/// </summary>
		private IList<IFilterable> LastFilter = new IFilterable[] { /* Empty */ };

		protected override void OnSelectionChanged(SelectionChangedEventArgs e)
		{
			base.OnSelectionChanged(e);

			if (!filtering)
			{
				BeginFilter();

				try
				{
					UIFilterChangedEventArgs<IList<IFilterable>> args = new UIFilterChangedEventArgs<IList<IFilterable>>(LastFilter, Filter);

					OnFilterChanged(args);

					if (args.Cancel)
						Filter = LastFilter;
					else
						LastFilter = new List<IFilterable>(Filter);
				}
				catch (Exception ex)
				{
					throw ex;
				}
				finally
				{
					EndFilter();
				}
			}
		}

		#endregion

		#region ComponentListFilterBase<IList<IFilterable>,IList<IFilterable>> Members

		public void Add(IList<IFilterable> source)
		{
			this.SelectionMode = SelectionMode.Multiple;
			this.ItemsSource = source;
			this.DisplayMemberPath = "DisplayFilter";
		}

		#endregion

		#region ComponentFilterBase<IList<IFilterable>> Members

		public IList<IFilterable> Filter
		{
			get	{ return SelectedItems as IList<IFilterable>; }
			set	{ SetSelectedItems(value);	}
		}

		public event UIFilterChangedEventHandler<IList<IFilterable>> FilterChanged;
		private void OnFilterChanged(UIFilterChangedEventArgs<IList<IFilterable>> e)
		{
			if (FilterChanged != null)
				FilterChanged(this as ListComponentFilter, e);
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
			ItemsSource = null;
		}

		public void SetLikeActive()
		{
			Focus();
		}

		#endregion

		#endregion
	}
}