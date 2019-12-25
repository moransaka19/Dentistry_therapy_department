using System.Collections.Generic;
using System.Data;
using System.Linq;
using DAL.Models;
using Dapper;

namespace DAL.Repositories.Implementations
{
    public class JournalRepository : BaseRepository<Journal>, IJournalRepository
    {
        public JournalRepository(string connectionString)
			: base(connectionString) { }

        public override void Add(Journal item)
        {
            var query = "insert into [dbo].[Journal] (DoctorId, ProcedureId, MedRecordId, ExecutingDate) values (@DoctrorId, @ProcedureId, @MedRecordId, @ExecutingDate); SELECT CAST(SCOPE_IDENTITY() as int)";
            int? id = Connection.Query<int>(query, new
            {
                @ExecutingDate = item.ExecutingDate,
                @DoctrorId = item.DoctorId,
                @ProcedureId = item.ProcedureId,
                @MedRecordId = item.MedRecordId 
            }).FirstOrDefault();

			if (id != null)
				item.JournalId = (int)id;
        }

        public void Remove(long id)
        {
			Connection.Execute("delete from Journal where JournalId=@journalId", new { @journalId = id });
        }

        public override void Update(Journal item)
        {
			Connection.Execute(@"update Journal 
									set ExecutingDate = @executingDate,
                                        DoctorId = @doctorId,
										MedRecordId = @medRecordId,
										ProcedureId = @procedureId
										where JournalId = @journalId", 
										new {
                                            @executingDate = item.ExecutingDate,
                                            @doctorId = item.DoctorId,
											@medRecordId = item.MedRecordId,
											@procedureId = item.ProcedureId,
											@journalId = item.JournalId
										});
        }

        public IEnumerable<Journal> GetJournals(OrderDirection? direction)
        {
            var result = Connection.Query<Journal, Doctor, Procedure, MedRecord, Journal>("GetJournal",
                map: (jr, d, p, md) =>
                {
                    jr.DoctorId = d.DoctorId;
                    jr.Doctor = d;
                    jr.ProcedureId = p.ProcedureId;
                    jr.Procedure = p;
                    jr.MedRecordId = md.MedRecordId;
                    jr.MedRecord = md;

                    return jr;
                },
                splitOn:"DoctorId,ProcedureId,MedRecordId",
                commandType: CommandType.StoredProcedure);

            return direction switch
            {
                OrderDirection.Asc => result.OrderBy(x => x.CreatedOn),
                OrderDirection.Desc => result.OrderByDescending(x => x.CreatedOn),
                _ => result,
            };
        }
    }
}