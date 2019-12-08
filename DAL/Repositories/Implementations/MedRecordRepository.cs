using System.Collections.Generic;
using System.Linq;
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
            var query = "insert into MedRecord (FirstName, SecondName, DOB) values (@FirstName, @SecondName, @DOB); SELECT CAST(SCOPE_IDENTITY() as int)";
            int? id = Connection.Query<int>(query, item).FirstOrDefault();

            if (id != null)
                item.MedRecordId = (int)id;
        }

        public override void Update(MedRecord item)
        {
            Connection.Execute(@"update MedRecord
                                    set FirstName = @FirstName,
                                        SecondName = @SecondName,
                                        DOB = @DOB
                                        where MedRecordId = @MedRecordId", item);
        }
    }
}