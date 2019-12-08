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

        public void Remove(long id)
        {
			Connection.Execute("delete [Procedure] where ProcedureId = @id", new { @id = id });
        }

        public override void Update(Procedure item)
        {
			Connection.Execute("update [Procedure] set Name = @name where ProcedureId = @id", 
				new { @name = item.Name, @id = item.ProcedureId });
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