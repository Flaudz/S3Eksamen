using S3Eksamen.Model;
using S3Eksamen.Models;
using S3Eksamen.ViewModels.Commands;
using S3Eksamen.ViewModels.Converter;
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
        // Change to Register Canvas
        private ChangeToRegisterCommand changeToRegisterCommand;
        public ChangeToRegisterCommand ChangeToRegisterCommand { get => changeToRegisterCommand; set => changeToRegisterCommand = value; }

        // WelcomeCanvas
        private VisibilityModel welcomeVisibility = new VisibilityModel();
        public VisibilityModel WelcomeVisibility { get => welcomeVisibility; set => welcomeVisibility = value; }

        // LoginCanvas
        private VisibilityModel loginVisibility = new VisibilityModel();
        public VisibilityModel LoginVisibility { get => loginVisibility; set => loginVisibility = value; }

        // LoginCommand
        private LoginCommand loginCommand;
        public LoginCommand LoginCommand { get => loginCommand; set => loginCommand = value; }

        // User
        private UserModel user = new UserModel();
        public UserModel User { get => user; set => user = value; }

        public LoginViewModel()
        {
            this.LoginCommand = new LoginCommand(this);
            this.ChangeToRegisterCommand = new ChangeToRegisterCommand(this);

            WelcomeVisibility.Visibility = "Hidden";
            LoginVisibility.Visibility = "Visible";
        }

        public void Login(object paramater)
        {
            // Her får jeg både brugernavn og adgangskode fra button binding
            object[] data = paramater as object[];
            string Username = data[0] as string;
            string Password = data[1] as string;
            // Her laver jeg en ny bruger med det brugernavn og adgangskode som jeg skrev ind før
            UserModel sendUser = new UserModel { UserName = Username, Password = Password };
            // Her kalder jeg den Bruger funktion som jeg har lavet som logger brugeren ind
            sendUser.Login();
        }

        public void ChangeToRegister()
        {
            loginVisibility.Visibility = "Hidden";
            RegisterViewModel RegisterView = (RegisterViewModel)App.Current.Resources["sharedRegisterViewmodel"];
            RegisterView.RegisterVisibility.Visibility = "Visible";
        }
    }
}
