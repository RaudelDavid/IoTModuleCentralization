using CentralizadorIIoT.Domain;

namespace IoT_Module_Centralization.Domain
{
    public class Module
    {
        public Guid Id { get; set; } = Guid.NewGuid();  // Identificador único
        public string Name { get; set; }  // Nombre del módulo
        public DireccionModulo Direccion { get; set; }  // Dirección IP y puerto
        public EstadoModulo Status { get; set; }  // Estado del módulo

        // Relación con las unidades (muchos a muchos)
        public ICollection<Unit> Units { get; set; } = new List<Unit>();

        // Relación con los mensajes (uno a muchos)
        public ICollection<Message> Messages { get; set; } = new List<Message>();

        // Constructor
        public Module(string name, DireccionModulo direccion, EstadoModulo status)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("El nombre no puede estar vacío.", nameof(name));

            Name = name;
            Direccion = direccion ?? throw new ArgumentNullException(nameof(direccion));
            Status = status;
        }
    }
}
