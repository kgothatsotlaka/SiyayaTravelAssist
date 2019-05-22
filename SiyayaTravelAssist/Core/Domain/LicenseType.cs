using System.Collections.Generic;

namespace SiyayaTravelAssist.Core.Domain
{
    public class LicenseType
    {
        public LicenseType()
        {
            Drivers = new HashSet<Driver>();
        }
        public int Id { get; set; }
        public string Description { get; set; }


        public ICollection<Driver> Drivers{ get; set; }
    }
}