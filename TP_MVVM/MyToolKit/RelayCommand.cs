using System;
using System.Windows.Input;

namespace MyToolKit
{

    public class RelayCommand<T> : ICommand
    {


        private readonly Action<T> execute;

        private readonly Func<T, bool> canExecute;


        public RelayCommand(Action<T> execute, Func<T, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute ?? (t => true);
        }


        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            T param = (T)parameter;
            return canExecute(param);
        }

        public void Execute(object? parameter)
        {
            T param = (T)parameter;
            execute(param);
        }

        public void RefreshCommand() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

    }

    public class RelayCommand : RelayCommand<object>
    {
        public RelayCommand(Action execute, Func<bool> canExecute = null) : base(
            o => execute(),
            o => canExecute != null ? canExecute() : true
        )
        {
        }
    }
}

