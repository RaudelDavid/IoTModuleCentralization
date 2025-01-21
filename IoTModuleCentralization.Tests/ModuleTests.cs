using IoT_Module_Centralization.DataAccess.Contexts;
using IoT_Module_Centralization.DataAccess.Repositories.Modules;
using IoT_Module_Centralization.Domain.Entities;
using IoT_Module_Centralization.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace IoT_Module_Centralization.DataAccess.Tests
{
    [TestClass]
    public class ModuleTests
    {
        private IModuleRepository _moduleRepository;
        private ApplicationDbContext _context;

        public ModuleTests()
        {
            // Configurar DbContextOptions para SQLite
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite("Data Source=TestDatabase.db")
                .Options;

            _context = new ApplicationDbContext(options);
            _moduleRepository = new ModuleRepository(_context);

            // Asegurar que la base de datos esté creada
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        [DataRow("Module1", "192.168.1.1", 8080, "Active")]
        [DataRow("Module2", "192.168.1.2", 8081, "Inactive")]
        public void Can_Add_New_Module(string name, string ipAddress, int port, string status)
        {
            // Arrange
            Guid id = Guid.NewGuid();
            Module module = new Module(id, name, new IpAddress(ipAddress), new Port(port), status);

            // Act
            _moduleRepository.Add(module);
            _context.SaveChanges();

            // Assert
            Module? loadedModule = _moduleRepository.GetById(id);
            Assert.IsNotNull(loadedModule);
            Assert.AreEqual(name, loadedModule.Name);
        }

        [TestMethod]
        public void Can_Get_All_Modules()
        {
            // Act
            var modules = _moduleRepository.GetAll().ToList();

            // Assert
            Assert.IsNotNull(modules);
            Assert.IsTrue(modules.Any());
        }
    }
}
