///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// Representa un control de barra de progreso de para un asistente.
/// 
/// Diseñador: David López Rguez.
/// Programador: David López Rguez.
/// </sumary>
/// <remarks>
/// ===============================================================================================
/// Historial de versiones:
///   - 17/01/2012 -- Creación de la clase
/// 
/// ===============================================================================================
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
using System.Windows.Controls.Primitives;
using System.ComponentModel;


namespace Sifaw.WPF.CCL
{
	/// <summary>
	/// Representa un control de barra de progreso de para un asistente.
	/// </summary>
	public sealed class AssistantProgressBar : FrameworkElement
	{
		#region Dependency Property´s

		public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register(
			"Minimum",
			typeof(byte),
			typeof(AssistantProgressBar),
			new FrameworkPropertyMetadata(
				(byte)1,
				FrameworkPropertyMetadataOptions.AffectsRender,
				new PropertyChangedCallback(AssistantProgressBar.OnMinimumChanged),
				new CoerceValueCallback(AssistantProgressBar.CoerceMinimum))
			, new ValidateValueCallback(AssistantProgressBar.IsValidMinimum));

		public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register(
			"Maximum",
			typeof(byte),
			typeof(AssistantProgressBar),
			new FrameworkPropertyMetadata(
				(byte)3,
				FrameworkPropertyMetadataOptions.AffectsRender,
				new PropertyChangedCallback(AssistantProgressBar.OnMaximumChanged),
				new CoerceValueCallback(AssistantProgressBar.CoerceMaximum))
			, new ValidateValueCallback(AssistantProgressBar.IsValidMaximum));

		public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
			"Value",
			typeof(byte),
			typeof(AssistantProgressBar),
			new FrameworkPropertyMetadata(
				(byte)1,
				FrameworkPropertyMetadataOptions.AffectsRender,
				new PropertyChangedCallback(AssistantProgressBar.OnValueChanged),
				new CoerceValueCallback(AssistantProgressBar.CoerceValue))
			, new ValidateValueCallback(AssistantProgressBar.IsValidValue));

		public static readonly DependencyProperty ArrowProperty = DependencyProperty.Register(
			"Arrow",
			typeof(int),
			typeof(AssistantProgressBar),
			new FrameworkPropertyMetadata(
				12,
				FrameworkPropertyMetadataOptions.AffectsRender,
				new PropertyChangedCallback(AssistantProgressBar.OnArrowChanged)));

		public static readonly DependencyProperty CurrentStepBrushProperty = DependencyProperty.Register(
			"CurrentStepBrush",
			typeof(Brush),
			typeof(AssistantProgressBar),
			new FrameworkPropertyMetadata(
				Brushes.CornflowerBlue,
				FrameworkPropertyMetadataOptions.AffectsRender,
				new PropertyChangedCallback(AssistantProgressBar.OnCurrentStepBrushChanged)));

		public static readonly DependencyProperty PreviousStepBrushProperty = DependencyProperty.Register(
			"PreviousStepBrush",
			typeof(Brush),
			typeof(AssistantProgressBar),
			new FrameworkPropertyMetadata(
				Brushes.LightGray,
				FrameworkPropertyMetadataOptions.AffectsRender,
				new PropertyChangedCallback(AssistantProgressBar.OnPreviousStepBrushChanged)));

		public static readonly DependencyProperty FollowingStepBrushProperty = DependencyProperty.Register(
			"FollowingStepBrush",
			typeof(Brush),
			typeof(AssistantProgressBar),
			new FrameworkPropertyMetadata(
				Brushes.WhiteSmoke,
				FrameworkPropertyMetadataOptions.AffectsRender,
				new PropertyChangedCallback(AssistantProgressBar.OnFollowingStepBrushChanged)));

		public static readonly DependencyProperty CurrentStepBorderBrushProperty = DependencyProperty.Register(
			"CurrentStepBorderBrush",
			typeof(Brush),
			typeof(AssistantProgressBar),
			new FrameworkPropertyMetadata(
				Brushes.CornflowerBlue,
				FrameworkPropertyMetadataOptions.AffectsRender,
				new PropertyChangedCallback(AssistantProgressBar.OnCurrentStepBorderBrushChanged)));

		public static readonly DependencyProperty PreviousStepBorderBrushProperty = DependencyProperty.Register(
			"PreviousStepBorderBrush",
			typeof(Brush),
			typeof(AssistantProgressBar),
			new FrameworkPropertyMetadata(
				Brushes.LightGray,
				FrameworkPropertyMetadataOptions.AffectsRender,
				new PropertyChangedCallback(AssistantProgressBar.OnPreviousStepBorderBrushChanged)));

