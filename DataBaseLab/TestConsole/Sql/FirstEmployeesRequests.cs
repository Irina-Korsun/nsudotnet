using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLab.DataObjects;
using DataBaseLab.MainSystem;

namespace TestConsole.Sql
{
    class FirstEmployeesRequests
    {
         private BaseContext context;
         public FirstEmployeesRequests()
        {
            context = new BaseContext();
        }

        //Получить список и общее число всех pаботников аэpопоpта
         public void EmployeesListRequest()
         {
             var t = context.EmployeesBase.ToList();
             Show(t);
             Console.WriteLine(t.Count);
         }
        //Получить список работников указанного отдела
         public void EmployeesOfDepartmentRequest(string department)
         {
             try
             {
                 var t = context.DepartmentsBase.Single(x => x.Name == department);

                 var w = t.Employees.ToList();
                 foreach (var x in w)
                 {
                     Console.WriteLine(x.Name);
                 }
             }
             catch (System.InvalidOperationException e)
             {
                 Console.WriteLine("Wrong department name");
             }

         }
        //Получить список и число всех начальников отделов
         public void ChiefListRequest()
         {
             var t = context.DepartmentsBase.ToList();
             foreach (var x in t)
             {
                 Console.WriteLine(x.Chief.Name);
             }
             Console.WriteLine(t.Count);

         }
         private void Show(List<Employees> data)
         {
             foreach (var employee in data)
             {
                 Console.WriteLine(employee.Name);
             }
         }
        //Получить список всех отделов
         public void DepartmentListRequest()
         {
             var t = context.DepartmentsBase.ToList();
             foreach (var x in t)
             {
                 Console.WriteLine(x.Name);
             }

         }
    }
}
