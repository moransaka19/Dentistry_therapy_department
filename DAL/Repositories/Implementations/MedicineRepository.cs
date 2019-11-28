using System.Linq;
using DAL.Models;
using Dapper;

namespace DAL.Repositories.Implementations
{
    public class MedicineRepository : BaseRepository<Medicine>, IMedicineRepository
    {
        public MedicineRepository(string connectionString) : base(connectionString)
        {
        }

        public override void Add(Medicine item)
        {
            var query = "insert into [dbo].[Medicine] (Name, Price) values (@Name, @Price); SELECT CAST(SCOPE_IDENTITY() as int)";
			int? id = Connection.Query<int>(query, item).FirstOrDefault();

			if (id != null)
				item.MedicineId = (int)id;
        }

        public override System.Collections.Generic.IEnumerable<Medicine> GetAll()
        {
            return Connection.Query<Medicine>("select * from Medicine");
        }

        public override void Remove(long id)
        {
            throw new System.NotImplementedException();
        }

        public override void Update(Medicine item)
        {
            throw new System.NotImplementedException();
        }
    }
}