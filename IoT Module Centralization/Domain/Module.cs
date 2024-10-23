namespace IoT_Module_Centralization.Domain
{
    public class Module
    {
        public int Id { get; set; }  // Identificador único del módulo
        public string Name { get; set; }  // Nombre del módulo
        public string IpAddress { get; set; }  // Dirección IP del módulo
        public int Port { get; set; }  // Puerto de acceso (número entero de hasta 4 cifras)
        public string Status { get; set; }  // Estado actual (conectado o desconectado)

        // Propiedad de navegación para las unidades
        public ICollection<Unit> Units { get; set; } = new List<Unit>();
    }
}

