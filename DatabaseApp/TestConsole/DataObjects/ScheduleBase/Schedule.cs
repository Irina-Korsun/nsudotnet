using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseLab.DataObjects
{
    [Table("SceduleBase")]
    public class Schedule
    {
        [Key]
        public long ID { get; set; }
        public AircraftTypes AircraftType { get; set; }
        public Flights Flight { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArivalDateTime { get; set; }
        public int Price { get; set; }
    }
}