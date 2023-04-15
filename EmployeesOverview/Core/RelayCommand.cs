using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace EmployeesOverview.Core
{
    public class RelayCommand : IDelegateCommand
    {
        private readonly Action<object> _executeAction;
        private readonly Func<object, bool> _canExecuteAction;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute)
        {
            this._executeAction = execute;
            this._canExecuteAction = canExecute;
        }

        public RelayCommand(Action<object> execute)
        {
            this._executeAction = execute;
            this._canExecuteAction = this.AlwaysCanExecute;
        }

        public void Execute(object param) => _executeAction(param);

        public bool CanExecute(object param) => _canExecuteAction?.Invoke(param) ?? true;

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        private bool AlwaysCanExecute(object param)
        {
            return true;
        }
    }
    public interface IDelegateCommand : ICommand
    {
        void RaiseCanExecuteChanged();
    }
}
