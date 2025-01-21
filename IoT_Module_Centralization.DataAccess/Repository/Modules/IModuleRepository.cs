using IoT_Module_Centralization.Domain.Entities;
using System;
using System.Collections.Generic;

namespace IoT_Module_Centralization.DataAccess.Repositories.Modules
{
    public interface IModuleRepository
    {
        void Add(Module module);
        Module? GetById(Guid id);
        IEnumerable<Module> GetAll();
        void Update(Module module);
    }
}
