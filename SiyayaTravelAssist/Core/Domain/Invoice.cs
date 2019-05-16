using System;

namespace SiyayaTravelAssist.Core.Domain
{
    public class Invoice
    {
        public int Id { get; set; }
        public double BookingCost { get; set; } // Will Discuss Biz logic Later //Zooning and Location
        public string PaymentStatus { get; set; }

        public DateTime DateGenerated { get; set; }
        public Booking BookingId { get; set; }
    }
}