using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using System.ComponentModel;

namespace WpfFormsAndTables
{
    public class MyViewModel : INotifyPropertyChanged
    {
        private string name;
        private string employee;
        private string chief;
        
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("Name");
            }
       }
        public string Employee
        {
            get { return employee; }
            set 
            { 
                employee = value;
                OnPropertyChanged("Employee");
            }
        }
        public string Chief 
            { 
            get { return chief; }
            set 
            { 
                chief = value;
                OnPropertyChanged("Chief");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }

}
