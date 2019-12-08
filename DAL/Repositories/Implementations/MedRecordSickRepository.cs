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
        
        public override void Add(MedRecordSick item)
        {
            var query = "insert into [dbo].[MedRecordSick] (MedRecordId, SickId) values (@MedRecordId, @SickId)";
            Connection.Execute(query, item);
        }

        public override void Update(MedRecordSick item)
        {
            throw new System.NotImplementedException();
        }
    }
}