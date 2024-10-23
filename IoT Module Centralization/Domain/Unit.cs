namespace IoT_Module_Centralization.Domain
{
    public class Unit
    {
        public int Id { get; set; }  // Identificador único de la unidad
        public string Name { get; set; }  // Nombre de la unidad
        public string AlphanumericCode { get; set; }  // Código que identifica la unidad
        public string Area { get; set; }  // Nombre del área donde se encuentra la unidad

        // Propiedad de navegación para los módulos
        public ICollection<Module> Modules { get; set; } = new List<Module>();
    }

}
