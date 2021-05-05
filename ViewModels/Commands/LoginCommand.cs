﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace S3Eksamen.ViewModels.Commands
{
    public class LoginCommand : ICommand
    {
        private LoginViewModel viewModel;
        public event EventHandler CanExecuteChanged;

        public LoginCommand(LoginViewModel viewModel)
        {
            this.viewModel = viewModel;
        }
        public bool CanExecute(object parameter)
        {
            if(parameter != null)
            {
                var s = parameter as String;
                if (String.IsNullOrEmpty(s))
                {
                    return false;
                }
                return true;
            }
            return true;
        }

        public void Execute(object parameter)
        {
            this.viewModel.Login(parameter as String);
        }
    }
}
