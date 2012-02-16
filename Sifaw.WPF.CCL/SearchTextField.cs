/*
 * Sifaw.WPF.CCL
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
using System.Windows.Threading;


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
		#region Auxiliary structures

		/// <summary>
		/// Define los modos de búsqueda de un <see cref="SearchTextField"/>.
		/// </summary>
		public enum SearchMode
		{
			/// <summary>
			/// El evento <see cref="Search"/> se desencadena de forma implícita según el usuario
			/// va introduciendo texto en el control.
			/// </summary>
			Instant,

			/// <summary>
			/// El evento <see cref="Search"/> se desencadena de forma explícita cuando el usuario pulsa sobre
			/// el botón de búsqueda o presiona la tecla Enter.
			/// </summary>
			Delayed,
		}

		#endregion

		#region Dependecy Properties

		public static DependencyProperty ModeProperty =
			DependencyProperty.Register(
				"Mode",
				typeof(SearchMode),
				typeof(SearchTextField),
				new PropertyMetadata(SearchMode.Instant));

		public static DependencyProperty InstantSearchTimeDelayProperty =
			DependencyProperty.Register(
				"InstantSearchTimeDelay",
				typeof(Duration),
				typeof(SearchTextField),
				new FrameworkPropertyMetadata(
					new Duration(new TimeSpan(0, 0, 0, 0, 500)),
					new PropertyChangedCallback(OnInstantSearchTimeDelayChanged)));

		private static DependencyPropertyKey HasTextPropertyKey =
			DependencyProperty.RegisterReadOnly(
				"HasText",
				typeof(bool),
				typeof(SearchTextField),
				new PropertyMetadata());

		public static DependencyProperty HasTextProperty = HasTextPropertyKey.DependencyProperty;

		private static DependencyPropertyKey IsSearchButtonTouchedPropertyKey =
			DependencyProperty.RegisterReadOnly(
				"IsSearchButtonTouched",
				typeof(bool),
				typeof(SearchTextField),
				new PropertyMetadata());

		public static DependencyProperty IsSearchButtonTouchedProperty = IsSearchButtonTouchedPropertyKey.DependencyProperty;

		#endregion

		#region Properties

		/// <summary>
		/// Obtiene o estableceun valor que indica el módo en el que se ejecutan las búsquedas.
		/// </summary>
		[Category("Common")]
		public SearchMode Mode
		{
			get { return (SearchMode)GetValue(ModeProperty); }
			set { SetValue(ModeProperty, value); }
		}

		/// <summary>
		/// Obtiene o establecela duración de tiempo en el desencadenamiento de eventos
		/// <see cref="Search"/> en el modo de búsqueda Instant.
		/// </summary>
		[Category("Common")]
		public Duration InstantSearchTimeDelay
		{
			get { return (Duration)GetValue(InstantSearchTimeDelayProperty); }
			set { SetValue(InstantSearchTimeDelayProperty, value); }
		}

		/// <summary>
		/// Obtiene un valor que indica si el control tiene una cadena de búsqueda.
		/// </summary>
		public bool HasText
		{
			get { return (bool)GetValue(HasTextProperty); }
			private set { SetValue(HasTextPropertyKey, value); }
		}

		/// <summary>
		/// Obtiene un valor que indica si se ha hecho click sobre el
		/// botón de búsqueda / reseteo.
		/// </summary>
		public bool IsSearchButtonTouched
		{
			get { return (bool)GetValue(IsSearchButtonTouchedProperty); }
			private set { SetValue(IsSearchButtonTouchedPropertyKey, value); }
		}

		#endregion

		#region Events

		public static readonly RoutedEvent SearchEvent =
			EventManager.RegisterRoutedEvent(
				"Search",
				RoutingStrategy.Bubble,
				typeof(RoutedEventHandler),
				typeof(SearchTextField));

		public event RoutedEventHandler Search
		{
			add { AddHandler(SearchEvent, value); }
			remove { RemoveHandler(SearchEvent, value); }
		}

		protected virtual void OnSearch(RoutedEventArgs e)
		{
			RaiseEvent(e);
		}

		#endregion

		#region Elements

		private DispatcherTimer instantSearchTimer;
		private Border searchButtonBorder = null;
		private Image searchIconImage = null;

		#endregion

		#region Constructors

		public SearchTextField()
			: base()
		{
			instantSearchTimer = new DispatcherTimer();
			instantSearchTimer.Interval = InstantSearchTimeDelay.TimeSpan;
			instantSearchTimer.Tick += new EventHandler(instantSearchTimer_Tick);
		}

		static SearchTextField()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchTextField), new FrameworkPropertyMetadata(typeof(SearchTextField)));
		}

		#endregion

		#region Methods de factoria

		private static void OnInstantSearchTimeDelayChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
		{
			SearchTextField stb = o as SearchTextField;

			if (stb != null)
			{
				stb.instantSearchTimer.Interval = ((Duration)e.NewValue).TimeSpan;
				stb.instantSearchTimer.Stop();
			}
		}

		#endregion

		#region Override Methods

		protected override void OnTextChanged(TextChangedEventArgs e)
		{
			base.OnTextChanged(e);

			HasText = (!string.IsNullOrEmpty(Text)) && (Text.Length != 0);

			switch (Mode)
			{
				case SearchMode.Instant:
					instantSearchTimer.Stop();
					instantSearchTimer.Start();
					break;

				case SearchMode.Delayed:
					/* Empty */
					break;
			}
		}

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);

			switch (Mode)
			{
				case SearchMode.Instant:
					// Clear:
					// Lanza el OnSearch con string.Empty
					if (e.Key == Key.Escape)
						Text = string.Empty;
					break;

				case SearchMode.Delayed:
					if (e.Key == Key.Return || e.Key == Key.Enter)
						OnSearch(new RoutedEventArgs(SearchEvent));
					break;
			}
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();

			if (searchButtonBorder == null)
			{
				searchButtonBorder = Template.FindName("PART_SearchButton", this) as Border;

				if (searchButtonBorder != null)
				{
					searchButtonBorder.MouseLeftButtonDown += new MouseButtonEventHandler(searchButtonBorder_MouseLeftButtonDown);
					searchButtonBorder.MouseLeftButtonUp += new MouseButtonEventHandler(searchButtonBorder_MouseLeftButtonUp);
					searchButtonBorder.MouseLeave += new MouseEventHandler(searchButtonBorder_MouseLeave);
				}
			}

			if (searchIconImage == null)
			{
				searchIconImage = Template.FindName("PART_SearchIcon", this) as Image;

				if (searchIconImage != null)
				{
					/* Empty */
				}
			}
		}

		#endregion

		#region Events Handlers

		private void searchButtonBorder_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			IsSearchButtonTouched = true;
		}

		private void searchButtonBorder_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
		{
			if (!IsSearchButtonTouched)
				return;

			switch (Mode)
			{
				case SearchMode.Instant:
					if (HasText)
						// Clear:
						// Lanza el OnSearch con string.Empty
						Text = string.Empty;
					break;

				case SearchMode.Delayed:
					if (HasText)
						OnSearch(new RoutedEventArgs(SearchEvent));
					break;
			}

			IsSearchButtonTouched = false;
		}

		private void searchButtonBorder_MouseLeave(object sender, MouseEventArgs e)
		{
			IsSearchButtonTouched = false;
		}

		private void instantSearchTimer_Tick(object o, EventArgs e)
		{
			instantSearchTimer.Stop();
			OnSearch(new RoutedEventArgs(SearchEvent));
		}

		#endregion
	}
}