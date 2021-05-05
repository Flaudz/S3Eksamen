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

            WelcomeVisibility.Visibility = "Hidden";
            LoginVisibility.Visibility = "Visible";
        }


        public void Login(object paramater)
        {
            // Her får jeg både brugernavn og adgangskode fra button binding
            object[] data = paramater as object[];
            string Username = data[0] as String;
            string Password = data[1] as String;

            // Får context som er database connection som jeg skal bruge til at logge ind
            using LoginContext context = new LoginContext();
            // Her får jeg alle Brugere fra databasen og sætter ind i en liste
            var allUsers = context.Users.Where(s => s.UserName == Username && s.Password == Password).ToList();
            if(allUsers.Count != 0)
            {
                User.UserName = allUsers[0].UserName;
                User.Password = allUsers[0].Password;
                User.Id = allUsers[0].Id;
                CheckUser();
                LoginVisibility.Visibility = "Hidden";
                WelcomeVisibility.Visibility = "Visible";
            }
            else
            {
                Debug.WriteLine("Der var ikke en bruger som hed dette");
            }
        }

        public void CheckUser()
        {
            Debug.WriteLine(User.UserName);
        }
    }
}
