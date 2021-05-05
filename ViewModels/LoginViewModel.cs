﻿using S3Eksamen.Model;
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
        // LoginConverter

        // LoginCommand
        private LoginCommand loginCommand;
        public LoginCommand LoginCommand { get => loginCommand; set => loginCommand = value; }

        // User
        private UserModel user;
        public UserModel User { get => user; set => user = value; }

        public LoginViewModel()
        {
            this.LoginCommand = new LoginCommand(this);
        }


        public void Login(object paramater)
        {
            var data = paramater as object[];
            var Username = data[0] as String;
            var Password = data[1] as String;
            // Får context som er database connection som jeg skal bruge til at logge ind
            using var context = new LoginContext();

            Debug.WriteLine(Username);
        }
    }
}
