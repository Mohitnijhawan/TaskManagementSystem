namespace TaskManagementSystem.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.CreateVersion7();
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.Now;
    }
}
