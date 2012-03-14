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
using System.Collections;


namespace Sifaw.WPF.CCL
{
	/// <summary>
	/// Representa una fila <see cref="DataTable"/>.
	/// </summary>
	public class DataTableRow : Control
	{
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
					Cells = new DataTableCellCollection(this);

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

		#region Miscellany

		/// <summary>
		/// Representa la colección de columnas de <see cref="DataTable"/>.
		/// </summary>
		[Serializable]
		public class DataTableCellCollection : CollectionBase
		{
			#region Fields

			/// <summary>
			/// Propietario de la colección.
			/// </summary>
			protected readonly DataTableRow Owner;

			#endregion

			#region Properties

			/// <summary>
			/// Obtiene la celda en el índice especificado de la colección.
			/// </summary>
			/// <param name="index">Índice de la celda que se va a recuperar de la colección.</param>
			/// <returns>
			/// <see cref="DataTableCell"/> que representa la celda
			/// ubicada en el índice especificado de la colección
			/// </returns>
			public DataTableCell this[int index]
			{
				get { return ((DataTableCell)List[index]); }
			}

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

			#region Public Methods

			/// <summary>
			/// Agrega un objeto <see cref="DataTableCell"/> nuevo a la colección.
			/// </summary>
			/// <returns>Índice basado en cero en la colección donde se almacena el elemento.</returns>
			public int Add()
			{
				return (List.Add(new DataTableCell()));
			}

			/// <summary>
			/// Devuelve el índice de la celda especificada incluida en la colección.
			/// </summary>
			/// <param name="cell"><see cref="DataTableCell"/> que representa la celda que se va a buscar en la colección.</param>
			/// <returns>
			/// Índice de base cero de la ubicación de la celda en la colección.
			/// Si la celda no se encuentra en la colección, el valor devuelto
			/// es -1.
			/// </returns>
			public int IndexOf(DataTableCell cell)
			{
				return (List.IndexOf(cell));
			}

			/// <summary>
			/// Inserta una sección existente en la colección, en el índice
			/// especificado.
			/// </summary>
			/// <param name="index">Posición de índice de base cero donde se inserta la celda.</param>
			/// <param name="cell">Objeto <see cref="DataTableCell"/> que se va a insertar en la colección.</param>
			public void Insert(int index, DataTableCell cell)
			{
				List.Insert(index, cell);
			}

			/// <summary>
			/// Quita la celda especificado de la colección.
			/// </summary>
			/// <param name="cell">
			/// <see cref="DataTableCell"/> que representa la celda
			/// que se va a quitar de la colección.
			/// </param>
			public void Remove(DataTableCell cell)
			{
				List.Remove(cell);
			}

			/// <summary>
			/// Determina si la celda especificado se encuentra en la colección.
			/// </summary>
			/// <param name="cell">
			/// <see cref="DataTableCell"/> que representa la celda 
			/// que se va a buscar en la colección.
			/// </param>
			/// <returns>
			/// true si la colección contiene la celda; en caso contrario, false.
			/// </returns>
			public bool Contains(DataTableCell cell)
			{
				return (List.Contains(cell));
			}

			#endregion
		}

		#endregion
	}
}