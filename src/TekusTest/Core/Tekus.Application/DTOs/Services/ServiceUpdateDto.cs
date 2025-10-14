namespace Tekus.Application.DTOs.Services
{
    public class ServiceUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal HourlyRate { get; set; }
        public int ProviderId { get; set; }
        public List<string> Countries { get; set; }
    }
}
