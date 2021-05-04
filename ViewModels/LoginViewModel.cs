using S3Eksamen.Models;
using S3Eksamen.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Eksamen.ViewModels
{
    public class LoginViewModel
    {
        private UserModel user;
        private LoginCommand loginCommand;
        public UserModel User { get => user; set => user = value; }
        internal LoginCommand LoginCommand { get => loginCommand; set => loginCommand = value; }

        public LoginViewModel()
        {
            this.loginCommand = new LoginCommand(this);
        }

        public void Login()
        {
            Debug.WriteLine(User.UserName);
        }
    }
}
