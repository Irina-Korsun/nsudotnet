using System;
using System.Linq;
using System.Reflection;
using TestConsole;
using DataBaseLab.MainSystem;
using DataBaseLab.DataObjects;
using DataBaseApp;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfFormsAndTables
{
    /// <summary>
    /// Логика взаимодействия для DelDepWindow.xaml
    /// </summary>
    public partial class DelDepWindow : Window
    {
        protected BaseContext context;
        public MyViewModel _event = new MyViewModel()
        {
            Name = "Noname",
            Employee = "Noname",
            Chief = "Noname"

        };
        public DelDepWindow()
        {
            InitializeComponent();
            this.context = new BaseContext();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_event.Name);
            try
            {
                var dep = context.DepartmentsBase.Single(s => s.Name == _event.Name) as Departments;
                context.DepartmentsBase.Remove(dep);
                context.SaveChanges();
                MessageBox.Show("DELETED");
            }
            catch (System.InvalidOperationException)
            {
              
                this.Close();
            }
            this.Close();
        }

        private void EventName_TextChanged(object sender, TextChangedEventArgs e)
        {
            _event.Name = Name.Text;
        }
    }
}
