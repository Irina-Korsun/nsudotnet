using System;
using System.Linq;
using TestConsole;
using DataBaseLab.MainSystem;
using DataBaseLab.DataObjects;
using DataBaseApp;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.Generic;
using System.Data.Entity;
using System.Web;
using System.Data;

namespace WpfFormsAndTables
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BaseContext context;
        public MainWindow()
        {
            this.context = new BaseContext();
            InitializeComponent();
        }


        private void Dep_Click(object sender, RoutedEventArgs e)
        {
            Dat.DataContext = context.DepartmentsBase.ToList<Departments>();
        }


        private void Emp_click(object sender, RoutedEventArgs e)
        {
            Dat.DataContext = context.EmployeesBase.ToList<Employees>();
        }

        private void Pos_Click(object sender, RoutedEventArgs e)
        {
            Dat.DataContext = context.PositionsBase.ToList<Positions>();
        }





       
    }
}
