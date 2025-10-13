namespace Tekus.Application.DTOs.Providers
{
    public class ProviderCustomFieldsCreateDto
    {
        public int ProviderId { get; set; }
        public CustomFieldDto Field { get; set; } = new();
    }
}
