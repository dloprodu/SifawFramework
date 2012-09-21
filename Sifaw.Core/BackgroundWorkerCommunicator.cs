/*
 * Sifaw.Core
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
using System.Threading;


namespace Sifaw.Core
{
    /// <summary>
    /// Provee de soporte a la comunicación con procesos pesados que se ejecutan 
    /// en hilos.
    /// </summary>
    [Serializable]
    public class BackgroundWorkerCommunicator
    {
        #region Fields

        private System.ComponentModel.BackgroundWorker Worker = null;

        #endregion

        #region Properties

        /// <summary>
        /// Devuelve un valor que indica si el usuario ha solicitado la cancelación del proceso
        /// </summary>
        public bool CancellationPending
        {
            get { return Worker.CancellationPending; }
        }

        #endregion

        #region Constructors

		/// <summary>
		/// Inicializa una instancia de la clase <see cref="BackgroundWorkerCommunicator"/>.
		/// </summary>
		/// <param name="worker"><see cref="System.ComponentModel.BackgroundWorker"/> que usará el comunicador para informar el progreso.</param>
        public BackgroundWorkerCommunicator(System.ComponentModel.BackgroundWorker worker)
        {
            Worker = worker;
        }

        #endregion

        #region Progress Methods

        private void ReportProgress(int percentProgress, object userState)
        {
            lock (this)
            {
                Worker.ReportProgress(percentProgress, userState);
                Monitor.Wait(this);
            }
        }

        /// <summary>
        /// Indica al gestor de procesos pesados, el progreso y el texto a mostrar en el progreso.
        /// Si se ha iniciado el proceso en modo sin control, este método no hace nada.
        /// </summary>
        public void Progress(int progess, string text)
        {
            ReportProgress(progess, new Tuple<ReportProgressCommands, string>(ReportProgressCommands.ProgressAndTextChanged, text));
        }

        /// <summary>
        /// Indica al gestor de procesos pesados el texto a mostrar en el progreso.
        /// </summary>
        public void Progress(string text)
        {
            ReportProgress(0, new Tuple<ReportProgressCommands, string>(ReportProgressCommands.TextChanged, text));
        }

        /// <summary>
        /// Incrementa en una unidad el progreso indicado, según el máximo indicado.
        /// Si se ha iniciado el proceso en modo SinControl, este método no hace nada.
        /// </summary>
        public void Increment(string text)
        {
            ReportProgress(1, new Tuple<ReportProgressCommands, string>(ReportProgressCommands.ProgressAndTextChanged, text));
        }

        /// <summary>
        /// Incrementa en una unidad el progreso indicado, según el máximo indicado.
        /// Si se ha iniciado el proceso en modo sin control, este método no hace nada.
        /// </summary>
        public void Increment()
        {
            ReportProgress(1, new Tuple<ReportProgressCommands, string>(ReportProgressCommands.ProgressChanged, string.Empty));
        }

        /// <summary>
        /// Cambia el máximo predeterminado del progreso.
        /// Si se ha iniciado el proceso en modo sin control, este método no hace nada.
        /// </summary>
        public void ChangeMaxProgress(int value)
        {
            ReportProgress(value, new Tuple<ReportProgressCommands, string>(ReportProgressCommands.MaximumProgressChanged, string.Empty));
        }

        /// <summary>
        /// Modifica el modo de la carga del proceso pesado.
        /// </summary>
        public void ChangeWithControl(bool value)
        {
            ReportProgress(0, new Tuple<ReportProgressCommands, string>(ReportProgressCommands.WithControlChanged, ""));
        }

        #endregion
    }
}
