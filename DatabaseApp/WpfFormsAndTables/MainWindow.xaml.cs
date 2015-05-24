using System;
using System.Linq;
using System.Reflection;
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
using System.Text;
using System.Data.Entity;
using System.Web;
using System.Data;

namespace WpfFormsAndTables
{
    public partial class MainWindow : Window
    {
        private BaseContext context;
        public MainWindow()
        {
            using (var db = new BaseContext())
            {
                db.ArivalAirportsBase.Add(new ArivalAirports { Name = "Another airport " });
                db.SaveChanges();

                foreach (var blog in db.ArivalAirportsBase)
                {
                    Console.WriteLine(blog.Name);
                }
            } 
 
            this.context = new BaseContext();
            InitializeComponent();

        }


        private void Dep_Click(object sender, RoutedEventArgs e)
        {
            Dat.DataContext = context.DepartmentsBase.ToList<Departments>();
            this.TableName.Content = "Departments";
        }

        public DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        private void Emp_click(object sender, RoutedEventArgs e)
        {
            Dat.DataContext = context.EmployeesBase.ToList<Employees>();
            this.TableName.Content = "Employees";
            FillEmployeeRequestList();
        }

        private void Pos_Click(object sender, RoutedEventArgs e)
        {
            Dat.DataContext = context.PositionsBase.ToList<Positions>();
            this.TableName.Content = "Positions";
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }
            public override string ToString()
            {
                return Text;
            }
        }
        private void FillEmployeeRequestList()
        {
            ComboboxItem item1 = new ComboboxItem();
            item1.Text = "Получить число работников аэропорта";
            item1.Value = 1;
            this.DropDownList.Items.Add(item1);
            ComboboxItem item2 = new ComboboxItem();
            item2.Text = "Получить список всех начальников отделов";
            item2.Value = 2;
            this.DropDownList.Items.Add(item2);

        }

        private void DropDownList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = (DropDownList.SelectedItem as ComboboxItem).Value.ToString();
            switch(Convert.ToString(a)){
                case "1":
                    MessageBox.Show(context.EmployeesBase.ToList<Employees>().Count.ToString());
                    break;
                case "2":
                    List<Employees> chiefs = new List<Employees>();
                    var t = context.DepartmentsBase.ToList();
                    foreach (var x in t)
                    {
                    chiefs.Add(x.Chief);
                    }
                    Dat.DataContext = chiefs;
                    break;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            context.SaveChanges();
        }

        private void Child_Click(object sender, RoutedEventArgs e)
        {
            Dat.DataContext = context.ChildrenBase.ToList<Childs>();
            this.TableName.Content = "Childs";
        }

        private void Med_Check(object sender, RoutedEventArgs e)
        {
            Dat.DataContext = context.MedicalChecksBase.ToList<MedicalChecks>();
            this.TableName.Content = "Medical Checks";
        }

        private void Brigade_Click(object sender, RoutedEventArgs e)
        {
            Dat.DataContext = context.BrigadesBase.ToList<Brigades>();
            this.TableName.Content = "Brigades";
        }

        private void AddDepartment_Click(object sender, RoutedEventArgs e)
        {
            var Addwin = new AddingWindow();
            Addwin.ToAdd<Departments>();
            Addwin.ShowDialog();
            //var t = (Departments)Addwin.GetResult();

            //context.DepartmentsBase.Add(t);
            //context.SaveChanges();
        }

        private void AddEmployee_Click(object sender, RoutedEventArgs e)
        {
            var Addwin = new AddingWindow();
            Addwin.ToAdd<Employees>();
            Addwin.ShowDialog();
           // var t = (Employees)Addwin.GetResult();

            //context.EmployeesBase.Add(t);
            //context.SaveChanges();
        }
    }
}
