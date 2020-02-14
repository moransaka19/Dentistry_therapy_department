using DAL.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DAL.Repositories.Implementations
{
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(string connectionString) 
            : base(connectionString)
        { }

        public override void Add(Doctor item)
        {
            string query = "insert into [dbo].[Doctor] (FirstName, SecondName) " +
                           "values (@firstName, @secondName); " +
                           "SELECT CAST(SCOPE_IDENTITY() as int)";

            int? id = Connection.Query<int>(query, item).FirstOrDefault();

            if (id != null)
                item.DoctorId = (int)id;
        }

        public override void Update(Doctor item)
        {
            Connection.Execute(@"update [Doctor] set FirstName = @firstName, SecondName = @secondName where DoctorId = @id",
                new { @id = item.DoctorId, @firstName = item.FirstName, @secondName = item.SecondName});
        }
    }
}
