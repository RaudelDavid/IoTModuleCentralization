namespace CentralizadorIIoT.Domain
{
    public class DireccionModulo
    {
        public string DireccionIP { get; }
        public int Puerto { get; }

        public DireccionModulo(string direccionIP, int puerto)
        {
            if (string.IsNullOrWhiteSpace(direccionIP))
                throw new ArgumentException("La dirección IP no puede estar vacía.", nameof(direccionIP));

            if (puerto < 0 || puerto > 9999)
                throw new ArgumentOutOfRangeException(nameof(puerto), "El puerto debe ser un número entre 0 y 9999.");

            DireccionIP = direccionIP;
            Puerto = puerto;
        }

        public override bool Equals(object obj)
        {
            if (obj is not DireccionModulo other) return false;
            return DireccionIP == other.DireccionIP && Puerto == other.Puerto;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(DireccionIP, Puerto);
        }

        public override string ToString()
        {
            return $"{DireccionIP}:{Puerto}";
        }
    }
}
