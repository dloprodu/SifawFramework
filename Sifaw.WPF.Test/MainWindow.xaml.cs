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
using System.Windows.Shapes;
using Sifaw.Views.Components;

using Sifaw.WPF.CCL;


namespace Sifaw.WPF.Test
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

            Label label1 = new Label();
            label1.Content = "Label1";
            label1.Background = Brushes.Red;

            Label label2 = new Label();
            label2.Content = "Label2";
            label2.Background = Brushes.Red;

            DataTableCell cell1 = new DataTableCell();
            cell1.Content = label1;
            DataTableCell cell2 = new DataTableCell();
            cell2.Content = label2;

            DataTableRow row = new DataTableRow();

            row.Cells.Add(cell1);
            row.Cells.Add(cell2);

            tableControl1.Header.Add(row);
		}
	}
}
