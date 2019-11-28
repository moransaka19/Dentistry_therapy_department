using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using Dapper;

namespace DAL.Repositories.Implementations
{
    public class JournalRepository : BaseRepository<Journal>, IJournalRepository
    {
        public JournalRepository(string connectionString)
			: base(connectionString)
		{ }

        public override IEnumerable<Journal> GetAll()
        {
            return Connection.Query<Journal>("select * from Journal");
        }

        public override void Add(Journal item)
        {
            var query = "insert into [dbo].[Journal] (Date, DoctorId, ProcedureId, MedRecordId) values (@Date, @DoctrorId, @ProcedureId, @MedRecordId); SELECT CAST(SCOPE_IDENTITY() as int)";
			int? id = Connection.Query<int>(query, item).FirstOrDefault();

			if (id != null)
				item.JournalId = (int)id;
        }


        public override void Remove(long id)
        {
            throw new System.NotImplementedException();
        }

        public override void Update(Journal item)
        {
            throw new System.NotImplementedException();
        }
    }
}