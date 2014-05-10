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
	public interface UILinkers 
		/****************************************************************/
		/* Lista de linker´s de controladoras con vistas y componentes. */
		/****************************************************************/	
		// • Componentes 
		: UILinker<ShellComponent>
        , UILinker<ShellConfirmComponent>
		, UILinker<BackgroundWorkerComponent>
        , UILinker<LabelComponent>
		, UILinker<TabHostComponent>
		, UILinker<AssistantComponent>
		, UILinker<TextFilterComponent>
		, UILinker<BoolFilterComponent>
		, UILinker<ListFilterComponent>
		, UILinker<EnumFilterComponent>
		, UILinker<DropDownListFilterComponent>
        , UILinker<DataListComponent<Guid>>
        , UILinker<DataListComponent<string>>
        , UILinker<DataListComponent<int>>
						
		// • Vistas 		 
		, UILinker<ShellView>
        , UILinker<ShellConfirmView>
	{
		/* Empty */
	}
}