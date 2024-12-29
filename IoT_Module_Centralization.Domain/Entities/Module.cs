using IoT_Module_Centralization.Domain.Common;
using IoT_Module_Centralization.Domain.ValueObjects;

namespace IoT_Module_Centralization.Domain.Entities
{
    public class Module : BaseEntity
    {
        public string Name { get; private set; }
        public IpAddress IpAddress { get; private set; }
        public Port Port { get; private set; }
        public string Status { get; private set; }

        public ICollection<Unit> Units { get; private set; } = new List<Unit>();

        protected Module() { }

        public Module(string name, IpAddress ipAddress, Port port, string status)
        {
            Name = name;
            IpAddress = ipAddress;
            Port = port;
            Status = status;
        }

        public void UpdateStatus(string status)
        {
            Status = status;
        }
    }
}
