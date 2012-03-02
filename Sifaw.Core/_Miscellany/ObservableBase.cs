/*
 * Sifaw.Core
 * 
 * Diseñador:   David López Rguez
 * Programador: David López Rguez
 * 
 * ===============================================================================================
 * Historial de versiones:
 *   - 02/03/2012: Creación de la clase.
 * ===============================================================================================
 * Observaciones:
 * 
 */



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.ComponentModel;


namespace Sifaw.Core
{
    /// <summary>
    /// Objeto con capacidad para notificar a los clientes que un valor de propiedad ha cambiado.
    /// </summary>
    public abstract class ObservableBase : INotifyPropertyChanged
    {
        /// <summary>
        /// Se produce cuando cambia el valor de una propiedad.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Provoca el evento <see cref="PropertyChanged"/>.
        /// </summary>
        /// <typeparam name="T">Tipo del objeto que produce el evento.</typeparam>
        /// <param name="expression"></param>
        protected virtual void OnPropertyChanged<T>(Expression<Func<T>> expression)
        {          
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(GetPropertyName(expression)));
        }

        /// <summary>
        /// Get the string name for the property
        /// </summary>
        protected string GetPropertyName<T>(Expression<Func<T>> expression)
        {
            return (expression.Body as MemberExpression).Member.Name;
        }
    }
}