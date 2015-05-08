using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLab.DataObjects;
using DataBaseLab.MainSystem;


namespace TestConsole.DataObjects.EmployeesAndChildsBase
{
    class EmployeesAndChildrensAdding
    {
         private BaseContext context;
         public EmployeesAndChildrensAdding()
        {
            context = new BaseContext();
        }
         public void CreateEmployeesAndChildrens()
         {
             CreateEmployeesAndChildrens(4, 3, 5, 20000, "Andrey", true, "Sa", "Nasty");
             CreateEmployeesAndChildrens(2, 3, 2, 20000, "Ghj", true, "VVV", "I");
             CreateEmployeesAndChildrens(4, 1, 2, 10000, "VBN", true, "We", "I");
             CreateEmployeesAndChildrens(1, 2, 3, 20000, "LKH", true, "SSD", "Na");
             context.SaveChanges();
         }
         private void CreateEmployeesAndChildrens(int PositionID, int DepartmentID, int BrigadeID, int Salary,
             string EmployeeName, bool Sex, string EmployeeAndChildSurname, string ChildName)
         {
             var a = context.PositionsBase.Single(s => s.ID == PositionID) as Positions;
             var f = context.DepartmentsBase.Single(s => s.ID == DepartmentID) as Departments;
             var b = context.BrigadesBase.Single(s => s.ID == BrigadeID) as Brigades;
             context.EmployeesBase.Add(new Employees
             {
                 Position = a,
                 Department = f,
                 Name = EmployeeName,
                 Surname = EmployeeAndChildSurname,
                 HireDate = DateTime.Now,
                 Sex = true,
                 BirthDate = DateTime.Now,
                 Salary = Salary,
                 Brigade = b,
                 Children = new List<Childs>()
                    { new Childs()
                        {
                            Name = ChildName, 
                            SurName = EmployeeAndChildSurname 
                        } 
                    }
             });
         }
    }
}
