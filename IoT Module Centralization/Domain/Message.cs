namespace IoT_Module_Centralization.Domain
{
    public class Message
    {
        public int Id { get; set; }  // Identificador único del mensaje
        public string Content { get; set; }  // Texto del mensaje
        public DateTime Timestamp { get; set; }  // Fecha y hora en que se generó el mensaje
        public int ModuleId { get; set; }  // Identificador del módulo que generó el mensaje
        public string Priority { get; set; }  // Prioridad del mensaje (baja, media, alta)

        // Propiedad de navegación para el módulo
        public Module Module { get; set; }
    }

}
