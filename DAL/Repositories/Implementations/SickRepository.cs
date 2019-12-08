using System.Collections.Generic;
using System.Linq;
using DAL.Models;
using Dapper;

namespace DAL.Repositories.Implementations
{
    public class SickRepository : BaseRepository<Sick>, ISickRepository
    {
        public SickRepository(string connectionString) : base(connectionString)
        {
        }

        public override void Add(Sick item)
        {
            var query = "insert into [dbo].[Sick] (Name) values (@Name); SELECT CAST(SCOPE_IDENTITY() as int)";
			int? id = Connection.Query<int>(query, item).FirstOrDefault();

			if (id != null)
				item.SickId = (int)id;
        }

        public override void Update(Sick item)
        {
            Connection.Execute("update Sick set Name = @Name where SickId = @SickId", item);
        }
    }
}