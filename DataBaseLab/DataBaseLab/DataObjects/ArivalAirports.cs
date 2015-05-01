using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseLab.DataObjects
{
    [Table("ArivalAirportsBase")]
    public class ArivalAirports
    {
        [Key]
        public long ID { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Town { get; set; }
    }
}
