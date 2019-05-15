using System.Collections.Generic;
using System.Threading.Tasks;
using SiyayaTravelAssist.Core.Domain;

namespace SiyayaTravelAssist.Core.Repositories
{
    public interface IPassengerRepository
    {
        Task<IEnumerable<Passenger>> ListAsync();
    }
}