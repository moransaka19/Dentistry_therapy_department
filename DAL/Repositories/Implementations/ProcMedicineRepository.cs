using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using Dapper;

namespace DAL.Repositories.Implementations
{
    public class ProcMedicineRepository : BaseRepository<ProcMedicine>, IProcMedicineRepository
    {
        public ProcMedicineRepository(string connectionString) : base(connectionString)
        {
        }

        public override IEnumerable<ProcMedicine> GetAll()
        {
            return Connection.Query<ProcMedicine>("select * from ProcMedicine");
        }

        public override void Add(ProcMedicine item)
        {
            var query = "insert into [dbo].[ProcMedicine] (MedicineId, ProcedureId, Count) values (@MedicineId, @ProcedureId, @Count)";
			Connection.Execute(query, item);
        }


        public override void Remove(long id)
        {
            throw new System.NotImplementedException();
        }

        public override void Update(ProcMedicine item)
        {
            throw new System.NotImplementedException();
        }
    }
}