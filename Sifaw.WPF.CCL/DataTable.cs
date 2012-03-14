/*
 * Sifaw.WPF.CCL
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 09/03/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 
 DataTable : MultiSelector

 DataTableCell : ContentControl



DataTable
   Border
      Grid
         PART_HeadersPresenter       : zona de cabecera
         PART_ScrollContentPresenter : zona de datos            -> VirtualizingPanel
            PART_DataTableCellsPanel : zona de celdas por fila  -> VirtualizingPanel
         PART_FooterPresenter        : zona de pie de datos
      
  
  
 */


using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Collections.Specialized;


namespace Sifaw.WPF.CCL
{
	/// <summary>
	/// Representa un control que permite representar datos en una tabla con cabecera y pie.
	/// Las celdas de la tabla pueden ocupar mas de una fila y/o columna.
	/// </summary>
	[TemplatePart(Name = "PART_Header", Type = typeof(DataTableHeadersPresenter))]
	[TemplatePart(Name = "PART_Rows", Type = typeof(DataTableRowsPresenter))]
	public class DataTable : Control
	{
		#region Fields

		private DataTableHeadersPresenter HeaderPresenter = null;
		private DataTableRowsPresenter RowsPresenter = null;

		#endregion

		#region Dependency Properties

		public static readonly DependencyProperty ColumnsProperty = DependencyProperty.Register(
			"Columns",
			typeof(DataTableColumnCollection),
			typeof(DataTable),
			new FrameworkPropertyMetadata(
				null,
				FrameworkPropertyMetadataOptions.AffectsRender));

		public static readonly DependencyProperty HeaderProperty = DependencyProperty.Register(
			"Header",
			typeof(DataTableRowCollection),
			typeof(DataTable),
			new FrameworkPropertyMetadata(
				null,
				FrameworkPropertyMetadataOptions.AffectsRender));

		public static readonly DependencyProperty RowsProperty = DependencyProperty.Register(
			"Rows",
			typeof(DataTableRowCollection),
			typeof(DataTable),
			new FrameworkPropertyMetadata(
				null,
				FrameworkPropertyMetadataOptions.AffectsRender));

		#endregion

		#region Properties

		/// <summary>
		/// Obtiene la colección de columnas del <see cref="DataTable"/>.
		/// </summary>
		public DataTableColumnCollection Columns
		{
			get 
			{
				if (GetValue(ColumnsProperty) == null)
				{
					Columns = new DataTableColumnCollection(this);
					Columns.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Columns_CollectionChanged);
				}

				return (DataTableColumnCollection)GetValue(ColumnsProperty); 
			}
			protected internal set { SetValue(ColumnsProperty, value); }
		}		

		/// <summary>
		/// Obtiene la colección de filas de la cabecera del <see cref="DataTable"/>.
		/// </summary>
		public DataTableRowCollection Header
		{
			get
			{
				if (GetValue(HeaderProperty) == null)
				{
					Header = new DataTableRowCollection(this);
					Header.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Header_CollectionChanged);
				}

				return (DataTableRowCollection)GetValue(HeaderProperty);
			}
			protected internal set { SetValue(HeaderProperty, value); }
		}
		
		/// <summary>
		/// Obtiene la colección de filas del <see cref="DataTable"/>.
		/// </summary>
		public DataTableRowCollection Rows
		{
			get 
			{
				if (GetValue(RowsProperty) == null)
				{
					Rows = new DataTableRowCollection(this);
					Rows.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Rows_CollectionChanged);
				}

				return (DataTableRowCollection)GetValue(RowsProperty); 
			}
			protected internal set { SetValue(RowsProperty, value); }
		}

		#endregion

		#region Constructor

		static DataTable()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(DataTable), new FrameworkPropertyMetadata(typeof(DataTable)));
		}

		#endregion

		#region Override Methods

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			HeaderPresenter = Template.FindName("PART_Header", this) as DataTableHeadersPresenter;
			RowsPresenter = Template.FindName("PART_Rows", this) as DataTableRowsPresenter;
		}

		#endregion

		#region Public Methods

		public void Clean()
		{
		}

		public void CleanHeader()
		{
			Header.Clear();
		}

		public void CleanRows()
		{
		}

		public DataTableRow AddHeader()
		{
			DataTableRow row = Header[Header.Add()];
			HeaderPresenter.Children.Add(row);
			return row;
		}

		public DataTableRow AddRow()
		{
			DataTableRow row = Rows[Rows.Add()];
			RowsPresenter.Children.Add(row);
			return row;
		}

		#endregion

		#region

		private void Columns_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			switch (e.Action)
			{
				case NotifyCollectionChangedAction.Add:
					break;

				case NotifyCollectionChangedAction.Remove:
					break;

				case NotifyCollectionChangedAction.Reset:
					break;

				case NotifyCollectionChangedAction.Move:
					break;

				case NotifyCollectionChangedAction.Replace:
					break;

				default:
					break;
			}
		}

		private void Header_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			throw new NotImplementedException();
		}

		private void Rows_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Miscellany

		/// <summary>
		/// Representa la colección de columnas de <see cref="DataTable"/>.
		/// </summary>
		[Serializable]
		public class DataTableColumnCollection : ObservableCollection<DataTableColumn>
		{
			#region Fields

			/// <summary>
			/// Propietario de la colección.
			/// </summary>
			protected readonly DataTable Owner;

			#endregion

			#region Constructor

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="DataTableColumnCollection"/>.
			/// </summary>
			/// <param name="owner"><see cref="DataTable"/> que posee esta colección.</param>
			internal DataTableColumnCollection(DataTable owner)
			{
				this.Owner = owner;
			}

			#endregion
		}

		/// <summary>
		/// Representa la colección de filas de <see cref="DataTable"/>.
		/// </summary>
		[Serializable]
		public class DataTableRowCollection : ObservableCollection<DataTableRow>
		{
			#region Fields

			/// <summary>
			/// Propietario de la colección.
			/// </summary>
			protected readonly DataTable Owner;

			#endregion

			#region Constructor

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="DataTableRowCollection"/>.
			/// </summary>
			/// <param name="owner"><see cref="DataTable"/> que posee esta colección.</param>
			internal DataTableRowCollection(DataTable owner)
			{
				this.Owner = owner;
			}

			#endregion
		}

		#endregion
	}
}