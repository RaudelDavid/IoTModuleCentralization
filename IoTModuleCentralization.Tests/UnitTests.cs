using IoT_Module_Centralization.Contracts;
using IoT_Module_Centralization.DataAccess.Contexts;
using IoT_Module_Centralization.DataAccess.Repositories;
using IoT_Module_Centralization.Domain.Entities;
using IoT_Module_Centralization.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace IoT_Module_Centralization.DataAccess.Tests
{
    [TestClass]
    public class UnitTests
    {
        private IUnitRepository _unitRepository;
        private ApplicationDbContext _context;

        public UnitTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite("Data Source=TestDatabase.db")
                .Options;

            _context = new ApplicationDbContext(options);
            _unitRepository = new UnitRepository(_context);
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public void Can_Add_And_Delete_Unit()
        {
            // Arrange
            var module = new Module(Guid.NewGuid(), "Module1", new IpAddress("192.168.1.1"), new Port(8080), "Online");
            _context.Modules.Add(module);
            _context.SaveChanges();

            var unit = new Unit(new CodigoUnidad("Code1"), "Unit1", "Area1", module);

            // Act - Add
            _unitRepository.Add(unit);
            _context.SaveChanges();

            // Assert - Added
            var loadedUnit = _unitRepository.GetById(unit.Id);
            Assert.IsNotNull(loadedUnit);

            // Act - Delete
            _unitRepository.Delete(unit.Id);
            _context.SaveChanges();

            // Assert - Deleted
            var deletedUnit = _unitRepository.GetById(unit.Id);
            Assert.IsNull(deletedUnit);
        }
    }
}
