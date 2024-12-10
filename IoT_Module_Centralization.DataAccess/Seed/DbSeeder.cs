using IoT_Module_Centralization.DataAccess.Context;
using IoT_Module_Centralization.Domain;
using System;
using System.Linq;

namespace IoT_Module_Centralization.DataAccess.Seed
{
    public static class DbSeeder
    {
        public static void Seed(AppDbContext context)
        {
            if (!context.Modules.Any())
            {
                // Crear algunos datos de prueba
                var module1 = new Module
                {
                    Name = "Módulo 1",
                    IpAddress = "192.168.1.1",
                    Port = 8080,
                    Status = "Connected"
                };

                var unit1 = new Unit
                {
                    Name = "Unidad A",
                    Area = "Producción"
                };

                var message1 = new Message
                {
                    Content = "Mensaje inicial",
                    Timestamp = DateTime.Now,
                    Priority = "Alta",
                    Module = module1
                };

                // Agregar los datos al contexto
                context.Modules.Add(module1);
                context.Units.Add(unit1);
                context.Messages.Add(message1);

                // Guardar los cambios
                context.SaveChanges();
            }
        }
    }
}
