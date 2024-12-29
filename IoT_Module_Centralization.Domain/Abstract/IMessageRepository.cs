using IoT_Module_Centralization.Domain.Entities;

namespace IoT_Module_Centralization.Domain.Abstract
{
    public interface IMessageRepository
    {
        Message GetById(Guid id);
        IEnumerable<Message> GetAll();
        IEnumerable<Message> GetByPriority(string priority);
        void Add(Message message);
    }
}
