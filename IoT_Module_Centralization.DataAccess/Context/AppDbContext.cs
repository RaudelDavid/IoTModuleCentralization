using IoT_Module_Centralization.Domain;
using Microsoft.EntityFrameworkCore;

namespace IoT_Module_Centralization.DataAccess.Context
{
    public class AppDbContext : DbContext
    {
        // Definir los DbSet que corresponden a las entidades
        public DbSet<Module> Modules { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Message> Messages { get; set; }

        // Configuración de la base de datos SQLite
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Asegúrate de que la base de datos sea SQLite
            optionsBuilder.UseSqlite("Data Source=IoTModules.db");
        }

        // Configuración de relaciones entre entidades
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relación Muchos a Muchos entre Module y Unit
            modelBuilder.Entity<Unit>()
                .HasMany(u => u.Modules)
                .WithMany(m => m.Units)
                .UsingEntity(join => join.ToTable("ModuleUnits"));

            // Configuración adicional si es necesario
        }
    }
}
