namespace Tekus.Domain.Entities
{
    public class Service : BaseEntity
    {
        public string Name { get; private set; }
        public decimal HourlyRate { get; private set; } // valor en USD

        public int ProviderId { get; private set; }
        public Provider Provider { get; private set; }

        public ICollection<ServiceCountry> ServiceCountries { get; private set; } = new List<ServiceCountry>();

        protected Service() { }

        public Service(string name, decimal hourlyRate)
        {
            Name = name;
            HourlyRate = hourlyRate;
        }

        public void UpdateName(string newName) => Name = newName;
        public void UpdateRate(decimal newRate) => HourlyRate = newRate;
    }
}