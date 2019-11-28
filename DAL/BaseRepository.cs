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

		public abstract void Add(T item);
		public abstract IEnumerable<T> GetAll();
		public abstract void Remove(long id);
		public abstract void Update(T item);

		public void Dispose()
		{
			Connection.Dispose();
		}
	}
}
