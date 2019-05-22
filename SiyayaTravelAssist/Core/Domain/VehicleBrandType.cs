using System.Collections.Generic;

namespace SiyayaTravelAssist.Core.Domain
{
    public class VehicleBrandType
    {
        public VehicleBrandType()
        {
            Vehicles = new HashSet<Vehicle>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }

        public virtual VehicleModelType VehicleModelType { get; set; }
        public int VehicleModelTypeId { get; set; }
    }
}