using System.Collections.Generic;

namespace DAL
{
	public interface IBaseRepository<T>
	{
		IEnumerable<T> GetAll();
		T GetById(int id);
		void Add(T item);
		void Update(T item);
	}
}