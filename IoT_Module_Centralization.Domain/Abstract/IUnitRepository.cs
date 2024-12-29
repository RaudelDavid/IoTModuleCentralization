using IoT_Module_Centralization.Domain.Entities;

namespace IoT_Module_Centralization.Domain.Abstract
{
    public interface IUnitRepository
    {
        Unit GetById(Guid id);
        IEnumerable<Unit> GetAll();
        void Add(Unit unit);
        void Update(Unit unit);
        void Delete(Guid id);
    }
}
