using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;
using SiyayaTravelAssist.Core.Domain;

namespace SiyayaTravelAssist.Persistence.EntityConfigurations
{
    public class GenderConfiguration: EntityTypeConfiguration<Gender>
    {
        public GenderConfiguration()
        {
            /**
             *  HasMany(c => c.Hospitals)
                .WithRequired(h => h.City)
                .HasForeignKey(c => c.CityId)
                .WillCascadeOnDelete(false);
             */
            HasMany(c => c.Employees)
                .WithRequired(h => h.Gender)
                .HasForeignKey(c => c.GenderId)
                .WillCascadeOnDelete(false);
        }
    }
}