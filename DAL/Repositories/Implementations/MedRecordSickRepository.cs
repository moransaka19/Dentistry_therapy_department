using System.Collections.Generic;
using DAL.Models;
using Dapper;

namespace DAL.Repositories.Implementations
{
    public class MedRecordSickRepository : BaseRepository<MedRecordSick>, IMedRecordSickRepository
    {
        public MedRecordSickRepository(string connectionString) : base(connectionString)
        {
        }

        public override IEnumerable<MedRecordSick> GetAll()
        {
            return Connection.Query<MedRecordSick>("select * from MedRecordSick");
        }
        
        public override void Add(MedRecordSick item)
        {
            var query = "insert into [dbo].[MedRecordSick] (MedRecordId, SickId) values (@MedRecordId, @SickId)";
            Connection.Execute(query, item);
        }

        public override void Remove(long id)
        {
            throw new System.NotImplementedException();
        }

        public override void Update(MedRecordSick item)
        {
            throw new System.NotImplementedException();
        }
    }
}