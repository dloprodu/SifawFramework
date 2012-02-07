/////////////////////////////////////////////////////////////
/// <summary>
/// AbstractViewLink.cs
/// 
/// Dise�ador:     David L�pez Rguez
/// Programadores: David L�pez Rguez
/// </summary>
/// <remarks>
/// ========================================================
/// Historial de versiones:
///   - 14/12/2011 -- Creaci�n de la clase.
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
using Sifaw.Views.Components.Filters;


namespace Sifaw.Controllers
{
	/// <summary>
	/// Proveedor de enlaces de carga de vistas para las controladoras
	/// con vistas.
	/// </summary>
	/// <remarks>
	/// Sigue el patr�n de dise�o 'Abstract Factory (F�brica abstractra)' para crear
	/// interfaces gr�ficas.
	/// </remarks>
	public interface AbstractUIProvider 
		/* Lista de linker�s de controladoras con vistas y componentes. */

		/* 
		 * Componentes 
		 */
		: AbstractUILinker<BackgroundWorkerComponent>
		, AbstractUILinker<AssistantComponent>
		, AbstractUILinker<FiltersGroupComponent>
		, AbstractUILinker<TextComponentFilter>
		, AbstractUILinker<BoolComponentFilter>
		, AbstractUILinker<ListComponentFilter>
		, AbstractUILinker<EnumComponentFilter>
		, AbstractUILinker<DropDownListComponentFilter>
		
		/* 
		 * Vistas 
		 */
		, AbstractUILinker<UIShellView>
	{
		/* Empty */
	}
}