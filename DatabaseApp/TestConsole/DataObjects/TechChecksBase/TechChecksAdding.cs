using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLab.DataObjects;
using DataBaseLab.MainSystem;

namespace TestConsole.DataObjects.TechChecksBase
{
    class TechChecksAdding
    {
        private BaseContext context;
        public TechChecksAdding()
        {
            context = new BaseContext();
        }
        public void CreateTechChecks()
        {
            CreateTechChecks(true);
            CreateTechChecks(false);
            CreateTechChecks(true);
            CreateTechChecks(true);
            context.SaveChanges();
        }
        private void CreateTechChecks(bool MustBeFixed)
        {
            context.TechChecksBase.Add(new TechChecks()
            {
                Date = DateTime.Now,
                MustBeFixed = MustBeFixed,
                Created = DateTime.Now
            });
        }
    }
}
