using System.Data.Entity;
using SiyayaTravelAssist.Core.Domain;
using SiyayaTravelAssist.Persistence.EntityConfigurations;

namespace SiyayaTravelAssist.Persistence
{
    public class AppDbContext: DbContext
    {
        public AppDbContext()
            : base("name=Siyaya_Db_ConnectionString")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Booking> Bookings { get; set; }
        public virtual DbSet<BookingTrip> BookingTrips { get; set; }
        public virtual DbSet<BookingType> BookingTypes { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        //public virtual DbSet<Employee> Employees { get; set; }
        //public virtual DbSet<EmployeeType> EmployeeTypes { get; set; }
        //public virtual DbSet<Gender> Genders { get; set; }
        //public virtual DbSet<LicenseType> LicenseTypes { get; set; }
        //public virtual DbSet<Location> Locations { get; set; }
        //public virtual DbSet< Nationality> Nationalities { get; set; }
        //public virtual DbSet< Passenger> Passengers { get; set; }
        //public virtual DbSet< Quote> Quotes { get; set; }
        //public virtual DbSet< Title> Titles { get; set; }
        //public virtual DbSet< Trip> Trips { get; set; }
        //public virtual DbSet< Vehicle> Vehicles { get; set; }
        //public virtual DbSet< VehicleBrandType> VehicleBrandTypes { get; set; }
        //public virtual DbSet< VehicleColor> VehicleColors { get; set; }
        //public virtual DbSet< VehicleGroup> VehicleGroups { get; set; }
        //public virtual DbSet< VehicleModelType> VehicleModelTypes { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new BookingConfiguration());
            modelBuilder.Configurations.Add(new BookingTripConfiguration());
            modelBuilder.Configurations.Add(new BookingTypeConfiguration());
            modelBuilder.Configurations.Add(new ClientConfiguration());
            modelBuilder.Configurations.Add(new DriverConfiguration());


        }
    }
}