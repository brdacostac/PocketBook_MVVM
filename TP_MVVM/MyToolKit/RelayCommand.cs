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
            this.canExecute = canExecute;
        }


        public event EventHandler? CanExecutedChanged;

        public void Exeute(object? parameter)
        {
            T param = (T)parameter;
            execute(param);
        }

        public bool CanExecute(object? parameter)
        {
            T param = (T)parameter;
            return CanExecute(param);
        }

        public void RefreshCommand() => CanExecutedChanged?.Invoke(this, EventArgs.Empty);



        event EventHandler ICommand.CanExecuteChanged
        {
            add
            {
                throw new NotImplementedException();
            }

            remove
            {
                throw new NotImplementedException();
            }
        }


        bool ICommand.CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        void ICommand.Execute(object parameter)
        {
            throw new NotImplementedException();
        }

        
    }

    public class RelayCommand : RelayCommand<object>
    {
        //Faut recopier cela:
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null) : base(execute, canExecute)
        {
        }
    }
}

