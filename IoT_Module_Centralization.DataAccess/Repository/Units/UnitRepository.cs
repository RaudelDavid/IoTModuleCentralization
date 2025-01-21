using IoT_Module_Centralization.Contracts;
using IoT_Module_Centralization.DataAccess.Contexts;
using IoT_Module_Centralization.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IoT_Module_Centralization.DataAccess.Repositories
{
    public class UnitRepository : IUnitRepository
    {
        private readonly ApplicationDbContext _context;

        public UnitRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Unit unit)
        {
            _context.Units.Add(unit);
        }

        public Unit? GetById(Guid id)
        {
            return _context.Units.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<Unit> GetAll()
        {
            return _context.Units.ToList();
        }

        public void Delete(Guid id)
        {
            var unit = _context.Units.FirstOrDefault(u => u.Id == id);
            if (unit != null)
            {
                _context.Units.Remove(unit);
            }
        }
    }
}
