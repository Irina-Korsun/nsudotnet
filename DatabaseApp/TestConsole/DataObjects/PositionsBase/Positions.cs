using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseLab.DataObjects
{
    [Table("PositionsBase")]
    public class Positions
    {
        [Key]
        public long ID { get; set; }
        public string Name { get; set; }
        public int MedicCheckPeriod { get; set; }
    }
}