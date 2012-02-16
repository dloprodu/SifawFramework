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

namespace Sifaw.WPF.Test
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public class Filterable : IFilterable
		{
			public readonly string Value;

			public Filterable(string value)
			{
				Value = value;
			}

			#region IFilterable Members

			public string DisplayFilter
			{
				get { return Value; }
			}

			public object ValueFilter
			{
				get { return Value; }
			}

			#endregion

			#region IComparable Members

			public int CompareTo(object obj)
			{
				return Value.CompareTo((obj as Filterable).Value);
			}

			#endregion

			#region IComparable<IFilterable> Members

			public int CompareTo(IFilterable other)
			{
				return Value.CompareTo((other as Filterable).Value);
			}

			#endregion

			#region IEquatable<IFilterable> Members

			public bool Equals(IFilterable other)
			{
				return Value.Equals(other.DisplayFilter);
			}

			#endregion
		}

		public MainWindow()
		{
			InitializeComponent();

			Filterable[] list = new Filterable[]
			{
				new Filterable("Z Fin ..."),
				new Filterable("A Uno ..."),
				new Filterable("B Dos ..."),
				new Filterable("C Tres ..."),
				new Filterable("D Cuatro ..."),
				new Filterable("E Cinco ..."),
				new Filterable("F Seis ..."),
				new Filterable("Exit ...")
			};

			enumFilter1.Orientation = Orientation.Vertical;
			enumFilter1.Add(list);
			enumFilter1.Width = double.NaN;
			enumFilter1.Height = double.NaN;
		}
	}
}
