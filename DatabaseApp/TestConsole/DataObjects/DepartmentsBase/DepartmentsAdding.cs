using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLab.DataObjects;
using DataBaseLab.MainSystem;

namespace TestConsole.DataObjects.DepartmentsBase
{
    class DepartmentsAdding
    {
          private BaseContext context;
          public DepartmentsAdding()
        {
            context = new BaseContext();
        }
          public void CreateDepartments()
          {
              CreateDepartments("HRDepartment", 1, 1, 10000, "Mihail", true, "Reas", "Lesha");
              CreateDepartments("ProgramDepartment", 1, 2, 20000, "Lesha", true, "Trex", "Ilya");
              CreateDepartments("EvilDepartment", 3,4, 20000, "Petya", true, "Sart", "Nastya");
              CreateDepartments("ChocolateDepartment", 1, 2, 10000, "Kolya", true, "WWW", "QQQ");
              CreateDepartments("Chocolate", 2, 2, 20000, "Artem", true, "VVV", "III");
              context.SaveChanges();
          }

          private void CreateDepartments(string Name, int PositionID, int BrigadeID, int Salary,
             string EmployeeName, bool Sex, string EmployeeAndChildSurname, string ChildName)
          {
              var a = context.PositionsBase.Single(s => s.ID == PositionID) as Positions;
              var b = context.BrigadesBase.Single(s => s.ID == BrigadeID) as Brigades;
              var emp = new Employees()
                {
                    Position = a,
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
                };
              context.DepartmentsBase.Add(new Departments
              {
                  Name = Name,
                  Employees = new List<Employees>()
                  {
                      emp
                      //new Employees
                  }
              });
              context.SaveChanges();
          }
          public void AddChiefsToDepartments()
          {
              foreach (var t in context.DepartmentsBase)
              {
                  t.Chief = t.Employees[0];
              }
              context.SaveChanges();
          }
    }
}
