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
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Sifaw.Core;


namespace Sifaw.Controllers.Components
{
    /// <summary>
    /// Representa un paquete de ejecucion de una tarea de fondo.
    /// </summary>
    [Serializable]
    public class BackgroundWorkerPack
    {
        #region Fields

        private BackgroundWorkerDelegate _method = null;
        private object[] _arguments = null;
        private object _result = null;

        #endregion

        #region Properties

		/// <summary>
		/// Delegado del método que se ejecutara de fondo.
		/// </summary>
        public BackgroundWorkerDelegate Method
        {
            get { return _method; }
        }

		/// <summary>
		/// Devuelve el resultado del método.
		/// </summary>
        public object Result
        {
            get { return _result; }
        }

        #endregion

        #region Constructors

        /// <summary>
		/// Inicializa una nueva instancia de la clase <see cref="BackgroundWorkerPack"/>.
        /// </summary>
        /// <param name="method">Delegado que contiene el código a ejecutar.</param>
        /// <param name="arguments">Lista de argumentos que se necesitan para ejecutar el delegado.</param>
        public BackgroundWorkerPack(BackgroundWorkerDelegate method, object[] arguments)
        {
            _method = method;
            _arguments = arguments;
        }

        #endregion

        #region Methods

		/// <summary>
		/// Inica el proceso pesado en un nuevo hilo de ejecución.
		/// </summary>
		/// <param name="communicator">Comunicador que usa el proceso para comunicarse con el proceso principal.</param>
        public void Start(BackgroundWorkerCommunicator communicator)
        {
            try
            {
                _result = _method.DynamicInvoke(new object[] { communicator, _arguments });
            }
            catch (Exception)
            {
                _result = null;
            }
        }

        #endregion
    }
}
