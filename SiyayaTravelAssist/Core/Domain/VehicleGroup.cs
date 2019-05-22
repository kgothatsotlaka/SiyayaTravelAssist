using System.Collections.Generic;

namespace SiyayaTravelAssist.Core.Domain
{
    public class VehicleGroup
    {
        public VehicleGroup()
        {
            Vehicles = new HashSet<Vehicle>();
        }
        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<Vehicle> Vehicles { get; set; }
    }
}