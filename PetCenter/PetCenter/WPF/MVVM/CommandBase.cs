using System.Windows.Input;

namespace PetCenter.WPF.MVVM
{
    public abstract class CommandBase : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        public virtual bool CanExecute(object? parameter)
        {
            return true;
        }
        public abstract void Execute(object? parameter);
        protected void OnCanExecutedChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
