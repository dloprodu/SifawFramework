/*
 * Sifaw.Controllers.Components
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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Core.Utilities;

using Sifaw.Views;
using Sifaw.Views.Components;


namespace Sifaw.Controllers.Components
{
	/// <summary>
	/// Controladora base que da soporte a la implementación de componentes para realizar filtros sobre listas.
	/// </summary>
    /// <typeparam name="TInput">
    /// Tipo para establecer los parámetros de inicio de la controladora. Ha de ser serializable y 
    /// derivar de <see cref="UIListFilterBaseController{TInput, TOutput, TFilter, TSource, TComponent}.Input"/>.
    /// </typeparam>
    /// <typeparam name="TOutput">
    /// Tipo para establcer los parametros de retorno cuando finaliza la controladora. Ha de ser serializable y 
    /// derivar de <see cref="UIListFilterBaseController{TInput, TOutput, TFilter, TSource, TComponent}.Output"/>.
    /// </typeparam>
    /// <typeparam name="TFilter">
	/// Tipo del filtro que devolverá la controladora.
	/// </typeparam>
	/// <typeparam name="TSource">
	/// Tipo de la lista sobre la que se aplicarán los filtros. 
	/// Ha de implementar <see cref="IList{IFilterable}"/>.</typeparam>
	/// <typeparam name="TComponent">
	/// Tipo para establecer el elemento de interfaz de usuario de la controladora. 
	/// Ha de implementar <see cref="ListFilterBaseComponent{TFilter, TSource}"/>.
	/// </typeparam>
	public abstract class UIListFilterBaseController<TInput, TOutput, TFilter, TSource, TComponent> : UIFilterBaseController
		< TInput
        , TOutput
        , TFilter
		, TComponent>
        where TInput     : UIListFilterBaseController<TInput, TOutput, TFilter, TSource, TComponent>.Input
        where TOutput    : UIListFilterBaseController<TInput, TOutput, TFilter, TSource, TComponent>.Output
        where TSource    : IList<IFilterable>
		where TComponent : ListFilterBaseComponent<TFilter, TSource>
	{
        #region Input / Output

        /// <summary>
        /// Parámetros de entrada de la controladora.
        /// </summary>
        [Serializable]
        public abstract new class Input :  UIFilterBaseController
		    < TInput
            , TOutput
            , TFilter
		    , TComponent>.Input
        {
            #region Fields

            private TSource _source;

            #endregion

            #region Properties

            /// <summary>
            /// Obtiene la lista sobre la que se realizará el filtro.
            /// </summary>
            public TSource Source
            {
                get { return _source; }
            }

            #endregion

            #region Constructors

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIListFilterBaseController{TInput, TOutput, TFilter, TSource, TComponent}.Input"/>,
            /// estableciendo un valores en la propiedad <see cref="Source"/> y
            /// <see cref="UIFilterBaseController{TInput, TOutput, TFilter, TComponent}.Filter"/>.
            /// </summary>
            /// <param name="source">Lista sobre la que se realizara el filtro.</param>
            /// <param name="filter">Filtro a aplicar al iniciar la controladora.</param>
            protected Input(TSource source, TFilter filter)
                : base(filter)
            {
                _source = (TSource)(new List<IFilterable>() as IList<IFilterable>);

                if (source != null)
                {
                    (_source as List<IFilterable>).AddRange(source);
                    (_source as List<IFilterable>).Sort();
                }
            }

            #endregion
        }

        /// <summary>
        /// Parámetros de retorno de la controladora.
        /// </summary>
        [Serializable]
        public abstract new class Output :  UIFilterBaseController
		    < TInput
            , TOutput
            , TFilter
		    , TComponent>.Output
        {
            #region Constructors

            /// <summary>
            /// Inicializa una nueva instancia de la clase <see cref="UIFilterBaseController{TInput, TOutput, TFilter, TComponent}.Output"/>,
            /// estableciendo un valor en la propiedad <see cref="UIFilterBaseController{TInput, TOutput, TFilter, TComponent}.Filter"/>.
            /// </summary>
            /// <param name="filter">Filtro al finalizar la controladora.</param>
            protected Output(TFilter filter)
                : base(filter)
            {
            }

            #endregion
        }

        #endregion

		#region Constructors

		/// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UIListFilterBaseController{TInput, TOutput, TFilter, TSource, TComponent}"/>.
		/// Establece como <see cref="AbstractUILinker{TUIElement}"/> aquel establecido por defecto a través de 
		/// <see cref="AbstractUIProviderManager{TLinker}"/>.
		/// </summary>
		protected UIListFilterBaseController()
			: base()
		{
		}

		/// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="UIListFilterBaseController{TInput, TOutput, TFilter, TSource, TComponent}"/>, 
		/// estableciendo el <see cref="AbstractUILinker{TUIElement}"/> especificado como valor de la propiedad 
		/// <see cref="UIElementController{TInput, TOutput, TUIElement}.Linker"/> donde <c>TUIElement</c>
		/// implementa <see cref="ListFilterBaseComponent{TFilter, TSource}"/>.
		/// </summary>
		protected UIListFilterBaseController(AbstractUILinker<TComponent> linker)
			: base(linker)
		{
		}

		#endregion

        #region Start Methods

        /// <summary>
        /// Invoca al método sobrescirto <see cref="Controller{TInput, TOutput}.OnAfterStartController()"/> y
        /// posteriormente establece la configuración inicial de <see cref="FilterBaseComponent{TFilter}"/>.
        /// </summary>
        protected override void OnAfterStartController()
        {
			/* Antes de aplicar el filtro añadimos el origen de datos. */
			UIElement.Add(Parameters.Source);
            
			base.OnAfterStartController();            
        }

        #endregion
    }
}