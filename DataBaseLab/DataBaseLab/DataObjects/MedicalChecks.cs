using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseLab.DataObjects
{
    public class MedicalChecks
    {
        [Key]
        public long ID { get; set; }
        public Employees Employee { get; set; }
        public DateTime Date { get; set; }
        public bool Valid { get; set; }

    }
}