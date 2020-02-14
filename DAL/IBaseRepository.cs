using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Repositories
{
    public interface IBaseRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        void Add(T item);
        void Update(T item);
    }
}
