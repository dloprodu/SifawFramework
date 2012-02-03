///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// SearchTextField.cs
/// 
/// Diseñador: David López Rguez
/// Programador: David López Rguez
/// </sumary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 30/01/2012: Creación de controladora.
/// 
/// ===============================================================================================
/// Observaciones:
/// </remarks>
///////////////////////////////////////////////////////////////////////////////////////////////////



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;


namespace Sifaw.WPF.CCL
{
	/// <summary>
	/// Representa un control que puede ser usado para mostrar o editar texto sin formato
	/// con el que ejecutar filtros o búsquedas.
	/// </summary>
	[TemplatePart(Name = "PART_SearchButton", Type = typeof(Border))]
	[TemplatePart(Name = "PART_SearchIcon", Type = typeof(Image))]
	public class SearchTextField : TextField
	{
		#region Dependecy Properties

		public static DependencyProperty SearchModeProperty =
			DependencyProperty.Register(
				"SearchMode",
				typeof(SearchMode),
				typeof(SearchTextField),
				new PropertyMetadata(SearchMode.Instant));

		private static DependencyPropertyKey HasTextPropertyKey =
			DependencyProperty.RegisterReadOnly(
				"HasText",
				typeof(bool),
				typeof(SearchTextField),
				new PropertyMetadata());

		public static DependencyProperty HasTextProperty = HasTextPropertyKey.DependencyProperty;

		#endregion

		#region Propiedades

		/// <summary>
		/// Obtiene o establece un valor que indica el módo en el que se ejecutan las búsquedas.
		/// </summary>
		[Category("Common")]
		public SearchMode SearchMode
		{
			get { return (SearchMode)GetValue(SearchModeProperty); }
			set { SetValue(SearchModeProperty, value); }
		}

		/// <summary>
		/// Obtiene un valor que indica si el control tiene una cadena de búsqueda.
		/// </summary>
		public bool HasText
		{
			get { return (bool)GetValue(HasTextProperty); }
			private set { SetValue(HasTextPropertyKey, value); }
		}

		#endregion

		#region Constructores

		static SearchTextField()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchTextField), new FrameworkPropertyMetadata(typeof(SearchTextField)));
		}

		#endregion

		#region Override Methods

		protected override void OnTextChanged(TextChangedEventArgs e)
		{
			base.OnTextChanged(e);
			HasText = (!string.IsNullOrEmpty(Text)) && (Text.Length != 0);
		}

		#endregion
	}

	public enum SearchMode
	{
		Instant,
		Delayed,
	}
}