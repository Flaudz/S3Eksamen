using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace S3Eksamen.ViewModels.Commands
{
    public class ChangeToRegisterCommand : ICommand
    {
        private LoginViewModel loginViewModel;

        public ChangeToRegisterCommand(LoginViewModel loginViewModel)
        {
            this.loginViewModel = loginViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.loginViewModel.ChangeToRegister();
        }
    }
}
