///////////////////////////////////////////////////////////////////////////////////////////////////
/// <summary>
/// Implementación del AbstractViewProvider para WPF.
/// 
/// Diseñador:     David López Rguez
/// Programadores: David López Rguez
///	
/// </summary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 23/12/2011 -- Creación de la clase.
/// ===============================================================================================
/// Observaciones:
/// 
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Controllers;

using Sifaw.Views;
using Sifaw.Views.Components;
using Sifaw.Views.Components.Filters;


namespace Sifaw.WPF
{
	/// <summary>
	/// Implementación WPF del proveedor de componentes y vistas 
	/// <see cref="AbstractUIProvider"/> para Sifaw Framework.
	/// </summary>
	public class WPFProvider : AbstractUIProvider
	{
		#region Controles

		public void Get(out ShellComponent ui)
		{
			ui = new ShellControl();
		}

		public void Get(out BackgroundWorkerComponent ui)
		{
			ui = new BackgroundWorkerControl();
		}

		public void Get(out AssistantComponent ui)
		{
			ui = new AssistantControl();
		}

		public void Get(out TextFilterComponent ui)
		{
			ui = new TextFilterControl();
		}

		public void Get(out BoolFilterComponent ui)
		{
			ui = new BoolFilterControl();
		}

		public void Get(out ListFilterComponent ui)
		{
			ui = new ListFilterControl();
		}

		public void Get(out EnumFilterComponent ui)
		{			
			ui = new EnumFilterControl();
		}

		public void Get(out DropDownListFilterComponent ui)
		{
			ui = new DropDownListFilterControl();
		}
		
		#endregion

		#region Vistas

		public void Get(out ShellView ui)
		{
			ui = new ShellWindow();
		}

		#endregion
	}
}