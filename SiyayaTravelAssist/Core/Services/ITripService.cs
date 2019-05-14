using System.Collections.Generic;
using System.Threading.Tasks;
using SiyayaTravelAssist.Core.Domain;

namespace SiyayaTravelAssist.Core.Services
{
    public interface ITripService
    {
        Task<IEnumerable<Trip>> ListAsync();
    }
}