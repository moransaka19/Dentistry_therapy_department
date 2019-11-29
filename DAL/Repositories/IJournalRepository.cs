using DAL.Models;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public interface IJournalRepository : IBaseRepository<Journal>
    {
        IEnumerable<Journal> GetJournals();
    }
}