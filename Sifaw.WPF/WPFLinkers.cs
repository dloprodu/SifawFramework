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

		public void Load(out ShellComponent ui)
		{
			ui = new ShellControl();
		}

		public void Load(out BackgroundWorkerComponent ui)
		{
			ui = new BackgroundWorkerControl();
		}

		public void Load(out TabHostComponent ui)
		{
			ui = new TabHostControl();
		}

		public void Load(out AssistantComponent ui)
		{
			ui = new AssistantControl();
		}

		public void Load(out TextFilterComponent ui)
		{
			ui = new TextFilterControl();
		}

		public void Load(out BoolFilterComponent ui)
		{
			ui = new BoolFilterControl();
		}

		public void Load(out ListFilterComponent ui)
		{
			ui = new ListFilterControl();
		}

		public void Load(out EnumFilterComponent ui)
		{			
			ui = new EnumFilterControl();
		}

		public void Load(out DropDownListFilterComponent ui)
		{
			ui = new DropDownListFilterControl();
		}

		#endregion

		#region Vistas

		public void Load(out ShellView ui)
		{
			ui = new ShellWindow();
		}

		#endregion
	}
}