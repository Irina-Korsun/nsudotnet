using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseLab.DataObjects
{
    [Table("TechChecksBase")]
    public class TechChecks
    {
        [Key]
        public long ID { get; set; }
        public DateTime Date { get; set; }
        public bool MustBeFixed { get; set; }
        public DateTime Created { get; set; }
    }
}
