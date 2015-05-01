using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBaseLab.DataObjects
{
    [Table("AircraftsBase")]
    public class Aircrafts
    {
        [Key]
        public long ID { get; set; }
        public AircfaftTypes AircraftType { get; set; }
        public TechChecks TechCheck { get; set; }
        public int NumberOfFlights { get; set; }
    }
}
