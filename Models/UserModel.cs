using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        // Property Changed
        public event PropertyChangedEventHandler PropertyChanged;

        // This fuction is what informors the thing that it is changed
        private void RaisePropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
