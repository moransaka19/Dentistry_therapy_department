using DAL.Models;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public interface IJournalRepository : IBaseRepository<Journal>, IRemovable
    {
        IEnumerable<Journal> GetJournals(OrderDirection? direction = null);
    }
}