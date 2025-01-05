namespace IoT_Module_Centralization.Domain.ValueObjects
{
    public class Port
    {
        public int Value { get; }

        // Constructor sin parámetros para EF Core
        protected Port() { }

        // Constructor que valida el puerto
        public Port(int value)
        {
            if (value < 1 || value > 65535)
                throw new ArgumentException("El puerto debe estar entre 1 y 65535.");

            Value = value;
        }

        // Método que compara dos puertos para la igualdad
        public override bool Equals(object? obj)
        {
            return obj is Port other && other.Value == Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(Port left, Port right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Port left, Port right)
        {
            return !(left == right);
        }

        public override string ToString() => Value.ToString();

        protected IEnumerable<object> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
