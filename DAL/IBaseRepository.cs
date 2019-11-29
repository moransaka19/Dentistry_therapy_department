using System.Collections.Generic;

namespace DAL
{
	public interface IBaseRepository<T>
	{
		IEnumerable<T> GetAll();
		void Add(T item);
		void Update(T item);
		void Remove(long id);
	}
}