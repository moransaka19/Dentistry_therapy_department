using System.Collections.Generic;
using DAL.Models;
using Dapper;

namespace DAL.Repositories.Implementations
{
    public class MedRecordRepository : BaseRepository<MedRecord>, IMedRecordRepository
    {
        public MedRecordRepository(string connectionString) 
            : base(connectionString)
        { }

        public override void Add(MedRecord item)
        {
            throw new System.NotImplementedException();
        }

        public override IEnumerable<MedRecord> GetAll()
        {
            return Connection.Query<MedRecord>("select * from MedRecord");
        }

        public override void Remove(long id)
        {
            throw new System.NotImplementedException();
        }

        public override void Update(MedRecord item)
        {
            throw new System.NotImplementedException();
        }
    }
}