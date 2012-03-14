/*
 * Sifaw.WPF
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 08/03/2012: Creación de la clase.
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

using Sifaw.Views;
using Sifaw.Views.Kit;
using Sifaw.Views.Components;
using Sifaw.WPF.CCL;


namespace Sifaw.WPF
{
	/// <summary>
	/// Representa un control que permite mostrar tablas del tipo <see cref="UITable"/>.
	/// </summary>
	public class TableControl : DataTable, TableComponent
	{
		#region Constructor

		static TableControl()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(TableControl), new FrameworkPropertyMetadata(typeof(TableControl)));
		}

		#endregion

		#region TableComponent Members

		#region Properties

		private TableControlSettings _uiSettings = null;
		public TableSettings UISettings
		{
			get 
			{
				if (_uiSettings == null)
					_uiSettings = new TableControlSettings(this);

				return _uiSettings;
			}
		}

		#endregion

		#region Methods

		public void SetTable(UITable table)
		{
			// ...
		}

		#endregion

		#region Events

		public event UITableSectionRowSelectedEventHandler RowSelected;
		private void OnRowSelected(UITableSectionRowSelectedEventArgs e)
		{
			if (RowSelected != null)
				RowSelected(this as TableComponent, e);
		}

		#endregion

		#endregion

		#region UIComponent Members

		ComponentSettings UIComponent.UISettings
		{
			get { return UISettings; }
		}

		#endregion

		#region UIElement Members

		UISettings Views.UIElement.UISettings
		{
			get { return UISettings; }
		}

		public void Refresh()
		{
			
		}

		public void Reset()
		{
			
		}

		public void SetLikeActive()
		{
			Focus();
		}

		#endregion

		#region Miscellany

		[Serializable]
		public class TableControlSettings : ControlSettings, TableSettings
		{
			#region Fields

			private double _indent = 0;

			#endregion

			#region Properties

			/// <summary>
			/// Obtiene o establece la identación de las tablas anidadas.
			/// </summary>
			public double Indent
			{
				get { return _indent; }
				set
				{
					if (_indent != value)
					{
						_indent = value;
						OnPropertyChanged(() => Indent);
					}
				}
			}

			#endregion

			#region Constructor

			public TableControlSettings(TableControl control)
				: base(control)
			{
				// UtilWPF.BindField(this, "Indent", control, TableControl.IndentProperty, BindingMode.TwoWay);
			}

			#endregion
		}

		#endregion
	}
}