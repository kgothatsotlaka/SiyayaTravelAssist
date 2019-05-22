namespace SiyayaTravelAssist.Core.Domain
{
    public class Location
    {
        public int Id { get; set; }
        public string LocationName { get; set; }
        public Trip PickupTrip { get; set; }
        public Trip DropOffTrip { get; set; }
    }
}