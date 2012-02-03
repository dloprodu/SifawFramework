///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// Controladora que permite realizar algún tipo de filtro.
/// 
/// Diseñador: David López Rguez
/// Programador: David López Rguez
/// </sumary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 27/01/2012: Creación de controladora.
/// 
/// ===============================================================================================
/// Observaciones:
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Views.Components;


namespace Sifaw.Controllers.Components.Filters
{
	public class UITextFilterController : UIFilterController
		< UITextFilterController.Input
		, UITextFilterController.Output
		, string
		, UITextFilterController.UISettingsContainer
		, FilterComponent<string>>
	{
		#region Parametros de inicio / finalización

		/// <summary>
		/// Parámetros de entrada de la controladora.
		/// </summary>
		[Serializable]
		public new class Input : UIFilterController
			< Input
			, Output
			, string
			, UISettingsContainer
			, FilterComponent<string>>.Input
		{
			#region Constructor

			public Input(string filter)
				: base(filter)
			{
			}

			#endregion
		}

		/// <summary>
		/// Parámetros de retorno de la controladora.
		/// </summary>
		[Serializable]
		public new class Output : UIFilterController
			< Input
			, Output
			, string
			, UISettingsContainer
			, FilterComponent<string>>.Output
		{
			#region Constructor

			/// <summary>
			/// Clase que engloba los parámetros de finalización de la controladora de procesos pesados
			/// </summary>
			/// <param name="cancelado">Indica si el proceso fue cancelado</param>
			public Output(string filter)
				: base(filter)
			{
			}

			#endregion
		}

		#endregion

		#region Settings

		[Serializable]
		public class UISettingsContainer : UIFilterController
			< Input
			, Output
			, string
			, UISettingsContainer
			, FilterComponent<string>>.UISettingsContainer<FilterComponent<string>>
		{
			#region Constructor

			public UISettingsContainer()
				: base()
			{
			}

			#endregion

			#region Métodos públicos

			public override void Apply()
			{
				base.Apply();
			}

			#endregion
		}

		#endregion

		#region Constructor

		protected UITextFilterController()
			: base()
		{
		}

		protected UITextFilterController(AbstractUILinker<FilterComponent<string>> linker)
			: base(linker)
		{
		}

		#endregion

		#region Default input / output

		public override Input GetDefaultInput()
		{
			return new Input(string.Empty);
		}

		public override Input GetResetInput()
		{
			return new Input(Parameters.Filter);
		}

		protected override Output GetDefaultOutput()
		{
			return new Output(Parameters.Filter);
		}

		#endregion

		#region StartController

		protected override void StartController()
		{
			throw new NotImplementedException();
		}

		protected override bool AllowReset()
		{
			return true;
		}

		protected override void ResetController()
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}