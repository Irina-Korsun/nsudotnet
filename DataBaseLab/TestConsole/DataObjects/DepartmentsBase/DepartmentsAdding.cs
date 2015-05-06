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
              CreateDepartments("HRDepartment");
              CreateDepartments("ProgramDepartment");
              CreateDepartments("EvilDepartment");
              CreateDepartments("ChocolateDepartment");
              context.SaveChanges();
          }
          private void CreateDepartments(string Name)
          {
              context.DepartmentsBase.Add(new Departments
              {
                  Name = Name,
                  Chief = null
              });
          }
    }
}