		public static readonly DependencyProperty FollowingStepBorderBrushProperty = DependencyProperty.Register(
			"FollowingStepBorderBrush",
			typeof(Brush),
			typeof(AssistantProgressBar),
			new FrameworkPropertyMetadata(
				Brushes.WhiteSmoke,
				FrameworkPropertyMetadataOptions.AffectsRender,
				new PropertyChangedCallback(AssistantProgressBar.OnFollowingStepBorderBrushChanged)));

		public static readonly DependencyProperty FontFamilyProperty = DependencyProperty.Register(
			"FontFamily",
			typeof(FontFamily),
			typeof(AssistantProgressBar),
			new FrameworkPropertyMetadata(
				new FontFamily("Tahoma"),
				FrameworkPropertyMetadataOptions.AffectsRender));

		public static readonly DependencyProperty FontSizeProperty = DependencyProperty.Register(
			"FontSize",
			typeof(double),
			typeof(AssistantProgressBar),
			new FrameworkPropertyMetadata(
				(double)9.0f,
				FrameworkPropertyMetadataOptions.AffectsRender));

		public static readonly DependencyProperty FontStretchProperty = DependencyProperty.Register(
			"FontStretch",
			typeof(FontStretch),
			typeof(AssistantProgressBar),
			new FrameworkPropertyMetadata(
				FontStretches.Normal,
				FrameworkPropertyMetadataOptions.AffectsRender));

		public static readonly DependencyProperty FontStyleProperty = DependencyProperty.Register(
			"FontStyle",
			typeof(FontStyle),
			typeof(AssistantProgressBar),
			new FrameworkPropertyMetadata(
				FontStyles.Normal,
				FrameworkPropertyMetadataOptions.AffectsRender));

		public static readonly DependencyProperty FontWeightProperty = DependencyProperty.Register(
			"FontWeight",
			typeof(FontWeight),
			typeof(AssistantProgressBar),
			new FrameworkPropertyMetadata(
				FontWeights.Normal,
				FrameworkPropertyMetadataOptions.AffectsRender));

		public static readonly DependencyProperty ForegroundProperty = DependencyProperty.Register(
			"Foreground",
			typeof(Brush),
			typeof(AssistantProgressBar),
			new FrameworkPropertyMetadata(
				Brushes.Black,
				FrameworkPropertyMetadataOptions.AffectsRender));

		#endregion

		#region Propiedades

		[Category("Behavior")]
		public byte Minimum
		{
			get { return (byte)GetValue(MinimumProperty); }
			set { SetValue(MinimumProperty, value); }
		}

		[Category("Behavior")]
		public byte Maximum
		{
			get { return (byte)GetValue(MaximumProperty); }
			set { SetValue(MaximumProperty, value); }
		}

		[Category("Behavior")]
		public byte Value
		{
			get { return (byte)GetValue(ValueProperty); }
			set { SetValue(ValueProperty, value); }
		}

		[Category("Behavior")]
		public int Arrow
		{
			get { return (int)GetValue(ArrowProperty); }
			set { SetValue(ArrowProperty, value); }
		}

		[Category("Brushes")]
		public Brush CurrentStepBrush
		{
			get { return (Brush)GetValue(CurrentStepBrushProperty); }
			set { SetValue(CurrentStepBrushProperty, value); }
		}

		[Category("Brushes")]
		public Brush PreviousStepBrush
		{
			get { return (Brush)GetValue(PreviousStepBrushProperty); }
			set { SetValue(PreviousStepBrushProperty, value); }
		}

		[Category("Brushes")]
		public Brush FollowingStepBrush
		{
			get { return (Brush)GetValue(FollowingStepBrushProperty); }
			set { SetValue(FollowingStepBrushProperty, value); }
		}

		[Category("Brushes")]
		public Brush CurrentStepBorderBrush
		{
			get { return (Brush)GetValue(CurrentStepBorderBrushProperty); }
			set { SetValue(CurrentStepBorderBrushProperty, value); }
		}

		[Category("Brushes")]
		public Brush PreviousStepBorderBrush
		{
			get { return (Brush)GetValue(PreviousStepBorderBrushProperty); }
			set { SetValue(PreviousStepBorderBrushProperty, value); }
		}

		[Category("Brushes")]
		public Brush FollowingStepBorderBrush
		{
			get { return (Brush)GetValue(FollowingStepBorderBrushProperty); }
			set { SetValue(FollowingStepBorderBrushProperty, value); }
		}

		[Bindable(true)]
		[Localizability(LocalizationCategory.Font)]
		[Category("Appearance")]
		public FontFamily FontFamily
		{
			get { return (FontFamily)GetValue(FontFamilyProperty); }
			set { SetValue(FontFamilyProperty, value); }
		}
		
