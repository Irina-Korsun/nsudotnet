using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataBaseLab.DataObjects;

namespace DataBaseLab.MainSystem
{
    public class BaseContext : DbContext
    {
        public DbSet<ActualFlights> ActualFlightsBase { get; set; }
        public DbSet<AircfaftTypes> AircraftTypesBase { get; set; }
        public DbSet<Aircrafts> AircraftsBase { get; set; }
        public DbSet<ArivalAirports> ArivalAirportsBase { get; set; }
        public DbSet<Brigades> BrigadesBase { get; set; }
        public DbSet<Childs> ChildrenBase { get; set; }
        public DbSet<Departments> DepartmentsBase { get; set; }
        public DbSet<Employees> EmployeesBase { get; set; }
        public DbSet<FlightCategories> FlightCategoriesBase { get; set; }
        public DbSet<Flights> FlightsBase { get; set; }
        public DbSet<FlightStatuses> FlightStatusesBase { get; set; }
        public DbSet<MedicalChecks> MedicalChecksBase { get; set; }
        public DbSet<Positions> PositionsBase { get; set; }
        public DbSet<Schedule> ScheduleBase { get; set; }
        public DbSet<TechChecks> TechChecksBase { get; set; }
        public BaseContext() : base("name=DBConnectionString") { }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using Fluent API here
            modelBuilder.Entity<Childs>()
                       .HasRequired<Employees>(s => s.Parent)
                       .WithMany(s => s.Children)
                       .HasForeignKey(s => s.ID);
        }
    }
}