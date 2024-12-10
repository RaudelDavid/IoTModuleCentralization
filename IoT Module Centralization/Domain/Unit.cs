namespace IoT_Module_Centralization.Domain
{
    public class Unit
    {
        public Guid Id { get; set; } = Guid.NewGuid();  // Identificador único
        public string Name { get; set; }  // Nombre de la unidad
        public CodigoUnidad Code { get; set; }  // Código único (Objeto de Valor)
        public string Area { get; set; }  // Área donde se encuentra la unidad

        // Relación con los módulos (muchos a muchos)
        public ICollection<Module> Modules { get; set; } = new List<Module>();

        // Constructor
        public Unit(string name, CodigoUnidad code, string area)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("El nombre no puede estar vacío.", nameof(name));

            Name = name;
            Code = code ?? throw new ArgumentNullException(nameof(code));
            Area = area;
        }
    }
}
