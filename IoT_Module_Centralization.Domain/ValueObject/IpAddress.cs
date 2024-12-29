using System.Net;

namespace IoT_Module_Centralization.Domain.ValueObjects
{
    public class IpAddress
    {
        public string Value { get; }

        // Constructor que valida la dirección IP
        public IpAddress(string value)
        {
            if (string.IsNullOrWhiteSpace(value) || !IsValidIpAddress(value))
                throw new ArgumentException("La dirección IP no es válida.");

            Value = value;
        }

        // Método que valida si la dirección IP es válida
        private bool IsValidIpAddress(string value)
        {
            return IPAddress.TryParse(value, out _);
        }

        // Método que compara dos direcciones IP para la igualdad
        public override bool Equals(object? obj)
        {
            return obj is IpAddress other && other.Value == Value;
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public static bool operator ==(IpAddress left, IpAddress right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(IpAddress left, IpAddress right)
        {
            return !(left == right);
        }

        public override string ToString() => Value;
    }
}
