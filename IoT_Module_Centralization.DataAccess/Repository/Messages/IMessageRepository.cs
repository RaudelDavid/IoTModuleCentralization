using IoT_Module_Centralization.Domain.Entities;
using System;
using System.Collections.Generic;

namespace IoT_Module_Centralization.Contracts
{
    public interface IMessageRepository
    {
        void Add(Message message);
        Message? GetById(Guid id);
        IEnumerable<Message> GetAll();
        void Delete(Guid id);
    }
}
