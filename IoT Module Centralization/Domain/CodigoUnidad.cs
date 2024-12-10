using System.Text.RegularExpressions;

namespace IoT_Module_Centralization.Domain
{
    public class CodigoUnidad
    {
        public string Valor { get; }

        public CodigoUnidad(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                throw new ArgumentException("El código no puede estar vacío.", nameof(valor));

            if (!Regex.IsMatch(valor, "^[A-Za-z0-9-]+$"))
                throw new ArgumentException("El código debe ser alfanumérico y puede incluir guiones.", nameof(valor));

            Valor = valor;
        }

        public override bool Equals(object obj)
        {
            if (obj is not CodigoUnidad other) return false;
            return Valor == other.Valor;
        }

        public override int GetHashCode() => Valor.GetHashCode();

        public override string ToString() => Valor;
    }
}
