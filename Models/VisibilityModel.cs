using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3Eksamen.Models
{
    public class VisibilityModel : INotifyPropertyChanged
    {
        private string visibility;

        public string Visibility
        {
            get { return visibility; }
            set
            {
                if(visibility != value)
                {
                    visibility = value;
                    RaisePropertyChanged("Visibility");
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
