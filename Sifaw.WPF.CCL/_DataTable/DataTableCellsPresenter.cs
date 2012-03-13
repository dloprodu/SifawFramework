﻿/*
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
	/// Se usa en la plantilla de un control <see cref="DataTable"/> para especificar la ubicación en el árbol visual del 
	/// control donde se van a agregar las celdas de tabla.
	/// </summary>
	public class DataTableCellsPresenter : ItemsControl
	{
		#region Constructor

		static DataTableCellsPresenter()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(DataTableCellsPresenter), new FrameworkPropertyMetadata(typeof(DataTableCellsPresenter)));
		}

		#endregion
	}
}