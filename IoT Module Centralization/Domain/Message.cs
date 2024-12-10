namespace IoT_Module_Centralization.Domain
{
    public class Message
    {
        public Guid Id { get; set; } = Guid.NewGuid();  // Identificador único
        public string Content { get; set; }  // Contenido del mensaje
        public DateTime Timestamp { get; set; }  // Fecha y hora
        public Prioridad Priority { get; set; }  // Prioridad (Enumeración)

        // Relación con el módulo (un mensaje está asociado a un único módulo)
        public Guid ModuleId { get; set; }  // ID del módulo al que pertenece
        public Module Module { get; set; }  // Navegación hacia el módulo

        // Constructor
        public Message(string content, DateTime timestamp, Prioridad priority, Module module)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new ArgumentException("El contenido no puede estar vacío.", nameof(content));

            Content = content;
            Timestamp = timestamp;
            Priority = priority;
            Module = module ?? throw new ArgumentNullException(nameof(module));
        }
    }
}
