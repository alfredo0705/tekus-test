namespace Tekus.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; private set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedAt { get; set; }
    }
}
