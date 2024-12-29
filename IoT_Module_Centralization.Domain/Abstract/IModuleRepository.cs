using System.Reflection;
using IoT_Module_Centralization.Domain.Entities;

namespace IoT_Module_Centralization.Domain.Abstract
{
    public interface IModuleRepository
    {
        Module GetById(Guid id);
        IEnumerable<Module> GetAll();
        void Add(Module module);
        void Update(Module module);
        void Delete(Guid id);
    }
}
