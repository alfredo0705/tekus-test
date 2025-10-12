namespace Tekus.Application.DTOs.Providers
{
    public class ProviderCustomFieldsCreateDto
    {
        public int ProviderId { get; set; }
        public List<CustomFieldDto> Fields { get; set; } = new();
    }
}
