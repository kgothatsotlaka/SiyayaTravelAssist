namespace SiyayaTravelAssist.Core.Domain
{
    public class Passenger
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Telephone { get; set; }

        public Trip TripId { get; set; }

    }
}