using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enities.IRepository
{
    public interface IGenericRepository<T> where T : class
    {
        IQueryable<T> GetAll();
        T GetById(string id);
        void Delete(T entity);
        void Update(T entity);
        void Add(T entity);
        int Save();
    }
}
