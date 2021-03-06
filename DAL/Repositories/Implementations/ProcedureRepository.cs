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
				" left join ProcedureMedicine pm on p.ProcedureId = pm.ProcedureId" +
				" left join Medicine m on m.MedicineId = pm.MedicineId";


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

			Connection.Execute("insert into ProcedureMedicine (ProcedureId, MedicineId, Count) values (@ProcedureId, @MedicineId, @Count)",
				item.Medicines
					.Select(x => new ProcedureMedicine { ProcedureId = (int) id, MedicineId = x.MedicineId })
					.GroupBy(x => x, (key, res) => new ProcedureMedicine { ProcedureId = key.ProcedureId, MedicineId = key.MedicineId, Count = res.Where(x => x.Equals(key)).Count() }));

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
			var result = Connection.Query<ProcedureTotalPrice, Procedure, MedRecord, Journal, ProcedureTotalPrice>("GetProceduresTotalPrice",
				map: (ptp, p, mr, j) =>
				{
					ptp.MedRecord = mr;
					ptp.Procedure = p;
					ptp.Journal = j;

					return ptp;
				},
				splitOn: "ProcedureId,MedRecordId,JournalId",
				commandType: CommandType.StoredProcedure);
			return result;
		}

		public IEnumerable<ProcedureSumPrices> GetProcedureSumPrices()
		{
			var result = Connection.Query<ProcedureSumPrices, Procedure, ProcedureSumPrices>("GetProcedureSumPrices",
				map: (psp, p) =>
				{
					psp.Procedure = p;

					return psp;
				},
				splitOn: "ProcedureId",
				commandType: CommandType.StoredProcedure);

			return result;
		}
	}
}