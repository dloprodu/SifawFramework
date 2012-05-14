/*
 * Sifaw.WPF.CCL
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 13/03/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;


namespace Sifaw.WPF.CCL
{
	/// <summary>
	/// Representa una columnma de <see cref="DataTable"/>.
	/// </summary>
	public class DataTableColumn : DependencyObject
	{
		#region Dependency Properties

		public static readonly DependencyProperty WidthProperty = DependencyProperty.Register(
			"Width",
			typeof(double),
			typeof(DataTableColumn),
			new FrameworkPropertyMetadata(
				(double)50,
				FrameworkPropertyMetadataOptions.AffectsRender));

        public static readonly DependencyProperty TypeLenghtProperty = DependencyProperty.Register(
            "TypeLenght",
            typeof(DataTableColumnTypesLenght),
			typeof(DataTableColumn),
			new FrameworkPropertyMetadata(
                (double)DataTableColumnTypesLenght.Fixed,
				FrameworkPropertyMetadataOptions.AffectsRender));

		#endregion

		#region Properties

		public double Width
		{
			get { return (double)GetValue(WidthProperty); }
			set { SetValue(WidthProperty, value); }
		}

        public DataTableColumnTypesLenght TypeLenght
        {
            get { return (DataTableColumnTypesLenght)GetValue(TypeLenghtProperty); }
            set { SetValue(TypeLenghtProperty, value); }
        }

		#endregion

		#region Constructor

		public DataTableColumn()
		{           
		}

		#endregion
	}
}