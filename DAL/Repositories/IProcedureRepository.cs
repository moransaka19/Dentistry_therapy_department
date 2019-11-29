using DAL.Models;
using System.Collections.Generic;

namespace DAL.Repositories
{
    public interface IProcedureRepository : IBaseRepository<Procedure>
    {
        IEnumerable<ProcedureTotalPrice> GetProcedureTotalPrices();
    }
}