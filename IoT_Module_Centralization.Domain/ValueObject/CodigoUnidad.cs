namespace IoT_Module_Centralization.Domain.ValueObjects
{
    public class CodigoUnidad
    {
        public string Value { get; }

        // Constructor que valida el código de unidad
        public CodigoUnidad(string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("El código de unidad no puede estar vacío.");

            if (value.Length > 10)
                throw new ArgumentException("El código de unidad no puede exceder los 10 caracteres.");

            Value = value;
        }

        // Método que compara dos objetos de valor para la igualdad
        public override bool Equals(object? obj)
        {
            return obj is CodigoUnidad other && other.Value == Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(CodigoUnidad left, CodigoUnidad right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CodigoUnidad left, CodigoUnidad right)
        {
            return !(left == right);
        }

        public override string ToString() => Value;
    }
}
