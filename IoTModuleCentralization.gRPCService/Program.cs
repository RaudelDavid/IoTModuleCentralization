using IoT_Module_Centralization.DataAccess.Contexts;
using IoT_Module_Centralization.Grpc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Configurar DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite("Data Source=IoTModuleCentralization.db"));

// Registrar servicios gRPC
builder.Services.AddGrpc();

// Crear la aplicación
var app = builder.Build();

// Mapear el servicio gRPC
app.MapGrpcService<ModuleServiceImpl>();
app.MapGet("/", () => "Este servidor gRPC está funcionando correctamente.");

// Ejecutar la aplicación
app.Run();
