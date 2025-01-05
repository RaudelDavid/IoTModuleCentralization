using IoT_Module_Centralization.Domain.Common;

namespace IoT_Module_Centralization.Domain.Entities
{
    public class Message : BaseEntity
    {
        public string Content { get; private set; }  // Texto del mensaje
        public DateTime Timestamp { get; private set; }  // Fecha y hora en que se generó
        public string Priority { get; private set; }  // Prioridad (baja, media, alta)

        // Relación: Un mensaje es generado por un módulo
        public Guid ModuleId { get; private set; }  // Clave foránea al módulo
        public Module Module { get; private set; }  // Propiedad de navegación al módulo

        // Constructor protegido
        protected Message() { }

        public Message(string content, DateTime timestamp, string priority, Module module)
        {
            Content = content;
            Timestamp = timestamp;
            Priority = priority;
            Module = module;
        }
    }
}
