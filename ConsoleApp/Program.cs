using System;
using System.Threading.Tasks;
using IoT_Module_Centralization.Domain.Entities;
using IoT_Module_Centralization.Domain.ValueObjects;
using IoT_Module_Centralization.DataAccess.Contexts;

class Program
{
    static async Task Main(string[] args)
    {
        // Crear un código de unidad válido
        var codigoUnidad = new CodigoUnidad("ABC123");
        Console.WriteLine($"Código de unidad: {codigoUnidad.Value}");

        // Crear una dirección IP válida
        var ip = new IpAddress("192.168.1.1");
        Console.WriteLine($"IpAddress: {ip.Value}");

        // Crear un puerto válido
        var port = new Port(8080);
        Console.WriteLine($"Port: {port.Value}");

        // Crear un módulo
        var modulo = new Module("Modulo Alfa", ip, port, "Online");
        Console.WriteLine($"Módulo ID: {modulo.Id}");
        Console.WriteLine($"Módulo Nombre: {modulo.Name}");

        // Crear una unidad asociada al módulo
        var unidad = new Unit(codigoUnidad, "Unidad A", "Área 1", modulo);
        Console.WriteLine($"Unidad ID: {unidad.Id}");
        Console.WriteLine($"Unidad Código: {unidad.Code.Value}");
        Console.WriteLine($"Unidad Nombre: {unidad.Name}");
        Console.WriteLine($"Unidad Área: {unidad.Area}");
        Console.WriteLine($"Unidad Módulo ID: {unidad.ModuleId}");

        // Crear un mensaje asociado al módulo
        var mensaje = new Message("Este es un mensaje importante", DateTime.Now, "Alta", modulo);
        Console.WriteLine($"Mensaje ID: {mensaje.Id}");
        Console.WriteLine($"Mensaje Contenido: {mensaje.Content}");
        Console.WriteLine($"Mensaje Timestamp: {mensaje.Timestamp}");
        Console.WriteLine($"Mensaje Prioridad: {mensaje.Priority}");
        Console.WriteLine($"Mensaje Módulo ID: {mensaje.ModuleId}");

        // Interacción con la base de datos
        using var context = new ApplicationDbContext();



    }
}
