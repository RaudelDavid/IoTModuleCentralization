using IoT_Module_Centralization.Contracts;
using IoT_Module_Centralization.DataAccess.Contexts;
using IoT_Module_Centralization.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IoT_Module_Centralization.DataAccess.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly ApplicationDbContext _context;

        public MessageRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Message message)
        {
            _context.Messages.Add(message);
        }

        public Message? GetById(Guid id)
        {
            return _context.Messages.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Message> GetAll()
        {
            return _context.Messages.ToList();
        }

        public void Delete(Guid id)
        {
            var message = _context.Messages.FirstOrDefault(m => m.Id == id);
            if (message != null)
            {
                _context.Messages.Remove(message);
            }
        }
    }
}
