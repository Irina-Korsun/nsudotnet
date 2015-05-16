using System;
using System.Linq;
using TestConsole;
using DataBaseLab.MainSystem;
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
            var add = new TestConsole.DropAndAdd();
            add.AddDataToDataBase();
            foreach (var t in context.EmployeesBase.ToList())
            {
                this.ListBox1.Items.Add(t.Name);
            }
         //   var a = new MainWindow();
            //this.Start();
        }
       public void Start()
        {
            
            //add.AddDataToDataBase();
        }
    }
}
