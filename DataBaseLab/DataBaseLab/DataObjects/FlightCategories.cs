using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseLab.DataObjects
{
    public class FlightCategories
    {
        [Key]
        public long ID { get; set; }
        public string Type { get; set; }
    }
}