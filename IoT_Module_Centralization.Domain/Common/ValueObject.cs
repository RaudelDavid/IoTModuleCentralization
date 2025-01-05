
namespace IoT_Module_Centralization.Domain.Common
{
    public abstract class ValueObject
    {
        protected abstract IEnumerable<object> GetEqualityComponents();
        public override bool Equals(object? obj)
        {
            if (obj == null || obj.GetType() != GetType())
                return false;

            var valueObject = (ValueObject)obj;

            return GetEqualityComponents().SequenceEqual(valueObject.GetEqualityComponents());
        }
    }
}