		[TypeConverter(typeof(FontSizeConverter))]
		[Localizability(LocalizationCategory.None)]
		[Bindable(true)]
		[Category("Appearance")]
		public double FontSize
		{
			get { return (double)GetValue(FontSizeProperty); }
			set { SetValue(FontSizeProperty, value); }
		}
		
		[Category("Appearance")]
		[Bindable(true)]
		public FontStretch FontStretch
		{
			get { return (FontStretch)GetValue(FontStretchProperty); }
			set { SetValue(FontStretchProperty, value); }
		}

		[Category("Appearance")]
		[Bindable(true)]
		public FontStyle FontStyle
		{
			get { return (FontStyle)GetValue(FontStyleProperty); }
			set { SetValue(FontStyleProperty, value); }
		}

		[Bindable(true)]
		[Category("Appearance")]
		public FontWeight FontWeight
		{
			get { return (FontWeight)GetValue(FontWeightProperty); }
			set { SetValue(FontWeightProperty, value); }
		}
		
		[Bindable(true)]
		[Category("Appearance")]
		public Brush Foreground
		{
			get { return (Brush)GetValue(ForegroundProperty); }
			set { SetValue(ForegroundProperty, value); }
		}

		#endregion

		#region Constructores

		static AssistantProgressBar()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(AssistantProgressBar), new FrameworkPropertyMetadata(typeof(AssistantProgressBar)));
		}

		#endregion

		#region Métodos sobrescritos

		protected override void OnRender(DrawingContext dC)
		{
			byte steps = Math.Max((byte)0, (byte)((Maximum - Minimum) + 1));

			for (double step = 1; step <= steps; step++)
			{
				if (step == Value)
					continue;

				PathGeometry pGeometry = new PathGeometry(new PathFigure[] { GetArrowFigure(steps, step == Minimum ? 0 : Arrow, step == Maximum ? 0 : Arrow) });
				pGeometry = Geometry.Combine(Geometry.Empty, pGeometry, GeometryCombineMode.Union, new TranslateTransform((step - 1) * (ActualWidth / steps), 0));

				Pen border = new Pen((step < Value) ? PreviousStepBorderBrush : FollowingStepBorderBrush, 1);
				dC.DrawGeometry((step < Value) ? PreviousStepBrush : FollowingStepBrush, border, pGeometry);
			}

			if (Minimum <= Value && Value <= Maximum)
			{
				PathGeometry pGeometry = new PathGeometry(new PathFigure[] { GetArrowFigure(steps, Value == Minimum ? 0 : Arrow, Value == Maximum ? 0 : Arrow) });
				pGeometry = Geometry.Combine(Geometry.Empty, pGeometry, GeometryCombineMode.Union, new ScaleTransform(1, 1.1, 0, ActualHeight / 2));
				pGeometry = Geometry.Combine(Geometry.Empty, pGeometry, GeometryCombineMode.Union, new TranslateTransform((Value - 1) * (ActualWidth / steps), 0));

				Pen border = new Pen(CurrentStepBorderBrush, 1);
				dC.DrawGeometry(CurrentStepBrush, border, pGeometry);
			}

			for (double step = 1; step <= steps; step++)
			{
				FormattedText fText = new FormattedText(
					  string.Format("Paso {0}", step)
					, System.Globalization.CultureInfo.CurrentCulture
					, System.Windows.FlowDirection.LeftToRight
					, new Typeface(FontFamily, FontStyle, FontWeight, FontStretch)
					, (step == Value) ? FontSize + 3 : FontSize
					, (step == Value) ? Brushes.White : Foreground);
				// Alineamos el texto horizontalmente.
				fText.TextAlignment = TextAlignment.Center;
				fText.MaxTextWidth = ActualWidth / steps;
				// Adorno al recortar el texto.
				fText.Trimming = TextTrimming.CharacterEllipsis;
				fText.SetFontWeight(step == Value ? FontWeights.Bold : FontWeight);
				// Limitamos el texto a una linea.
				fText.MaxLineCount = 1;
                fText.LineHeight = ActualHeight * 0.75;
								
				// X = Posición de inicio de la región del texto mas el error producido al añadir la flecha de
				//     dirección a la región.
				// Y = Posición vertical.
				dC.DrawText(fText, new Point(((step - 1) * (ActualWidth / steps)) + (Arrow / 2), 0));
			}

			base.OnRender(dC);
		}

		private PathFigure GetArrowFigure(int steps, int lArrow, int rArrow)
		{
			PathFigure figure = new PathFigure();

			figure.StartPoint = new Point(0, 0);
			figure.Segments.Add(new LineSegment(new Point(ActualWidth / steps, 0), true));
			figure.Segments.Add(new LineSegment(new Point((ActualWidth / steps) + rArrow, ActualHeight / 2), true));
			figure.Segments.Add(new LineSegment(new Point(ActualWidth / steps, ActualHeight), true));
			figure.Segments.Add(new LineSegment(new Point(0, ActualHeight), true));
			figure.Segments.Add(new LineSegment(new Point(lArrow, ActualHeight / 2), true));
			figure.Segments.Add(new LineSegment(new Point(0, 0), true));

			return figure;
		}

		#endregion

		#region Métodos virtuales

		private void OnMinimumChanged(byte oldValue, byte newValue)
		{

		}

		private void OnMaximumChanged(byte oldValue, byte newValue)
		{

		}

		private void OnValueChanged(byte oldValue, byte newValue)
		{

		}

		private void OnArrowChanged(int oldValue, int newValue)
		{

		}

		private void OnCurrentStepBrushChanged(Brush oldValue, Brush newValue)
		{

		}

		private void OnPreviousStepBrushChanged(Brush oldValue, Brush newValue)
		{

		}

		private void OnFollowingStepBrushChanged(Brush oldValue, Brush newValue)
		{

		}

		private void OnCurrentStepBorderBrushChanged(Brush oldValue, Brush newValue)
		{

		}

		private void OnPreviousStepBorderBrushChanged(Brush oldValue, Brush newValue)
		{

		}

		private void OnFollowingStepBorderBrushChanged(Brush oldValue, Brush newValue)
		{

		}

		#endregion

		#region Mëtodos de factoria

		#region Coerce

		private static object CoerceValue(DependencyObject d, object value)
		{
			AssistantProgressBar assitant = (AssistantProgressBar)d;

			if ((byte)value < assitant.Minimum)
			{
				return assitant.Minimum;
			}

			if ((byte)value > assitant.Maximum)
			{
				return assitant.Maximum;
			}

			return value;
		}

		private static object CoerceMinimum(DependencyObject d, object value)
		{
			AssistantProgressBar assistant = (AssistantProgressBar)d;

			if ((byte)value < 1)
			{
				return 1;
			}

			if ((byte)value > assistant.Maximum)
			{
				return assistant.Maximum;
			}

			return value;
		}

		private static object CoerceMaximum(DependencyObject d, object value)
		{
			AssistantProgressBar assistant = (AssistantProgressBar)d;

			if ((byte)value < assistant.Minimum)
			{
				return assistant.Minimum;
			}

			return value;
		}

		#endregion

		#region IsValid

		private static bool IsValidMaximum(object value)
		{
			return ((byte)value >= 2);
		}

		private static bool IsValidMinimum(object value)
		{
			return ((byte)value >= 1);
		}

		private static bool IsValidValue(object value)
		{
			return ((byte)value >= 1);
		}

		#endregion

		#region OnSelectedChanged

		private static void OnMinimumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			(d as AssistantProgressBar).OnMinimumChanged((byte)e.OldValue, (byte)e.NewValue);
		}

		private static void OnMaximumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			(d as AssistantProgressBar).OnMaximumChanged((byte)e.OldValue, (byte)e.NewValue);
		}

		private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			(d as AssistantProgressBar).OnValueChanged((byte)e.OldValue, (byte)e.NewValue);
		}

		private static void OnArrowChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			(d as AssistantProgressBar).OnArrowChanged((int)e.OldValue, (int)e.NewValue);
		}

		private static void OnCurrentStepBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			(d as AssistantProgressBar).OnCurrentStepBrushChanged((Brush)e.OldValue, (Brush)e.NewValue);
		}

		private static void OnPreviousStepBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			(d as AssistantProgressBar).OnPreviousStepBrushChanged((Brush)e.OldValue, (Brush)e.NewValue);
		}

		private static void OnFollowingStepBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			(d as AssistantProgressBar).OnFollowingStepBrushChanged((Brush)e.OldValue, (Brush)e.NewValue);
		}

		private static void OnCurrentStepBorderBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			(d as AssistantProgressBar).OnCurrentStepBorderBrushChanged((Brush)e.OldValue, (Brush)e.NewValue);
		}

		private static void OnPreviousStepBorderBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			(d as AssistantProgressBar).OnPreviousStepBorderBrushChanged((Brush)e.OldValue, (Brush)e.NewValue);
		}

		private static void OnFollowingStepBorderBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			(d as AssistantProgressBar).OnFollowingStepBorderBrushChanged((Brush)e.OldValue, (Brush)e.NewValue);
		}

		#endregion

		#endregion
	}
}