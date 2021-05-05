using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace S3Eksamen.ViewModels.Commands
{
    public class RegisterCommand : ICommand
    {
        private RegisterViewModel registerViewModel;

        public RegisterCommand(RegisterViewModel registerViewModel)
        {
            this.registerViewModel = registerViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.registerViewModel.Register(parameter);
        }
    }
}
