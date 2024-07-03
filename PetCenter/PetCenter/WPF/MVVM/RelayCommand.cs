using System.Windows.Input;

namespace PetCenter.WPF.MVVM
{
    public class RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
        : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object? parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            execute(parameter);
        }
    }


    internal class RelayCommand<T>(Action<T> execute, Func<T, bool>? canExecute = null) : ICommand
    {
        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object? parameter)
        {
            if (parameter is T typedParameter)
            {
                return canExecute == null || canExecute(typedParameter);
            }
            return false;
        }

        public void Execute(object? parameter)
        {
            if (parameter is T typedParameter)
            {
                execute(typedParameter);
            }
        }
    }
}