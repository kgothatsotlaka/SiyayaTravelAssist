using System.Collections.Generic;
using System.Threading.Tasks;
using SiyayaTravelAssist.Core.Domain;

namespace SiyayaTravelAssist.Core.Services
{
    public interface IBookingService
    {
        //The implementations of the ListAsync method must asynchronously return an enumeration of Booking.
        Task<IEnumerable<Booking>> ListAsync();
    }
}