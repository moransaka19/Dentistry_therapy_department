using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using Dapper;

namespace DAL.Repositories.Implementations
{
    public class ProcedureMedicineRepository : BaseRepository<ProcedureMedicine>, IProcedureMedicineRepository
    {
        public ProcedureMedicineRepository(string connectionString) : base(connectionString)
        {
        }

        public override void Add(ProcedureMedicine item)
        {
            var query = "insert into ProcedureMedicine (MedicineId, ProcedureId, Count) values (@MedicineId, @ProcedureId, @Count)";
			Connection.Execute(query, item);
        }

        public override void Update(ProcedureMedicine item)
        {
            throw new System.NotImplementedException();
        }
    }
}