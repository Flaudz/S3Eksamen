using S3Eksamen.Model;
using S3Eksamen.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Eksamen.Models
{
    public class UserModel : INotifyPropertyChanged
    {
        private int id;
        private string userName;
        private string password;

        public int Id { get => id; set => id = value; }
        public string UserName
        {
            get { return userName; }
            set
            {
                if(userName != value)
                {
                    userName = value;
                    RaisePropertyChanged("UserName");
                }
            }
        }
        public string Password
        {
            get { return password; }
            set
            {
                if (password != value)
                {
                    password = value;
                    RaisePropertyChanged("Password");
                }
            }
        }

        public void Register()
        {
            using LoginContext context = new LoginContext();

            var checkUsername = context.Users.Where(s => s.UserName == this.UserName).ToList();
            if(checkUsername.Count == 0)
            {
                context.Add(this);
                context.SaveChanges();
                RegisterViewModel RegisterView = (RegisterViewModel)App.Current.Resources["sharedRegisterViewmodel"];
                RegisterView.ChangeVisibility();
            }
        }

        public void Login()
        {
            LoginViewModel LoginView = (LoginViewModel)App.Current.Resources["sharedLoginViewmodel"];
            // Får context som er database connection som jeg skal bruge til at logge ind
            using LoginContext context = new LoginContext();
            // Her får jeg alle Brugere fra databasen som har det samme navn og adgangskode som man skrev ind og sætter ind i en liste
            var allUsers = context.Users.Where(s => s.UserName == this.UserName && s.Password == this.Password).ToList();
            if (allUsers.Count != 0)
            {
                LoginView.User.UserName = allUsers[0].UserName;
                LoginView.User.Password = allUsers[0].Password;
                LoginView.User.Id = allUsers[0].Id;
                LoginView.LoginVisibility.Visibility = "Hidden";
                LoginView.WelcomeVisibility.Visibility = "Visible";
            }
        }

        // Property Changed
        public event PropertyChangedEventHandler PropertyChanged;

        // This fuction is what informors the thing that it is changed
        private void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
