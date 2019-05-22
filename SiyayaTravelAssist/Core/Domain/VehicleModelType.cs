using System.Collections.Generic;

namespace SiyayaTravelAssist.Core.Domain
{
    public class VehicleModelType
    {
        public VehicleModelType()
        {
            VehicleBrandTypes = new HashSet<VehicleBrandType>();
        }
        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<VehicleBrandType> VehicleBrandTypes { get; set; }

    }
}