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
using Sifaw.Views.Components;
using Sifaw.Views;


namespace Sifaw.WPF
{
	/// <summary>
	/// Implementación WPF del proveedor de componentes y vistas 
	/// <see cref="AbstractUIProvider"/>  para Sifaw Framework.
	/// </summary>
	public class WPFProvider : AbstractUIProvider
	{
		#region Controles

		public void Get(out BackgroundWorkerComponent ui)
		{
			ui = new BackgroundWorkerControl();
		}

		public void Get(out AssistantComponent ui)
		{
			ui = new AssistantControl();
		}

		public void Get(out FiltersGroupComponent ui)
		{
			// TODO: FiltersGroupComponent
			throw new NotImplementedException();
		}

		public void Get(out ComponentFilter<string> ui)
		{
			ui = new TextFilter();
		}

		public void Get(out ComponentFilter<bool> ui)
		{
			ui = new BoolFilter();
		}

		public void Get(out ComponentFilter<IList<IFilterable>> ui)
		{
			throw new NotImplementedException();
		}
		
		#endregion

		#region Vistas

		public void Get(out UIShellView ui)
		{
			ui = new ShellWindow();
		}

		#endregion
	}
}