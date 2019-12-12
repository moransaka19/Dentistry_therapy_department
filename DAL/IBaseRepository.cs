using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace DAL
{
	public interface IBaseRepository<T>
	{
		IEnumerable<T> GetAll();
		IEnumerable<T> GetAll<Q>(Expression<Func<T, Q>> expression = null, OrderDirection direction = OrderDirection.Asc);
		T GetById(int id);
		void Add(T item);
		void Update(T item);
	}
}