using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLab.DataObjects;
using DataBaseLab.MainSystem;

namespace TestConsole.DataObjects.PositionsBase
{
    class PositionsAdding
    {
          private BaseContext context;
          public PositionsAdding()
        {
            context = new BaseContext();
        }
          public void CreatePositions()
          {
              CreatePositions("HRManager", 1);
              CreatePositions("Dispetcher", 2);
              CreatePositions("Programmer", 1);
              CreatePositions("Doctor", 4);
              CreatePositions("Teacher", 3);
              context.SaveChanges();
          }
          private void CreatePositions(string Name, int MedicCheckPeriod)
          {
              context.PositionsBase.Add(new Positions()
              {
                  Name = Name,
                  MedicCheckPeriod = MedicCheckPeriod
              });
          }
    }
}
