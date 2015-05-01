using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseLab.DataObjects
{
    public class Flights
    {
        [Key]
        public long ID { get; set; }
        public FlightCategories Category { get; set; }
        public ArivalAirport Route { get; set; }
        public int PassengersCount { get; set; }

    }
}