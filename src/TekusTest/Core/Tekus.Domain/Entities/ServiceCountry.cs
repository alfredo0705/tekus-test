namespace Tekus.Domain.Entities
{
    public class ServiceCountry : BaseEntity
    {
        public int ServiceId { get; private set; }
        public int CountryId { get; private set; }

        public Service Service { get; private set; }
        public Country Country { get; private set; }

        protected ServiceCountry() { }

        public ServiceCountry(int serviceId, int countryId)
        {
            ServiceId = serviceId;
            CountryId = countryId;
        }
    }
}