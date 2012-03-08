/*
 * Sifaw.Views
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 08/02/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;

using Sifaw.Views;
using Sifaw.Views.Components;
using Sifaw.Views.Components.Filters;


namespace Sifaw.Views
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
		/****************************************************************/
		/* Lista de linker´s de controladoras con vistas y componentes. */
		/****************************************************************/	
		// • Componentes 
		: AbstractUILinker<ShellComponent>
		, AbstractUILinker<BackgroundWorkerComponent>
		, AbstractUILinker<TabHostComponent>
		, AbstractUILinker<AssistantComponent>
		, AbstractUILinker<TextFilterComponent>
		, AbstractUILinker<BoolFilterComponent>
		, AbstractUILinker<ListFilterComponent>
		, AbstractUILinker<EnumFilterComponent>
		, AbstractUILinker<DropDownListFilterComponent>
		, AbstractUILinker<TableComponent>
						
		// • Vistas 		 
		, AbstractUILinker<ShellView>
	{
		/* Empty */
	}
}