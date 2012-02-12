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
using System.Windows.Data;
using System.Windows;


namespace Sifaw.WPF.CCL
{
	/// <summary>
	/// Provee de utilidades varías para dar apoyo a controles personalizados.
	/// </summary>
	public static class UtilWPF
	{
		public static void BindParent(
			  string path
			, FrameworkElement target
			, DependencyProperty dp
			, BindingMode mode = BindingMode.OneWay
			, IValueConverter converter = null)
		{
			if (!BindingOperations.IsDataBound(target, dp))
			{
				Binding bind = new Binding(path);
				bind.Mode = mode;
				bind.Converter = converter;
				bind.RelativeSource = new RelativeSource(RelativeSourceMode.TemplatedParent);
				BindingOperations.SetBinding(target, dp, bind);
			}
		}

		public static void BindField(
			  object source
			, string path
			, FrameworkElement target
			, DependencyProperty dp
			, BindingMode mode = BindingMode.Default
			, IValueConverter converter = null)
		{
			if (!BindingOperations.IsDataBound(target, dp))
			{
				Binding bind = new Binding(path);
				bind.Mode = mode;
				bind.Source = source;
				bind.Converter = converter;
				BindingOperations.SetBinding(target, dp, bind);
			}
		}

		public static void UnbindField(FrameworkElement target, DependencyProperty dp)
		{
			if (BindingOperations.IsDataBound(target, dp))
			{
				BindingOperations.ClearBinding(target, dp);
			}
		}
	}
}