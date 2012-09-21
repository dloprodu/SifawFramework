/*
 * Sifaw.Controllers
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 21/09/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Views;


namespace Sifaw.Controllers
{
    /// <summary>
    /// Extension de <see cref="UIViewManager"/>.
    /// </summary>
    public class UIViewManagerExtension : UIViewManager
    {
        /// <summary>
        /// Registra una nueva vista como activa. Si no se ha especificado la vista por defecto de la aplicación
        /// no se realiza el registro.
        /// </summary>
        /// <param name="view">Vista activa a registrar en la pila de vistas activas.</param>
        public static void SetActiveView(UIView view)
        {
            if (GetDefaultView() != null)
            {
                UIViewManager.Views.Push(view);
            }
        }

        /// <summary>
        /// Elimina del registro la vista indicada por parámetro. La operación se realiza si se ha especificado
        /// la vista por defecto de la aplicación.
        /// </summary>
        /// <param name="view">Vitsa activa por defecto de la aplicación.</param>
        public static void RemoveActiveView(UIView view)
        {
            if (GetDefaultView() != null)
            {
                UIView[] views = UIViewManager.Views.ToArray();

                SetDefaultView(GetDefaultView());

                for (int i = 0; i < views.Length; i++)
                {
                    if (!views[i].Equals(view))
                        SetActiveView(views[i]);
                }
            }
        }
    }
}