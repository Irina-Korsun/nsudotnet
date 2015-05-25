using System;
using System.Linq;
using System.Reflection;
using TestConsole;
using DataBaseLab.MainSystem;
using DataBaseLab.DataObjects;
using DataBaseApp;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Data.Entity;
using System.Windows.Shapes;
using System.Collections;
using System.Collections.ObjectModel;
using System.Reflection;
using DataBaseLab.DataObjects;
using System.Collections.Generic;

namespace WpfFormsAndTables
{
    
    public partial class AddDepWindow : Window
    {
        protected BaseContext context;
        public MyViewModel _event = new MyViewModel()
        {
            Name = "Noname",
            Employee = "Noname",
            Chief = "Noname"

        };
        public AddDepWindow()
        {
            InitializeComponent();
            this.context = new BaseContext();
        }


        private void EventName_TextChanged(object sender, TextChangedEventArgs e)
  {
    _event.Name = Name.Text;
  }


  private void EventEmployee_TextChanged(object sender, TextChangedEventArgs e)
  {
      _event.Employee = Employee.Text;
  }

  private void EventChief_TextChanged(object sender, TextChangedEventArgs e)
  {
      _event.Chief = Chief.Text;
  }

  private void Button_Click_1(object sender, RoutedEventArgs e)
  {
      var dep = context.DepartmentsBase.Where(s => s.Name == _event.Name) as Departments;
      var emp = context.EmployeesBase.Where(w => w.Name == _event.Employee) as Employees;
      var chief = context.EmployeesBase.Where(q => q.Name == _event.Chief) as Employees;
      if (dep != null)
      {
          if (emp != null)
          {
              dep.Employees.Add(emp);
          }
          else
          {
              var new_emp = new Employees()
              {
                  Name = _event.Employee
              };
              // context.EmployeesBase.Add(new_emp);
              dep.Employees.Add(new_emp);
          }
          if (chief != null)
          {
              dep.Chief = chief;
          }
          else
          {
              var new_chief = new Employees()
              {
                  Name = _event.Chief
              };
              context.EmployeesBase.Add(new_chief);
              dep.Chief = new_chief;
          }
          context.DepartmentsBase.Add(dep);
      }
      else
      {
          var new_dep = new Departments();
          new_dep.Name = _event.Name;
          if (emp != null)
          {
              new_dep.Employees.Add(emp);
          }
          else
          {
              var new_emp = new Employees()
              {
                  Name = _event.Employee
              };
              // context.EmployeesBase.Add(new_emp);
              new_dep.Employees = new List<Employees>(){
                 new_emp
              };
          }
          if (chief != null)
          {
              new_dep.Chief = chief;
          }
          else
          {
              new_dep.Chief = emp;
          }
          context.DepartmentsBase.Add(new_dep);
      }
      context.SaveChanges();
      MessageBox.Show("ADDED");
      this.Close();
  }

    }
       
}
