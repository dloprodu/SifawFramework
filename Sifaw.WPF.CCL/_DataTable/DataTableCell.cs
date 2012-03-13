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
	/// Representa una celda de un control <see cref="DataTable"/>.
	/// </summary>
	public class DataTableCell : ContentControl
	{
		#region Dependency Properties

		public static readonly DependencyProperty RowSpanProperty = DependencyProperty.Register(
			"RowSpan",
			typeof(int),
			typeof(DataTableCell),
			new FrameworkPropertyMetadata(
				(int)1,
				FrameworkPropertyMetadataOptions.AffectsRender,
				new PropertyChangedCallback(DataTableCell.OnRowSpanChanged),
				new CoerceValueCallback(DataTableCell.CoerceRowSpan))
			, new ValidateValueCallback(DataTableCell.IsValidRowSpan));

		public static readonly DependencyProperty ColumnSpanProperty = DependencyProperty.Register(
			"ColumnSpan",
			typeof(int),
			typeof(DataTableCell),
			new FrameworkPropertyMetadata(
				(int)1,
				FrameworkPropertyMetadataOptions.AffectsRender,
				new PropertyChangedCallback(DataTableCell.OnColumnSpanChanged),
				new CoerceValueCallback(DataTableCell.CoerceColumnSpan))
			, new ValidateValueCallback(DataTableCell.IsValidColumnSpan));

		#endregion

		#region Properties

		public int RowSpan
		{
			get { return (int)GetValue(RowSpanProperty); }
			set { SetValue(RowSpanProperty, value); }
		}

		public int ColumnSpan
		{
			get { return (int)GetValue(ColumnSpanProperty); }
			set { SetValue(ColumnSpanProperty, value); }
		}

		#endregion

		#region Constructor

		static DataTableCell()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(DataTableCell), new FrameworkPropertyMetadata(typeof(DataTableCell)));
		}

		#endregion

		#region Changed Methods

		private void OnRowSpanChanged(int oldValue, int newValue)
		{
			/* Empty */
		}

		private void OnColumnSpanChanged(int oldValue, int newValue)
		{
			/* Empty */
		}

		#endregion

		#region Factory Methods

		#region Coerce

		private static object CoerceRowSpan(DependencyObject d, object value)
		{
			//DataTableCell cell = (DataTableCell)d;

			if ((int)value < 1)
			{
				return 1;
			}

			//if ((byte)value > cell.Parent.Rows.Count)
			//{
			//    return cell.Parent.Rows.Count;
			//}

			return value;
		}

		private static object CoerceColumnSpan(DependencyObject d, object value)
		{
			//DataTableCell cell = (DataTableCell)d;

			if ((int)value < 1)
			{
				return 1;
			}

			//if ((byte)value > cell.Parent.Columns.Count)
			//{
			//    return cell.Parent.Columns.Count;
			//}

			return value;
		}	

		#endregion

		#region IsValid

		private static bool IsValidRowSpan(object value)
		{
			return ((int)value >= 1);
		}

		private static bool IsValidColumnSpan(object value)
		{
			return ((int)value >= 1);
		}

		#endregion

		#region OnSelectedChanged

		private static void OnRowSpanChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			(d as DataTableCell).OnRowSpanChanged((int)e.OldValue, (int)e.NewValue);
		}

		private static void OnColumnSpanChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			(d as DataTableCell).OnColumnSpanChanged((int)e.OldValue, (int)e.NewValue);
		}

		#endregion

		#endregion
	}
}