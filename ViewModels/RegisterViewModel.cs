using S3Eksamen.Models;
using S3Eksamen.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Eksamen.ViewModels
{
    public class RegisterViewModel
    {
        private VisibilityModel registerVisibility = new VisibilityModel();
        public VisibilityModel RegisterVisibility { get => registerVisibility; set => registerVisibility = value; }

        private RegisterCommand registerCommand;
        public RegisterCommand RegisterCommand { get => registerCommand; set => registerCommand = value; }

        public RegisterViewModel()
        {
            this.RegisterCommand = new RegisterCommand(this);

        }

        // Register function
        public void Register(object paramater)
        {
            object[] data = paramater as object[];
            string Username = data[0] as string;
            string Password = data[1] as string;
            UserModel registerUser = new UserModel{ UserName = Username, Password = Password};
            registerUser.Register();
        }

        public void ChangeVisibility()
        {
            RegisterVisibility.Visibility = "Hidden";
            LoginViewModel LoginView = (LoginViewModel)App.Current.Resources["sharedLoginViewmodel"];
            LoginView.LoginVisibility.Visibility = "Visible";
        }
    }
}
