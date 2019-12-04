using DAL.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL.Repositories.Implementations
{
	public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
	{
		public DoctorRepository(string connectionString)
			: base(connectionString)
		{ }

		public override IEnumerable<Doctor> GetAll()
		{
			return Connection.Query<Doctor>("select * from Doctor");
		}

		public override void Add(Doctor item)
		{
			var query = "insert into [dbo].[Doctor] (FirstName, SecondName) values (@FirstName, @SecondName); SELECT CAST(SCOPE_IDENTITY() as int)";
			int? id = Connection.Query<int>(query, item).FirstOrDefault();

			if (id != null)
				item.DoctorId = (int)id;
		}

		public override void Update(Doctor item)
		{
			Connection.Execute(@"update Doctor set FirstName = @firstName, SecondName = @secondName where DoctorId = @id",
				new { @firstName = item.FirstName, @secondName = item.SecondName, @id = item.DoctorId });
		}

		public override void Remove(long id)
		{
			Connection.Execute("delete from Doctor where DoctorId = @doctorId", new { @doctorId = id });
		}
	}
}
