using IoT_Module_Centralization.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using using_IoT_Module_Centralization.Contracts;

namespace IoT_Module_Centralization.DataAccess
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            EnsureDatabaseCreated();
        }

        /// <summary>
        /// Verifica si la base de datos existe, de lo contrario la crea y aplica migraciones.
        /// </summary>
        private void EnsureDatabaseCreated()
        {
            try
            {
                if (_context.Database.GetPendingMigrations().Any())
                {
                    _context.Database.Migrate();
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores al crear o migrar la base de datos
                throw new InvalidOperationException("No se pudo verificar o migrar la base de datos.", ex);
            }
        }

        /// <summary>
        /// Guarda los cambios realizados en el contexto.
        /// </summary>
        /// <returns>Número de entidades afectadas.</returns>
        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
