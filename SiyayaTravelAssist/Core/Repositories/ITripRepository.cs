﻿using System.Collections.Generic;
using System.Threading.Tasks;
using SiyayaTravelAssist.Core.Domain;

namespace SiyayaTravelAssist.Core.Repositories
{
    public interface ITripRepository
    {
        Task<IEnumerable<Trip>> ListAsync();
    }
}