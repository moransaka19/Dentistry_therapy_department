using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace DAL
{
	public abstract class BaseRepository<T> : IBaseRepository<T>, IDisposable
	{
		protected readonly DbConnection Connection;

		public BaseRepository(string connectionString)
		{
			Connection = new SqlConnection(connectionString);
		}

		public virtual IEnumerable<T> GetAll() =>
			Connection.Query<T>($"select * from [{typeof(T).Name}]");

		public virtual T GetById(int id) =>
			Connection.QuerySingle<T>($"select * from [{typeof(T).Name}] where {typeof(T).Name}Id = @id", new { @id = id });

		public abstract void Add(T item);
		public abstract void Update(T item);

		public void Dispose()
		{
			Connection.Dispose();
		}
	}
}
