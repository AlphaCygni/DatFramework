using System;
using System.Diagnostics;
using System.Windows.Input;

namespace DatFramework.ViewModels
{
    /// <summary>
    /// A command whose sole purpose is to relay its functionality to other objects by invoking delegates.
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Fields

        private Action<object> execute;
        private Predicate<object> canExecute;

        #endregion

        #region Events

        private event EventHandler CanExecuteChangedInternal;

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
                CanExecuteChangedInternal += value;
            }

            remove
            {
                CommandManager.RequerySuggested -= value;
                CanExecuteChangedInternal -= value;
            }
        }

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        public RelayCommand(Action<object> execute)
            : this(DefaultCanExecute, execute)
        {

        }

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Predicate<object> canExecute, Action<object> execute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            if (canExecute == null)
            {
                throw new ArgumentNullException("canExecute");
            }

            this.execute = execute;
            this.canExecute = canExecute;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Sets Can Execute Property to True or False
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns>Whether or not the action can execute</returns>
        /// <remarks>
        /// Uses DebuggerStepThrough from System.Diagnostics
        /// CanExecute can happen a lot as the UI checks if it CanExecute something.
        /// Debugger will step over unless there is an explicit break point inside of it
        /// </remarks>
        [DebuggerStepThrough()]
        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute(parameter);
        }

        /// <summary>
        /// Launches Execute ICommand
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            execute(parameter);
        }

        public void OnCanExecuteChanged()
        {
            EventHandler handler = CanExecuteChangedInternal;

            if (handler != null)
            {
                //DispatcherHelper.BeginInvokeOnUIThread(() => handler.Invoke(this, EventArgs.Empty));
                handler.Invoke(this, EventArgs.Empty);
            }
        }


        private static bool DefaultCanExecute(object parameter)
        {
            return true;
        }

        #endregion
    }
}
