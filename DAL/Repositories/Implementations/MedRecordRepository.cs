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

        public override void Update(MedRecord item)
        {
            throw new System.NotImplementedException();
        }
    }
}