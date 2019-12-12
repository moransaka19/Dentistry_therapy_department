using Dapper;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Reflection;

namespace DAL
{
	public abstract class BaseRepository<T> : IBaseRepository<T>, IDisposable
	{
		protected readonly DbConnection Connection;

		public BaseRepository(string connectionString)
		{
			Connection = new SqlConnection(connectionString);
		}

		public virtual IEnumerable<T> GetAll()
			=> Connection.Query<T>($"select * from [{typeof(T).Name}]");

		public virtual IEnumerable<T> GetAll<Q>(Expression<Func<T, Q>> expression = null,
			OrderDirection direction = OrderDirection.Asc)
		{
			var query = $"select * from [{typeof(T).Name}]";

			if (expression != null)
			{
				var member = expression.Body as MemberExpression;
				var prop = member.Member as PropertyInfo;
				var name = prop.Name;
				query += $" order by {name} {direction.ToString()}";
			}

			return Connection.Query<T>(query);
		}

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
