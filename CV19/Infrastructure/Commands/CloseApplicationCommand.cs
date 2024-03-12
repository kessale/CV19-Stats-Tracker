using CV19.Infrastructure.Commands.Base;
using System.Windows;

// Implements a command to shut down the application.
namespace CV19.Infrastructure.Commands
{
    internal class CloseApplicationCommand : Command
    {
        // Always allows execution.
        public override bool CanExecute(object parameter) => true;

        // Executes the command to shut down the application.
        public override void Execute(object parameter) => Application.Current.Shutdown();
    }
}
