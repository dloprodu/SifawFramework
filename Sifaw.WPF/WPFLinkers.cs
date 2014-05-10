/*
 * Sifaw.WPF
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 09/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Views;
using Sifaw.Views.Components;
using Sifaw.Views.Components.Filters;

using Sifaw.WPF.Filters;


namespace Sifaw.WPF
{
	/// <summary>
	/// Implementación WPF del proveedor de componentes y vistas 
	/// <see cref="UILinkers"/> para Sifaw Framework.
	/// </summary>
	public class WPFLinkers : UILinkers
	{
		#region Controles

		public void Create(out ShellComponent ui)
		{
			ui = new ShellControl();
		}

        public void Create(out ShellConfirmComponent ui)
        {
            ui = new ShellConfirmControl();
        }

		public void Create(out BackgroundWorkerComponent ui)
		{
			ui = new BackgroundWorkerControl();
		}

		public void Create(out TabHostComponent ui)
		{
			ui = new TabHostControl();
		}

		public void Create(out AssistantComponent ui)
		{
			ui = new AssistantControl();
		}

		public void Create(out TextFilterComponent ui)
		{
			ui = new TextFilterControl();
		}

		public void Create(out BoolFilterComponent ui)
		{
			ui = new BoolFilterControl();
		}

		public void Create(out ListFilterComponent ui)
		{
			ui = new ListFilterControl();
		}

		public void Create(out EnumFilterComponent ui)
		{			
			ui = new EnumFilterControl();
		}

		public void Create(out DropDownListFilterComponent ui)
		{
			ui = new DropDownListFilterControl();
		}

        public void Create(out DataListComponent<Guid> ui)
        {
            ui = new DataListGuidValueControl();
        }

        public void Create(out DataListComponent<string> ui)
        {
            ui = new DataListStringValueControl();
        }

        public void Create(out DataListComponent<int> ui)
        {
            ui = new DataListIntValueControl();
        }

        public void Create(out LabelComponent ui)
        {
            ui = new LabelControl();
        }

		#endregion

		#region Vistas

		public void Create(out ShellView ui)
		{
			ui = new ShellWindow();
		}

        public void Create(out ShellConfirmView ui)
        {
            ui = new ShellConfirmWindow();
        }

		#endregion
    }
}