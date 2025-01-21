using IoT_Module_Centralization.DataAccess.Contexts;
using IoT_Module_Centralization.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IoT_Module_Centralization.DataAccess.Repositories.Modules
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly ApplicationDbContext _context;

        public ModuleRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Module module)
        {
            _context.Modules.Add(module);
        }

        public Module? GetById(Guid id)
        {
            return _context.Modules.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Module> GetAll()
        {
            return _context.Modules.ToList();
        }

        public void Update(Module module)
        {
            _context.Modules.Update(module);
        }
    }
}
