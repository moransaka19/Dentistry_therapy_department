using System.Collections.Generic;
using System.Data;
using System.Linq;
using DAL.Models;
using Dapper;

namespace DAL.Repositories.Implementations
{
    public class ProcedureRepository : BaseRepository<Procedure>, IProcedureRepository
    {
        public ProcedureRepository(string connectionString) : base(connectionString)
        {
        }

        public override void Add(Procedure item)
        {
            var query = "insert into [dbo].[Procedure] (Name) values (@Name); SELECT CAST(SCOPE_IDENTITY() as int)";
			int? id = Connection.Query<int>(query, item).FirstOrDefault();

			if (id != null)
				item.ProcedureId = (int)id;
        }

        public override IEnumerable<Procedure> GetAll()
        {
            return Connection.Query<Procedure>("select * from [Procedure]");
        }

        public override void Remove(long id)
        {
            throw new System.NotImplementedException();
        }

        public override void Update(Procedure item)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ProcedureTotalPrice> GetProcedureTotalPrices()
        {
            var result = Connection.Query<ProcedureTotalPrice, Procedure, MedRecord, ProcedureTotalPrice>("GetProceduresTotalPrice",
                map: (ptp, p, mr) =>
                {
                    ptp.MedRecord = mr;
                    ptp.Procedure = p;

                    return ptp;
                },
                splitOn: "ProcedureId,MedRecordId",
                commandType: CommandType.StoredProcedure);
            return result;
        }
    }
}