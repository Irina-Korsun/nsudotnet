using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLab.DataObjects;
using DataBaseLab.MainSystem;

namespace TestConsole.DataObjects.BrigadesBase
{
    class BrigadesAdding
    {
          private BaseContext context;
          public BrigadesAdding()
        {
            context = new BaseContext();
        }
          public void CreateBrigades()
          {
              CreateBrigades("Brigade 1");
              CreateBrigades("Brigade 2");
              CreateBrigades("Brigade 3");
              CreateBrigades("Brigade 4");
              CreateBrigades("Brigade 5");
              CreateBrigades("Brigade 6");
              context.SaveChanges();
          }
          private void CreateBrigades(string Name)
          {
              context.BrigadesBase.Add(new Brigades()
              {
                  Name = Name
              });
          }
    }
}
