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
	/// Representa una fila <see cref="DataTable"/>.
	/// </summary>
	public class DataTableRow : Control
	{
		#region Constructor

		static DataTableRow()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(DataTableRow), new FrameworkPropertyMetadata(typeof(DataTableRow)));
		}

		#endregion
	}
}