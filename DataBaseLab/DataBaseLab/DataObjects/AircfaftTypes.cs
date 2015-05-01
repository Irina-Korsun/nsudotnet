using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseLab.DataObjects
{
    [Table("AircraftTypesBase")]
    public class AircfaftTypes
    {
        [Key]
        public long ID { get; set; }
        public string Name { get; set; }
    }
}
