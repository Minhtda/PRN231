using Enities.IRepository;
using Enities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enities.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public SilverJewelry2023DbContext _context;

        public GenericRepository(SilverJewelry2023DbContext context)
        {
            _context = context;
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }

        public virtual T GetById(string id)
        {
            return _context.Set<T>().Find(id);
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
        }
    }
}
