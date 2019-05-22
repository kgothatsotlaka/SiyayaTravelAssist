using System.Data.Entity.ModelConfiguration;
using SiyayaTravelAssist.Core.Domain;

namespace SiyayaTravelAssist.Persistence.EntityConfigurations
{
    public class PassengerConfiguration: EntityTypeConfiguration<Passenger>
    {
        public PassengerConfiguration()
        {
            HasMany(c => c.Trips)
                .WithRequired(h => h.Passenger)
                .HasForeignKey(c => c.PassengerId)
                .WillCascadeOnDelete(false);
        }
    }
}