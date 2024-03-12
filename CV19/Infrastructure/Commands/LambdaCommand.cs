using CV19.Infrastructure.Commands.Base;
using System;

// Represents a command whose sole purpose is to relay its functionality to other objects by invoking delegates.
namespace CV19.Infrastructure.Commands
{
    internal class LambdaCommand : Command
    {
        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;

        // Initializes a new instance of the LambdaCommand.
        public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            _Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _CanExecute = CanExecute;
        }

        // Determines whether the command can execute in its current state using a delegate.
        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;

        // Executes the command using the provided delegate.
        public override void Execute(object parameter) => _Execute(parameter);
    }
}
