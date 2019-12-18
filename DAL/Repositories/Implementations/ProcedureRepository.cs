using DAL.Models;
using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAL.Repositories.Implementations
{
	public class ProcedureRepository : BaseRepository<Procedure>, IProcedureRepository
	{
		public ProcedureRepository(string connectionString) : base(connectionString)
		{
		}

		public override IEnumerable<Procedure> GetAll()
		{
			var query =
				@"select p.*, m.* from [Procedure] p" +
				" inner join ProcedureMedicine pm on p.ProcedureId = pm.ProcedureId" +
				" inner join Medicine m on m.MedicineId = pm.MedicineId";


			return Connection.Query<Procedure, Medicine, Procedure>(query, 
				(procedure, medicine) =>
				{
					procedure.Medicines ??= new List<Medicine>();
					procedure.Medicines.Add(medicine);
					return procedure;
				}, splitOn: "MedicineId")
				.GroupBy(o => o.ProcedureId)
				.Select(group =>
				{
					var combinedOwner = group.First();
					combinedOwner.Medicines = group.Select(owner => owner.Medicines.Single()).ToList();
					return combinedOwner;
				});
		}

		public override void Add(Procedure item)
		{
			var query = "insert into [dbo].[Procedure] (Name) values (@Name); SELECT CAST(SCOPE_IDENTITY() as int)";
			int? id = Connection.Query<int>(query, item).FirstOrDefault();

			Connection.Execute("insert into ProcedureMedicine (ProcedureId, MedicineId) values (@ProcedureId, @MedicineId)",
				item.Medicines.Select(x => new { ProcedureId = id, x.MedicineId }));

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