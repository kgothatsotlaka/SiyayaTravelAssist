using System.Data.Entity.ModelConfiguration;
using SiyayaTravelAssist.Core.Domain;

namespace SiyayaTravelAssist.Persistence.EntityConfigurations
{
    public class TripConfiguration: EntityTypeConfiguration<Trip>
    {
        public TripConfiguration()
        {
            HasRequired(h => h.Passenger)
                .WithMany(c => c.Trips)
                .HasForeignKey(c => c.PassengerId)
                .WillCascadeOnDelete(false);
        }
    }
}