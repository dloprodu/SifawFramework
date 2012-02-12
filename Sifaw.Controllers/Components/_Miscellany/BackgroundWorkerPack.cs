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

        public BackgroundWorkerDelegate Method
        {
            get { return _method; }
        }

        public object Result
        {
            get { return _result; }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Construye el paquete de información para ejecutar un proceso pesado
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
