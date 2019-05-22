using System.Data.Entity;
using SiyayaTravelAssist.Core.Domain;

namespace SiyayaTravelAssist.Persistence
{
    public class AppDbContext:DbContext
    {
        public AppDbContext()
            : base("name=Siyaya_Db_ConnectionString")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingTrip> BookingTrips { get; set; }
        public DbSet<BookingType> BookingTypes { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<LicenseType> LicenseTypes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet< Nationality> Nationalities { get; set; }
        public DbSet< Passenger> Passengers { get; set; }
        public DbSet< Quote> Quotes { get; set; }
        public DbSet< Title> Titles { get; set; }
        public DbSet< Trip> Trips { get; set; }
        public DbSet< Vehicle> Vehicles { get; set; }
        public DbSet< VehicleBrandType> VehicleBrandTypes { get; set; }
        public DbSet< VehicleColor> VehicleColors { get; set; }
        public DbSet< VehicleGroup> VehicleGroups { get; set; }
        public DbSet< VehicleModelType> VehicleModelTypes { get; set; }




        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Configurations.Add(new BedConfiguration());


        }
    }
}