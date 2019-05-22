using System.Collections.Generic;
using System.Security.AccessControl;

namespace SiyayaTravelAssist.Core.Domain
{
    public class Vehicle
    {

        public Vehicle()
        {
            BookingTrips = new HashSet<BookingTrip>();
        }

        public int Id { get; set; }
        
        

        //Vehicle - VehicleColor (H-C)
        public virtual VehicleColor VehicleColor { get; set; }
        public int VehicleColorId { get; set; }
        
        //Vehicle - VehicleGroup (H-C)
        public virtual VehicleGroup VehicleGroup { get; set; }
        public int VehicleGroupId { get; set; }

        //Vehicle - BrandType (H-C)
        public virtual VehicleBrandType VehicleBrandType { get; set; }
        public int VehicleBrandTypeId { get; set; }


        public ICollection<BookingTrip> BookingTrips { get; set; }

    }
}