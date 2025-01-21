using IoT_Module_Centralization.Domain.Entities;
using IoT_Module_Centralization.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace IoT_Module_Centralization.DataAccess.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Module> Modules { get; set; }
        public DbSet<Unit> Units { get; set; }
        public DbSet<Message> Messages { get; set; }

        // Constructor que toma DbContextOptions
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Configuración por defecto (por si no se pasan opciones)
                optionsBuilder.UseSqlite("Data Source=IoTModuleCentralization.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuración de relaciones y restricciones
            modelBuilder.Entity<Unit>()
                .HasOne(u => u.Module)
                .WithMany(m => m.Units)
                .HasForeignKey(u => u.ModuleId);

            modelBuilder.Entity<Message>()
                .HasOne(m => m.Module)
                .WithMany()
                .HasForeignKey(m => m.ModuleId);

            // Configuración de mapeo para propiedades de objetos de valor
            modelBuilder.Entity<Unit>(entity =>
            {
                entity.OwnsOne(u => u.Code, codigo =>
                {
                    codigo.Property(c => c.Value)
                          .HasColumnName("CodigoUnidad")
                          .IsRequired();
                });
            });

            modelBuilder.Entity<Module>(entity =>
            {
                entity.OwnsOne(m => m.IpAddress, ip =>
                {
                    ip.Property(i => i.Value)
                      .HasColumnName("IpAddress")
                      .IsRequired();
                });

                entity.OwnsOne(m => m.Port, port =>
                {
                    port.Property(p => p.Value)
                        .HasColumnName("Port")
                        .IsRequired();
                });
            });
        }
    }
}
