using IoT_Module_Centralization.Domain.Common;
using IoT_Module_Centralization.Domain.ValueObjects;

namespace IoT_Module_Centralization.Domain.Entities
{
    public class Unit : BaseEntity
    {
        public CodigoUnidad Code { get; private set; }
        public string Name { get; private set; }
        public string Area { get; private set; }

        public Guid ModuleId { get; private set; }
        public Module Module { get; private set; }

        protected Unit() { }

        public Unit(CodigoUnidad code, string name, string area, Module module)
        {
            Code = code;
            Name = name;
            Area = area;
            Module = module;
            ModuleId = module.Id;
        }
    }
}
