using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Controllers.Components;
using Sifaw.Views.Components;
using Sifaw.Views;


namespace Sifaw.WPF.Test
{
	public class UITableTestController : UITableController<UITableTestController.Input, UITableTestController.Output>
	{
		#region Input / Output

		/// <summary>
		/// Parámetros de entrada de las controladora.
		/// </summary>
		[Serializable]
		public new class Input : UITableController
			< Input
			, Output>.Input
		{
			#region Constructor

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UITableController{TInput, TOutput}.Input"/>.
			/// </summary>
			public Input()
			{
			}

			#endregion
		}

		/// <summary>
		/// Parámetros de retorno de la controladora.
		/// </summary>
		[Serializable]
		public new class Output : UITableController
			< Input
			, Output>.Output
		{
			#region Constructor

			/// <summary>
			/// Inicializa una nueva instancia de la clase <see cref="UITableController{TInput, TOutput}.Output"/>.
			/// </summary>
			public Output()
			{
			}

			#endregion
		}

		#endregion

		#region Constructor
				
		public UITableTestController()
			: base()
		{
		}

		public UITableTestController(AbstractUILinker<TableComponent> linker)
			: base(linker)
		{
		}

		#endregion

		#region Table Methos

		protected override int GetNumberOfHeaderRows(string table)
		{
			return 1;
		}

		protected override int GetNumberOfFooterRows(string table)
		{
			return 1;
		}

		protected override int GetNumberOfSectionsAt(string table, out UITableSection.UISettings settings)
		{
			settings = UITableSection.UISettings.Default;
			return 2;
		}

		protected override int GetNumberOfRowsAt(string table, int section)
		{
			return 2;
		}

		protected override UITableCell[] GetHeaderAt(string table, int row)
		{
			return new UITableCell[]
			{
				  new UITableTextCell("Foto", "Foto Alumno", UITableCell.UISettings.Default, 2, 1)
				, new UITableTextCell("Detalle", "Detalle alumno", UITableCell.UISettings.Default, 1, 1)
			};
		}

		protected override UITableCell[] GetCellsAt(UIIndexRowPath path)
		{
			switch (path.Row)
			{
				case 0:
					return new UITableCell[]
					{
						  new UITableTextCell("Foto", "Foto Alumno " + path.Row.ToString(), UITableCell.UISettings.Default, 2, 1)
						, new UITableTextCell("Detalle", "Detalle alumno " + path.Row.ToString(), UITableCell.UISettings.Default, 1, 1)
					};

				case 1:
					return new UITableCell[]
					{
						  new UITableTextCell("Detalle", "Detalle alumno" + path.Row.ToString(), UITableCell.UISettings.Default, 1, 1)
					};
			}

			return null;
		}

		protected override bool RowContainChildTable(UIIndexRowPath path)
		{
			return false;
		}

		protected override string GetChildTableNameAt(UIIndexRowPath path)
		{
			return null;
		}

		protected override UITableCell[] GetFooterAt(string table, int row)
		{
			return new UITableCell[] { new UITableTextCell("Pie", "Texto del pie", UITableCell.UISettings.Default, 1, 3) };
		}

		#endregion

		#region Default Input / Output

		public override Input GetDefaultInput()
		{
			return new Input();
		}

		public override Input GetResetInput()
		{
			return new Input();
		}

		protected override Output GetDefaultOutput()
		{
			return new Output();
		}

		#endregion

		#region Start Methods

		protected override void StartController()
		{
			
		}

		protected override void ResetController()
		{
			
		}

		#endregion
	}
}