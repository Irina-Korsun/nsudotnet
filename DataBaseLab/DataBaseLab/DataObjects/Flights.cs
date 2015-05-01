using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseLab.DataObjects
{
    [Table("FlightsBase")]
    public class Flights
    {
        [Key]
        public long ID { get; set; }
        public FlightCategories Category { get; set; }
        public ArivalAirports Route { get; set; }
        public int PassengersCount { get; set; }
    }
}