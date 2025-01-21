using IoT_Module_Centralization.Domain.Entities;
using System;
using System.Collections.Generic;

namespace IoT_Module_Centralization.Contracts
{
    public interface IUnitRepository
    {
        void Add(Unit unit);
        Unit? GetById(Guid id);
        IEnumerable<Unit> GetAll();
        void Delete(Guid id);
    }
}

