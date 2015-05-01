using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseLab.DataObjects
{
    public class ActualFlight
    {
        [Key]
        public long ID { get; set; }
        public Flights Flight { get; set; }
        public Aircrafts Aircraft { get; set; }
        public FlightStatuses FlightStatus { get; set; }
        public int SeatsCount { get; set; }
        public int TicketsSold { get; set; }
        public int TicketsReturned { get; set; }
        public DateTime DepartureDateTime { get; set; }
        public DateTime ArivalDateTime { get; set; }
    }
}