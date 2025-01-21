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
    public class MessageTests
    {
        private IMessageRepository _messageRepository;
        private ApplicationDbContext _context;

        public MessageTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite("Data Source=TestDatabase.db")
                .Options;

            _context = new ApplicationDbContext(options);
            _messageRepository = new MessageRepository(_context);
            _context.Database.EnsureCreated();
        }

        [TestMethod]
        public void Can_Add_And_Delete_Message()
        {
            // Arrange
            var module = new Module(Guid.NewGuid(), "Module1", new IpAddress("192.168.1.1"), new Port(8080), "Online");
            _context.Modules.Add(module);
            _context.SaveChanges();

            var message = new Message("Test Msessage", DateTime.Now, "High", module);

            // Act - Add
            _messageRepository.Add(message);
            _context.SaveChanges();

            // Assert - Added
            var loadedMessage = _messageRepository.GetById(message.Id);
            Assert.IsNotNull(loadedMessage);

            // Act - Delete
            _messageRepository.Delete(message.Id);
            _context.SaveChanges();

            // Assert - Deleted
            var deletedMessage = _messageRepository.GetById(message.Id);
            Assert.IsNull(deletedMessage);
        }
    }
}
