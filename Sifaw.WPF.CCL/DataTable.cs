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
    [TemplatePart(Name = "PART_Header", Type = typeof(ListBox))]
    [TemplatePart(Name = "PART_Rows", Type = typeof(ListBox))]
	public class DataTable : Control
	{
		#region Fields

        private ListBox HeaderPresenter = null;
        private ListBox RowsPresenter = null;

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

            if (HeaderPresenter == null)
            {
                HeaderPresenter = Template.FindName("PART_Header", this) as ListBox;

                foreach (DataTableRow row in Header)
                    HeaderPresenter.Items.Add(row);
            }

            if (RowsPresenter == null)
            {
                RowsPresenter = Template.FindName("PART_Rows", this) as ListBox;

                foreach (DataTableRow row in Rows)
                    RowsPresenter.Items.Add(row);
            }
		}

		#endregion

		#region Public Methods

		public void Clean()
		{
            Columns.Clear();
            Header.Clear();
            Rows.Clear();
		}

		#endregion

		#region Collections Event Handlers

		private void Columns_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
            // Depedency Property -> FrameworkPropertyMetadataOptions.AffectsRender
            // InvalidateVisual();			
		}

		private void Header_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
            if (HeaderPresenter != null)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        HeaderPresenter.Items.Add(e.NewItems[0] as DataTableRow);
                        break;

                    case NotifyCollectionChangedAction.Remove:
                        HeaderPresenter.Items.Remove(e.OldItems[0] as DataTableRow);
                        break;

                    case NotifyCollectionChangedAction.Reset:
                        HeaderPresenter.Items.Clear();
                        break;

                    case NotifyCollectionChangedAction.Move:
                    case NotifyCollectionChangedAction.Replace:
                    default:
                        break;
                }
            }
		}

		private void Rows_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
		{
            if (RowsPresenter != null)
            {
                switch (e.Action)
                {
                    case NotifyCollectionChangedAction.Add:
                        RowsPresenter.Items.Add(e.NewItems[0] as DataTableRow);
                        break;

                    case NotifyCollectionChangedAction.Remove:
                        RowsPresenter.Items.Remove(e.OldItems[0] as DataTableRow);
                        break;

                    case NotifyCollectionChangedAction.Reset:
                        RowsPresenter.Items.Clear();
                        break;

                    case NotifyCollectionChangedAction.Move:
                    case NotifyCollectionChangedAction.Replace:
                    default:
                        break;
                }
            }
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