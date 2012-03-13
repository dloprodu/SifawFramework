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


namespace Sifaw.WPF.CCL
{
	/// <summary>
	/// Representa un panel que pone celdas en una cuadrícula de datos.
	/// </summary>
	/// <remarks>
	/// El <see cref="DataTableCellsPanel"/> se utiliza como ItemsPanel del <see cref="DataTableCellsPresenter"/> para disponer las celdas en una fila. 
	/// Se utiliza como ItemsPanel de <see cref="DataTableHeadersPresenter"/> para la disposición de los encabezados. El panel organiza las 
	/// celdas horizontalmente y usa la información de columna de cada celda para determinar el tamaño correcto de cada celda.
	/// </remarks>
	public class DataTableCellsPanel : VirtualizingPanel
	{
		#region Constructor

		static DataTableCellsPanel()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(DataTableCellsPanel), new FrameworkPropertyMetadata(typeof(DataTableCellsPanel)));
		}

		#endregion
	}
}