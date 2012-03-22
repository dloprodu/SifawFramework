/*
 * Sifaw.WPF.CCL
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 13/03/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */


using System;
using System.Collections;
using System.Collections.ObjectModel;
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
using System.Collections.Specialized;


namespace Sifaw.WPF.CCL
{
	/// <summary>
	/// Representa una fila <see cref="DataTable"/>.
	/// </summary>
    [TemplatePart(Name = "PART_Cells", Type = typeof(DataTableRowsPresenter))]
    public class DataTableRow : Control
	{
        #region Fields

        private DataTableCellsPresenter CellsPresenter = null;

        #endregion

		#region Dependency Properties

		public static readonly DependencyProperty CellsProperty = DependencyProperty.Register(
			"Cells",
			typeof(DataTableCellCollection),
			typeof(DataTableRow),
			new FrameworkPropertyMetadata(
				null,
				FrameworkPropertyMetadataOptions.AffectsRender));

		#endregion

		#region Properties

		/// <summary>
		/// Obtiene la colección de celdas del <see cref="DataTableRow"/>.
		/// </summary>
		public DataTableCellCollection Cells
		{
			get
			{
                if (GetValue(CellsProperty) == null)
                {
                    Cells = new DataTableCellCollection(this);
                    Cells.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(Cells_CollectionChanged);
                }

				return (DataTableCellCollection)GetValue(CellsProperty);
			}
			protected internal set { SetValue(CellsProperty, value); }
		}

		#endregion

		#region Constructor

		static DataTableRow()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(DataTableRow), new FrameworkPropertyMetadata(typeof(DataTableRow)));
		}

		#endregion

        #region Override Methods

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            CellsPresenter = Template.FindName("PART_Cells", this) as DataTableCellsPresenter;
        }

        #endregion

        #region Collections Event Handlers

        private void Cells_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    CellsPresenter.Items.Add(e.NewItems[0] as UIElement);
                    break;

                case NotifyCollectionChangedAction.Remove:
                    CellsPresenter.Items.Remove(e.OldItems[0] as UIElement);
                    break;

                case NotifyCollectionChangedAction.Reset:
                    CellsPresenter.Items.Clear();
                    break;

                case NotifyCollectionChangedAction.Move:
                case NotifyCollectionChangedAction.Replace:
                default:
                    break;
            }
        }

        #endregion

        #region Miscellany

        /// <summary>
		/// Representa la colección de columnas de <see cref="DataTable"/>.
		/// </summary>
		[Serializable]
        public class DataTableCellCollection : ObservableCollection<DataTableCell>
		{
			#region Fields

			/// <summary>
			/// Propietario de la colección.
			/// </summary>
			protected readonly DataTableRow Owner;

			#endregion

			#region Constructor

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="DataTableCellCollection"/>.
			/// </summary>
			/// <param name="owner"><see cref="DataTableRow"/> que posee esta colección.</param>
			internal DataTableCellCollection(DataTableRow owner)
			{
				this.Owner = owner;
			}

			#endregion
		}

		#endregion
	}
}