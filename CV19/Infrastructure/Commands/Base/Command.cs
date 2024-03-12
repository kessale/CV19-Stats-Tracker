using System;
using System.Windows.Input;

// Defines the abstract base for commands, supporting the ICommand interface implementation.
namespace CV19.Infrastructure.Commands.Base
{
    internal abstract class Command : ICommand
    {
        // Event to re-evaluate whether the command can execute.
        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        // Determines whether the command can be executed in its current state.
        public abstract bool CanExecute(object parameter);

        // Defines the method to be called when the command is invoked.
        public abstract void Execute(object parameter);
    }
}
