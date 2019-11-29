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

        public override IEnumerable<Sick> GetAll()
        {
            return Connection.Query<Sick>("select * from Sick");
        }

        public override void Add(Sick item)
        {
            var query = "insert into [dbo].[Sick] (Name) values (@Name); SELECT CAST(SCOPE_IDENTITY() as int)";
			int? id = Connection.Query<int>(query, item).FirstOrDefault();

			if (id != null)
				item.SickId = (int)id;
        }


        public override void Remove(long id)
        {
            throw new System.NotImplementedException();
        }

        public override void Update(Sick item)
        {
            throw new System.NotImplementedException();
        }
    }
}