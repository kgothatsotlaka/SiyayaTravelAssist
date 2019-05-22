using System.Data.Entity.ModelConfiguration;
using SiyayaTravelAssist.Core.Domain;

namespace SiyayaTravelAssist.Persistence.EntityConfigurations
{
    public class LocationConfiguration: EntityTypeConfiguration<Location>
    {
        public LocationConfiguration()
        {
            HasOptional(b => b.DropOffTrip)
                .WithRequired(p => p.DropOffLocation);
            HasOptional(b => b.PickupTrip)
                .WithRequired(p => p.PickupLocation);
        }
    }
}