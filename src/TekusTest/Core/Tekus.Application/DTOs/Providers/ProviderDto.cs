namespace Tekus.Application.DTOs.Providers
{
    public class ProviderDto
    {
        public int Id { get; set; }
        public string NIT { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<CustomFieldDto> CustomFields { get; set; }
    }
}
