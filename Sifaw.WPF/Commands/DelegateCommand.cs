/*
 * Sifaw.WPF.Commands
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
using System.Windows.Input;


namespace Sifaw.WPF.Commands
{
	public class DelegateCommand : ICommand
	{
		#region Fields

		private readonly Action actionMethod;
		private readonly Func<bool> canExecuteMethod;

		#endregion

		#region Constructors

		public DelegateCommand(Action action)
			: this(action, null)
		{
		}

		public DelegateCommand(Action action, Func<bool> canExecute)
		{
			this.actionMethod = action;
			this.canExecuteMethod = canExecute;
		}

		#endregion

		#region ICommand

		public bool CanExecute(object parameter)
		{
			return this.canExecuteMethod != null ? this.canExecuteMethod() : true;
		}

		public void Execute(object parameter)
		{
			if (this.actionMethod != null)
			{
				this.actionMethod();
			}
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		#endregion
	}

	public class DelegateCommand<T> : ICommand
	{
		#region Fields

		private readonly Action<T> actionMethod;
		private readonly Func<T, bool> canExecuteMethod;

		#endregion

		#region Constructors

		public DelegateCommand(Action<T> action)
			: this(action, null)
		{
		}

		public DelegateCommand(Action<T> action, Func<T, bool> canExecute)
		{
			this.actionMethod = action;
			this.canExecuteMethod = canExecute;
		}

		#endregion

		#region ICommand

		public bool CanExecute(object parameter)
		{
			return this.canExecuteMethod != null ? this.canExecuteMethod((T)parameter) : true;
		}

		public void Execute(object parameter)
		{
			if (this.actionMethod != null)
			{
				this.actionMethod((T)parameter);
			}
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		#endregion
	}
}
