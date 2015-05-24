using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseLab.DataObjects
{
    [Table("DepartmentsBase")]
    public class Departments
    {
        [Key]
        public long ID { get; set; }
        public string URI { get; set; }
        public string Name { get; set; }
        public Employees Chief { get; set; }
        public List<Employees> Employees { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}