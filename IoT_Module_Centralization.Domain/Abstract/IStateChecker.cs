using System.Reflection;
using IoT_Module_Centralization.Domain.Entities;

namespace IoT_Module_Centralization.Domain.Abstract
{
    public interface IStateChecker
    {
        bool IsModuleConnected(Module module);
    }
}
