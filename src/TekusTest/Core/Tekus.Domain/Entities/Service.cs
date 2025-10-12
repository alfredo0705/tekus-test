namespace Tekus.Domain.Entities
{
    public class Service : BaseEntity
    {
        public string Name { get; private set; }
        public decimal HourlyRate { get; private set; } // valor en USD

        public int ProviderId { get; private set; }
        public Provider Provider { get; private set; }

        public List<string> Countries { get; set; } = new();

        protected Service() { }

        public Service(string name, decimal hourlyRate, int providerId)
        {
            Name = name;
            HourlyRate = hourlyRate;
            ProviderId = providerId;
        }

        public void UpdateName(string newName) => Name = newName;
        public void UpdateRate(decimal newRate) => HourlyRate = newRate;
    }
}