using System.Collections.Generic;
using System.Threading.Tasks;
using SiyayaTravelAssist.Core.Domain;

namespace SiyayaTravelAssist.Core.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> ListAsync();
    }
}