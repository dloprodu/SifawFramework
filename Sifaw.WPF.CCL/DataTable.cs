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


namespace Sifaw.WPF.CCL
{
	/// <summary>
	/// Representa un control que permite representar datos en una tabla con cabecera y pie.
	/// Las celdas de la tabla pueden ocupar mas de una fila y/o columna.
	/// </summary>
	public class DataTable : Control
	{
		#region Dependency Properties

		public static readonly DependencyProperty ColumnsProperty = DependencyProperty.Register(
			"Columns",
			typeof(DataTableColumnCollection),
			typeof(DataTable),
			new FrameworkPropertyMetadata(
				null,
				FrameworkPropertyMetadataOptions.AffectsRender));

		#endregion

		#region Properties

		public DataTableColumnCollection Columns
		{
			get { return (DataTableColumnCollection)GetValue(ColumnsProperty); }
			set { SetValue(ColumnsProperty, value); }
		}

		#endregion

		#region Constructor

		static DataTable()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(DataTable), new FrameworkPropertyMetadata(typeof(DataTable)));
		}

		public DataTable()
		{
			Columns = new DataTableColumnCollection(this);
		}

		#endregion

		#region Miscellany

		/// <summary>
		/// Representa la colección de columnas de <see cref="DataTable"/>.
		/// </summary>
		[Serializable]
		public class DataTableColumnCollection : CollectionBase
		{
			#region Fields

			/// <summary>
			/// Propietario de la colección.
			/// </summary>
			protected readonly DataTable Owner;

			#endregion

			#region Properties

			/// <summary>
			/// Obtiene la columna en el índice especificado de la colección.
			/// </summary>
			/// <param name="index">Índice de la columna que se va a recuperar de la colección.</param>
			/// <returns>
			/// <see cref="DataTableColumn"/> que representa la columna
			/// ubicada en el índice especificado de la colección
			/// </returns>
			public DataTableColumn this[int index]
			{
				get { return ((DataTableColumn)List[index]); }
			}

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

			#region Public Methods

			/// <summary>
			/// Agrega un objeto <see cref="DataTableColumn"/> nuevo a la colección.
			/// </summary>
			/// <returns>Índice basado en cero en la colección donde se almacena el elemento.</returns>
			public int Add()
			{
				return (List.Add(new DataTableColumn()));
			}

			/// <summary>
			/// Devuelve el índice de la columna especificada incluida en la colección.
			/// </summary>
			/// <param name="section"><see cref="DataTableColumn"/> que representa la columna que se va a buscar en la colección.</param>
			/// <returns>
			/// Índice de base cero de la ubicación de la columna en la colección.
			/// Si la columna no se encuentra en la colección, el valor devuelto
			/// es -1.
			/// </returns>
			public int IndexOf(DataTableColumn section)
			{
				return (List.IndexOf(section));
			}

			/// <summary>
			/// Inserta una sección existente en la colección, en el índice
			/// especificado.
			/// </summary>
			/// <param name="index">Posición de índice de base cero donde se inserta la columna.</param>
			/// <param name="section">Objeto <see cref="DataTableColumn"/> que se va a insertar en la colección.</param>
			public void Insert(int index, DataTableColumn section)
			{
				List.Insert(index, section);
			}

			/// <summary>
			/// Quita la columna especificado de la colección.
			/// </summary>
			/// <param name="section">
			/// <see cref="DataTableColumn"/> que representa la columna
			/// que se va a quitar de la colección.
			/// </param>
			public void Remove(DataTableColumn section)
			{
				List.Remove(section);
			}

			/// <summary>
			/// Determina si la columna especificado se encuentra en la colección.
			/// </summary>
			/// <param name="section">
			/// <see cref="DataTableColumn"/> que representa la columna 
			/// que se va a buscar en la colección.
			/// </param>
			/// <returns>
			/// true si la colección contiene la columna; en caso contrario, false.
			/// </returns>
			public bool Contains(DataTableColumn section)
			{
				return (List.Contains(section));
			}

			#endregion
		}

		#endregion
	}
}