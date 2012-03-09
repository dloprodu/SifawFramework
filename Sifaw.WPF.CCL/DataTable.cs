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
		#region Constructor

		static DataTable()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(DataTable), new FrameworkPropertyMetadata(typeof(DataTable)));
		}

		#endregion
	}
}
