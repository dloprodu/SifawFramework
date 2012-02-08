///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// EnumControl.cs
/// 
/// Diseñador: David López Rguez
/// Programador: David López Rguez
/// </sumary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 08/02/2012: Creación de controladora.
/// 
/// ===============================================================================================
/// Observaciones:
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



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

using Sifaw.Views;
using Sifaw.Views.Components;
using Sifaw.Views.Components.Filters;


namespace Sifaw.WPF
{
	/// <summary>
	/// Representa un control que implementa el componente <see cref=""/>.
	/// </summary>
	public partial class EnumControl : UserControl, EnumComponentFilter
	{
		#region Constructor

		public EnumControl()
		{
			InitializeComponent();
		}

		#endregion
		
		#region ComponentListFilterBase<IFilterable,IList<IFilterable>> Members

		public void Add(IList<IFilterable> source)
		{
			UIShellRow[] rows = new UIShellRow[source.Count];

			for (int i = 0; i < source.Count; i++)
			{
				//UIShellRowCell cell = new UIShellRowCell(

				rows[i] = new UIShellRow(double.NaN, UILengthModes.Auto, null);
			}

			shell.SetSettings(rows);
		}

		#endregion

		#region ComponentFilterBase<IFilterable> Members

		public IFilterable Filter
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public event UIFilterChangedEventHandler<IFilterable> FilterChanged;
		private void OnFilterChanged(UIFilterChangedEventArgs<IFilterable> e)
		{
			if (FilterChanged != null)
				FilterChanged(this as ComponentFilterBase<IFilterable>, e);
		}

		#endregion

		#region UIElement Members

		#region Propiedades

		private string _denomination = string.Empty;
		public string Denomination
		{
			get { return _denomination; }
			set { _denomination = value; }
		}

		private string _description = string.Empty;
		public string Description
		{
			get { return _description; }
			set { _description = value; }
		}

		#endregion

		#region Métodos

		public void Refresh()
		{
			/* Emtpy */
		}

		public void Reset()
		{
			/* Emtpy */
		}

		public void SetLikeActive()
		{
			shell.Focus();
		}

		#endregion

		#endregion
	}
}