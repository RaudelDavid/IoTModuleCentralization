using Microsoft.EntityFrameworkCore;

namespace IoT_Module_Centralization.Domain.Abstract
{
    public abstract class BaseRepository<T> where T : class
    {
        protected readonly DbContext _context;

        protected BaseRepository(DbContext context)
        {
            _context = context;
        }

        public virtual T GetById(Guid id)
        {
            return _context.Set<T>().Find(id);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public virtual void Add(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
        }
    }
}
