namespace Tekus.Domain.Entities
{
    public class Provider : BaseEntity
    {
        public string NIT { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }

        public ICollection<Service> Services { get; private set; } = new List<Service>();

        protected Provider() { } // Requerido por EF Core

        public Provider(string nit, string name, string email)
        {
            NIT = nit;
            Name = name;
            Email = email;
        }

        public void UpdateEmail(string newEmail) => Email = newEmail;
        public void UpdateName(string newName) => Name = newName;
        public void UpdateNit(string newNit) => NIT = newNit;
    }
}
