namespace Tekus.Domain.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; private set; }
        public string Code { get; private set; } // ISO code e.g. "CO", "PE"

        public ICollection<ServiceCountry> ServiceCountries { get; private set; } = new List<ServiceCountry>();

        protected Country() { }

        public Country(string name, string code)
        {
            Name = name;
            Code = code;
        }
    }
}
