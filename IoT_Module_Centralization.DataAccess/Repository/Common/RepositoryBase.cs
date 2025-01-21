using IoT_Module_Centralization.DataAccess.Contexts;

namespace IoT_Module_Centralization.DataAccess.Repositories.Common
{
    /// <summary>
    /// Clase base para repositorios.
    /// </summary>
    public abstract class RepositoryBase<TEntity> where TEntity : class
    {
        /// <summary>
        /// Contexto de datos.
        /// </summary>
        protected readonly ApplicationDbContext _context;

        protected RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Agrega una nueva entidad.
        /// </summary>
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        /// <summary>
        /// Elimina una entidad existente.
        /// </summary>
        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        /// <summary>
        /// Actualiza una entidad existente.
        /// </summary>
        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }

        /// <summary>
        /// Obtiene todas las entidades.
        /// </summary>
        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        /// <summary>
        /// Obtiene una entidad por su identificador.
        /// </summary>
        public TEntity? GetById(Guid id)
        {
            return _context.Set<TEntity>().Find(id);
        }
    }
}
