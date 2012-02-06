/////////////////////////////////////////////////////////////
/// <summary>
/// AbstractViewLink.cs
/// 
/// Diseñador:     David López Rguez
/// Programadores: David López Rguez
/// </summary>
/// <remarks>
/// ========================================================
/// Historial de versiones:
///   - 14/12/2011 -- Creación de la clase.
/// 
/// ========================================================
/// Observaciones:
/// 
/// </remarks>
////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;

using Sifaw.Controllers.Components;
using Sifaw.Controllers.Test;

using Sifaw.Views.Components;
using Sifaw.Views;


namespace Sifaw.Controllers
{
	/// <summary>
	/// Proveedor de enlaces de carga de vistas para las controladoras
	/// con vistas.
	/// </summary>
	/// <remarks>
	/// Sigue el patrón de diseño 'Abstract Factory (Fábrica abstractra)' para crear
	/// interfaces gráficas.
	/// </remarks>
	public interface AbstractUIProvider 
		/* Lista de linker´s de controladoras con vistas y componentes. */

		/* 
		 * Componentes 
		 */
		: AbstractUILinker<BackgroundWorkerComponent>
		, AbstractUILinker<AssistantComponent>
		, AbstractUILinker<FiltersGroupComponent>
		, AbstractUILinker<ComponentFilter<string>>
		, AbstractUILinker<ComponentFilter<bool>>
		, AbstractUILinker<ComponentFilter<IList<IFilterable>>>
		
		/* 
		 * Vistas 
		 */
		, AbstractUILinker<UIShellView>
	{
		/* Empty */
	}
}