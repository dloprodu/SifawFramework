///////////////////////////////////////////////////////////////////////////////////////////////////
/// <sumary>
/// TextField.cs
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
using System.Globalization;


namespace Sifaw.WPF.CCL
{
	/// <summary>
	/// Representa un control que puede ser usado para mostrar o editar texto sin formato.
	/// Tiene la capacidad de poder establecer un texto como máscara o punto de entrada (Placeholder).
	/// </summary>
	[TemplatePart(Name = "PART_Placeholder", Type = typeof(Label))]
	public class TextField : TextBox
	{
		#region Dependecy Properties

		public static DependencyProperty PlaceholderProperty =
		   DependencyProperty.Register(
			   "Placeholder",
			   typeof(string),
			   typeof(TextField),
			   new PropertyMetadata("Placeholder"));

		public static DependencyProperty PlaceholderBrushProperty =
			DependencyProperty.Register(
				"PlaceholderBrush",
				typeof(Brush),
				typeof(TextField),
				new PropertyMetadata(SystemColors.ControlDarkBrush));

		public static DependencyProperty PlaceholderStyleProperty =
			DependencyProperty.Register(
				"PlaceholderStyle",
				typeof(FontStyle),
				typeof(TextField),
				new PropertyMetadata(FontStyles.Normal));

		public static DependencyProperty PlaceholderWeightProperty =
			DependencyProperty.Register(
				"PlaceholderWeight",
				typeof(FontWeight),
				typeof(TextField),
				new PropertyMetadata(FontWeights.Light));

		#endregion

		#region Propiedades

		/// <summary>
		/// Obtiene o establece el texto que se muesta cuando la propiedad Text no tiene valor definido.
		/// </summary>
		[Category("Placeholder")]
		[Bindable(true)]
		public string Placeholder
		{
			get { return (string)GetValue(PlaceholderProperty); }
			set { SetValue(PlaceholderProperty, value); }
		}

		/// <summary>
		/// Obtiene o establece el <see cref="Brush"/> usado para representar <see cref="Placeholder"/>.
		/// </summary>
		[Category("Brushes")]
		[Bindable(true)]
		public Brush PlaceholderBrush
		{
			get { return (Brush)GetValue(PlaceholderBrushProperty); }
			set { SetValue(PlaceholderBrushProperty, value); }
		}	
	
		/// <summary>
		/// Obtiene o establece el estilo de la fuente.
		/// </summary>
		[Category("Placeholder")]
		[Bindable(true)]
		public FontStyle PlaceholderStyle 
		{
			get { return (FontStyle)GetValue(PlaceholderStyleProperty); }
			set { SetValue(PlaceholderStyleProperty, value); }
		}
		
		/// <summary>
		/// Obtiene o establece el espesor o grosor de la fuente del <see cref="Placeholder"/>.
		/// </summary>
		[Bindable(true)]
		[Category("Placeholder")]
		public FontWeight PlaceholderWeight 
		{
			get { return (FontWeight)GetValue(PlaceholderWeightProperty); }
			set { SetValue(PlaceholderWeightProperty, value); }
		}

		#endregion

		#region Elements

		private Label placeHolderLabel = null;

		#endregion

		#region Constructor

		static TextField()
		{
			DefaultStyleKeyProperty.OverrideMetadata(typeof(TextField), new FrameworkPropertyMetadata(typeof(TextField)));
		}

		#endregion

		#region Override Methods

		protected override void OnTextChanged(TextChangedEventArgs e)
		{
			placeHolderLabel.Visibility = string.IsNullOrEmpty(Text) ? Visibility.Visible : Visibility.Collapsed;

			base.OnTextChanged(e);
		}

		public override void OnApplyTemplate()
		{
			base.OnApplyTemplate();
			
			if (placeHolderLabel == null)
			{
				placeHolderLabel = Template.FindName("PART_Placeholder", this) as Label;
				
				if (placeHolderLabel != null)
				{
					/* 
					 * PlaceHolder:
					 * • Configuración fija. 
					 */
					placeHolderLabel.Background = Brushes.Transparent;
					placeHolderLabel.Margin = new Thickness(2, 0, 0, 0);
					
					/* • TemplateBinding */
					UtilWPF.BindParent("VerticalContentAlignment", placeHolderLabel, Control.VerticalContentAlignmentProperty);
					UtilWPF.BindParent("HorizontalContentAlignment", placeHolderLabel, Control.HorizontalContentAlignmentProperty);
					UtilWPF.BindParent("Placeholder", placeHolderLabel, Label.ContentProperty);
					UtilWPF.BindParent("PlaceholderBrush", placeHolderLabel, Control.ForegroundProperty);
					UtilWPF.BindParent("FontFamily", placeHolderLabel, Control.FontFamilyProperty);
					UtilWPF.BindParent("FontSize", placeHolderLabel, Control.FontSizeProperty);
					UtilWPF.BindParent("FontStretch", placeHolderLabel, Control.FontStretchProperty);
					UtilWPF.BindParent("PlaceholderStyle", placeHolderLabel, Control.FontStyleProperty);
					UtilWPF.BindParent("PlaceholderWeight", placeHolderLabel, Control.FontWeightProperty);
					UtilWPF.BindParent("Padding", placeHolderLabel, Control.PaddingProperty);
				}
			}
		}

		#endregion
	}
}